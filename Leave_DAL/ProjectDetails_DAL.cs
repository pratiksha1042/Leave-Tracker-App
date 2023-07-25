using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leave_DAL
{
    public class ProjectDetails_DAL
    {
        public DataTable GetProjectDetailList(string SqlconString)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_GetALL", new Dictionary<string, string>());
            return dt;

        }
        //public DataTable ShowData(string SqlconString)
        //{
        //    Common.Common objCommonSQL = new Common.Common();
        //    DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_GetByID", new Dictionary<string, string>());
        //    return dt;

        //}
        public DataTable InsertProjectDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_add", ParamValue);
        }
        public DataTable UpdateProjectDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_Update", ParamValue);
        }
        public DataTable DeleteProjectDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_Delete", ParamValue);
        }

        public DataTable ShowData(Dictionary<string, string> ParamValue)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_GetByID", ParamValue);
            return dt;
        }


    }
}
