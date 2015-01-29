using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceTemplateView : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_ServiceTemplate_View";

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

            DAL.ServiceTemplateCrmEvolutionItem item = DAL.ServiceTemplateCrmEvolution.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;
                txtServiceType.Text = item.ServiceTypeItem.Name;
                txtActive.Text = (item.IsActive) ? "Yes" : "No";

            
             
                  }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("CrmEvolutionServiceTemplate.aspx", true);
          }

          string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}