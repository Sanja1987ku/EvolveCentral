using System;
using System.Collections.Generic;
using System.Linq;


namespace EvolveCentral.DAL
{
    public static class AdministratorPermission
    {

        public static List<AdministratorPermissionItem> GetAll(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorPermissionItem>();

            try
            {

                items = (from i in ctx.AdministratorPermissionItems orderby i.Name ascending select i).ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorPermission.GetAll(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }
        public static List<AdministratorPermissionItem> GetSelectable(entitiesEvolveCentral ctx)
        {

            var items = new List<AdministratorPermissionItem>();

            try
            {

                items = (from i in ctx.AdministratorPermissionItems where i.IsSelectable == true orderby i.Name ascending select i).ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.GetSelectable(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }

        public static AdministratorPermissionItem Get(entitiesEvolveCentral ctx, int itemid)
        {

            var item = new AdministratorPermissionItem();

            try
            {

                item = (from i in ctx.AdministratorPermissionItems where i.Id == itemid select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorPermission.Get(entitiesEvolveCentral ctx, int itemid)", ex.Message);
                item = null;
            }

            return item;
        }

        public static List<AdministratorPermissionItem> GetByRole(entitiesEvolveCentral ctx, int roleid)
        {

            var items = new List<AdministratorPermissionItem>();

            try
            {
                AdministratorRoleItem item_role = AdministratorRole.Get(ctx, roleid);
                if (item_role != null) items = item_role.AdministratorPermissionItems.ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorPermission.GetByRole(entitiesEvolveCentral ctx, int roleid)", ex.Message);
                items = null;
            }

            return items;
        }

        public static bool Save(entitiesEvolveCentral ctx, AdministratorPermissionItem item)
        {

            bool retval = true;

            try
            {
                if (item.Id == 0) ctx.AdministratorPermissionItems.Add(item);

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.AdministratorPermission.Save(entitiesEvolveCentral ctx, AdministratorRoleItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }

        public static bool Delete(entitiesEvolveCentral ctx, AdministratorPermissionItem item)
        {

            bool retval = true;

            try
            {
                ctx.AdministratorPermissionItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.Delete(entitiesEvolveCentral ctx, AdministratorPermissionItem item)", ex.Message);
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
                DAL.AdministratorPermissionItem item = (from i in ctx.AdministratorPermissionItems where i.Code.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.AdministratorPermission.IsCodeAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
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
                DAL.AdministratorPermissionItem item = (from i in ctx.AdministratorPermissionItems where i.Name.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.AdministratorPermission.IsNameAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval; ;
        }

    }
}
