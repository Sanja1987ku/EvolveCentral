using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
namespace EvolveCentral.Administration
{
    public partial class ServiceDetailList : System.Web.UI.Page
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
        void LoadData()
        {

        }

        protected void rgvData_Unload(object sender, EventArgs e)
        {

        }


        protected void rgvData_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            
            rgvData.DataSource = DAL.ServiceCrmEvolutionDetail.GetByService(ctx,Convert.ToInt32(serviceid));
        }







        protected void rgvData_ItemCommand(object source, GridCommandEventArgs e)
        {
            string id = null;
           

           

            //switch (e.CommandName)
            //{
            //    case "Edit":

            //        id = ((GridDataItem)e.Item)["Id"].Text;
            //        Page.Response.Redirect("ServiceDetailEdit.aspx?Id=" + id + "&serviceid=" + serviceid + "&returnurl=ServiceDetailList.aspx", true);
            //        break;

            //    case "InitInsert":

            //        Page.Response.Redirect("ServiceDetailEdit.aspx?serviceid=" + serviceid + "&returnurl=ServiceDetailList.aspx", true);
            //        break;
            //    case "Delete":



            //        id = ((GridDataItem)e.Item)["Id"].Text;
            //        DAL.ServiceCrmEvolutionDetail.Delete(ctx, Convert.ToInt32(id));

            //        break;
            //    case "Revert":



            //        id = ((GridDataItem)e.Item)["Id"].Text;
            //        DAL.ServiceCrmEvolutionDetail.Revert(ctx, Convert.ToInt32(id));
            //        rgvData.DataSource = DAL.ServiceCrmEvolutionDetail.GetByService(ctx, Convert.ToInt32(serviceid));
            //        rgvData.Rebind();
            //        break;
                
            //    case "Execute":



            //        id = ((GridDataItem)e.Item)["Id"].Text;
            //        DAL.ServiceCrmEvolutionDetailItem i = DAL.ServiceCrmEvolutionDetail.GetByID(ctx, Convert.ToInt32(id));
 
            //        string command = i.Command;
            //        command = command.Replace("[sourceDataBase]", "[" + i.ServiceCrmEvolutionItem.DatabaseName_Source + "]");
            //        command = command.Replace("[destinationDataBase]", "[" + i.ServiceCrmEvolutionItem.DatabaseName_Destination + "]");


            //        try
            //        {
            //            string connstring = null;
            //            connstring = "Server=[@DATABASESERVER];User Id=[@DATABASEUSERNAME];Password=[@DATABASEPASSWORD];DataBase=[@DATABASENAME];";
            //            connstring = connstring.Replace("[@DATABASESERVER]", i.ServiceCrmEvolutionItem.Connection_DatabaseServer);
            //            connstring = connstring.Replace("[@DATABASEUSERNAME]", i.ServiceCrmEvolutionItem.Connection_DatabaseUserName);
            //            connstring = connstring.Replace("[@DATABASEPASSWORD]", i.ServiceCrmEvolutionItem.Connection_DatabasePassword);
            //            connstring = connstring.Replace("[@DATABASENAME]", i.ServiceCrmEvolutionItem.Connection_DatabaseName);
       
            //            using (SqlConnection sqlconn = new SqlConnection(connstring))
            //        {
            //            sqlconn.Open();
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = sqlconn;
                        
            //            cmd.CommandType = CommandType.Text;

            //            cmd.CommandTimeout = 0;
            //            if (!string.IsNullOrEmpty(command))
            //            {
            //                cmd.CommandText = command;
            //                cmd.ExecuteNonQuery();
                         
            //            }
            //        }
            //        RadWindowManager1.RadAlert("Execution of the sql command was successful!", 100, 50, "MESSAGE", null);
            //                     }
            //                     catch (Exception ex)
            //                     {
            //                         RadWindowManager1.RadAlert("Execution of the sql command has been failed!<br /> " + ex.Message, 100, 50, "MESSAGE", null);
                
            //                     }


            //        break;
            //    default:

            //        break;
        //    }
        //    rgvData.DataSource = null;
        }

        protected void rgvData_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {

                GridDataItem dataBoundItem = e.Item as GridDataItem;


                if (Convert.ToBoolean(((DAL.ServiceCrmEvolutionDetailItem)dataBoundItem.DataItem).IsUnique))
                {
                    dataBoundItem.BackColor = Color.PaleGreen;


                }

            }

        }
        
    }
}