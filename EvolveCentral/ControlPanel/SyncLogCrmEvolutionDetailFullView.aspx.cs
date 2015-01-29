using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class SyncLogCrmEvolutionDetailFullView : System.Web.UI.Page
    {
        string RequiredPermission_View = "LogManagement_CrmEvolution_View";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();
          


                LoadData();
                lblTitle.Text += " - " + DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(GetServiceId())).Name;
            }
        }
        void CheckPermissions()
        {
            bool HasPermission = Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] != null && Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_View);
            if (!HasPermission) Response.Redirect("Login.aspx", true);
         
        
        }

        void LoadData()
        {
            string id = GetId();

            DAL.SyncLogCrmEvolutionDetailItem item = DAL.SyncLogCrmEvolutionDetail.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
              
                txtName.Text = item.Name;
                txtErrorMessage.Text = item.ErrorMessage;
                txtCommand.Text = item.ExecutedCommand;
           
            
                 
                   txtCreateDate.Text = Convert.ToDateTime(item.CreateDate).ToShortDateString() + " " + Convert.ToDateTime(item.CreateDate).ToShortTimeString();

                    txtSuccessful.Text = (Convert.ToBoolean(item.IsSuccessful)) ? "Yes" : "No";

            
             
                  }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("SyncLogCrmEvolutionDetailFull.aspx?ServiceId=" + GetServiceId() + "&LogId=" + GetLogId(), true);
          }

          string GetServiceId()
          {
              return (Request.QueryString["ServiceId"] != null && !string.IsNullOrEmpty(Request.QueryString["ServiceId"])) ? Request.QueryString["ServiceId"].ToString() : null;

          }
          string GetLogId()
          {
              return (Request.QueryString["LogId"] != null && !string.IsNullOrEmpty(Request.QueryString["LogId"])) ? Request.QueryString["LogId"].ToString() : null;

          }
          
        string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}