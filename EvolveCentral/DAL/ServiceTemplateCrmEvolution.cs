using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static class ServiceTemplateCrmEvolution
    {
        public static List<ServiceTemplateCrmEvolutionItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<ServiceTemplateCrmEvolutionItem>();
            try
            {
                items = (from i in ctx.ServiceTemplateCrmEvolutionItems orderby i.Name ascending select i).ToList();
                return items;
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.GetAll(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }
            return items;
        }


        public static List<ServiceTemplateCrmEvolutionItem> List(entitiesEvolveCentral ctx)
        {

            var items = new List<ServiceTemplateCrmEvolutionItem>();

            try
            {
                items = (from i in ctx.ServiceTemplateCrmEvolutionItems where i.IsActive == true orderby i.Name ascending select i).ToList();
                items.Insert(0, new ServiceTemplateCrmEvolutionItem() { Id = 0, Name = null });
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.List(entitiesEvolveCentral ctx)", ex.Message);
                items = null;
            }

            return items;
        }
        public static ServiceTemplateCrmEvolutionItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new ServiceTemplateCrmEvolutionItem();
         try
            {   
             item = (from i in ctx.ServiceTemplateCrmEvolutionItems where i.Id == id orderby i.Name ascending select i).FirstOrDefault();
            }
         catch (Exception ex)
         {
             ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.Get(entitiesEvolveCentral ctx, int id)", ex.Message);
             item = null;
         } 
            return item;
        }


        public static bool Save(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionItem item)
        {
            try
            {
                if (item.Id == 0)
                {
                    ctx.ServiceTemplateCrmEvolutionItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.Save(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionItem item)", ex.Message);
                return false;
            }
            return true;
        }

        public static bool Delete(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionItem item)
        {

            bool retval = true;

            try
            {
                ctx.ServiceTemplateCrmEvolutionItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.Delete(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionItem item)", ex.Message);
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
                DAL.ServiceTemplateCrmEvolutionItem item = (from i in ctx.ServiceTemplateCrmEvolutionItems where i.Code.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.IsCodeAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
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
                DAL.ServiceTemplateCrmEvolutionItem item = (from i in ctx.ServiceTemplateCrmEvolutionItems where i.Name.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.IsNameAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval; ;
        }
    }
}