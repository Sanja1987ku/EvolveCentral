using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class AdministratorRoleEdit : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_AdministratorRole_Edit";

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

            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.AdministratorRoleItem item = DAL.AdministratorRole.Get(ctx, Convert.ToInt32(id));
            
            if (item.Code == Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER)
                Response.Redirect("Login.aspx", true);

            if (item.Code == Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR && (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR))
                Response.Redirect("Login.aspx", true);
        
        }
        
        void LoadData()
        {
            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.AdministratorRoleItem item = DAL.AdministratorRole.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;
               
                chkActive.Checked = item.IsActive;

               }
        }

        bool Save()
        {
            if (!IsValid()) return false;

            DateTime currentdate = DateTime.Now;

            id = GetId();

            DAL.AdministratorRoleItem item = DAL.AdministratorRole.Get(ctx, Convert.ToInt32(id));
            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.IsActive = chkActive.Checked;
            item.Description = txtDescription.Text;

            List<int> permission_ids = new List<int>();

            foreach (RadTreeNode rtn in rtvPermission.CheckedNodes)
            {
                permission_ids.Add(Convert.ToInt32(rtn.Value));
            }

            bool succeeded = DAL.AdministratorRole.Save(ctx, item);
          
            if (succeeded)
            {
                succeeded = DAL.AdministratorRole.RemoveAllPermissions(ctx, item);
                if (succeeded)
                {
                    succeeded = DAL.AdministratorRole.AddPermissions(ctx, item, permission_ids);
                }
            }
            return succeeded;
        }


        void BindPermission(List<DAL.AdministratorPermissionItem> permissions)
        {
            
            foreach (Telerik.Web.UI.RadTreeNode rtn in rtvPermission.GetAllNodes())
            {
                foreach (DAL.AdministratorPermissionItem p in permissions)
                {
                    if (p.Id.ToString() == rtn.Value)
                    {
                        rtn.Checked = true;
                        break;
                    }
                }
            }
        }

        bool IsValid()
        {
            id = GetId();

            List<string> messages = new List<string>();

            if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
            if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
           if (!(Boolean)DAL.AdministratorRole.IsCodeAvailable(ctx, txtCode.Text,Convert.ToInt32(id))) messages.Add("The code already exists in the system!<br />");
           if (!(Boolean)DAL.AdministratorRole.IsNameAvailable(ctx, txtName.Text, Convert.ToInt32(id))) messages.Add("The name already exists in the system!<br />");
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

        protected void lbChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdministratorAccountChangePassword.aspx?Id=" + GetId()  , true);
        }

        string GetId()
        {         
            return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;
     
        }

        protected void rtvPermission_DataBound(object sender, EventArgs e)
        {
            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.AdministratorRoleItem item = DAL.AdministratorRole.Get(ctx, Convert.ToInt32(id));

            BindPermission(item.AdministratorPermissionItems.ToList());
    
        }
        protected void edsAdministratorPermission_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            if (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR)
                edsAdministratorPermission.Where = "it.[IsSelectable]=TRUE";
        }

       }
}