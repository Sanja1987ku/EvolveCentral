using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentralConsole.DAL
{
    public static  class ServiceCrmEvolution
    {
        public static ServiceCrmEvolutionItem  GetByCode(entitiesEvolveCentralConsole ctx, string servicecode)
        {
            var item = new ServiceCrmEvolutionItem();
            item = (from i in ctx.ServiceCrmEvolutionItems where i.Code == servicecode where i.IsActive == true select i).FirstOrDefault();
            return item;
        }

        public static bool Save(entitiesEvolveCentralConsole ctx, ServiceCrmEvolutionItem item)
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

     
    }
}