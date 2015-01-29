using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class AdministratorRoleCreate : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_AdministratorRole_Create";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
      
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                CheckPermissions();
                BindPermissions();
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

            var item = new DAL.AdministratorRoleItem();
            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.Description = txtDescription.Text;           
            item.IsActive = chkActive.Checked;
            item.IsDeletable = true;

            List<int> permission_ids = new List<int>();

            foreach (RadTreeNode rtn in rtvPermission.CheckedNodes)
            {
                permission_ids.Add(Convert.ToInt32(rtn.Value));
            }

            bool succeeded = DAL.AdministratorRole.Save(ctx, item);

            if (succeeded)
            {
              succeeded =  DAL.AdministratorRole.RemoveAllPermissions(ctx, item);
              if (succeeded)
              {
                  succeeded = DAL.AdministratorRole.AddPermissions(ctx, item, permission_ids);
              }
            }
          
            return succeeded;
        }
      
        
        void BindPermissions()
        {
            //rcbRole.DataSource = DAL.AdministratorRole.List(ctx);
            //rcbRole.DataBind();
        }

        bool IsValid()
        {
         List<string> messages = new List<string>();

         if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
         if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
         if (!(Boolean)DAL.AdministratorRole.IsCodeAvailable(ctx, txtCode.Text, null)) messages.Add("The code already exists in the system!<br />");
         if (!(Boolean)DAL.AdministratorRole.IsNameAvailable(ctx, txtName.Text, null)) messages.Add("The name already exists in the system!<br />");
         if (rtvPermission.CheckedNodes.Count == 0) messages.Add("Please select at least 1 permission!<br />");
        
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
            Response.Redirect("AdministratorRole.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = Save();
            if (isSaved)
            {
                Response.Redirect("AdministratorRole.aspx", true);
            }
        }

        protected void edsAdministratorPermission_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            if(Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR)
            edsAdministratorPermission.Where = "it.[IsSelectable]=TRUE";
        }

     
    }
}