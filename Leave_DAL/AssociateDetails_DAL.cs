using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Leave_App.Common.Model;

namespace Leave_DAL
{
    public class AssociateDetails_DAL
    {
        
        public DataTable InsertAssociateDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_AssociateTable_add", ParamValue);
        }
        public DataTable UpdateAssociateDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_AssociateTable_Update", ParamValue);
        }
        
        public void InsertDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            objCommonSQL.InsertUpdateDelete("USP_AssociateTable_add", ParamValue);
        }
        public DataTable ShowData(Dictionary<string, string> ParamValue)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_AssociateTable_GetByID", ParamValue);
            return dt;
        }

        #region Unwanted 

        public void DeleteDetails(Dictionary<string, string> ParamValue)
        {
            Common.Common objCommonSQL = new Common.Common();
            objCommonSQL.InsertUpdateDelete("USP_AssociateTable_Delete", ParamValue);

        }
        public List<AssociateDetailModel> GetAllAssociateDetails(string SqlconString)
        {
            List<AssociateDetailModel> AssociateDetails = new List<AssociateDetailModel>();
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("USP_AssociateTable_GetALL", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sql_cmnd.ExecuteReader();


                while (reader.Read())
                {
                    AssociateDetailModel AssociateDetailObj = new AssociateDetailModel();
                    AssociateDetailObj.ID = int.Parse(reader["ID"].ToString());
                    AssociateDetailObj.FirstName = reader["FirstName"].ToString();
                    AssociateDetailObj.LastName = reader["LastName"].ToString();
                    AssociateDetailObj.UserName = reader["UserName"].ToString();
                    AssociateDetailObj.EmailID = reader["EmailID"].ToString();
                    AssociateDetailObj.Phone = reader["Phone"].ToString();
                    AssociateDetailObj.ProjectID= reader["ProjectID"].ToString();

                    AssociateDetails.Add(AssociateDetailObj);
                }

                //GridView.DataSource = projectDetails;
                //GridView.DataBind();


                sqlCon.Close();
            }
            return AssociateDetails;
        }

        #endregion


        public DataTable GetAssociateDetailList(string SqlconString)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt=objCommonSQL.ExecuteSQLQuery("USP_AssociateTable_GetALL", new Dictionary<string, string>());
            return dt;

        }

      
        public DataTable DeleteAssociateDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_AssociateTable_Delete", ParamValue);
        }
    }
}
