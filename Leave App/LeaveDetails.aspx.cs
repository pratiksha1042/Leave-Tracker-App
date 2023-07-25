using Leave_App.Common.Model;
using Leave_BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace Leave_App
{
    public partial class LeaveDetails : Page
    {
        public static string connectionString { get; set; }
        public Common.Common objCommon { get; set; }
        public string LeaveListString { get; private set; }

        LeaveDetail_BAL BALObj = new LeaveDetail_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            objCommon = new Common.Common();
            connectionString = objCommon.SqlconString;
            if (!IsPostBack)
            {

                //DropDownProjectID("USP_ProjectTable_GetALL", objCommonSQL.SqlconString);
                DropDownAssociateID("USP_AssociateTable_GetALL", objCommon.SqlconString);

            }

            try
            {
                var LeaveDetails = BALObj.GetLeaveDetailList(connectionString);
                LeaveListString = JsonConvert.SerializeObject(LeaveDetails);
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
                objDict.Add("AssociateID", AssociateIDDropDownList.SelectedValue);
                var startdate = DateTime.ParseExact(StartDatetxt.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(EndDatetxt.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                objDict.Add("StartDate", Convert.ToString(startdate));
                objDict.Add("EndDate", Convert.ToString(enddate));
                objDict.Add("Description", Descriptiontxt.Text);
                var response = BALObj.InsertLeaveDetails(objDict);
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

                objDict.Add("ID", IDTextBox.Text);
                objDict.Add("AssociateID", AssociateIDDropDownList.SelectedValue);
                var startdate = DateTime.ParseExact(StartDatetxt.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                var enddate = DateTime.ParseExact(EndDatetxt.Text, "d/M/yyyy", CultureInfo.InvariantCulture);
                objDict.Add("StartDate", Convert.ToString(startdate));
                objDict.Add("EndDate", Convert.ToString(enddate));
                objDict.Add("Description", Descriptiontxt.Text);
                var response = BALObj.UpdateLeaveDetails(objDict);
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
            LeaveDetail_BAL objBAL = new LeaveDetail_BAL();
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
            LeaveDetail_BAL objBAL = new LeaveDetail_BAL();
            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();
                objDict.Add("ID", Convert.ToString(ID));
                var response = objBAL.DeleteLeaveDetails(objDict);
                resultString = JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
            }
            return resultString;

        }

        protected void Cancelbtn_Click(object sender, EventArgs e)
        {
            AssociateIDDropDownList.SelectedIndex = 0;
            StartDatetxt.Text = string.Empty;
            EndDatetxt.Text = string.Empty;
            Descriptiontxt.Text = string.Empty;
        }


        public void DropDownAssociateID(string PROC_NAME, string SqlconString)
        {
            using (var sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand(PROC_NAME, sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sql_cmnd.ExecuteReader();

                List<AssociateDetailModel> AssociateModelList = new List<AssociateDetailModel>();

                while (reader.Read())
                {
                    AssociateDetailModel AssociateDetailObj = new AssociateDetailModel();
                    AssociateDetailObj.ID = int.Parse(reader["ID"].ToString());
                    AssociateDetailObj.UserName = reader["UserName"].ToString();
                    //PD.ProjectID = reader["ProjectID"].ToString();

                    AssociateModelList.Add(AssociateDetailObj);
                }

                AssociateIDDropDownList.DataSource = AssociateModelList;

                AssociateIDDropDownList.DataTextField = "UserName";
                AssociateIDDropDownList.DataValueField = "ID";
                AssociateIDDropDownList.DataBind();
                sqlCon.Close();
            }
        }



    }
}