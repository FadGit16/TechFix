using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApplication
{
    public partial class CategoryWebForm : System.Web.UI.Page
    {
        CategoryServiceReference.CategoryWebServiceSoapClient obj = new CategoryServiceReference.CategoryWebServiceSoapClient();

        SqlConnection sqlCon = null;
        public SqlConnection getConnection()
        {
            try
            {

                sqlCon = new SqlConnection("data source = FADHILA; initial catalog = TechFix; Integrated Security = true");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db" + ex);
            }
            return sqlCon;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if Category ID or Category Name fields are blank
            if (string.IsNullOrEmpty(txtCategoryId.Text.Trim()) || string.IsNullOrEmpty(txtCategoryName.Text.Trim()))
            {
                lblText.Text = "Category ID and Category Name cannot be blank.";
                return; // Exit the method if any field is blank
            }

            DataSet ds = obj.SearchCategory(txtCategoryId.Text.Trim());
    
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblText.Text = "Category ID already exists.";
            }
            else
            {
                    // Proceed to insert the category
                    string value = obj.insertCategory(txtCategoryId.Text, txtCategoryName.Text);
                    int norecord = Int32.Parse(value);

                    if (norecord > 0)
                    {
                        lblText.Text = "Category added successfully.";
                        BindAllCategories();
                    }
                    else
                    {
                        lblText.Text = "Failed to add category.";
                    }
            }

        }


        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            string CategoryId = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(CategoryId))
            {
                // Call the SearchCategory web method
                DataSet ds = obj.SearchCategory(CategoryId);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    // Bind the result to GridView if records are found
                    gvCategories.DataSource = ds;
                    gvCategories.DataBind();
                    lblText.Text = "";
                }
                else
                {
                    // Display a message if no records are found
                    gvCategories.DataSource = null;
                    gvCategories.DataBind();
                    lblText.Text = "No records found for the given Category ID.";
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            BindAllCategories();
        }

        private void BindAllCategories()
        {
            try
            {
                // Establish SQL connection
                using (SqlConnection conn = getConnection())
                {
                    // Define the SQL query to fetch all categories
                    string query = "SELECT CategoryId, CategoryName FROM Category_Table"; 

                    // Create a SqlCommand object
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Create a SqlDataAdapter to execute the query and fill a DataSet
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();

                        // Fill the DataSet with the result of the query
                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            // Bind the data to gvAllCategories GridView
                            gvAllCategories.DataSource = ds;
                            gvAllCategories.DataBind();
                            gvAllCategories.Visible = true;  // Make sure the GridView is visible
                            lblText.Text = "";  // Clear any previous messages
                        }
                        else
                        {
                            gvAllCategories.DataSource = null;
                            gvAllCategories.DataBind();
                            lblText.Text = "No categories found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error retrieving categories: " + ex.Message;
            }
        }

        protected void gvCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                // Get the selected row index
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCategories.Rows[index];

                // Retrieve CategoryId from the row
                string categoryId = row.Cells[0].Text;

                // Call the delete method
                string result = obj.deleteCategory(categoryId);
                int noOfRowsDeleted = Int32.Parse(result);

                if (noOfRowsDeleted > 0)
                {
                    lblText.Text = "Category deleted successfully.";
                    BindAllCategories(); // Refresh the category list after deletion
                }
                else
                {
                    lblText.Text = "Failed to delete category.";
                }
            }
        }

        protected void gvAllCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAllCategories.Rows[index];
                string categoryId = row.Cells[0].Text;

                string result = obj.deleteCategory(categoryId);
                int noOfRowsDeleted = Int32.Parse(result);

                if (noOfRowsDeleted > 0)
                {
                    lblText.Text = "Category deleted successfully.";
                    BindAllCategories();
                }
                else
                {
                    lblText.Text = "Failed to delete category.";
                }
            }
        }

        protected void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string categoryId = txtCategoryId.Text;
            string categoryName = txtCategoryName.Text;

            // Call the update method
            string result = obj.updateCategory(categoryId, categoryName);
            int noOfRowsUpdated = Int32.Parse(result);

            if (noOfRowsUpdated > 0)
            {
                lblText.Text = "Category updated successfully.";
                BindAllCategories(); // Refresh the category list after update
            }
            else
            {
                lblText.Text = "Failed to update category.";
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardWebForm.aspx");

        }
    }
}