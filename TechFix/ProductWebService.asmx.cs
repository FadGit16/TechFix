using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechFix
{
    /// <summary>
    /// Summary description for ProductWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductWebService : System.Web.Services.WebService
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
                Console.WriteLine("Error connecting to Db" + ex);
            }
            return sqlCon;
        }

        [WebMethod]
        public string AutoProductId()
        {
            string ProductId = null;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select CategoryId from Product_Table", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                string id = "";
                bool records = dr.HasRows;//
                if (records)
                {
                    while (dr.Read())
                    {
                        id = dr[0].ToString(); //C002
                    }
                    string idString = id.Substring(1); //002
                    int CTR = Int32.Parse(idString); //2
                    if (CTR >= 1 && CTR < 9)
                    {
                        CTR = CTR + 1; //3
                        ProductId = "P00" + CTR;
                    }
                    else if (CTR >= 10 && CTR < 99)
                    {
                        CTR = CTR + 1;
                        ProductId = "P0" + CTR;
                    }
                    else if (CTR > 99)
                    {
                        CTR = CTR + 1;
                        ProductId = "P" + CTR;
                    }
                }
                else
                {
                    ProductId = "P001";
                }
                dr.Close();
            }
            catch (Exception e1)
            {
                ProductId = e1.ToString();
            }
            return ProductId;
        }


        [WebMethod]
        public string getCategoryId(string CategoryName)
        {
            string CategoryId = "";
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select CategoryId from Category_Table where CategoryName = '" + CategoryName + "'", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();

                Boolean records = dr.HasRows;
                if (records)
                {
                    while (dr.Read())
                    {
                        CategoryId = dr[0].ToString();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Searching Category Name" + ex);
            }
            return CategoryId;
        }

        [WebMethod]
        public DataSet getCategoryName()
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmdCategory = new SqlCommand("Select CategoryName from Category_Table", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmdCategory);

                da.Fill(ds, "Category_Table");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching CategoryName" + ex);
            }
            return ds;
        }

        [WebMethod]
        public string insertProduct(string ProductId, string ProductName, string Price, string CategoryId, string Quantity)
        {
            int noRows = 0;

            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into Product_Table values('" + ProductId + "', '" + ProductName + "', '" + Price + "', '" + CategoryId + "', '" + Quantity + "');", sqlCon);
                noRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRows.ToString();
        }

        [WebMethod]
        public DataSet SearchProduct(string ProductId)
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Product_Table where ProductId= '" + ProductId + "'", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Product_Table");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching product" + ex);
            }
            return ds;
        }

        [WebMethod]
        public string updateProduct(string ProductId, string ProductName, string Price, string CategoryId, string Quantity)
        {
            int noRows = 0;
            try
            {
                getConnection();
                string query = "UPDATE Product_Table SET ProductName = '" + ProductName +
                       "', Price = '" + Price +
                       "', CategoryId = '" + CategoryId +
                       "', Quantity = '" + Quantity +
                       "' WHERE ProductId = '" + ProductId + "';";

                SqlCommand cmd = new SqlCommand(query, sqlCon);

                // Execute the query
                noRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRows.ToString();
        }

        [WebMethod]
        public string deleteProduct(string ProductId)
        {
            int noRows = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Product_Table WHERE ProductId = '" + ProductId + "';", sqlCon);
                noRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRows.ToString();
        }
    }
}
