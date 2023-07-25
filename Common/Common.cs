using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Runtime.InteropServices;

namespace Common
{
    public class Common
    {
        public String SqlconString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString; //property
        //public String SqlconString = @"Data Source=PSL-BB077L3\SQLEXPRESS;Initial Catalog=Legacy;Integrated Security=True;";
        public int InsertUpdateDelete(string PROC_NAME, Dictionary<string, string> ParamValue)
        {
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand(PROC_NAME, sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                foreach (var item in ParamValue)
                {
                    sql_cmnd.Parameters.AddWithValue("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                }
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return 1;
        }


        public DataTable ExecuteSQLQuery(string PROC_NAME, Dictionary<string, string> ParamValue)
        {
            DataTable dataTable = new DataTable();

            using (var adapter = new SqlDataAdapter(PROC_NAME, SqlconString))

            {
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (var item in ParamValue)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                }
                adapter.Fill(dataTable);
            };

            return dataTable;
        }
        public void AlertMessage(string MessageString, HttpRequest request, ClientScriptManager ClientScript)
        {
            string msgstring = MessageString;
            string content = "window.onload=function(){ alert('";
            content += msgstring;
            content += "');";
            content += "window.location='";
            content += request.Url.AbsoluteUri;
            content += "';}";
            ClientScript.RegisterStartupScript(this.GetType(), "SucessMessage", content, true);
        }

    }
}
