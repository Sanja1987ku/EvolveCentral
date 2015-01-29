using System;
using System.Collections.Generic;
using System.Linq;

namespace EvolveCentral.DAL
{
    public static class ServiceTemplateCrmEvolutionDetail
    {
        public static List<ServiceTemplateCrmEvolutionDetailItem> GetByService(entitiesEvolveCentral ctx, int id)
        {
            var items = new List<ServiceTemplateCrmEvolutionDetailItem>();
            try
            {
                items = (from i in ctx.ServiceTemplateCrmEvolutionDetailItems where i.ServiceTemplateCrmEvolutionId == id orderby i.Sequence ascending select i).ToList();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolutionDetail.GetByService(entitiesEvolveCentral ctx, int id)", ex.Message);
                items = null;
            } 
            return items;
        }

        public static ServiceTemplateCrmEvolutionDetailItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new ServiceTemplateCrmEvolutionDetailItem();
          try
          {
              item = (from i in ctx.ServiceTemplateCrmEvolutionDetailItems where i.Id == id orderby i.Name ascending select i).FirstOrDefault();
          }
          catch (Exception ex)
          {
              ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolutionDetail.Get(entitiesEvolveCentral ctx, int id)", ex.Message);
              item = null;
          } 
            return item;
        }

        public static ServiceTemplateCrmEvolutionDetailItem GetByCode(entitiesEvolveCentral ctx, string code, int servicetemplateid)
        {
            var item = new ServiceTemplateCrmEvolutionDetailItem();

            try
            {
                item = (from i in ctx.ServiceTemplateCrmEvolutionDetailItems where i.Code == code && i.ServiceTemplateCrmEvolutionId == servicetemplateid orderby i.Name ascending select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolutionDetail.GetByCode(entitiesEvolveCentral ctx, string code, int servicetemplateid)", ex.Message);
                item = null;
            }
            return item;
        }

        public static bool Save(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionDetailItem item)
        {
            try
            {
                if (item.Id == 0)
                {
                    ctx.ServiceTemplateCrmEvolutionDetailItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolutionDetail.Save(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionDetailItem item)", ex.Message);
               return false;
            }
            return true;
        }

        public static bool Delete(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionDetailItem item)
        {

            bool retval = true;

            try
            {
                ctx.ServiceTemplateCrmEvolutionDetailItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceTemplateCrmEvolution.Delete(entitiesEvolveCentral ctx, ServiceTemplateCrmEvolutionDetailItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }
        public static bool Publish(entitiesEvolveCentral ctx, int detailid)
        {

            //try
            //{
            //    DAL.ServiceTemplateCrmEvolutionDetailItem detailitem = GetByID(ctx, detailid);

            //    string templatedetailcode = detailitem.Code;
            //    int templateserviceid = detailitem.ServiceTemplateCrmEvolutionItem.Id;


            //    List<DAL.ServiceCrmEvolutionDetailItem> servicedetailitems = (from i in ctx.ServiceCrmEvolutionDetailItems where i.Code == templatedetailcode && i.ServiceCrmEvolutionItem.ServiceTemplateCrmEvolutionId == templateserviceid select i).ToList();

            //    for (int i = 0; i < servicedetailitems.Count; i++)
            //    {
            //        servicedetailitems[i].IsActive = detailitem.IsActive;
            //        servicedetailitems[i].Code = detailitem.Code;
            //        servicedetailitems[i].Command = detailitem.Command;
            //        servicedetailitems[i].CommandType = detailitem.CommandType;
            //        servicedetailitems[i].Description = detailitem.Description;
            //        servicedetailitems[i].DestinationTable = detailitem.DestinationTable;
            //        servicedetailitems[i].IsUnique = false;
            //        servicedetailitems[i].Name = detailitem.Name;
            //        servicedetailitems[i].Sequence = detailitem.Sequence;
            //        servicedetailitems[i].SourceTable = servicedetailitems[i].SourceTable;
            //           DAL.ServiceCrmEvolutionDetail.Save(ctx,  servicedetailitems[i]);

            //    }
             
                 


              
            //}
            //catch (Exception ex)
            //{
            //    return false;

            //}
            return true;
        }
    }
}