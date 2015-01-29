using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class SyncLogCrmEvolutionDetailFull : System.Web.UI.Page
    {
        string RequiredPermission_View = "LogManagement_CrmEvolution_View";
       
    

        bool canView = false; 
     
        bool canDelete = false;

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();       

        protected void Page_Load(object sender, EventArgs e)
        {
           
                CheckPermissions();
                lblTitle.Text += " - " + DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(GetServiceId())).Name;
           
        }

        void CheckPermissions()
        {
          
                canView = (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] != null && (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_View))) ? true : false;

                if (!canView) Response.Redirect("Login.aspx", true);

                string permissioncodelist = Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString();

               
           
       

        }

        protected void rgvData_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = null;

            switch (e.CommandName)
            {
                case "View":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("SyncLogCrmEvolutionDetailFullView.aspx?ServiceId=" + GetServiceId() + "&LogId=" + GetLogId() + "&Id=" + id, true);
                    break;
            }
        }


        protected void eds_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            string logid = GetLogId();
            eds.WhereParameters.Clear();
            eds.Where = "it.SyncLogCrmEvolutionId= @LogId";
            eds.WhereParameters.Add(new Parameter("LogId", TypeCode.Int32, logid));
        }

        protected void rgvData_DataBound(object sender, EventArgs e)
        {
             rgvData.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = false;
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SyncLogCrmEvolutionDetail.aspx?ServiceId=" + GetServiceId(), true);
        }
        string GetServiceId()
        {
            return (Request.QueryString["ServiceId"] != null && !string.IsNullOrEmpty(Request.QueryString["ServiceId"])) ? Request.QueryString["ServiceId"].ToString() : null;

        }
        string GetLogId()
        {
            return (Request.QueryString["LogId"] != null && !string.IsNullOrEmpty(Request.QueryString["LogId"])) ? Request.QueryString["LogId"].ToString() : null;

        }
        }
}