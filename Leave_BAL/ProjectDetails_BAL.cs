using Leave_App.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Leave_DAL;
using Common.Model;

namespace Leave_BAL
{
    public class ProjectDetails_BAL
    {
        ProjectDetails_DAL DALObj = new ProjectDetails_DAL();
        public List<ProjectDetailModel> GetProjectDetailList(string SqlconString)
        {
            List<ProjectDetailModel> ProjectDetails = new List<ProjectDetailModel>();
            var dt = DALObj.GetProjectDetailList(SqlconString);
            var dtString = JsonConvert.SerializeObject(dt);
            ProjectDetails = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
            return ProjectDetails;
        }

        public List<ProjectDetailModel> ShowData(Dictionary<string, string> ParamValue)
        {
            List<ProjectDetailModel> ProjectDetails = new List<ProjectDetailModel>();
            var dt = DALObj.ShowData(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            ProjectDetails = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
            return ProjectDetails;
        }

        //public List<ProjectDetailModel> ShowData(string SqlconString)
        //{
        //    List<ProjectDetailModel> ProjectDetails = new List<ProjectDetailModel>();
        //    var dt = DALObj.GetProjectDetailList(SqlconString);
        //    var dtString = JsonConvert.SerializeObject(dt);
        //    ProjectDetails = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
        //    return ProjectDetails;
        //}
        public ResponseModel InsertProjectDetails(Dictionary<string, string> ParamValue)
        {
            List<ResponseModel> objResponseModel = new List<ResponseModel>();
            var dt = DALObj.InsertProjectDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            objResponseModel = JsonConvert.DeserializeObject<List<ResponseModel>>(dtString);
            return objResponseModel[0];

        }
        public ResponseModel UpdateProjectDetails(Dictionary<string, string> ParamValue)
        {
            List<ResponseModel> objResponseModel = new List<ResponseModel>();
            var dt = DALObj.UpdateProjectDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            objResponseModel = JsonConvert.DeserializeObject<List<ResponseModel>>(dtString);
            return objResponseModel[0];

        }
        public List<ProjectDetailModel> DeleteProjectDetails(Dictionary<string, string> ParamValue)
        {
            List<ProjectDetailModel> ProjectDetails = new List<ProjectDetailModel>();
            var dt = DALObj.DeleteProjectDetails(ParamValue);
            var dtString = JsonConvert.SerializeObject(dt);
            ProjectDetails = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
            return ProjectDetails;

        }

        //public List<ProjectDetailModel> ShowData(string SqlconString)
        //{
        //    List<ProjectDetailModel> ProjectDetails = new List<ProjectDetailModel>();
        //    var dt = DALObj.ShowData(SqlconString);
        //    var dtString = JsonConvert.SerializeObject(dt);
        //    ProjectDetails = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
        //    return ProjectDetails;
        //}
        //public ProjectDetailModel ShowAssociateDetails(Dictionary<string, string> ParamValue)
        //{
        //    List<ProjectDetailModel> objResponseModel = new List<ProjectDetailModel>();
        //    var dt = DALObj.ShowAssociateDetails(ParamValue);
        //    var dtString = JsonConvert.SerializeObject(dt);
        //    objResponseModel = JsonConvert.DeserializeObject<List<ProjectDetailModel>>(dtString);
        //    return objResponseModel;

        //}


    }
}
