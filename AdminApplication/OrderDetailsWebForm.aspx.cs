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
    public partial class OrderDetailsWebForm : System.Web.UI.Page
    {
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
                Console.WriteLine("Error connecting to Db: " + ex.Message);
            }
            return sqlCon;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        protected void LoadOrders()
        {
            using (SqlConnection con = getConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT ProductId, ProductName, Price, Quantity, Total FROM Order_Table", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvAdminOrders.DataSource = dt;
                gvAdminOrders.DataBind();

                // Calculate total amount for display
                decimal totalAmount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalAmount += Convert.ToDecimal(row["Total"]);
                }
                ltTotalAmount.Text = "Total Amount: " + totalAmount.ToString("C");
            }
        }
        protected void btnRefresh_Click1(object sender, EventArgs e)
        {
            LoadOrders(); // Refresh orders
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DashboardWebForm.aspx");
        }
    }
}