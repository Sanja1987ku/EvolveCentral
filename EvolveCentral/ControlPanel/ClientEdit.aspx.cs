using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace EvolveCentral.Administration
{
    public partial class ClientEdit : System.Web.UI.Page
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
            //if (id != null)
            //{
            //    txtId.Enabled = false; 
                
            //    DAL.CompanyItem item = DAL.Company.GetByID(ctx, (Int32)id);
              
            //    txtCode.Text = item.Code;
            //    txtId.Text = item.Id.ToString();
            //    txtName.Text = item.Name;
            //    txtContact.Text = item.Contact;
            //    chkActive.Checked = item.Active;
            //}
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
                DAL.CompanyItem item = new DAL.CompanyItem();
                
                //if (id != null)
                //    item = DAL.Company.GetByID(ctx, (Int32)id);

                item.Active = chkActive.Checked;                   
                item.Code = txtCode.Text;
                item.Name = txtName.Text;
                item.Contact = txtContact.Text;
                            
                DAL.Company.Save(ctx, item);

                Response.Redirect(Request.QueryString["returnurl"]);
            }
            
        }

       
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.QueryString["returnurl"]);
        }

     
    }
}