using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceDetailCreate : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_Service_Create";

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
      
        protected void Page_Load(object sender, EventArgs e)
        { 
            if (!IsPostBack)
            {
                CheckPermissions();
                lblTitle.Text += " - " + DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(GetServiceId())).Name;
                  
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

            var item = new DAL.ServiceCrmEvolutionDetailItem();
            item.ServiceCrmEvolutionId = Convert.ToInt32(GetServiceId());
            item.Code = txtCode.Text;
            item.Name = txtName.Text;
            item.Description = txtDescription.Text;
            item.Command = txtCommand.Text;
            item.CommandType = txtCommandType.Text;
            item.DestinationTable = txtDestinationTable.Text;
            item.Sequence = Convert.ToInt32(txtSequence.Text);
            item.ModifiedOn = DateTime.Now;
            item.LastModifiedAdministratorAccountId = Convert.ToInt32(Helper.Current.AdministratorAccoundId());
                item.SourceTable = txtSourceTable.Text;
            item.IsActive = chkActive.Checked;
            item.LastModifiedMemberAccountId = null;
            item.ModifiedOn = currentdate;
            item.IsUnique = chkUnique.Checked;
           


            bool succeeded = DAL.ServiceCrmEvolutionDetail.Save(ctx, item);

            return succeeded;
        }
      
        
     

        bool IsValid()
        {
         List<string> messages = new List<string>();

         if (string.IsNullOrEmpty(txtCode.Text)) messages.Add("Field [Code] is required!<br />");
         if (string.IsNullOrEmpty(txtName.Text)) messages.Add("Field [Name] is required!<br />");
         if (string.IsNullOrEmpty(txtSequence.Text)) messages.Add("Field [Sequence] is required!<br />");
         if (string.IsNullOrEmpty(txtCommand.Text)) messages.Add("Field [Command] is required!<br />"); 
         

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
            Response.Redirect("CrmEvolutionServiceDetail.aspx?ServiceId=" + GetServiceId(), true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isSaved = Save();
            if (isSaved)
            {
                Response.Redirect("CrmEvolutionServiceDetail.aspx?ServiceId=" + GetServiceId(), true);
            }
        }
        string GetServiceId()
        {
            return (Request.QueryString["ServiceId"] != null && !string.IsNullOrEmpty(Request.QueryString["ServiceId"])) ? Request.QueryString["ServiceId"].ToString() : null;

        }
    }
}