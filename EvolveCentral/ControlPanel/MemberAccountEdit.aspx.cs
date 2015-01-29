using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class MemberAccountEdit : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_MemberAccount_Edit";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        string id = null;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();
                BindCompany();
               

              
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

            DAL.MemberAccountItem item = DAL.MemberAccount.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtFirstName.Text = item.FirstName;
                txtLastName.Text = item.LastName;
                txtEmail.Text = item.Email;

              

                rblGender.SelectedValue =  (item.Gender == true) ? "MALE": "FEMALE";





                rcbCompany.SelectedValue = item.CompanyId.ToString();
                   chkActive.Checked = item.IsActive;
            }
        }

        bool Save()
        {
            if (!IsValid()) return false;

            DateTime currentdate = DateTime.Now;

            id = GetId();

            DAL.MemberAccountItem item = DAL.MemberAccount.Get(ctx, Convert.ToInt32(id));
            item.CompanyId = Convert.ToInt32(rcbCompany.SelectedValue);
         
        
            item.Email = txtEmail.Text;
            item.FirstName = txtFirstName.Text;
            item.IsActive = chkActive.Checked;

            item.Gender = (rblGender.SelectedValue == "MALE") ? true : false;
          
            item.LastName = txtLastName.Text;
            
            bool succeeded = DAL.MemberAccount.Save(ctx, item);

            return succeeded;
        }


       
        void BindCompany()
        {
            rcbCompany.DataSource = DAL.Company.List(ctx);

            rcbCompany.DataBind();
        }
       

        bool IsValid()
        {
            id = GetId();

            List<string> messages = new List<string>();

            if (string.IsNullOrEmpty(txtFirstName.Text)) messages.Add("Field [First Name] is required!<br />");
            if (string.IsNullOrEmpty(txtLastName.Text)) messages.Add("Field [Last Name] is required!<br />");
            if (string.IsNullOrEmpty(txtEmail.Text)) messages.Add("Field [Email] is required!<br />");
            if (rcbCompany.SelectedIndex < 1) messages.Add("Field [Company] is required!<br />");
         
            if (!(Boolean)DAL.AdministratorAccount.IsEmailAvailable(ctx, txtEmail.Text, Convert.ToInt32(id))) messages.Add("The e-mail address already exists in the system!<br />");
            if (!Helper.Validation.IsEmail(txtEmail.Text)) messages.Add("Invalid e-mail format!<br />");

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
            Response.Redirect("MemberAccount.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = Save();
            if (isSaved)
            {
                Response.Redirect("MemberAccount.aspx", true);
            }
        }

        protected void lbChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberAccountChangePassword.aspx?Id=" + GetId(), true);
        }

        string GetId()
        {         
            return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;
     
        }
    }
}