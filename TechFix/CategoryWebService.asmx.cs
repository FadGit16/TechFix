using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace TechFix
{
    /// <summary>
    /// Summary description for CategoryWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategoryWebService : System.Web.Services.WebService
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
        public string insertCategory(string CategoryId, string CategoryName)
        {
            int noRows = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("insert into Category_Table values ('" + CategoryId + "', '" + CategoryName + "');", sqlCon);
                noRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRows.ToString();
        }

        [WebMethod]
        public string deleteCategory(string CategoryId)
        {
            int noRows = 0;
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Category_Table WHERE CategoryId = '" + CategoryId + "';", sqlCon);
                noRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return noRows.ToString();
        }

        [WebMethod]
        public DataSet SearchCategory(string CategoryId)
        {
            DataSet ds = new DataSet();
            try
            {
                getConnection();
                SqlCommand cmd = new SqlCommand("Select * from Category_Table where CategoryId= '" + CategoryId + "'", sqlCon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Category_Table");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching category" + ex);
            }
            return ds;
        }

        [WebMethod]
        public string updateCategory(string CategoryId, string CategoryName)
        {
            int noRows = 0;
            try
            {
                getConnection(); 
                SqlCommand cmd = new SqlCommand("UPDATE Category_Table SET CategoryName = '" + CategoryName + "' WHERE CategoryId = '" + CategoryId + "';", sqlCon);
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
