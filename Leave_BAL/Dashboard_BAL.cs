using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Model;
using Leave_DAL;
using Newtonsoft.Json;
using Leave_DAL;
using Leave_App.Common.Model;

namespace Leave_BAL
{
    public class Dashboard_BAL
    {
        Dashboard_DAL objDAL = new Dashboard_DAL();
        public List<ProjectDetailModel> GetAccountsDetails( string SqlconString)
        {
            List<ProjectDetailModel> ProjectModelList = new List<ProjectDetailModel>();
             var dt = objDAL.GetAccountsDetails(SqlconString);
            var dtString = JsonConvert.SerializeObject(dt);
            ProjectModelList = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
            return ProjectModelList;
        }

        public string GetAllData(Dictionary<string, string> ParamValue)
        {
            List<DashboardModel> DashboardDetails = new List<DashboardModel>();
            var dt = objDAL.GetAllData(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt); 
            return dtString;
        } 

    }
}
