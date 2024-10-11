using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace Online_Pharmacy_MS
{
    public partial class Sellers : System.Web.UI.Page
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\EPharmacyDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowSellers()
        {
            Con.Open();
            string Query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerGV.DataSource = ds.Tables[0];
            SellerGV.DataBind();
            Con.Close();
        }

        private void DeleteSeller()
        {
            if (SName.Value == "" || SGen.SelectedIndex == -1 || SPhone.Value == "" || SAdd.Value == "" )
            {
                // print Error Message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Select the Seller to be deleted');", true);

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from SellerTbl where SNum=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SKey", SellerGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Seller Deleted!!!');", true);
                    Con.Close();
                    ShowSellers();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void EditSeller()
        {
            if (SName.Value == "" || SGen.SelectedIndex == -1 ||  SPhone.Value == "" || SAdd.Value == "")
            {
                // print Error Message
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Missing Information');", true);

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update SellerTbl set SName=@SN,SGen=@SG,SDOB=@SD,SPhone=@SP,SAdd=@SA,SPass=@SPA where SNum=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", SName.Value);
                    cmd.Parameters.AddWithValue("@SG", SGen.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SD", SDOB.Value);
                    cmd.Parameters.AddWithValue("@SP", SPhone.Value);
                    cmd.Parameters.AddWithValue("@SA", SAdd.Value);
                    cmd.Parameters.AddWithValue("@SPA", SPass.Value);
                    cmd.Parameters.AddWithValue("@SKey", SellerGV.SelectedRow.Cells[1].Text);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Seller Updated Successfully');", true);
                    Con.Close();
                    ShowSellers();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void InsertSeller()
        {
            if (SName.Value == "" || SGen.SelectedIndex == -1 || SDOB.Value == "" || SPhone.Value == "" || SAdd.Value == "" || SPass.Value == "")
            {
                // print Error Message
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SellerTbl(SName,SGen,SDOB,SPhone,SAdd,SPass) values(@SN,@SG,@SD,@SP,@SA,@SPA)", Con);
                    cmd.Parameters.AddWithValue("@SN", SName.Value);
                    cmd.Parameters.AddWithValue("@SG", SGen.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SD", SDOB.Value);
                    cmd.Parameters.AddWithValue("@SP", SPhone.Value);
                    cmd.Parameters.AddWithValue("@SA", SAdd.Value);
                    cmd.Parameters.AddWithValue("@SPA", SPass.Value);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Seller Added Successfully');", true);
                    Con.Close();
                    ShowSellers();

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ShowSellers();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            InsertSeller();
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            EditSeller();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteSeller();
        }

        int Key = 0;

        protected void SellerGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            SName.Value = SellerGV.SelectedRow.Cells[2].Text;
            SGen.Text = SellerGV.SelectedRow.Cells[3].Text;
            SDOB.Value = SellerGV.SelectedRow.Cells[4].Text;
            SPhone.Value = SellerGV.SelectedRow.Cells[5].Text;
            SAdd.Value = SellerGV.SelectedRow.Cells[6].Text;
            SPass.Value = SellerGV.SelectedRow.Cells[7].Text;
            if (SName.Value == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellerGV.SelectedRow.Cells[1].Text);
            }
        }
    }
}