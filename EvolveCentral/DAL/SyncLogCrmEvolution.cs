using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static  class SyncLogCrmEvolution
    {
        public static List<SyncLogCrmEvolutionItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<SyncLogCrmEvolutionItem>();
            items = (from i in ctx.SyncLogCrmEvolutionItems orderby i.CreateDate descending select i).ToList();
            return items;
        }
        public static List<SyncLogCrmEvolutionItem> GetByService(entitiesEvolveCentral ctx, int serviceid)
        {
            var items = new List<SyncLogCrmEvolutionItem>();
            items = (from i in ctx.SyncLogCrmEvolutionItems where i.ServiceCrmEvolutionId == serviceid orderby i.CreateDate descending select i).ToList();
            return items;
        }
        public static SyncLogCrmEvolutionItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new SyncLogCrmEvolutionItem();
            item = (from i in ctx.SyncLogCrmEvolutionItems where i.Id == id orderby i.CreateDate descending select i).FirstOrDefault();
            return item;
        }  
        public static bool DeleteByService(entitiesEvolveCentral ctx, int id)
        {

            try
            {



                List<DAL.SyncLogCrmEvolutionItem> logitems = DAL.SyncLogCrmEvolution.GetByService(ctx, id);
                for (int i = 0; i < logitems.Count; i++)
                {
                    int logid = logitems[i].Id;
                    DAL.SyncLogCrmEvolutionDetail.DeleteByLog(ctx, logid);
                    DAL.SyncLogCrmEvolutionItem litem = ctx.SyncLogCrmEvolutionItems.Find(logid);
                    ctx.SyncLogCrmEvolutionItems.Remove(litem);

                }
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }
        public static bool Save(entitiesEvolveCentral ctx, SyncLogCrmEvolutionItem item)
        {
            try
            {
                if (item.Id == 0)
                {
                    ctx.SyncLogCrmEvolutionItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }
    }
}