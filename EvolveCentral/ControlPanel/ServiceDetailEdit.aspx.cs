using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.Administration
{
    public partial class ServiceDetailEdit : System.Web.UI.Page
    {
        int? id = null;
        int? serviceid = null;

        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx"); if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
                id = Convert.ToInt32(Request.QueryString["Id"]);

            if (Request.QueryString["serviceid"] != null && !string.IsNullOrEmpty(Request.QueryString["serviceid"]))
                serviceid = Convert.ToInt32(Request.QueryString["serviceid"]);
         
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

           //     DAL.ServiceCrmEvolutionDetailItem item = DAL.ServiceCrmEvolutionDetail.GetByID(ctx, (Int32)id);
              
              
           //     txtId.Text = item.Id.ToString();
           //     txtName.Text = item.Name;
           //txtCommand.Text = item.Command;
           //txtSequence.Text = item.Sequence.ToString();
           //     chkActive.Checked = item.IsActive;
           //     txtCommandType.Text = item.CommandType;
           //     txtDescription.Text = item.Description;
           //     txtDestinationTable.Text = item.DestinationTable;
           //     txtSourceTable.Text = item.SourceTable;
           //     txtCode.Text = item.Code;
           //     chkUnique.Checked = Convert.ToBoolean(item.IsUnique);
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                DAL.ServiceCrmEvolutionDetailItem item = new DAL.ServiceCrmEvolutionDetailItem();

               

                //if (id != null)
                //    item = DAL.ServiceCrmEvolutionDetail.GetByID(ctx, (Int32)id);

                item.IsActive = chkActive.Checked;                   
              
                item.Name = txtName.Text;
                item.Command = txtCommand.Text;
                item.ServiceCrmEvolutionId = serviceid;
                item.Sequence = Convert.ToInt32(txtSequence.Text);                
                item.CommandType = txtCommandType.Text;
                item.Description = txtDescription.Text;
                item.DestinationTable = txtDestinationTable.Text;
                item.SourceTable = txtSourceTable.Text;
                item.Code = txtCode.Text;
                item.IsUnique = chkUnique.Checked;
             


                DAL.ServiceCrmEvolutionDetail.Save(ctx, item);

                Response.Redirect("ServiceDetailList.aspx?id=" + serviceid);
            }
            
        }

       
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ServiceDetailList.aspx?id=" + serviceid);
        }


       

       
    
    }
}