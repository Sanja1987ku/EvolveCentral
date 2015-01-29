using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentral.DAL
{
    public static  class ApplicationSettings
    {
        public static ApplicationSettingsItem GetByCode(entitiesEvolveCentral ctx, string code)
        {
            var item = new ApplicationSettingsItem();
            item = (from i in ctx.ApplicationSettingsItems where i.Code == code select i).FirstOrDefault();
            return item;
        }

        public static List<ApplicationSettingsItem> GetAll(entitiesEvolveCentral ctx)
        {
            var items = new List<ApplicationSettingsItem>();
            items = (from i in ctx.ApplicationSettingsItems select i).ToList();
            return items;
        }
    }
}