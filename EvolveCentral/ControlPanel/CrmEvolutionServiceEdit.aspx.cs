using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceEdit : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_Service_Edit";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        string id = null;
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckPermissions();

                BindCompany();
                BindServiceTemplate();
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

            DAL.ServiceCrmEvolutionItem item = DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(id));

            if (item != null)
            {
                txtId.Text = item.Id.ToString();
                txtCode.Text = item.Code;
                txtName.Text = item.Name;
                txtDescription.Text = item.Description;
              
           
              rcbServiceTemplate.SelectedValue =  item.ServiceTemplateCrmEvolutionId.ToString();
              rcbCompany.SelectedValue =  item.CompanyId.ToString();
                txtConnectionDatabase.Text = item.Connection_DatabaseName  ;
                txtConnectionPassword.Text = item.Connection_DatabasePassword ;
                txtConnectionServer.Text = item.Connection_DatabaseServer;
                txtConnectionUsername.Text = item.Connection_DatabaseUserName  ;
                txtDestinationDatabase.Text = item.DatabaseName_Destination;
                  txtSourceDatabase.Text = item.DatabaseName_Source;

           
                chkActive.Checked = item.IsActive;
            }
        }

        bool Save()
        {
            if (!IsValid()) return false;

            DateTime currentdate = DateTime.Now;

            id = GetId();

            DAL.ServiceCrmEvolutionItem item = DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(id));

            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.Description = txtDescription.Text;
            item.ServiceTemplateCrmEvolutionId = Convert.ToInt32(rcbServiceTemplate.SelectedValue);
            item.CompanyId = Convert.ToInt32(rcbCompany.SelectedValue);
            item.Connection_DatabaseName = txtConnectionDatabase.Text;
            item.Connection_DatabasePassword = txtConnectionPassword.Text;
            item.Connection_DatabaseServer = txtConnectionServer.Text;
            item.Connection_DatabaseUserName = txtConnectionUsername.Text;
            item.DatabaseName_Destination = txtDestinationDatabase.Text;
            item.DatabaseName_Source = txtSourceDatabase.Text;
            
            item.IsActive = chkActive.Checked;

            bool succeeded = DAL.ServiceCrmEvolution.Save(ctx, item);

            return succeeded;
        }


      

        bool IsValid()
        {
            id = GetId();

            List<string> messages = new List<string>();

            if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
            if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
            if (string.IsNullOrEmpty(txtSourceDatabase.Text)) messages.Add("Field [Source Database] is required!<br />");
            if (string.IsNullOrEmpty(txtDestinationDatabase.Text)) messages.Add("Field [Destination Database] is required!<br />");

            if (string.IsNullOrEmpty(txtConnectionServer.Text)) messages.Add("Field [Connection - Server] is required!<br />");
            if (string.IsNullOrEmpty(txtConnectionDatabase.Text)) messages.Add("Field [Connection - Database] is required!<br />"); if (!(Boolean)DAL.ServiceCrmEvolution.IsCodeAvailable(ctx, txtCode.Text, null)) messages.Add("The code already exists in the system!<br />");
            if (string.IsNullOrEmpty(txtConnectionUsername.Text)) messages.Add("Field [Connection - Username] is required!<br />"); if (!(Boolean)DAL.ServiceCrmEvolution.IsCodeAvailable(ctx, txtCode.Text, null)) messages.Add("The code already exists in the system!<br />");
            if (string.IsNullOrEmpty(txtConnectionPassword.Text)) messages.Add("Field [Connection - Password] is required!<br />"); if (!(Boolean)DAL.ServiceCrmEvolution.IsCodeAvailable(ctx, txtCode.Text, null)) messages.Add("The code already exists in the system!<br />");
            if (rcbCompany.SelectedIndex < 1) messages.Add("Field [Company] is required!<br />");
            if (rcbServiceTemplate.SelectedIndex < 1) messages.Add("Field [Service Template] is required!<br />");
  
            if (messages.Count > 0)
            {
                string message = String.Join(String.Empty, messages.ToArray());
                rwm.RadAlert(message, null, null, null, null);
                return false;
            }

            return true;
        }
        void BindCompany()
        {
            rcbCompany.DataSource = DAL.Company.List(ctx);
            rcbCompany.DataBind();
        }
        void BindServiceTemplate()
        {
            rcbServiceTemplate.DataSource = DAL.ServiceTemplateCrmEvolution.List(ctx);
            rcbServiceTemplate.DataBind();
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrmEvolutionService.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = Save();
            if (isSaved)
            {
                Response.Redirect("CrmEvolutionService.aspx", true);
            }
        }

       

        string GetId()
        {         
            return (Request.QueryString["id"] != null && !string.IsNullOrEmpty(Request.QueryString["id"])) ? Request.QueryString["id"].ToString() : null;
     
        }
    }
}