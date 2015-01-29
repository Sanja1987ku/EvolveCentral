using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.Common
{
  
        public static class Constant
        {
  

            public static string CODE_SESSION_USERID = "UserID";
            public static string CODE_SESSION_USERNAME = "UserName";
            
            public static string CODE_SESSION_ADMINISTRATORID = "UserID";
            public static string CODE_SESSION_ADMINISTRATORNAME = "UserName";
            public static string CODE_SESSION_ADMINISTRATORROLE = "RoleName";

            public static string CODE_ROLE_SUPERADMINISTRATOR = "SUPERADMINISTRATOR";
            public static string CODE_ROLE_ADMINISTRATOR = "ADMINISTRATOR";
            public static string CODE_ROLE_USER = "USER";
        }

        public static class Validation2
        {
            public static string CODE_STATUS_PENDING = "PENDING";
            public static string CODE_STATUS_SUBMITTED = "SUBMITTED";
            public static string CODE_STATUS_APPROVED = "APPROVED";

        }


        public static class Validation
        {
            public static bool isDouble(string value)
            {
                try
                {
                    double d = Convert.ToDouble(value);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }


            }





        }
 
}