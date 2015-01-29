using System;
using System.Collections.Generic;
using System.Linq;


namespace EvolveCentral.DAL
{
    public static class MemberAccount
    {

        public static List<MemberAccountItem> GetAll(entitiesEvolveCentral ctx)
        {

            var items = new List<MemberAccountItem>();

            try
            {

                items = (from i in ctx.MemberAccountItems orderby i.FirstName ascending select i).ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.MemberAccount.GetAll(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }

        public static MemberAccountItem Get(entitiesEvolveCentral ctx, int itemid)
        {

            var item = new MemberAccountItem();

            try
            {

                item = (from i in ctx.MemberAccountItems where i.Id == itemid select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.MemberAccount.Get(entitiesEvolveCentral ctx, int itemid)", ex.Message);
                item = null;
            }

            return item;
        }

        public static List<MemberAccountItem> List(entitiesEvolveCentral ctx)
        {

            var items = new List<MemberAccountItem>();

            try
            {
                items = (from i in ctx.MemberAccountItems where i.IsActive == true orderby i.FirstName ascending select i).ToList();
                items.Insert(0, new MemberAccountItem() { Id = 0, FirstName = null });
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.MemberAccount.List(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }




        public static bool Save(entitiesEvolveCentral ctx, MemberAccountItem item)
        {

            bool retval = true;

            try
            {
                if (item.Id == 0) ctx.MemberAccountItems.Add(item);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.MemberAccount.Save(entitiesEvolveCentral ctx, MemberAccountItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }



        public static bool Delete(entitiesEvolveCentral ctx, MemberAccountItem item)
        {

            bool retval = true;

            try
            {
                ctx.MemberAccountItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.MemberAccount.Delete(entitiesEvolveCentral ctx, MemberAccountItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }


    }
}
