using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //    if (!isAuth()) Response.Redirect("~\\Login.aspx");
        //    lblCurrentUser.Text = "Welcome, " + Session[Common.Constant.CODE_SESSION_USERNAME].ToString() + " !";
        }


        bool isAuth()
        {
            //if (Session[Common.Constant.CODE_SESSION_USERNAME] == null || String.IsNullOrEmpty(Session[Common.Constant.CODE_SESSION_USERNAME].ToString()))
            //    return false;

            //if (Session[Common.Constant.CODE_SESSION_ADMINISTRATORROLE].ToString().ToUpper() != Common.Constant.CODE_ROLE_ADMINISTRATOR)
            //    return false;

            return true;


        }
    }
}