using System;
using System.Linq;


namespace EvolveCentral.Administration
{
    public partial class ServiceTemplateEdit : System.Web.UI.Page
    {
        int? id = null;
        DAL.entitiesEvolveCentral ctx = new DAL.entitiesEvolveCentral();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAuth()) Response.Redirect("~//Administration/Login.aspx"); 
            if (Request.QueryString["Id"] != null && !string.IsNullOrEmpty(Request.QueryString["Id"]))
                id = Convert.ToInt32(Request.QueryString["Id"]);
            
            if (!IsPostBack)
            {
                FillServiceTypes();            
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

                //DAL.ServiceTemplateCrmEvolutionItem item = DAL.ServiceTemplateCrmEvolution.GetByID(ctx, (Int32)id);              
                //txtId.Text = item.Id.ToString();
                //txtName.Text = item.Name;             
                //txtDescription.Text = item.Description;                
                //rcbServiceType.SelectedValue = item.ServiceTypeId.ToString();
                //txtCode.Text = item.Code;
                //chkActive.Checked = item.IsActive;
             
            }
        }

        bool isValid()
        {
            bool retval = true;
            return retval;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (isValid())
            //{
            //    DAL.ServiceTemplateCrmEvolutionItem item = new DAL.ServiceTemplateCrmEvolutionItem();            

            //    if (id != null)
            //        item = DAL.ServiceTemplateCrmEvolution.GetByID(ctx, (Int32)id);

            //    item.IsActive = chkActive.Checked;              
            //    item.Name = txtName.Text;
            //    item.Code = txtCode.Text;              
            //    item.Description = txtDescription.Text;
            //     item.ServiceTypeId = Convert.ToInt32(rcbServiceType.SelectedValue);           
            //    DAL.ServiceTemplateCrmEvolution.Save(ctx, item);
              
            //    Response.Redirect(Request.QueryString["returnurl"]);
            //}
            
        }

       
    
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.QueryString["returnurl"]);
        }


        void FillServiceTypes()
        {
            rcbServiceType.DataSource = DAL.ServiceType.GetAll(ctx);
            rcbServiceType.DataValueField = "Id";
            rcbServiceType.DataTextField = "Name";
            rcbServiceType.DataBind();
        }

      
    
    }
}