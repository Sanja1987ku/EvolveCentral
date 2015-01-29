using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EvolveCentral.Helper
{
    public static class Validation
    {

        public static bool isDecimal(string value)
        {
            try
            {
                decimal d = Convert.ToDecimal(value);
                return true;
            }
            catch { return false; }
          
        }

        public static bool isDouble(string value)
        {
            try
            {
                double d = Convert.ToDouble(value);
                return true;
            }
            catch { return false; }

        }

        public static bool isInteger(string value)
        {
            try
            {
                Int32 i = Convert.ToInt32(value);
                return true;
            }
            catch { return false; }

        }

        public static bool IsEmail(string value)
        {            
            string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
          + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
          + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
          + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            
            return Regex.IsMatch(value, pattern);
          
        }
  
    }
}