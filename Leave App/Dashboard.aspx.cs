using Leave_App.Common.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Leave_App.Common;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;
using System.Security.AccessControl;
using System.Web.Services;
using Common.Model;
using Leave_BAL;
using System.Web.Script.Services;

namespace Leave_App
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public string dashboardModelList { get; set; }
        public string SqlconString { get; set; }
        public Dictionary<string, string> ObjDict { get; set; }
        public static string connectionString { get; set; }

        public Dashboard_BAL _objDashboard_BAL { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Common.Common objCommonCommon = new Common.Common();
            SqlconString = objCommonCommon.SqlconString;
            _objDashboard_BAL = new Dashboard_BAL();
            connectionString = objCommonCommon.SqlconString;
            
            
            if (!IsPostBack)
            {

                //DropDownClientName("USP_ProjectTable_GetALL", objCommonCommon.SqlconString);
                GetAccountsDetails();

                var YearInput = DateTime.Now.Year.ToString();
                Dictionary<string, string> ObjDict = new Dictionary<string, string>();
                ObjDict.Add("year", Convert.ToString(YearInput));
                YearDropdown.SelectedValue = YearInput;

                //var result = GetAllDashboardDetailsTest("USP_Dashboard_GetAll", ObjDict, objCommonCommon.SqlconString);
                var result = GetAllData(Convert.ToInt32(ClientNameDropDownList.SelectedValue), Convert.ToInt32(YearInput));
                //dashboardModelList = JsonConvert.SerializeObject(result);
                dashboardModelList = result;
                
            }
        }

        public void GetAccountsDetails()
        {
            var ProjectModelList = _objDashboard_BAL.GetAccountsDetails(connectionString);
            ClientNameDropDownList.DataSource = ProjectModelList; 
            ClientNameDropDownList.DataTextField = "ClientName";
            ClientNameDropDownList.DataValueField = "ID";
            ClientNameDropDownList.DataBind();
        }


        public void DropDownClientName(string PROC_NAME, string SqlconString)
        {
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand(PROC_NAME, sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sql_cmnd.ExecuteReader();

                List<ProjectDetailModel> ProjectModelList = new List<ProjectDetailModel>();

                while (reader.Read())
                {
                    ProjectDetailModel ProjectDetailObj = new ProjectDetailModel();
                    ProjectDetailObj.ID = int.Parse(reader["ID"].ToString());
                    //PD.AssociateID = reader["AssociateID"].ToString();
                    ProjectDetailObj.ClientName = reader["ClientName"].ToString();

                    ProjectModelList.Add(ProjectDetailObj);
                }
                reader.Close();
                //GridView.DataSource = projectDetails;
                //GridView.DataBind()

                ClientNameDropDownList.DataSource = ProjectModelList;

                ClientNameDropDownList.DataTextField = "ClientName";
                ClientNameDropDownList.DataValueField = "ID";
                ClientNameDropDownList.DataBind();
                sqlCon.Close();
            }
        }
        public List<DashboardModel> GetAllDashboardDetailsTest(string PROC_NAME, Dictionary<string, string> Paramvalue, string SqlconString)
        {
            List<DashboardModel> dashboardModelList = new List<DashboardModel>();

            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();

                SqlCommand sql_cmnd = new SqlCommand(PROC_NAME, sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                foreach (var item in Paramvalue)
                {
                    sql_cmnd.Parameters.AddWithValue("@" + item.Key, SqlDbType.VarChar).Value = item.Value;
                }
                SqlDataReader reader = sql_cmnd.ExecuteReader();


                while (reader.Read())
                {
                    DashboardModel dashboardModelObj = new DashboardModel();
                    dashboardModelObj.UserName = reader["UserName"].ToString();
                    dashboardModelObj.ProjectName = reader["ProjectName"].ToString();
                    dashboardModelObj.Jan = reader["Jan"].ToString();
                    dashboardModelObj.Feb = reader["feb"].ToString();
                    dashboardModelObj.Mar = reader["Mar"].ToString();
                    dashboardModelObj.Apr = reader["Apr"].ToString();
                    dashboardModelObj.May = reader["May"].ToString();
                    dashboardModelObj.Jun = reader["Jun"].ToString();
                    dashboardModelObj.Jul = reader["Jul"].ToString();
                    dashboardModelObj.Aug = reader["Aug"].ToString();
                    dashboardModelObj.Sep = reader["Sep"].ToString();
                    dashboardModelObj.Oct = reader["Oct"].ToString();
                    dashboardModelObj.Nov = reader["Nov"].ToString();
                    dashboardModelObj.Dec = reader["Dec"].ToString();
                    dashboardModelObj.AllowedLeaves = reader["AllowedLeaves"].ToString();
                    dashboardModelObj.Total_Leaves_Taken_Q1 = reader["Total_Leaves_Taken_Q1"].ToString();
                    dashboardModelObj.Total_Leaves_Taken_Q2 = reader["Total_Leaves_Taken_Q2"].ToString();
                    dashboardModelObj.Total_Leaves_Taken_Q3 = reader["Total_Leaves_Taken_Q3"].ToString();
                    dashboardModelObj.Total_Leaves_Taken_Q4 = reader["Total_Leaves_Taken_Q4"].ToString();
                    dashboardModelObj.Adjustment_Leaves_Q1 = reader["Adjustment_Leaves_Q1"].ToString();
                    dashboardModelObj.Adjustment_Leaves_Q2 = reader["Adjustment_Leaves_Q2"].ToString();
                    dashboardModelObj.Adjustment_Leaves_Q3 = reader["Adjustment_Leaves_Q3"].ToString();
                    dashboardModelObj.Adjustment_Leaves_Q4 = reader["Adjustment_Leaves_Q4"].ToString();


                    dashboardModelList.Add(dashboardModelObj);
                }

                reader.Close();

                //LeaveTableGridView.DataSource = dashboardModelList;
                //LeaveTableGridView.DataBind();
                sqlCon.Close();
            }
            return dashboardModelList;
        }


        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]


        public static string GetAllData(int projectID, int years)
        { 
            string result = string.Empty;
            DataTable dataTable = new DataTable();
            try
            {
                Dictionary<string, string> ParamValue = new Dictionary<string, string>();
                Dashboard_BAL objDashboard_BAL = new Dashboard_BAL();

                ParamValue.Add("year", Convert.ToString(years));
                ParamValue.Add("projectID", Convert.ToString( projectID));

                result = objDashboard_BAL.GetAllData(ParamValue); 
            }
            catch (Exception ex)
            {
            }
            return result;
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

    }
}

