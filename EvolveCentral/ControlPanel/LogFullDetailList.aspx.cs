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
    public partial class LogFullDetailList : System.Web.UI.Page
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int serviceid = Convert.ToInt32(Request.QueryString["serviceId"]);
            Response.Redirect("LogDetailList.aspx?serviceid=" + serviceid.ToString());
        }

        protected void eds_Selecting(object sender, EntityDataSourceSelectingEventArgs e)
        {
            string serviceid = Request.QueryString["logid"].ToString();
            eds.WhereParameters.Clear();
            eds.Where = "it.LogId = @LogId";
            eds.WhereParameters.Add(new Parameter("LogId", TypeCode.Int32, serviceid.ToString()));

        }
        protected void rgvData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
        }







        protected void rgvData_ItemCommand(object source, GridCommandEventArgs e)
        {
            string id = null;

            switch (e.CommandName)
            {
                case "View":

                    int serviceid = Convert.ToInt32(Request.QueryString["serviceId"]);
                    int logid = Convert.ToInt32(Request.QueryString["logid"]);
                    id = ((GridDataItem)e.Item)["Id"].Text;
                    Page.Response.Redirect("LogDetailView.aspx?id=" + id + "&serviceId=" + serviceid.ToString() + "&logid=" + logid, true);
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


                if (!Convert.ToBoolean(((DAL.SyncLogCrmEvolutionDetailItem)dataBoundItem.DataItem).IsSuccessful))
                {
                    dataBoundItem.BackColor = Color.PaleVioletRed;


                }

            }

        }
   


        
    }
}