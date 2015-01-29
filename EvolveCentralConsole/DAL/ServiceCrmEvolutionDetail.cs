using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolveCentralConsole.DAL
{
    public static class ServiceCrmEvolutionDetail
    {
        public static List<ServiceCrmEvolutionDetailItem> GetByServiceID(entitiesEvolveCentralConsole ctx, int id)
        {
            var item = new List<ServiceCrmEvolutionDetailItem>();
            item = (from i in ctx.ServiceCrmEvolutionDetailItems where i.ServiceCrmEvolutionId == id where i.IsActive == true orderby i.Sequence ascending select i).ToList();
            return item;
        }
    }
}
