using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceView : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_Service_View";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();
          


                LoadData();
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

            DAL.ServiceCrmEvolutionItem item = DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;


                txtServiceTemplate.Text = item.ServiceTemplateCrmEvolutionItem.Name.ToString();
                txtCompany.Text = item.CompanyItem.Name.ToString();
                txtConnectionDatabase.Text = item.Connection_DatabaseName;
                txtConnectionPassword.Text = item.Connection_DatabasePassword;
                txtConnectionServer.Text = item.Connection_DatabaseServer;
                txtConnectionUsername.Text = item.Connection_DatabaseUserName;
                txtDestinationDatabase.Text = item.DatabaseName_Destination;
                txtSourceDatabase.Text = item.DatabaseName_Source;


                txtActive.Text = (item.IsActive) ? "Yes" : "No";
             if(item.LastSyncSuccessful.HasValue)   txtLastSyncSuccesful.Text =  (Convert.ToBoolean(item.LastSyncSuccessful)) ? "Yes" : "No";
              if(item.LastSyncDate.HasValue)  txtLastSyncDate.Text = Convert.ToDateTime(item.LastSyncDate).ToShortDateString() + " " + Convert.ToDateTime(item.LastSyncDate).ToShortTimeString();

             
                  }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("CrmEvolutionService.aspx", true);
          }

          string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}