using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceTemplateDetailView : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_ServiceTemplate_View";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();
          


                LoadData();
                lblTitle.Text += " - " + DAL.ServiceTemplateCrmEvolution.Get(ctx, Convert.ToInt32(GetTemplateId())).Name;
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

            DAL.ServiceTemplateCrmEvolutionDetailItem item = DAL.ServiceTemplateCrmEvolutionDetail.Get(ctx, Convert.ToInt32(id));

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

                    txtLastModifiedOn.Text = Convert.ToDateTime(item.ModifiedOn).ToShortDateString() + " " + Convert.ToDateTime(item.ModifiedOn).ToShortTimeString();

                txtActive.Text = (item.IsActive) ? "Yes" : "No";

            
             
                  }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("CrmEvolutionServiceTemplateDetail.aspx?TemplateId=" + GetTemplateId(), true);
          }

          string GetTemplateId()
          {
              return (Request.QueryString["TemplateId"] != null && !string.IsNullOrEmpty(Request.QueryString["TemplateId"])) ? Request.QueryString["TemplateId"].ToString() : null;

          }
          
        string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}