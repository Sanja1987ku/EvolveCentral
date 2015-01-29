using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class MemberAccountCreate : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_MemberAccount_Create";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
      
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                CheckPermissions();
                BindCompany();
              
            
            }
        }

        void CheckPermissions()
        {
            bool HasPermission = Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] != null && Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_View);
            if (!HasPermission) Response.Redirect("Login.aspx", true);
        }

        bool Save()
        {
            if(!IsValid()) return false;
           
            DateTime currentdate = DateTime.Now;

            var item = new DAL.MemberAccountItem();
            item.CompanyId = Convert.ToInt32(rcbCompany.SelectedValue);
           
            item.RegisteredOn = currentdate;
           
              item.Email = txtEmail.Text;
            item.FirstName = txtFirstName.Text;
            item.IsActive = chkActive.Checked;

            item.Gender = (rblGender.SelectedValue == "MALE") ? true : false;
            item.LastLogonOn = null;
            item.LastName = txtLastName.Text;
          

            item.Password = Helper.Encryption.Encrypt(txtPassword.Text);

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
         List<string> messages = new List<string>();

         if (string.IsNullOrEmpty(txtFirstName.Text)) messages.Add("Field [First Name] is required!<br />");
         if (string.IsNullOrEmpty(txtLastName.Text)) messages.Add("Field [Last Name] is required!<br />");
         if (string.IsNullOrEmpty(txtEmail.Text)) messages.Add("Field [Email] is required!<br />");
         if (rcbCompany.SelectedIndex < 1) messages.Add("Field [Company] is required!<br />");
      
         if (string.IsNullOrEmpty(txtPassword.Text)) messages.Add("Field [Password] is required!<br />");
         if (string.IsNullOrEmpty(txtPasswordAgain.Text)) messages.Add("Field [Password again] is required!<br />");

         if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtPasswordAgain.Text) && txtPassword.Text != txtPasswordAgain.Text) messages.Add("Field [Password] and [Password again] must match!<br />");

         if (!(Boolean)DAL.AdministratorAccount.IsEmailAvailable(ctx, txtEmail.Text)) messages.Add("The e-mail address already exists in the system!<br />");

            if(!Helper.Validation.IsEmail(txtEmail.Text)) messages.Add("Invalid e-mail format!<br />");

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
    }
}