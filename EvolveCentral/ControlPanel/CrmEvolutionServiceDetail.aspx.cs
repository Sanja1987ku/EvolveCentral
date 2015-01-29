using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionServiceDetail : System.Web.UI.Page
    {
        string RequiredPermission_View = "ServiceManagement_CrmEvolution_Service_View";
        string RequiredPermission_Create = "ServiceManagement_CrmEvolution_Service_Create";
        string RequiredPermission_Edit = "ServiceManagement_CrmEvolution_Service_Edit";
        string RequiredPermission_Delete = "ServiceManagement_CrmEvolution_Service_Delete";

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



                    lblTitle.Text += " - " + DAL.ServiceCrmEvolution.Get(ctx, Convert.ToInt32(GetServiceId())).Name;
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
                    Response.Redirect("CrmEvolutionServiceDetailCreate.aspx?ServiceId=" + GetServiceId(), true);
                    break;
                case "View":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceDetailView.aspx?ServiceId=" + GetServiceId() + "&Id=" + id, true);
                    break;
                case "Edit":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceDetailEdit.aspx?ServiceId=" + GetServiceId() + "&Id=" + id, true);
                    break;
                  }
        } 

        void DeleteItem(int itemid)
        {

            DAL.ServiceCrmEvolutionDetailItem item = DAL.ServiceCrmEvolutionDetail.Get(ctx, itemid);
            bool succeded = DAL.ServiceCrmEvolutionDetail.Delete(ctx, item);
            rgvData.Rebind(); 
        }

        protected void eds_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            string serviceid = GetServiceId();
            eds.WhereParameters.Clear();
            eds.Where = "it.ServiceCrmEvolutionId= @ServiceId";
            eds.WhereParameters.Add(new Parameter("ServiceId", TypeCode.Int32, serviceid));
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
            Response.Redirect("CrmEvolutionService.aspx", true);
        }
        string GetServiceId()
        {
            return (Request.QueryString["ServiceId"] != null && !string.IsNullOrEmpty(Request.QueryString["ServiceId"])) ? Request.QueryString["ServiceId"].ToString() : null;

        }
      

        }
}