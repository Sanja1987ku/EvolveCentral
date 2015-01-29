using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceTemplateDetail : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_ServiceTemplate_View";
        string RequiredPermission_Create = "ServiceManagement_CrmEvolution_ServiceTemplate_Create";
        string RequiredPermission_Edit = "ServiceManagement_CrmEvolution_ServiceTemplate_Edit";
        string RequiredPermission_Delete = "ServiceManagement_CrmEvolution_ServiceTemplate_Delete";

        bool canView = false; 
        bool canCreate = false;     
        bool canEdit = false;
        bool canDelete = false;

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();       

        protected void Page_Load(object sender, EventArgs e)
        {
           
                CheckPermissions();
                if (!IsPostBack)
                {



                    lblTitle.Text += " - " + DAL.ServiceTemplateCrmEvolution.Get(ctx, Convert.ToInt32(GetTemplateId())).Name;
                }
        }

        void CheckPermissions()
        {
          
                canView = (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST] != null && (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_View))) ? true : false;

                if (!canView) Response.Redirect("Login.aspx", true);

                string permissioncodelist = Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString();

                canCreate = (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_Create));
                canEdit = (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_Edit));
                canDelete = (Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORPERMISSIONCODELIST].ToString().Contains(RequiredPermission_Delete));

           
       

        }

        protected void rgvData_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            string id = null;

            switch (e.CommandName)
            {
                case "InitInsert":
                    Response.Redirect("CrmEvolutionServiceTemplateDetailCreate.aspx?TemplateId=" + GetTemplateId(), true);
                    break;
                case "View":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceTemplateDetailView.aspx?TemplateId=" + GetTemplateId() + "&Id=" + id, true);
                    break;
                case "Edit":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceTemplateDetailEdit.aspx?TemplateId=" + GetTemplateId() + "&Id=" + id, true);
                    break;
                  }
        } 

        void DeleteItem(int itemid)
        {

            DAL.ServiceTemplateCrmEvolutionDetailItem item = DAL.ServiceTemplateCrmEvolutionDetail.Get(ctx, itemid);
            bool succeded = DAL.ServiceTemplateCrmEvolutionDetail.Delete(ctx, item);
            rgvData.Rebind(); 
        }

        protected void eds_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            string templateid = GetTemplateId();
            eds.WhereParameters.Clear(); 
            eds.Where = "it.ServiceTemplateCrmEvolutionId= @TemplateId";
            eds.WhereParameters.Add(new Parameter("TemplateId", TypeCode.Int32, templateid));
        }

        protected void rgvData_DataBound(object sender, EventArgs e)
        {
         rgvData.MasterTableView.GetColumn("Delete").Display = canDelete;
         rgvData.MasterTableView.GetColumn("Edit").Display = canEdit;
         rgvData.MasterTableView.CommandItemSettings.ShowAddNewRecordButton = canCreate;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
               

        string id = ((GridDataItem)((LinkButton)sender).Parent.Parent).GetDataKeyValue("Id").ToString();
                DeleteItem(Convert.ToInt32(id));  
              
    
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrmEvolutionServiceTemplate.aspx", true);
        }
        string GetTemplateId()
        {
            return (Request.QueryString["TemplateId"] != null && !string.IsNullOrEmpty(Request.QueryString["TemplateId"])) ? Request.QueryString["TemplateId"].ToString() : null;

        }
      

        }
}