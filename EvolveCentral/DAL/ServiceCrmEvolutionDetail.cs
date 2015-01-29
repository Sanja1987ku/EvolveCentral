using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static  class ServiceCrmEvolutionDetail
    {
        public static List<ServiceCrmEvolutionDetailItem> GetByService(entitiesEvolveCentral ctx, int id)
        {
            var items = new List<ServiceCrmEvolutionDetailItem>();
            items = (from i in ctx.ServiceCrmEvolutionDetailItems where i.ServiceCrmEvolutionId == id orderby i.Sequence ascending select i).ToList();
            return items;
        }

        public static List<ServiceCrmEvolutionDetailItem> GetByServiceAndCode(entitiesEvolveCentral ctx, int id, string code)
        {
            var items = new List<ServiceCrmEvolutionDetailItem>();
            items = (from i in ctx.ServiceCrmEvolutionDetailItems where i.ServiceCrmEvolutionId == id && i.Code == code orderby i.Sequence ascending select i).ToList();
            return items;
        }

        public static ServiceCrmEvolutionDetailItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new ServiceCrmEvolutionDetailItem();
            item = (from i in ctx.ServiceCrmEvolutionDetailItems where i.Id == id orderby i.Name ascending select i).FirstOrDefault();
            return item;
        }

        public static bool Save(entitiesEvolveCentral ctx, ServiceCrmEvolutionDetailItem item)
        {
            try
            {
                if (item.Id == 0)
                {
                    ctx.ServiceCrmEvolutionDetailItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

        public static bool Delete(entitiesEvolveCentral ctx, ServiceCrmEvolutionDetailItem item)
        {

            bool retval = true;

            try
            {
                ctx.ServiceCrmEvolutionDetailItems.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                ApplicationLog.Log(ctx, "DAL.ServiceCrmEvolutionDetail.Delete(entitiesEvolveCentral ctx, ServiceCrmEvolutionDetailItem item)", ex.Message);
                retval = false;
            }

            return retval;
        }
        public static bool DeleteByService(entitiesEvolveCentral ctx, int id,bool deleteUnique)
        {
            var item = new ServiceCrmEvolutionDetailItem();
            try
            {

                DAL.ServiceCrmEvolutionItem sitem = DAL.ServiceCrmEvolution.Get(ctx, id);

                DAL.ServiceTemplateCrmEvolutionItem stitem = DAL.ServiceTemplateCrmEvolution.Get(ctx, Convert.ToInt32(sitem.ServiceTemplateCrmEvolutionId));

                List<DAL.ServiceCrmEvolutionDetailItem> detailitems = DAL.ServiceCrmEvolutionDetail.GetByService(ctx, id);
                for (int i = 0; i < detailitems.Count; i++)
                {
                    int detailid = detailitems[i].Id;
                    DAL.ServiceCrmEvolutionDetailItem sditem = ctx.ServiceCrmEvolutionDetailItems.Find(detailid);
                    if (deleteUnique) ctx.ServiceCrmEvolutionDetailItems.Remove(sditem);
                    else
                    {
                        if (!Convert.ToBoolean(sditem.IsUnique)) ctx.ServiceCrmEvolutionDetailItems.Remove(sditem);
                    }
                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }

        public static bool Revert(entitiesEvolveCentral ctx, int detailid)
        {
          
            try
            {
                //DAL.ServiceCrmEvolutionDetailItem detailitem = GetByID(ctx, detailid);

                //DAL.ServiceCrmEvolutionItem serviceitem = DAL.ServiceCrmEvolution.GetByID(ctx, Convert.ToInt32(detailitem.ServiceCrmEvolutionId));

                //DAL.ServiceTemplateCrmEvolutionItem servicetemplateitem = DAL.ServiceTemplateCrmEvolution.GetByID(ctx, Convert.ToInt32(serviceitem.ServiceTemplateCrmEvolutionId));

                //DAL.ServiceTemplateCrmEvolutionDetailItem servicetemplatedetailitem = DAL.ServiceTemplateCrmEvolutionDetail.GetByCode(ctx, detailitem.Code, servicetemplateitem.Id);
                //if(servicetemplatedetailitem != null)
                //{
                //Delete(ctx, detailid);


               
                //DateTime cdate = DateTime.Now;

                //DAL.ServiceCrmEvolutionDetailItem newitem = new DAL.ServiceCrmEvolutionDetailItem();
                //    newitem.IsActive = servicetemplatedetailitem.IsActive;
                //    newitem.Code = servicetemplatedetailitem.Code;
                //    newitem.Command = servicetemplatedetailitem.Command;
                //    newitem.IsUnique = false;
                //    newitem.CommandType = servicetemplatedetailitem.CommandType;
                   
                //    newitem.Description = servicetemplatedetailitem.Description;
                //    newitem.DestinationTable = servicetemplatedetailitem.DestinationTable;
                   
                //    newitem.Name = servicetemplatedetailitem.Name;
                //    newitem.Sequence = servicetemplatedetailitem.Sequence;
                //    newitem.ServiceCrmEvolutionId = serviceitem.Id;
                //    newitem.SourceTable = servicetemplatedetailitem.SourceTable;
                //    DAL.ServiceCrmEvolutionDetail.Save(ctx, newitem);

                
                //}

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }
   
    }
}