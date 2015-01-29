using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public class AdministratorAccount
    {
        public static List<AdministratorAccountItem> GetAll(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorAccountItem>();

            try
            {

                items = (from i in ctx.AdministratorAccountItems orderby i.FirstName ascending, i.LastName ascending select i).ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.GetAll(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }

        public static AdministratorAccountItem Get(entitiesEvolveCentral ctx, int itemid)
        {

            var item = new AdministratorAccountItem();

            try
            {

                item = (from i in ctx.AdministratorAccountItems where i.Id == itemid select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.Get(entitiesEvolveCentral ctx, int itemid)", ex.Message);
                item = null;
            }

            return item;
        }

        public static List<AdministratorAccountItem> List(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorAccountItem>();

            try
            {
                items = (from i in ctx.AdministratorAccountItems where i.IsActive == true orderby i.FirstName ascending, i.LastName ascending select new AdministratorAccountItem() { Id = i.Id, Email = i.FirstName + " " + i.LastName + " (" + i.Email + ")" }).ToList();
                items.Insert(0, new AdministratorAccountItem() { Id = 0, Email = null });
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.List(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }

        public static bool Save(entitiesEvolveCentral ctx, AdministratorAccountItem item)
        {

            bool retval = true;

            try
            {
                if (item.Id == 0) ctx.AdministratorAccountItems.Add(item);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.Save(entitiesEvolveCentral ctx, AdministratorAccountItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }

        public static bool Delete(entitiesEvolveCentral ctx, AdministratorAccountItem item)
        {

            bool retval = true;

            try
            {
                ctx.AdministratorAccountItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.Delete(entitiesEvolveCentral ctx, AdministratorAccountItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }

        public static AdministratorAccountItem Login(entitiesEvolveCentral ctx, string email, string password)
        {
            var item = new AdministratorAccountItem();

            try
            {
                item = (from i in ctx.AdministratorAccountItems where i.Email == email && i.Password == password select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.Login(entitiesEvolveCentral ctx, string email,string password)", ex.Message);
                item = null;
            }

            return item;
        }

        public static AdministratorAccountItem GetByEmail(entitiesEvolveCentral ctx, string value)
        {

            var item = new AdministratorAccountItem();

            try
            {

                item = (from i in ctx.AdministratorAccountItems where i.Email == value select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.GetByEmail(entitiesEvolveCentral ctx, string value)", ex.Message);
                item = null;
            }

            return item;
        }

        public static bool IsEmailAvailable(entitiesEvolveCentral ctx, string value)
        {
            return IsEmailAvailable(ctx, value, null);
        }

        public static bool IsEmailAvailable(entitiesEvolveCentral ctx, string value, int? id)
        {

            bool retval = true;

            try
            {
                DAL.AdministratorAccountItem item = (from i in ctx.AdministratorAccountItems where i.Email.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.AdministratorAccount.IsEmailAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval;
        }

    }
}