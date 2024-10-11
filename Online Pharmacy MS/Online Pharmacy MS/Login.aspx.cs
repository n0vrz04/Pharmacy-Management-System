using System;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text;
            string enteredPassword = password.Text;

            if (enteredUsername == "admin" && enteredPassword == "admin")
            {
                // Successful login, redirect to default.aspx
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Invalid login, show an error message
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid username or password!');", true);
            }
        }
    }
}
