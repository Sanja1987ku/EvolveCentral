using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static  class Company
    {
        public static List<CompanyItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<CompanyItem>();
            items = (from i in ctx.CompanyItems orderby i.Name ascending select i).ToList();
            return items;
        }
        public static List<CompanyItem> List(entitiesEvolveCentral ctx)
        {

            var items = new List<CompanyItem>();

            try
            {
                items = (from i in ctx.CompanyItems where i.Active == true orderby i.Name ascending select i).ToList();
                items.Insert(0, new CompanyItem() { Id = 0, Name = null });
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.Company.List(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }
        public static CompanyItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new CompanyItem();
            item = (from i in ctx.CompanyItems where i.Id == id orderby i.Name ascending select i).FirstOrDefault();
            return item;
        }

        public static bool Save(entitiesEvolveCentral ctx, CompanyItem item)
        {         
            try
            {
                if (item.Id == 0)
                {
                    ctx.CompanyItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

        public static bool Delete(entitiesEvolveCentral ctx, CompanyItem item)
        {

            bool retval = true;

            try
            {
                ctx.CompanyItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.Company.Delete(entitiesEvolveCentral ctx, CompanyItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }
        public static bool IsCodeAvailable(entitiesEvolveCentral ctx, string value)
        {
            return IsCodeAvailable(ctx, value, null);
        }

        public static bool IsCodeAvailable(entitiesEvolveCentral ctx, string value, int? id)
        {

            bool retval = true;

            try
            {
                DAL.CompanyItem item = (from i in ctx.CompanyItems where i.Code.ToUpper() == value.ToUpper() select i).FirstOrDefault();
                if (item != null)
                {
                    if (id == null) retval = false;

                    if (id != null && item.Id != id)
                    {
                        retval = false;
                    }
                }

            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.Company.IsCodeAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval; ;
        }

        public static bool IsNameAvailable(entitiesEvolveCentral ctx, string value)
        {
            return IsNameAvailable(ctx, value, null);
        }

        public static bool IsNameAvailable(entitiesEvolveCentral ctx, string value, int? id)
        {

            bool retval = true;

            try
            {
                DAL.CompanyItem item = (from i in ctx.CompanyItems where i.Name.ToUpper() == value.ToUpper() select i).FirstOrDefault();
                if (item != null)
                {
                    if (id == null) retval = false;

                    if (id != null && item.Id != id)
                    {
                        retval = false;
                    }
                }

            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.Company.IsNameAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval; ;
        }
    }
}