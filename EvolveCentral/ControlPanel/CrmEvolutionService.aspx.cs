using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class CrmEvolutionService : System.Web.UI.Page
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
                    Response.Redirect("CrmEvolutionServiceCreate.aspx", true);
                    break;
                case "View":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceView.aspx?Id=" + id, true);
                    break;
                case "Edit":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceEdit.aspx?Id=" + id, true);
                    break;
                case "Details":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("CrmEvolutionServiceDetail.aspx?ServiceId=" + id, true);
                    break;
                case "Revert":
                    id = ((GridDataItem)e.Item)["Id"].Text;
                    DAL.ServiceCrmEvolution.Revert(ctx, Convert.ToInt32(id));
                    break;
                case "Execute":
                    id = ((GridDataItem)e.Item)["Id"].Text;
                    Helper.Execute.Start(DAL.ServiceCrmEvolution.Get(ctx,Convert.ToInt32(id)).Code);
                    break;
            }
        } 

        void DeleteItem(int itemid)
        {

            DAL.ServiceCrmEvolutionItem item = DAL.ServiceCrmEvolution.Get(ctx, itemid);
            bool succeded = DAL.ServiceCrmEvolution.Delete(ctx, item);
            rgvData.Rebind(); 
        }

        protected void eds_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
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

   
      

        }
}