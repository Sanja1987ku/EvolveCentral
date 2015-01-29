using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class AdministratorPermissionEdit : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_AdministratorPermission_Edit";

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

            DAL.AdministratorPermissionItem item = DAL.AdministratorPermission.Get(ctx, Convert.ToInt32(id));
        

            if (item.IsSelectable == false && (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR))
                Response.Redirect("Login.aspx", true);
        
        }
        
        void LoadData()
        {
            string id = (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;

            DAL.AdministratorPermissionItem item = DAL.AdministratorPermission.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtParentId.Text = item.ParentId.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;
               
              chkIsSelectable.Checked = Convert.ToBoolean(item.IsSelectable);

              if (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR)
              {
                  chkIsSelectable.Enabled = false;
                  txtCode.Enabled = false;
                  txtParentId.Enabled = false;
              }
               }
        }

        bool Save()
        {
            if (!IsValid()) return false;

            DateTime currentdate = DateTime.Now;

            id = GetId();

            DAL.AdministratorPermissionItem item = DAL.AdministratorPermission.Get(ctx, Convert.ToInt32(id));
            item.ParentId = (!string.IsNullOrEmpty(txtParentId.Text) ? Convert.ToInt32(txtParentId.Text) : (int?)null);
            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.IsSelectable = chkIsSelectable.Checked;
            item.Description = txtDescription.Text;

          

            bool succeeded = DAL.AdministratorPermission.Save(ctx, item);
          
          
            return succeeded;
        }


    
        bool IsValid()
        {
            id = GetId();

            List<string> messages = new List<string>();

            if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
            if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
            if (!(Boolean)DAL.AdministratorPermission.IsCodeAvailable(ctx, txtCode.Text, Convert.ToInt32(id))) messages.Add("The code already exists in the system!<br />");
           
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
            Response.Redirect("AdministratorPermission.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = Save();
            if (isSaved)
            {
                Response.Redirect("AdministratorPermission.aspx", true);
            }
        }

      

        string GetId()
        {         
            return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;
     
        }

      

       }
}