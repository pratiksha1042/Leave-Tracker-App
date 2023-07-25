using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leave_DAL;
using Common.Model;
using Newtonsoft.Json;

namespace Leave_BAL
{
    public class LeaveDetail_BAL
    {
        LeaveDetail_DAL DALObj=new LeaveDetail_DAL();
        public List<LeaveDetailModel> GetLeaveDetailList(string SqlconString)
        {
            List<LeaveDetailModel> ProjectDetails = new List<LeaveDetailModel>();
            var dt = DALObj.GetLeaveDetailList(SqlconString);
            var dtString = JsonConvert.SerializeObject(dt);
            ProjectDetails = JsonConvert.DeserializeObject<List<LeaveDetailModel>>(dtString);
            return ProjectDetails;
        }

        public List<LeaveDetailModel> ShowData(Dictionary<string, string> ParamValue)
        {
            List<LeaveDetailModel> LeaveDetails = new List<LeaveDetailModel>();
            var dt = DALObj.ShowData(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            LeaveDetails = JsonConvert.DeserializeObject<List<LeaveDetailModel>>(dtString);
            return LeaveDetails;
        }


        public ResponseModel InsertLeaveDetails(Dictionary<string, string> ParamValue)
        {
            List<ResponseModel> objResponseModel = new List<ResponseModel>();
            var dt = DALObj.InsertLeaveDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            objResponseModel = JsonConvert.DeserializeObject<List<ResponseModel>>(dtString);
            return objResponseModel[0];

        }
        public ResponseModel UpdateLeaveDetails(Dictionary<string, string> ParamValue)
        {
            List<ResponseModel> objResponseModel = new List<ResponseModel>();
            var dt = DALObj.UpdateLeaveDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            objResponseModel = JsonConvert.DeserializeObject<List<ResponseModel>>(dtString);
            return objResponseModel[0];

        }
        public List<LeaveDetailModel> DeleteLeaveDetails(Dictionary<string, string> ParamValue)
        {
            List<LeaveDetailModel> LeaveDetails = new List<LeaveDetailModel>();
            var dt = DALObj.DeleteLeaveDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            LeaveDetails = JsonConvert.DeserializeObject<List<LeaveDetailModel>>(dtString);
            return LeaveDetails;

        }
    }
}
