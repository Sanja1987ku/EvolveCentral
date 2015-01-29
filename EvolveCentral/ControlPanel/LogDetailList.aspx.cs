using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace EvolveCentral.Administration
{
    public partial class LogDetailList : System.Web.UI.Page
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

        protected void eds_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            string serviceid = Request.QueryString["serviceid"].ToString();
            eds.WhereParameters.Clear();
            eds.Where = "it.ServiceId = @ServiceId";
            eds.WhereParameters.Add(new Parameter("ServiceId", TypeCode.Int32, serviceid.ToString()));
              
        }
        protected void rgvData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
          //  int serviceid = Convert.ToInt32(Request.QueryString["serviceId"]);
          //  rgvData.DataSource = DAL.Log.GetByService(ctx,serviceid);
        }







        protected void rgvData_ItemCommand(object source, GridCommandEventArgs e)
        {
            string logid = null;

            switch (e.CommandName)
            {
                case "Detail":

                         int serviceid = Convert.ToInt32(Request.QueryString["serviceId"]);
                    logid = ((GridDataItem)e.Item)["Id"].Text;
                    Page.Response.Redirect("LogFullDetailList.aspx?logid=" + logid + "&serviceid=" + serviceid.ToString() , true);
                    break;
               
                default:

                    break;
            }
            rgvData.DataSource = null;
        }

        protected void rgvData_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
               
                GridDataItem dataBoundItem = e.Item as GridDataItem;

             
                    if (!Convert.ToBoolean(((DAL.SyncLogCrmEvolutionItem)dataBoundItem.DataItem).IsSuccessful))
                    {
                        dataBoundItem.BackColor = Color.PaleVioletRed;


                    }
             
            }

        }
      


        
    }
}