using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveCentralConsole.DAL
{
    public static class SyncLogCrmEvolutionDetail
    {
        public static bool Save(entitiesEvolveCentralConsole ctx, SyncLogCrmEvolutionDetailItem item)
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

  
  
  }
}
