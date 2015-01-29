using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using Telerik.Web.UI;
namespace EvolveCentral.Administration
{
    public partial class ServiceTemplateDetailList : System.Web.UI.Page
    {
        int? serviceid = null; 
        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx");

            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
                serviceid = Convert.ToInt32(Request.QueryString["Id"]);
          
        }

        bool isAuth()
        {
            //if (Session[Common.Constant.CODE_SESSION_ADMINISTRATORNAME] == null || String.IsNullOrEmpty(Session[Common.Constant.CODE_SESSION_ADMINISTRATORNAME].ToString()))
            //    return false;

            //if (Session[Common.Constant.CODE_SESSION_ADMINISTRATORROLE].ToString().ToUpper() != Common.Constant.CODE_ROLE_ADMINISTRATOR && Session[Common.Constant.CODE_SESSION_ADMINISTRATORROLE].ToString().ToUpper() != Common.Constant.CODE_ROLE_SUPERADMINISTRATOR)
            //    return false;

            return true;
        }   

        protected void rgvData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {            
            rgvData.DataSource = DAL.ServiceTemplateCrmEvolutionDetail.GetByService(ctx,Convert.ToInt32(serviceid));
        }

        protected void rgvData_ItemCommand(object source, GridCommandEventArgs e)
        {
            string id = null;

            switch (e.CommandName)
            {
                case "Edit":

                    id = ((GridDataItem)e.Item)["Id"].Text;
                    Page.Response.Redirect("ServiceTemplateDetailEdit.aspx?Id=" + id + "&servicetemplateid=" + serviceid + "&returnurl=ServiceTemplateDetailList.aspx", true);
                    break;

                case "InitInsert":
                    Page.Response.Redirect("ServiceTemplateDetailEdit.aspx?servicetemplateid=" + serviceid + "&returnurl=ServiceTemplateDetailList.aspx", true);
                    break;
                case "Delete":
                    id = ((GridDataItem)e.Item)["Id"].Text;
                    //DAL.ServiceTemplateCrmEvolutionDetail.Delete(ctx, Convert.ToInt32(id));
                    break;
                case "Publish":



                    id = ((GridDataItem)e.Item)["Id"].Text;
                    DAL.ServiceTemplateCrmEvolutionDetail.Publish(ctx, Convert.ToInt32(id));
                    rgvData.DataSource = DAL.ServiceTemplateCrmEvolutionDetail.GetByService(ctx, Convert.ToInt32(serviceid));
                    rgvData.Rebind();
                    break;
                
                default:

                    break;
            }
           
            rgvData.DataSource = null;
        }        
    }
}