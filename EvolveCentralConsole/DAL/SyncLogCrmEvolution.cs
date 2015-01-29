using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveCentralConsole.DAL
{
  public static   class SyncLogCrmEvolution
    {
      public static SyncLogCrmEvolutionItem GetById(entitiesEvolveCentralConsole ctx, int id)
        {
            var item = new SyncLogCrmEvolutionItem();
            item = (from i in ctx.SyncLogCrmEvolutionItems where i.Id == id orderby i.CreateDate descending select i).FirstOrDefault();
            return item;
        }

      public static bool Save(entitiesEvolveCentralConsole ctx, SyncLogCrmEvolutionItem item)
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
