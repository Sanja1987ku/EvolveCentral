using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static  class ServiceCrmEvolution
    {
        public static List<ServiceCrmEvolutionItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<ServiceCrmEvolutionItem>();
            items = (from i in ctx.ServiceCrmEvolutionItems orderby i.Name ascending select i).ToList();
            return items;
        }

        //public static ServiceItem GetByCode(entitiesEvolveCentral ctx, string clientcode,string servicetypecode)
        //{
        //    var item = new ServiceItem();
        //    item = (from i in ctx.ServiceItems where i.ClientItem.Code  == clientcode && i.ServiceTypeItem.Code == servicetypecode orderby i.Name ascending select i).FirstOrDefault();
        //    return item;
        //}

        public static ServiceCrmEvolutionItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new ServiceCrmEvolutionItem();
            item = (from i in ctx.ServiceCrmEvolutionItems where i.Id == id orderby i.Name ascending select i).FirstOrDefault();
            return item;
        }


        public static bool Save(entitiesEvolveCentral ctx, ServiceCrmEvolutionItem item)
        {
            try
            {
                if (item.Id == 0)
                {
                    ctx.ServiceCrmEvolutionItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

        public static bool Delete(entitiesEvolveCentral ctx, ServiceCrmEvolutionItem item)
        {

            bool retval = true;

            try
            {
                ctx.ServiceCrmEvolutionItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceCrmEvolution.Delete(entitiesEvolveCentral ctx, ServiceCrmEvolutionItem item)", ex.Message);
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
                DAL.ServiceCrmEvolutionItem item = (from i in ctx.ServiceCrmEvolutionItems where i.Code.ToUpper() == value.ToUpper() select i).FirstOrDefault();
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
                ApplicationLog.Log(ctx, "DAL.ServiceCrmEvolution.IsCodeAvailable(entitiesEvolveCentral ctx, string value, int? id)", ex.Message);
                retval = false;
            }

            return retval; ;
        }


         public static bool Revert(entitiesEvolveCentral ctx, int id)
        {
            var item = new ServiceCrmEvolutionItem();
            try
            {
                DAL.ServiceCrmEvolutionItem sitem = Get(ctx, id);

                DAL.ServiceTemplateCrmEvolutionItem stitem = DAL.ServiceTemplateCrmEvolution.Get(ctx, Convert.ToInt32(sitem.ServiceTemplateCrmEvolutionId));

                DAL.ServiceCrmEvolutionDetail.DeleteByService(ctx, id, false);



                DateTime cdate = DateTime.Now;

                foreach (DAL.ServiceTemplateCrmEvolutionDetailItem i in stitem.ServiceTemplateCrmEvolutionDetailItems)
                {
                    DAL.ServiceCrmEvolutionDetailItem newitem = new DAL.ServiceCrmEvolutionDetailItem();
                    newitem.IsActive = i.IsActive;
                    newitem.Code = i.Code;
                    newitem.Command = i.Command;
                    newitem.IsUnique = false;
                    newitem.CommandType = i.CommandType;

                    newitem.Description = i.Description;
                    newitem.DestinationTable = i.DestinationTable;

                    newitem.Name = i.Name;
                    newitem.Sequence = i.Sequence;
                    newitem.ServiceCrmEvolutionId = sitem.Id;
                    newitem.SourceTable = i.SourceTable;

                    if (DAL.ServiceCrmEvolutionDetail.GetByServiceAndCode(ctx, Convert.ToInt32(newitem.ServiceCrmEvolutionId), newitem.Code).Count == 0)
                        DAL.ServiceCrmEvolutionDetail.Save(ctx, newitem);


                }

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

         public static ServiceCrmEvolutionItem GetByCode(entitiesEvolveCentral ctx, string servicecode)
         {
             var item = new ServiceCrmEvolutionItem();
             item = (from i in ctx.ServiceCrmEvolutionItems where i.Code == servicecode where i.IsActive == true select i).FirstOrDefault();
             return item;
         }
    }
}