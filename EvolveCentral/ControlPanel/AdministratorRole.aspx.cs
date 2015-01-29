using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.ControlPanel
{
    public partial class AdministratorRole : System.Web.UI.Page
    {
        string RequiredPermission_View = "UserManagement_AdministratorRole_View";
        string RequiredPermission_Create = "UserManagement_AdministratorRole_Create";
        string RequiredPermission_Edit = "UserManagement_AdministratorRole_Edit";
        string RequiredPermission_Delete = "UserManagement_AdministratorRole_Delete";

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
                    Response.Redirect("AdministratorRoleCreate.aspx", true);
                    break;
                case "View":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("AdministratorRoleView.aspx?Id=" + id, true);
                    break;
                case "Edit":
                    id = ((e.Item as GridDataItem)).GetDataKeyValue("Id").ToString();
                    Response.Redirect("AdministratorRoleEdit.aspx?Id=" + id, true);
                    break;
            }
        }

        void DeleteItem(int itemid)
        {
            DAL.AdministratorRoleItem item = DAL.AdministratorRole.Get(ctx, itemid);
            bool succeded = DAL.AdministratorRole.Delete(ctx, item);
            rgvData.Rebind();
        }

        protected void rgvData_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {

                GridDataItem ditem = e.Item as GridDataItem;
                DAL.AdministratorRoleItem item = ((DAL.AdministratorRoleItem)ditem.DataItem);
                if (item.Code == Helper.Constant.CODE_ROLE_DEVELOPER)
                {
                    if (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER )
                    {
                        ditem.Display = false;
                    }
                }

                if (item.Code == Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR)
                {
                    if (Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_DEVELOPER && Helper.Current.AdministratorRoleCode() != Helper.Constant.CODE_ROLE_SUPERADMINISTRATOR)
                    {
                        ditem.Display = false;
                    }
                }
            }
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