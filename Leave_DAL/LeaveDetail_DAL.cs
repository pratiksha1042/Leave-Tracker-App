using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Model;

namespace Leave_DAL
{
    public class LeaveDetail_DAL
    {
        public DataTable GetLeaveDetailList(string SqlconString)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_LeaveDetails_GetALL", new Dictionary<string, string>());
            return dt;

        }

        public DataTable InsertLeaveDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_LeaveDetails_add", ParamValue);
        }
        public DataTable UpdateLeaveDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_LeaveDetails_Update", ParamValue);
        }
        
        public DataTable DeleteLeaveDetails(Dictionary<string, string> ParamValue)
        {

            Common.Common objCommonSQL = new Common.Common();
            return objCommonSQL.ExecuteSQLQuery("USP_LeaveDetails_Delete", ParamValue);
        }

        public DataTable ShowData(Dictionary<string, string> ParamValue)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_LeaveDetails_GetByID", ParamValue);
            return dt;
        }
    }
}
