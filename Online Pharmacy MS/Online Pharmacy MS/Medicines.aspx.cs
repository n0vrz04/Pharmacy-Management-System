using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Online_Pharmacy_MS
{
    public partial class About : Page
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\EPharmacyDb.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void ShowMedicines()
        {
            Con.Open();
            string Query = "select * from MedicineTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MedGV.DataSource = ds.Tables[0];
            MedGV.DataBind();
            Con.Close();
        }

        private void DeleteMed()
        {
            if (MName.Value == "" || MType.SelectedIndex == -1 || MQty.Value == "" || MPrice.Value == "" || MMan.SelectedIndex == -1)
            {
                // print Error Message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select the Medicine to be deleted');", true);

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from MedicineTbl where MedNum=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", MedGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Medicine Deleted!!!');", true);
                    Con.Close();
                    ShowMedicines();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void EditMed()
        {
            if (MName.Value == "" || MType.SelectedIndex == -1 || MQty.Value == "" || MPrice.Value == "" || MMan.SelectedIndex == -1)
            {
                // print Error Message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update MedicineTbl set MedName=@MN,MedType=@MT,MedQty=@MQ,MedPrice=@MP,MedManufact=@MM where MedNum=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MT", MType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ", MQty.Value);
                    cmd.Parameters.AddWithValue("@MP", MPrice.Value);
                    cmd.Parameters.AddWithValue("@MM", MMan.SelectedIndex);
                    cmd.Parameters.AddWithValue("@MKey", MedGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Medicine Updated In Stock');", true);
                    Con.Close();
                    ShowMedicines();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void InsertMed()
        {
            if(MName.Value == "" || MType.SelectedIndex == -1 || MQty.Value == "" || MPrice.Value == "" || MMan.SelectedIndex == -1)
            {
                // print Error Message
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into MedicineTbl(MedName,MedType,MedQty,MedPrice,MedManufact) values(@MN,@MT,@MQ,@MP,@MM)",Con);
                    cmd.Parameters.AddWithValue("@MN",MName.Value);
                    cmd.Parameters.AddWithValue("@MT",MType.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@MQ",MQty.Value);
                    cmd.Parameters.AddWithValue("@MP",MPrice.Value);
                    cmd.Parameters.AddWithValue("@MM",MMan.SelectedIndex);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Medicine Added In Stock');", true);
                    Con.Close();
                    ShowMedicines();

                }
                catch(Exception)
                {
                    throw; 
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowMedicines();
        }

        int Key = 0;
        protected void MedGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Grid View Clicked');",true);  
            MName.Value = MedGV.SelectedRow.Cells[2].Text;
            MType.Text = MedGV.SelectedRow.Cells[3].Text;
            MQty.Value = MedGV.SelectedRow.Cells[4].Text;
            MPrice.Value = MedGV.SelectedRow.Cells[5].Text;
            MMan.Text = MedGV.SelectedRow.Cells[6].Text;
            if(MName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MedGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertMed();
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditMed();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteMed();
        }
    }
}