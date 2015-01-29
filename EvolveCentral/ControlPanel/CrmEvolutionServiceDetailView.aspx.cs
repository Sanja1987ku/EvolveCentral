using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceDetailView : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_Service_View";

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

            DAL.ServiceCrmEvolutionDetailItem item = DAL.ServiceCrmEvolutionDetail.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;
                txtCommand.Text = item.Command;
                txtCommandType.Text = item.CommandType;
                txtDestinationTable.Text = item.DestinationTable;
                txtSequence.Text = item.Sequence.ToString();
                txtSourceTable.Text = item.SourceTable;
            
                    DAL.AdministratorAccountItem aia = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(item.LastModifiedAdministratorAccountId));
                   if(aia != null) txtLastModifiedAministratorAccount.Text = aia.FirstName + " " + aia.LastName + " ( " + aia.Email + " )";

                   DAL.MemberAccountItem mia = DAL.MemberAccount.Get(ctx, Convert.ToInt32(item.LastModifiedMemberAccountId));
                   if (mia != null) txtLastModifiedAministratorAccount.Text = mia.FirstName + " " + mia.LastName + " ( " + mia.Email + " )";


                    txtLastModifiedOn.Text = Convert.ToDateTime(item.ModifiedOn).ToShortDateString() + " " + Convert.ToDateTime(item.ModifiedOn).ToShortTimeString();

                txtActive.Text = (item.IsActive) ? "Yes" : "No";
         if(item.IsUnique.HasValue)     txtUnique.Text = (Convert.ToBoolean(item.IsUnique)) ? "Yes" : "No";

            
             
                  }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("CrmEvolutionServiceDetail.aspx?ServiceId=" + GetServiceId(), true);
          }

          string GetServiceId()
          {
              return (Request.QueryString["ServiceId"] != null && !string.IsNullOrEmpty(Request.QueryString["ServiceId"])) ? Request.QueryString["ServiceId"].ToString() : null;

          }
          
        string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}