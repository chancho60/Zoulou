using System.Web;
using System.Web.Mvc;
using Zoulou.Culture;

namespace Zoulou {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new CultureFilter(defaultCulture: "en"));
            filters.Add(new HandleErrorAttribute());
        }
    }
}
