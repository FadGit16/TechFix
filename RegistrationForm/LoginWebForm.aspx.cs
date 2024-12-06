using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class LoginWebForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            using (SqlConnection con = new SqlConnection("data source=FADHILA; initial catalog=TechFix; Integrated Security=true"))
            {
                con.Open();

                // Check if the user exists
                SqlCommand cmd = new SqlCommand("SELECT Email, Password FROM Users WHERE Email = @Email AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password); // In real applications, make sure the password is hashed!

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();

                    // Check if the user is an admin
                    if (email == "admin@gmail.com" && password == "admin")
                    {
                        lblMessage.Text = "Admin logged in successfully!";
                        Response.Redirect("TechFix/AdminApplication/DashboardWebForm.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Customer logged in successfully!";
                        Response.Redirect("TechFix/ClientWebApplication/ClientWebForm.aspx");
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid email or password. Please try again.";
                }
            }
        }
    }
}