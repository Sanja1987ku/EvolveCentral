using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static class SyncLogCrmEvolutionDetail
    {
        public static List<SyncLogCrmEvolutionDetailItem> GetByLog(entitiesEvolveCentral ctx, int id)
        {
            var items = new List<SyncLogCrmEvolutionDetailItem>();
            items = (from i in ctx.SyncLogCrmEvolutionDetailItems where i.SyncLogCrmEvolutionId == id orderby i.CreateDate descending select i).ToList();
            return items;
        }
        public static SyncLogCrmEvolutionDetailItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new SyncLogCrmEvolutionDetailItem();
            item = (from i in ctx.SyncLogCrmEvolutionDetailItems where i.Id == id orderby i.CreateDate descending select i).FirstOrDefault();
            return item;
        }
        public static bool Save(entitiesEvolveCentral ctx, SyncLogCrmEvolutionDetailItem item)
        {
            try
            {
                if (item.Id == 0)
                {
                    ctx.SyncLogCrmEvolutionDetailItems.Add(item);
                }

                ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;

            }
            return true;
        }
        
        public static bool DeleteByLog(entitiesEvolveCentral ctx, int id)
        {

            try
            {




                List<DAL.SyncLogCrmEvolutionDetailItem> logdetailitems = DAL.SyncLogCrmEvolutionDetail.GetByLog(ctx, id);
                for (int i = 0; i < logdetailitems.Count; i++)
                {
                    int logdetailid = logdetailitems[i].Id;
                    DAL.SyncLogCrmEvolutionDetailItem lditem = ctx.SyncLogCrmEvolutionDetailItems.Find(logdetailid);
                    ctx.SyncLogCrmEvolutionDetailItems.Remove(lditem);

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