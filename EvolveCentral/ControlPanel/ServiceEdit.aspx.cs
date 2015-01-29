using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.Administration
{
    public partial class ServiceEdit : System.Web.UI.Page
    {
        int? id = null;
        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx"); 
            
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
                id = Convert.ToInt32(Request.QueryString["Id"]);
            
            if (!IsPostBack)
            {
                FillServiceTemplates();
                FillClients();
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

                //DAL.ServiceCrmEvolutionItem item = DAL.ServiceCrmEvolution.GetByID(ctx, (Int32)id);
              
              
                //txtId.Text = item.Id.ToString();
                //txtName.Text = item.Name;
                //txtCode.Text = item.Code;
                //txtDataBaseName.Text = item.Connection_DatabaseName;
                //txtDatabasePassword.Text = item.Connection_DatabasePassword;
                //txtDatabaseServer.Text = item.Connection_DatabaseServer;
                //txtDatabaseUsername.Text = item.Connection_DatabaseUserName;
                //txtDestinationDatabaseName.Text = item.DatabaseName_Destination;
                //txtSourceDatabaseName.Text = item.DatabaseName_Source;
                //rcbServiceTemplate.SelectedValue = item.ServiceTemplateCrmEvolutionId.ToString();
                //txtDescription.Text = item.Description;
                //rcbClient.SelectedValue = item.CompanyId.ToString();
          
                //chkActive.Checked = item.IsActive;

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
            //if (isValid())
            //{
            //    DAL.ServiceCrmEvolutionItem item = new DAL.ServiceCrmEvolutionItem();

       

            //    if (id != null)
            //        item = DAL.ServiceCrmEvolution.GetByID(ctx, (Int32)id);

            //    item.IsActive = chkActive.Checked;
            //    item.Code = txtCode.Text;
            //    item.Name = txtName.Text;
            //    item.CompanyId = Convert.ToInt32(rcbClient.SelectedValue);            
            //    item.Description = txtDescription.Text;
            //    item.Connection_DatabaseName = txtDataBaseName.Text;
            //    item.Connection_DatabasePassword = txtDatabasePassword.Text;
            //    item.Connection_DatabaseServer = txtDatabaseServer.Text;
            //    item.Connection_DatabaseUserName = txtDatabaseUsername.Text;
            //    item.DatabaseName_Destination = txtDestinationDatabaseName.Text;
            //    item.DatabaseName_Source = txtSourceDatabaseName.Text;              
            //    item.ServiceTemplateCrmEvolutionId = Convert.ToInt32(rcbServiceTemplate.SelectedValue);
           
            //    DAL.ServiceCrmEvolution.Save(ctx, item);

            //    if (id == null)
            //    {
            //       string servicetypecode = DAL.ServiceTemplateCrmEvolution.GetByID(ctx, Convert.ToInt32(item.ServiceTemplateCrmEvolutionId)).ServiceTypeItem.Code;
            //        if (servicetypecode == "CRM_EVOLUTION")
            //        {

            //            DAL.ServiceTemplateCrmEvolutionItem servicetemplate = DAL.ServiceTemplateCrmEvolution.GetByID(ctx, Convert.ToInt32(item.ServiceTemplateCrmEvolutionId));

            //            List<DAL.ServiceTemplateCrmEvolutionDetailItem> servicetemplateitems = servicetemplate.ServiceTemplateCrmEvolutionDetailItems.ToList();

            //            int cuserid = 1; // DAL.AdministratorAccount.GetCurrentAdministrator(ctx).Id;
            //            DateTime cdate =   DateTime.Now;
                        
            //            foreach (DAL.ServiceTemplateCrmEvolutionDetailItem i in servicetemplateitems)
            //           {
            //               DAL.ServiceCrmEvolutionDetailItem sitem = new DAL.ServiceCrmEvolutionDetailItem();
            //               sitem.IsActive = i.IsActive;
            //               sitem.Code = i.Code;
            //               sitem.Command = i.Command;
            //               sitem.IsUnique = false;
            //               sitem.CommandType = i.CommandType;
                          
            //               sitem.Description = i.Description;
            //               sitem.DestinationTable = i.DestinationTable;
                           
            //               sitem.Name = i.Name;
            //               sitem.Sequence = i.Sequence;
            //               sitem.ServiceCrmEvolutionId = item.Id;
            //               sitem.SourceTable = i.SourceTable;
            //               DAL.ServiceCrmEvolutionDetail.Save(ctx, sitem);


            //           }
            //        }
            //    }

            //    Response.Redirect(Request.QueryString["returnurl"]);
            //}
            
        }

       
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.QueryString["returnurl"]);
        }


        void FillServiceTemplates()
        {
            rcbServiceTemplate.DataSource = DAL.ServiceTemplateCrmEvolution.GetAll(ctx);
            rcbServiceTemplate.DataValueField = "Id";
            rcbServiceTemplate.DataTextField = "Name";
            rcbServiceTemplate.DataBind();

        }

        void FillClients()
        {
            rcbClient.DataSource = DAL.Company.GetAll(ctx);
            rcbClient.DataValueField = "Id";
            rcbClient.DataTextField = "Name";
            rcbClient.DataBind();

        }
    
    }
}