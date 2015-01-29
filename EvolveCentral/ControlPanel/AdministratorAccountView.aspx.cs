using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class AdministratorAccountView : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_AdministratorAccount_View";

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
         
            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.AdministratorAccountItem item = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(id));

            if (item.AdministratorRoleItem.Code == Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER)
                Response.Redirect("Login.aspx", true);

            if (item.AdministratorRoleItem.Code == Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR && (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR))
                Response.Redirect("Login.aspx", true);

        }

        void LoadData()
        {
            string id = GetId();

            DAL.AdministratorAccountItem item = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtFirstName.Text = item.FirstName;
                txtLastName.Text = item.LastName;
                txtEmail.Text = item.Email;
                txtRole.Text = item.AdministratorRoleItem.Name;
                txtActive.Text = (item.IsActive) ? "Yes" : "No";

                if (item.LastLogonOn.HasValue) txtLastLogon.Text = Convert.ToDateTime(item.LastLogonOn).ToShortDateString() + " " + Convert.ToDateTime(item.LastLogonOn).ToShortTimeString();
                txtCreatedOn.Text = Convert.ToDateTime(item.CreatedOn).ToShortDateString() + " " + Convert.ToDateTime(item.CreatedOn).ToShortTimeString();
                txtModifiedOn.Text = Convert.ToDateTime(item.ModifiedOn).ToShortDateString() + " " + Convert.ToDateTime(item.ModifiedOn).ToShortTimeString();

                if (item.CreatedBy.HasValue)
                {
                    DAL.AdministratorAccountItem aia = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(item.CreatedBy));
                    txtCreatedBy.Text = aia.FirstName + " " + aia.LastName + " ( " + aia.Email + " )";

                }

                if (item.ModifiedBy.HasValue)
                {
                    DAL.AdministratorAccountItem aia = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(item.ModifiedBy));
                    txtModifiedBy.Text = aia.FirstName + " " + aia.LastName + " ( " + aia.Email + " )";

                }
            }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("AdministratorAccount.aspx", true);
          }

          string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}