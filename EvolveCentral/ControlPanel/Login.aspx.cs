using System;
using System.Linq;

namespace EvolveCentral.ControlPanel
{
    public partial class Login : System.Web.UI.Page
    {
        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LOGOFF
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTID] = null;
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTNAME] = null;
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLEID] = null;
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLECODE] = null;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {         

            int? userid = null;
            int? roleid = null;

          var item =  DAL.AdministratorAccount.Login(ctx,txtEmail.Text, Helper.Encryption.Encrypt( txtPassword.Text));

            if (item != null)
            {
              //LOGIN SUCCESSFUL
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTID] = item.Id;
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTNAME] = item.FirstName + " " + item.LastName;
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLEID] = item.AdministratorRoleItem.Id;
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLECODE] = item.AdministratorRoleItem.Code;

                string permissioncodelist = null;
                foreach (DAL.AdministratorPermissionItem i in DAL.AdministratorRole.GetPermissions(ctx, item.AdministratorRoleItem.Id))
                {
                    permissioncodelist += i.Code + ";";
                }
                Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] = permissioncodelist;
                
                Response.Redirect("DashBoard.aspx", true);
            }
          
        }
    }
}