using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvolveCentralConsole.DAL
{
    public static class ApplicationSettings
    {
        public static ApplicationSettingsItem GetByCode(entitiesEvolveCentralConsole ctx, string code)
        {
            var item = new ApplicationSettingsItem();
            item = (from i in ctx.ApplicationSettingsItems where i.Code == code select i).FirstOrDefault();
            return item;
        }

        public static List<ApplicationSettingsItem> GetAll(entitiesEvolveCentralConsole ctx)
        {
            var items = new List<ApplicationSettingsItem>();
            items = (from i in ctx.ApplicationSettingsItems select i).ToList();
            return items;
        }
    }
}