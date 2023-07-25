using Leave_BAL;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Leave_App.Common.Model;
using System.Web.Services;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using Common.Model;
using System.Web.Script.Services;

namespace Leave_App
{

    public partial class AssociateDetails : Page
    {
        public static string connectionString { get; set; }
        public string AssociateListString { get; set; }
        public Common.Common objCommon { get; set; }

        AssociateDetails_BAL BALObj = new AssociateDetails_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objCommon = new Common.Common();
            connectionString = objCommon.SqlconString;
            try
            {
                var AssociateDetails = BALObj.GetAssociateDetailList(connectionString);
                AssociateListString = JsonConvert.SerializeObject(AssociateDetails);
            }
            catch (Exception ex)
            {
            }

            if (!IsPostBack)
            {

                DropDownProjectID("USP_ProjectTable_GetALL", objCommon.SqlconString);


            }

            //var AssociateDetails = GetAllAssociateDetails("USP_AssociateTable_GetALL", objCommonSQL.SqlconString);
            //AssociateListString = JsonConvert.SerializeObject(AssociateDetails);


            connectionString = objCommon.SqlconString;
        }

        #region unwanted code
        //public List<AssociateDetailModel> GetAllAssociateDetails(string PROC_NAME, string SqlconString)
        //{
        //    List<AssociateDetailModel> AssociateDetails = new List<AssociateDetailModel>();

        //    using (var sqlCon = new SqlConnection(SqlconString))
        //    {
        //        sqlCon.Open();
        //        SqlCommand sql_cmnd = new SqlCommand(PROC_NAME, sqlCon);
        //        sql_cmnd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader reader = sql_cmnd.ExecuteReader();


        //        while (reader.Read())
        //        {
        //            AssociateDetailModel AssociateDetailObj = new AssociateDetailModel();
        //            AssociateDetailObj.ID = int.Parse(reader["ID"].ToString());
        //            AssociateDetailObj.FirstName = reader["FirstName"].ToString();
        //            AssociateDetailObj.LastName = reader["LastName"].ToString();
        //            AssociateDetailObj.UserName = reader["UserName"].ToString();
        //            AssociateDetailObj.EmailID = reader["EmailID"].ToString();
        //            AssociateDetailObj.Phone = reader["Phone"].ToString();
        //            AssociateDetailObj.Address = reader["Address"].ToString();

        //            AssociateDetails.Add(AssociateDetailObj);
        //        }

        //        //GridView.DataSource = projectDetails;
        //        //GridView.DataBind();


        //        sqlCon.Close();
        //    }
        //    return AssociateDetails;
        //}
        //protected void UpdateButton_Click(object sender, EventArgs e)
        //{

        //    Dictionary<string, string> objDict = new Dictionary<string, string>();

        //    objDict.Add("ID", IDtxt.Text);
        //    objDict.Add("FirstName", FirstNametxt.Text);
        //    objDict.Add("LastName", LastNametxt.Text);
        //    objDict.Add("UserName", UserNametxt.Text);
        //    objDict.Add("EmailID", EmailIDtxt.Text);
        //    objDict.Add("Phone", Phonetxt.Text);
        //    objDict.Add("Address", Addresstxt.Text);
        //    BALObj.UpdateAssociateDetails(objDict);


        //}
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> objDict = new Dictionary<string, string>();
            objDict.Add("ID", IDtxt.Text);
            BALObj.DeleteAssociateDetails(objDict);
        }
        #endregion

        public void DropDownProjectID(string PROC_NAME, string SqlconString)
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
                    ProjectDetailObj.ProjectID= reader["ProjectID"].ToString();
                    ProjectDetailObj.ProjectName = reader["ProjectName"].ToString();

                    ProjectModelList.Add(ProjectDetailObj);
                }
                reader.Close();
                //GridView.DataSource = projectDetails;
                //GridView.DataBind()

                ProjectIDDropDownList.DataSource = ProjectModelList;

                ProjectIDDropDownList.DataTextField = "ProjectID";
                ProjectIDDropDownList.DataValueField = "ID";
                ProjectIDDropDownList.DataBind();
                sqlCon.Close();
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {

            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();
                objDict.Add("FirstName", FirstNametxt.Text);
                objDict.Add("LastName", LastNametxt.Text);
                objDict.Add("UserName", UserNametxt.Text);
                objDict.Add("EmailID", EmailIDtxt.Text);
                objDict.Add("Phone", Phonetxt.Text);
                objDict.Add("ProjectID", ProjectIDDropDownList.SelectedValue);
                var response = BALObj.InsertAssociateDetails(objDict);
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
                objDict.Add("FirstName", FirstNametxt.Text);
                objDict.Add("LastName", LastNametxt.Text);
                objDict.Add("UserName", UserNametxt.Text);
                objDict.Add("EmailID", EmailIDtxt.Text);
                objDict.Add("Phone", Phonetxt.Text);
                objDict.Add("ProjectID", ProjectIDDropDownList.SelectedValue);
                var response = BALObj.UpdateAssociateDetails(objDict);
                objCommon.AlertMessage(response.Message, Request, ClientScript);

                AddButton.Style.Add("display", "block");
                UpdateButton.Style.Add("display", "none");
            }
            catch (Exception ex)
            {
            }


        }


        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string DeleteData(int ID)
        {
            string resultString = string.Empty;
            AssociateDetails_BAL objBAL = new AssociateDetails_BAL();
            try
            {
                Dictionary<string, string> objDict = new Dictionary<string, string>();
                objDict.Add("ID", Convert.ToString(ID));
                var response = objBAL.DeleteAssociateDetails(objDict);
                resultString = JsonConvert.SerializeObject(response);
            }
            catch (Exception ex)
            {
            }
            return resultString;

        }

        [WebMethod, ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = false)]
        public static string ShowData(int ID)
        {
            string resultString = string.Empty;
            AssociateDetails_BAL objBAL = new AssociateDetails_BAL();
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



        protected void Cancelbtn_Click(object sender, EventArgs e)
        {
            FirstNametxt.Text = string.Empty;
            LastNametxt.Text = string.Empty;
            UserNametxt.Text = string.Empty;
            EmailIDtxt.Text = string.Empty;
            Phonetxt.Text = string.Empty;
            ProjectIDDropDownList.SelectedIndex = 0;
            IDtxt.Text = string.Empty;
        }
    }

   

}

