using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationForm
{
    public partial class SignupWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (!IsValidEmail(email))
            {
                lblMessage.Text = "Please Include @ in your enetered email address.";
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            using (SqlConnection con = new SqlConnection("data source=FADHILA; initial catalog=TechFix; Integrated Security=true"))
            {
                con.Open();

                // Check if email already exists
                SqlCommand checkEmailCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", con);
                checkEmailCmd.Parameters.AddWithValue("@Email", email);
                int emailExists = (int)checkEmailCmd.ExecuteScalar();

                if (emailExists > 0)
                {
                    lblMessage.Text = "This email is already registered.";
                }
                else
                {
                    // Admin email and password check
                    if (email == "admin@gmail.com" && password == "admin")
                    {
                        lblMessage.Text = "Admin account already exists.";
                        return;
                    }

                    // Save user details to the database
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (Email, Password) VALUES (@Email, @Password)", con);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password); // You should hash the password in a real application!

                    try
                    {
                        cmd.ExecuteNonQuery();

                        // Show alert and redirect to login page
                        string script = "alert('Registration successful!'); window.location.href = 'LoginWebForm.aspx';";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Error: " + ex.Message;
                    }
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            // Use regular expressions to check for a valid email format
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
    }
}