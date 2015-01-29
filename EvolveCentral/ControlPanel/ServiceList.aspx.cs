using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace EvolveCentral.Administration
{
    public partial class ServiceList : System.Web.UI.Page
    {
        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx");
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

        }

        protected void rgvData_Unload(object sender, EventArgs e)
        {

        }


        protected void rgvData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgvData.DataSource = DAL.ServiceCrmEvolution.GetAll(ctx);
        }







        protected void rgvData_ItemCommand(object source, GridCommandEventArgs e)
        {
            string id = null;

            switch (e.CommandName)
            {
                case "Edit":

                    id = ((GridDataItem)e.Item)["Id"].Text;
                    Page.Response.Redirect("ServiceEdit.aspx?Id=" + id + "&returnurl=" + Page.Request.Url, true);
                    break;

                case "InitInsert":

                    Page.Response.Redirect("ServiceEdit.aspx?returnurl=" + Page.Request.Url, true);
                    break;
                case "Delete":



                    id = ((GridDataItem)e.Item)["Id"].Text;
                    DAL.ServiceCrmEvolutionDetail.DeleteByService(ctx, Convert.ToInt32(id),true);
                    DAL.SyncLogCrmEvolution.DeleteByService(ctx, Convert.ToInt32(id));
                    //   DAL.ServiceCrmEvolution.Delete(ctx, Convert.ToInt32(id));

                    break;
                case "Revert":



                    id = ((GridDataItem)e.Item)["Id"].Text;
                    DAL.ServiceCrmEvolution.Revert(ctx, Convert.ToInt32(id));

                    break;

                case "Details":


                    id = ((GridDataItem)e.Item)["Id"].Text;
                    Page.Response.Redirect("ServiceDetailList.aspx?id=" + id + "&returnurl=" + Page.Request.Url, true);
                    break;
                default:

                    break;
            }
            rgvData.DataSource = null;
        }


        
    }
}