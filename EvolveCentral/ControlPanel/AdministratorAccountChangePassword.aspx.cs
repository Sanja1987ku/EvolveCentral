using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class AdministratorAccountChangePassword : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_AdministratorAccount_ChangePassword";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();         


             
            }
        }
        void CheckPermissions()
        {
            bool HasPermission = Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] != null && Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_View);
            if (!HasPermission) Response.Redirect("Login.aspx", true);

           
            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.AdministratorAccountItem item = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(id));

            if(item.AdministratorRoleItem.Code == Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER)
                Response.Redirect("Login.aspx", true);

            if (item.AdministratorRoleItem.Code == Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR && (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR))
                Response.Redirect("Login.aspx", true);
 }

       
          protected void btnBack_Click(object sender, EventArgs e)
          {
              Response.Redirect("AdministratorAccountEdit.aspx?Id=" + GetId(), true);
          }
          protected void btnSave_Click(object sender, EventArgs e)
          {
              if(Save())
                  Response.Redirect("AdministratorAccount.aspx?Id=" + GetId(), true);
          }

          bool Save()
          {
           
              try
              {
                  if (!IsValid()) return false;

                  string id = GetId();
                  DAL.AdministratorAccountItem item = DAL.AdministratorAccount.Get(ctx, Convert.ToInt32(id));
                  item.Password = Helper.Encryption.Encrypt(txtPassword.Text);
                  item.ModifiedBy = Helper.Current.AdministratorAccoundId();
                  item.ModifiedOn = DateTime.Now;

                  DAL.AdministratorAccount.Save(ctx, item);


                  return true;
              }
              catch (Exception ex)
              {
                
                  return false;
              }
           

          }
        
        bool IsValid()
        {
         List<string> messages = new List<string>();

         if (string.IsNullOrEmpty(txtPassword.Text)) messages.Add("Field [Password] is required!<br />");
         if (string.IsNullOrEmpty(txtPasswordAgain.Text)) messages.Add("Field [Password again] is required!<br />");

         if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtPasswordAgain.Text) && txtPassword.Text != txtPasswordAgain.Text) messages.Add("Field [Password] and [Password again] must match!<br />");
         
            if (messages.Count > 0)
         {
             string message = String.Join(String.Empty, messages.ToArray());


             rwm.RadAlert(message, null, null, null, null);
             return false;
         }

         return true;
        }


          string GetId()
          {
              return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

          }
    }
}