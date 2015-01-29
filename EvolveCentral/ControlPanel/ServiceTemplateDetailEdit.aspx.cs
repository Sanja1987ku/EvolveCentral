using System;
using System.Linq;


namespace EvolveCentral.Administration
{
    public partial class ServiceTemplateDetailEdit : System.Web.UI.Page
    {
        int? id = null;
        int? servicetemplateid = null;

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx"); if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
                id = Convert.ToInt32(Request.QueryString["Id"]);

            if (Request.QueryString["servicetemplateid"] != null && !string.IsNullOrEmpty(Request.QueryString["servicetemplateid"]))
                servicetemplateid = Convert.ToInt32(Request.QueryString["servicetemplateid"]);
         
            if (!IsPostBack)
            {
              
                LoadData();
            }
        }
        bool isAuth()
        {
            //if (Session[Common.Constant.CODE_SESSION_ADMINISTRATORNAME] == null || String.IsNullOrEmpty(Session[Common.Constant.CODE_SESSION_ADMINISTRATORNAME].ToString()))
            //    return false;

            //if (Session[Common.Constant.CODE_SESSION_ADMINISTRATORROLE].ToString().ToUpper() != Common.Constant.CODE_ROLE_ADMINISTRATOR && Session[Common.Constant.CODE_SESSION_ADMINISTRATORROLE].ToString().ToUpper() != Common.Constant.CODE_ROLE_SUPERADMINISTRATOR)
            //    return false;

            return true;

        }
        void LoadData()
        {
            if (id != null)
            {
                txtId.Enabled = false;

                DAL.ServiceTemplateCrmEvolutionDetailItem item = DAL.ServiceTemplateCrmEvolutionDetail.Get(ctx, (Int32)id);
              
              
                txtId.Text = item.Id.ToString();
                txtName.Text = item.Name;
           txtCommand.Text = item.Command;
           txtSequence.Text = item.Sequence.ToString();
                chkActive.Checked = item.IsActive;
                txtCommandType.Text = item.CommandType;
                txtDescription.Text = item.Description;
                txtDestinationTable.Text = item.DestinationTable;
                txtSourceTable.Text = item.SourceTable;
                txtCode.Text = item.Code;
            }
        }

        protected void rgvData_Unload(object sender, EventArgs e)
        {
        }

        bool isValid()
        {
            bool retval = true;

            return retval;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                DAL.ServiceTemplateCrmEvolutionDetailItem item = new DAL.ServiceTemplateCrmEvolutionDetailItem();

             //   item.CreatedBy = DAL.AdministratorAccount.GetCurrentAdministrator(ctx).Id;
              //  item.CreatedOn = DateTime.Now;

                if (id != null)
                    item = DAL.ServiceTemplateCrmEvolutionDetail.Get(ctx, (Int32)id);

                item.IsActive = chkActive.Checked;                   
              
                item.Name = txtName.Text;
                item.Command = txtCommand.Text;
                item.ServiceTemplateCrmEvolutionId = Convert.ToInt32(servicetemplateid);
                item.Sequence = Convert.ToInt32(txtSequence.Text);
           //     item.ModifiedBy = DAL.AdministratorAccount.GetCurrentAdministrator(ctx).Id;
                item.ModifiedOn = DateTime.Now;
                item.CommandType = txtCommandType.Text;
                item.Description = txtDescription.Text;
                item.DestinationTable = txtDestinationTable.Text;
                item.SourceTable = txtSourceTable.Text;
                item.Code = txtCode.Text;



                DAL.ServiceTemplateCrmEvolutionDetail.Save(ctx, item);

                Response.Redirect("ServiceTemplateDetailList.aspx?id=" + servicetemplateid);
            }
            
        }

       
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceTemplateDetailList.aspx?id=" + servicetemplateid);
        }


       

       
    
    }
}