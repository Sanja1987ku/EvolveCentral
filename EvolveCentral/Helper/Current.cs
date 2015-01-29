using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.Helper
{
    public static  class Current
    {

        public static int? AdministratorAccoundId()
        {
            return (HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTID] != null && !string.IsNullOrEmpty(HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTID].ToString())) ? Convert.ToInt32(HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORACCOUNTID]) : (Int32?)null;
     
        }

        public static string AdministratorRoleCode()
        {
            return (HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLECODE] != null && !string.IsNullOrEmpty(HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLECODE].ToString())) ? HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTADMINISTRATORROLECODE].ToString() : null;

        }


        public static int? MemberAccoundId()
        {
            return (HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTMEMBERACCOUNTID] != null && !string.IsNullOrEmpty(HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTMEMBERACCOUNTID].ToString())) ? Convert.ToInt32(HttpContext.Current.Session[Helper.Constant.CODE_SESSION_CURRENTMEMBERACCOUNTID]) : (Int32?)null;

        }
    
    }
}