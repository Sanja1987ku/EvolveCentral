using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static  class AdministratorRole
    {

        public static List<AdministratorRoleItem> GetAll(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorRoleItem>();

            try
            {

                items = (from i in ctx.AdministratorRoleItems orderby i.Name ascending select i).ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.GetAll(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }

        public static AdministratorRoleItem Get(entitiesEvolveCentral ctx, int itemid)
        {

            var item = new AdministratorRoleItem();

            try
            {

                item = (from i in ctx.AdministratorRoleItems where i.Id == itemid select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.Get(entitiesEvolveCentral ctx, int itemid)", ex.Message);
                item = null;
            }

            return item;
        }

        public static List<AdministratorRoleItem> List(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorRoleItem>();

            try
            {
                items = (from i in ctx.AdministratorRoleItems where i.IsActive == true orderby i.Name ascending select i).ToList();
                items.Insert(0, new AdministratorRoleItem() { Id = 0, Name = null });
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.List(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }

        public static List<AdministratorRoleItem> ListSelectable(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorRoleItem>();

            try
            {
                items = (from i in ctx.AdministratorRoleItems where i.IsActive == true && i.IsDeletable == true orderby i.Name ascending select i).ToList();
                items.Insert(0, new AdministratorRoleItem() { Id = 0, Name = null });
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.List(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }


        public static List<AdministratorPermissionItem> GetPermissions(entitiesEvolveCentral ctx, int itemid)
        {

            var items = new List<AdministratorPermissionItem>();

            try
            {

                var roleitem = (from i in ctx.AdministratorRoleItems where i.Id == itemid select i).FirstOrDefault();
                if (roleitem != null) items = roleitem.AdministratorPermissionItems.ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.GetPermissions(entitiesEvolveCentral ctx, int itemid)", ex.Message);
                items = null;
            }

            return items;
        }

        public static bool Save(entitiesEvolveCentral ctx, AdministratorRoleItem item)
        {

            bool retval = true;

            try
            {
                if (item.Id == 0) ctx.AdministratorRoleItems.Add(item);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.Save(entitiesEvolveCentral ctx, AdministratorRoleItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }

        public static bool AddPermissions(entitiesEvolveCentral ctx, AdministratorRoleItem item, List<int> permission_ids)
        {

            bool retval = true;

            try
            {
                foreach (int i in permission_ids)
                {
                    DAL.AdministratorPermissionItem pitem = DAL.AdministratorPermission.Get(ctx, i);
                    item.AdministratorPermissionItems.Add(pitem);
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AddPermissions(entitiesEvolveCentral ctx, AdministratorRoleItem item,List<DAL.AdministratorPermissionItem> permissions)", ex.Message);
                retval = false;
            }

            return retval;
        }


        public static bool Delete(entitiesEvolveCentral ctx, AdministratorRoleItem item)
        {

            bool retval = true;

            try
            {
                ctx.AdministratorRoleItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.Delete(entitiesEvolveCentral ctx, AdministratorRoleItem item)", ex.Message);
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
                DAL.AdministratorRoleItem item = (from i in ctx.AdministratorRoleItems where i.Code.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.IsCodeAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
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
                DAL.AdministratorRoleItem item = (from i in ctx.AdministratorRoleItems where i.Name.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.AdministratorRole.IsNameAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval; ;
        }

        public static bool RemoveAllPermissions(entitiesEvolveCentral ctx, AdministratorRoleItem item)
        {

            bool retval = true;

            try
            {
                item.AdministratorPermissionItems.Clear();
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.RemoveAllPermissions(entitiesEvolveCentral ctx, AdministratorRoleItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }
    }
}