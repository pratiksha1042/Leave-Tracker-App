using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leave_App.Common.Model;
using Leave_BAL;
using Common;
using Newtonsoft.Json;
using System.Web.Services;
using System.Data;
using Common.Model;
using System.Web.Script.Services;

namespace Leave_App
{
    public partial class ProjectDetails : Page
    {
        public static string connectionString { get; set; }
        public Common.Common objCommon { get; set; }
        public string ProjectListString { get; private set; }

         ProjectDetails_BAL BALObj = new ProjectDetails_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objCommon = new Common.Common();
            connectionString = objCommon.SqlconString;
            try
            {
                var ProjectDetails = BALObj.GetProjectDetailList(connectionString);
                ProjectListString = JsonConvert.SerializeObject(ProjectDetails);
            }
            catch (Exception ex)
            {
            }

        }


        protected void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();
                objDict.Add("ProjectName", ProjectNametxt.Text);
                objDict.Add("ProjectID", ProjectIDtxt.Text);
                objDict.Add("ClientName", ClientNametxt.Text);
                objDict.Add("MonthlyLeaves", MontlyLeavestxt.Text);
                var response = BALObj.InsertProjectDetails(objDict);
                objCommon.AlertMessage(response.Message, Request, ClientScript);
            }
            catch (Exception ex)
            {
            }
        }
        protected void UpdateButton_Click(object sender, EventArgs e)
        {

            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();

                objDict.Add("ID", IDtxt.Text);
                objDict.Add("ProjectName", ProjectNametxt.Text);
                objDict.Add("ProjectID", ProjectIDtxt.Text);
                objDict.Add("ClientName", ClientNametxt.Text);
                objDict.Add("MonthlyLeaves", MontlyLeavestxt.Text);
                var response = BALObj.UpdateProjectDetails(objDict);
                objCommon.AlertMessage(response.Message, Request, ClientScript);

                AddButton.Style.Add("display", "block");
                UpdateButton.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
            }


        }


        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string ShowData(int ID)
        {
            string resultString = string.Empty;
            ProjectDetails_BAL objBAL = new ProjectDetails_BAL();
            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();
                objDict.Add("ID", Convert.ToString(ID));
                var response = objBAL.ShowData(objDict);
                resultString = JsonConvert.SerializeObject(response);

            }
            catch (Exception ex)
            {
            }
            return resultString;

        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string DeleteData(int ID)
        {
            string resultString = string.Empty;
            ProjectDetails_BAL objBAL = new ProjectDetails_BAL();
            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();
                objDict.Add("ID", Convert.ToString(ID));
                var response = objBAL.DeleteProjectDetails(objDict);
                resultString = JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
            }
            return resultString;

        }

        protected void Cancelbtn_Click(object sender, EventArgs e)
        {
            ClientNametxt.Text = string.Empty;
            ProjectIDtxt.Text = string.Empty;
            ProjectNametxt.Text = string.Empty;
            MontlyLeavestxt.Text = string.Empty;
            //IDtxt.Text = string.Empty;
        }


    }
}