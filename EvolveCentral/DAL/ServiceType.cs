using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static class ServiceType
    {
        public static List<ServiceTypeItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<ServiceTypeItem>();
            items = (from i in ctx.ServiceTypeItems orderby i.Name ascending select i).ToList();
         return items;
        }
        public static ServiceTypeItem Get(entitiesEvolveCentral ctx, int id)
        {
            var item = new ServiceTypeItem();
            item = (from i in ctx.ServiceTypeItems where i.Id == id orderby i.Name ascending select i).FirstOrDefault();
            return item;
        }
        public static ServiceTypeItem GetByCode(entitiesEvolveCentral ctx, string code)
        {
            var item = new ServiceTypeItem();
            item = (from i in ctx.ServiceTypeItems where i.Code == code orderby i.Name ascending select i).FirstOrDefault();
            return item;
        }
    }
}