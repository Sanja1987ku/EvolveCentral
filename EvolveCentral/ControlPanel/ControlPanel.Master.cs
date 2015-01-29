using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class ControlPanel : System.Web.UI.MasterPage
    {
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
            bool HasPermission = Session[ Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] != null;
            if (!HasPermission) Response.Redirect("Login.aspx", true);
        }

        void LoadData()
        {
            lblCurrentUser.Text = lblCurrentUser.Text.Replace("[CurrentUserName]", Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTNAME].ToString());

        }
        protected void lbLogOff_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", true);
        }
    }
}