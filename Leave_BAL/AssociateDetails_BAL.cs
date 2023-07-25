using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leave_DAL;
using Leave_App.Common.Model;
using Newtonsoft.Json;
using Common.Model;

namespace Leave_BAL
{
    public class AssociateDetails_BAL
    {
        AssociateDetails_DAL DALObj= new AssociateDetails_DAL();
        public void AddAssociateDetails(Dictionary<string, string> ParamValue)
        {
            DALObj.InsertDetails(ParamValue);
        }
        public ResponseModel InsertAssociateDetails(Dictionary<string, string> ParamValue)
        {
            List <ResponseModel> objResponseModel = new List<ResponseModel>();
            var dt=DALObj.InsertAssociateDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            objResponseModel=JsonConvert.DeserializeObject<List<ResponseModel>>(dtString);
            return objResponseModel[0];

        }

        public List<AssociateDetailModel> ShowData(Dictionary<string, string> ParamValue)
        {
            List<AssociateDetailModel> AssociateDetails = new List<AssociateDetailModel>();
            var dt = DALObj.ShowData(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            AssociateDetails = JsonConvert.DeserializeObject<List<AssociateDetailModel>>(dtString);
            return AssociateDetails;
        }

        public ResponseModel UpdateAssociateDetails(Dictionary<string, string> ParamValue)
        {
            List<ResponseModel> objResponseModel = new List<ResponseModel>();
            var dt = DALObj.UpdateAssociateDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            objResponseModel = JsonConvert.DeserializeObject<List<ResponseModel>>(dtString);
            return objResponseModel[0];

        }
        public List<AssociateDetailModel> DeleteAssociateDetails(Dictionary<string, string> ParamValue)
        {
            List<AssociateDetailModel> AssociateDetails = new List<AssociateDetailModel>();
            var dt = DALObj.DeleteAssociateDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            AssociateDetails = JsonConvert.DeserializeObject<List<AssociateDetailModel>>(dtString);
            return AssociateDetails;

        }

        public List<AssociateDetailModel> GetAssociateDetailList(string SqlconString)
        {
            List<AssociateDetailModel> AssociateDetails = new List<AssociateDetailModel>();
            var dt=DALObj.GetAssociateDetailList(SqlconString);
            var dtString=JsonConvert.SerializeObject(dt);
            AssociateDetails = JsonConvert.DeserializeObject <List<AssociateDetailModel>>(dtString);
            return AssociateDetails;
           

        }
    }

}
