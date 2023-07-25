using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leave_App.Common;
using Leave_App.Common.Model;

namespace Leave_DAL
{
    public class Dashboard_DAL
    {
        public DataTable GetAccountsDetails( string SqlconString)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_ProjectTable_GetALL", new Dictionary<string, string>());
            return dt;

        }
        public DataTable GetAllData(Dictionary<string, string> ParamValue)
        {
            Common.Common objCommonSQL = new Common.Common();
            DataTable dt = objCommonSQL.ExecuteSQLQuery("USP_Dashboard_GetAll", ParamValue);
            return dt;

        }

 
    }
}
