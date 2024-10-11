using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Online_Pharmacy_MS
{

    public partial class Contact : Page
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\EPharmacyDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowManufactures()
        {
            Con.Open();
            string Query = "select * from ManufacturerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ManGV.DataSource = ds.Tables[0];
            ManGV.DataBind();
            Con.Close();
        }
        

        private void InsertMan()
        {
            if (MName.Value == "" || MPhone.Value == "" || MAdd.Value == "")
            {
                // print Error Message
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ManufacturerTbl(ManName,ManAdd,ManPhone,ManDate) values(@MN,@MA,@MP,@MD)", Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MA", MAdd.Value);
                    cmd.Parameters.AddWithValue("@MP", MPhone.Value);
                    cmd.Parameters.AddWithValue("@MD", MDate.Value);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Manufacturer Added Successfully');", true);
                    Con.Close();
                    ShowManufactures();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void DeleteMan()
        {
            if (MName.Value == "" || MPhone.Value == "" || MAdd.Value == "")
            {
                // print Error Message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select the Manufacturer to be deleted');", true);

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ManufacturerTbl where ManId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", ManGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Manufacturer Deleted!!!');", true);
                    Con.Close();
                    ShowManufactures();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void EditMan()
        {
            if (MName.Value == "" || MPhone.Value == "" || MAdd.Value == "")
            {
                // print Error Message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ManufacturerTbl set ManName=@MN,ManAdd=@MA,ManPhone=@MP,ManDate=@MD where ManId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", MName.Value);
                    cmd.Parameters.AddWithValue("@MA", MAdd.Value);
                    cmd.Parameters.AddWithValue("@MP", MPhone.Value);
                    cmd.Parameters.AddWithValue("@MD", MDate.Value);
                    cmd.Parameters.AddWithValue("@MKey", ManGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Manufacturer Updated Successfully');", true);
                    Con.Close();
                    ShowManufactures();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowManufactures();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertMan();
        }

        int Key = 0;

        protected void ManGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            MName.Value = ManGV.SelectedRow.Cells[2].Text;
            MAdd.Value = ManGV.SelectedRow.Cells[3].Text;
            MPhone.Value = ManGV.SelectedRow.Cells[4].Text;
            MDate.Value = ManGV.SelectedRow.Cells[5].Text;
            if (MName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ManGV.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditMan();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteMan();
        }
    }
}