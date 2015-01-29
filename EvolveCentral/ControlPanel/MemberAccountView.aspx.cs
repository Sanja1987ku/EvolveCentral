using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class MemberAccountView : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_MemberAccount_View";

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

            DAL.MemberAccountItem item = DAL.MemberAccount.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtFirstName.Text = item.FirstName;
                txtLastName.Text = item.LastName;
                txtEmail.Text = item.Email;
                txtCompany.Text = item.CompanyItem.Name;
                   txtActive.Text = (item.IsActive) ? "Yes" : "No";
                txtGender.Text = (item.Gender) ? "Male" : "Female";

                if (item.LastLogonOn.HasValue) txtLastLogon.Text = Convert.ToDateTime(item.LastLogonOn).ToShortDateString() + " " + Convert.ToDateTime(item.LastLogonOn).ToShortTimeString();
                txtRegisteredOn.Text = Convert.ToDateTime(item.RegisteredOn).ToShortDateString() + " " + Convert.ToDateTime(item.RegisteredOn).ToShortTimeString();
              

            }
        }

          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("MemberAccount.aspx", true);
          }

          string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}