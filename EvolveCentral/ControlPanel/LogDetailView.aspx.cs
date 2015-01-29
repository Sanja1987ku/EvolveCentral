using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.Administration
{
    public partial class LogDetailView : System.Web.UI.Page
    {
        int? id = null;
        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx"); if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
                id = Convert.ToInt32(Request.QueryString["Id"]);
            
            if (!IsPostBack)
            {
                LoadData();
            }
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
            if (id != null)
            {
                txtId.Enabled = false;

                //DAL.SyncLogCrmEvolutionDetailItem item = DAL.SyncLogCrmEvolutionDetail.GetById(ctx, (Int32)id);
              
              
                //txtId.Text = item.Id.ToString();
                //txtName.Text = item.Name;
                //chkExecutedWithoutErrors.Checked = Convert.ToBoolean(item.IsSuccessful);
                //txtDate.Text = item.CreateDate.ToString();
                //txtErrorMessage.Text = item.ErrorMessage;
                //txtCommand.Text = item.ExecutedCommand;
               
             
            }
        }

        protected void rgvData_Unload(object sender, EventArgs e)
        {
        }

        bool isValid()
        {
            bool retval = true;

            return retval;
        }

     

       
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int serviceid = Convert.ToInt32(Request.QueryString["serviceId"]);
            int logid = Convert.ToInt32(Request.QueryString["logid"]);
            Response.Redirect("LogFullDetailList.aspx?serviceid=" + serviceid.ToString() + "&logid=" + logid.ToString());
        }

     
    }
}