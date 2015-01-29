using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static class ApplicationLog
    {
        public static List<ApplicationLogItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<ApplicationLogItem>();

            try
            {
                items = (from i in ctx.ApplicationLogItems orderby i.CreatedOn descending select i).ToList();
            }
            catch (Exception ex)
            {
                items = null;
            }

            return items;
        }

        public static ApplicationLogItem Get(entitiesEvolveCentral ctx, int itemid)
        {
            var item = new ApplicationLogItem();

            try
            {
                item = (from i in ctx.ApplicationLogItems where i.Id == itemid select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                item = null;
            }

            return item;
        }

        public static bool Save(entitiesEvolveCentral ctx, ApplicationLogItem item)
        {
            bool retval = true;

            try
            {
                if (item.Id == 0) ctx.ApplicationLogItems.Add(item);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                retval = false;
            }

            return retval;
        }

        public static bool Delete(entitiesEvolveCentral ctx, ApplicationLogItem item)
        {
            bool retval = true;

            try
            {
                ctx.ApplicationLogItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                retval = false;
            }

            return retval;
        }

        public static bool Log(entitiesEvolveCentral ctx, string source, string message)
        {

            bool retval = true;

            try
            {
                ApplicationLogItem item = new ApplicationLogItem();
                item.CreatedOn = DateTime.Now;
                item.AdministratorAccountId = null;
                item.MemberAccountId = null;
                item.Message = message;
                item.Source = source;

                retval = Save(ctx, item);
            }
            catch (Exception ex)
            {
                retval = false;
            }

            return retval;


        }
    }
}