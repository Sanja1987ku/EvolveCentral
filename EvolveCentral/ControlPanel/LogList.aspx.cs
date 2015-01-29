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
    public partial class LogList : System.Web.UI.Page
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
            string serviceid = null;

            switch (e.CommandName)
            {
                case "Details":


                    serviceid = ((GridDataItem)e.Item)["Id"].Text;
                    Page.Response.Redirect("LogDetailList.aspx?serviceid=" + serviceid + "&returnurl=" + Page.Request.Url, true);
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

             
                    if (!Convert.ToBoolean(((DAL.ServiceCrmEvolutionItem)dataBoundItem.DataItem).LastSyncSuccessful))
                    {
                        dataBoundItem.BackColor = Color.PaleVioletRed;


                    }
             
            }

        }


        
    }
}