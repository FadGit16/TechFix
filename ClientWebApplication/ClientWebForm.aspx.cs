using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientWebApplication
{
    public partial class ClientWebForm : System.Web.UI.Page
    {
        SqlConnection sqlCon = null;
        DataTable Order_Table = new DataTable();

        public SqlConnection getConnection()
        {
            try
            {
                sqlCon = new SqlConnection("data source = FADHILA; initial catalog = TechFix; Integrated Security = true");
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db: " + ex.Message);
            }
            return sqlCon;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }


        protected void LoadProducts()
        {
            using (SqlConnection con = getConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductId, ProductName, Price FROM Product_Table", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProducts.DataSource = dt;
                gvProducts.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = searchInput.Value;
            using (SqlConnection con = getConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductId, ProductName, Price FROM Product_Table WHERE ProductName LIKE '%' + @search + '%'", con);
                da.SelectCommand.Parameters.AddWithValue("@search", searchText);
                DataTable dt = new DataTable();
                da.Fill(dt);
                // Check if the DataTable is empty
                if (dt.Rows.Count == 0)
                {
                    // Display the "Product not available" message
                    lblMessage.Text = "Product not available";
                    gvProducts.DataSource = null;
                    gvProducts.DataBind(); // Clear any previous results
                }
                else
                {
                    lblMessage.Text = ""; // Clear any previous message
                    gvProducts.DataSource = dt;
                    gvProducts.DataBind();
                }
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            bool orderPlaced = false;

            using (SqlConnection con = getConnection())
            {
                foreach (GridViewRow row in gvProducts.Rows)
                {
                    // Retrieve ProductId, ProductName, and Price
                    string productId = row.Cells[0].Text;
                    string productName = row.Cells[1].Text;
                    decimal price = Convert.ToDecimal(row.Cells[2].Text);

                    // Get the entered quantity from the TextBox
                    TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                    if (!string.IsNullOrEmpty(txtQuantity.Text) && int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
                    {
                        decimal total = price * quantity;


                        // Insertion of the data into Order_Table
                        SqlCommand cmd = new SqlCommand("INSERT INTO Order_Table (ProductId, ProductName, Price, Quantity, Total) VALUES (@ProductId, @ProductName, @Price, @Quantity, @Total)", con);
                        cmd.Parameters.AddWithValue("@ProductId", productId);
                        cmd.Parameters.AddWithValue("@ProductName", productName);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@Total", total);
                        cmd.ExecuteNonQuery();

                        // Set flag to true indicating at least one order has been placed
                        orderPlaced = true;
                    }
                }
            }
            // If an order was placed, show a success message
            if (orderPlaced)
            {
                lblOrderMessage.Text = "Order placed successfully!";
                lblOrderMessage.Visible = true;

                lblOrderStatus.Visible = false;
            }
            else
            {
                // Show a failure message if no order was placed
                lblOrderStatus.Text = "No order was placed. Please enter a quantity.";
                lblOrderStatus.Visible = true;  // Make the label visible

                lblOrderMessage.Visible = false;
            }

            btnViewOrders_Click(null, null);

        }

        protected void btnViewOrders_Click(object sender, EventArgs e)
        {

            using (SqlConnection con = getConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductId, ProductName, Price, Quantity, Total FROM Order_Table", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvOrders.DataSource = dt;
                gvOrders.Visible = true;  //GridView is visible Code
                gvOrders.DataBind();      // Bind the data to the GridView

                decimal totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["Total"]);
                }

                // Display the total amount in the Literal control
                ltTotalAmount.Text = "LKR " + totalAmount.ToString("N2");
            }

        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteOrder")
            {
                // Get the row index
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                // Retrieve the ProductId from the GridView row
                GridViewRow row = gvOrders.Rows[rowIndex];
                string productId = row.Cells[0].Text;

                using (SqlConnection con = getConnection())
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Order_Table WHERE ProductId = @ProductId", con);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.ExecuteNonQuery();
                }
                // Show a success message
                lblDeleteMessage.Text = "Order deleted successfully!";
                lblDeleteMessage.Visible = true;

                // Refresh the GridView to show updated orders after deletion
                btnViewOrders_Click(null, null);
            }
        }

    }
}