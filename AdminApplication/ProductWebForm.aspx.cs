using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminApplication
{
    public partial class ProductWebForm : System.Web.UI.Page
    {
        ProductServiceReference.ProductWebServiceSoapClient obj = new ProductServiceReference.ProductWebServiceSoapClient();

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
            if (!IsPostBack)
            {
                try
                {
                    txtProductId.Text = obj.AutoProductId();
                    DataSet ds = obj.getCategoryName();
                    dlCategory.DataSource = ds;
                    dlCategory.DataTextField = "CategoryName";
                    dlCategory.DataValueField = "CategoryName";
                    dlCategory.DataBind();
                }
                catch (Exception ex) 
                {
                    lblText.Text = "Error Loading Categories" + ex.Message;
                }
            }

        }

        protected void btnInsertProduct_Click(object sender, EventArgs e)
        {
            try
            {
                string CategoryId = obj.getCategoryId(dlCategory.SelectedValue);

                DataSet ds = obj.SearchProduct(txtProductId.Text.Trim()); 
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lblText.Text = "Product already exists.";
                    return; 
                }
                string value = obj.insertProduct(txtProductId.Text, txtProductName.Text, txtPrice.Text, CategoryId, txtQuantity.Text);
                int record = int.Parse(value);

                if (record >= 1)
                {
                    lblText.Text = "Product inserted successfully!";
                    BindAllCategories(); 
                }
                else
                {
                    lblText.Text = "Product insertion failed.";
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error: " + ex.Message;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string CategoryId = obj.getCategoryId(dlCategory.SelectedValue);

                string ProductId = txtProductId.Text;
                string ProductName = txtProductName.Text;
                string Price = txtPrice.Text;
                string Quantity = txtQuantity.Text;

                string result = obj.updateProduct(ProductId, ProductName, Price, CategoryId, Quantity);
                int noOfRowsUpdated = int.Parse(result);

                if (noOfRowsUpdated > 0)
                {
                    lblText.Text = "Product updated successfully.";
                    BindAllCategories();
                }
                else
                {
                    lblText.Text = "Failed to update Product.";
                }
            }
            catch (Exception ex) 
            {
                lblText.Text = "Error:" + ex.Message;
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
                using (SqlConnection conn = getConnection())
                {
                    string query = "SELECT ProductId, ProductName, Price, CategoryId, Quantity FROM Product_Table";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();

                        da.Fill(ds);

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            gvAllProducts.DataSource = ds;
                            gvAllProducts.DataBind();
                            gvAllProducts.Visible = true;
                            lblText.Text = "";
                        }
                        else 
                        {
                            gvAllProducts.DataSource = null;
                            gvAllProducts.DataBind();
                            lblText.Text = "No prouducts found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblText.Text = "Error retrieving prouducts: " + ex.Message;
            }
        }

        protected void gvAllProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAllProducts.Rows[index];
                string ProductId = row.Cells[0].Text;

                string result = obj.deleteProduct(ProductId);
                int noOfRowsDeleted = Int32.Parse(result);

                if (noOfRowsDeleted > 0)
                {
                    lblText.Text = "Product deleted successfully.";
                    BindAllCategories();
                }
                else
                {
                    lblText.Text = "Failed to delete Product.";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string ProductId = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(ProductId))
            {
                DataSet ds = obj.SearchProduct(ProductId);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvProducts.DataSource = ds;
                    gvProducts.DataBind();
                    lblText.Text = "";
                }
                else
                {
                    gvProducts.DataSource = null;
                    gvProducts.DataBind();
                    lblText.Text = "No records found for the given Product ID.";
                }
            }
        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProducts.Rows[index];
                string ProductId = row.Cells[0].Text;

                string result = obj.deleteProduct(ProductId);
                int noOfRowsDeleted = Int32.Parse(result);

                if (noOfRowsDeleted > 0)
                {
                    lblText.Text = "Product deleted successfully.";
                    BindAllCategories();
                }
                else
                {
                    lblText.Text = "Failed to delete Product.";
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardWebForm.aspx");
        }
    }
}