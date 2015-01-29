using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class CompanyCreate : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_Company_Create";

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
        }

        bool Save()
        {
            if(!IsValid()) return false;
           
            DateTime currentdate = DateTime.Now;

            var item = new DAL.CompanyItem();

            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.Contact = txtContact.Text;
            
            item.Active = chkActive.Checked;


            bool succeeded = DAL.Company.Save(ctx, item);

            return succeeded;
        }
      
        
     

        bool IsValid()
        {
         List<string> messages = new List<string>();

         if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
         if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
         if (!(Boolean)DAL.Company.IsCodeAvailable(ctx, txtCode.Text, null)) messages.Add("The code already exists in the system!<br />");
        

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
    }
}