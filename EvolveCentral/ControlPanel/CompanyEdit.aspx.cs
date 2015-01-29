using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class CompanyEdit : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_Company_Edit";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        string id = null;
         
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
            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.CompanyItem item = DAL.Company.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtContact.Text = item.Contact;
                 chkActive.Checked = item.Active;
            }
        }

        bool Save()
        {
            if (!IsValid()) return false;

            DateTime currentdate = DateTime.Now;

            id = GetId();

            DAL.CompanyItem item = DAL.Company.Get(ctx, Convert.ToInt32(id));
     
            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.Active = chkActive.Checked;    
            item.Contact = txtContact.Text;

            bool succeeded = DAL.Company.Save(ctx, item);

            return succeeded;
        }


      

        bool IsValid()
        {
            id = GetId();

            List<string> messages = new List<string>();

            if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
            if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
            if (!(Boolean)DAL.Company.IsCodeAvailable(ctx, txtCode.Text, Convert.ToInt32(id))) messages.Add("The code already exists in the system!<br />");
         
            if (messages.Count > 0)
            {
                string message = String.Join(String.Empty, messages.ToArray());
                rwm.RadAlert(message, null, null, null, null);
                return false;
            }

            return true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Company.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = Save();
            if (isSaved)
            {
                Response.Redirect("Company.aspx", true);
            }
        }

        protected void lbChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorAccountChangePassword.aspx?Id=" + GetId()  , true);
        }

        string GetId()
        {         
            return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;
     
        }
    }
}