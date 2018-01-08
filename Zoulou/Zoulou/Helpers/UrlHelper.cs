using System.Web.Mvc;
using System.Web.Routing;

namespace Zoulou.Helpers {
    public static class UrlHelper {
        public static string RouteCultureUrl(this System.Web.Mvc.UrlHelper UrlHelper, RouteValueDictionary RouteValueDictionary, string Lang) {
            if(RouteValueDictionary.ContainsKey("culture")) {
                if(RouteValueDictionary["culture"].ToString() != Lang) {
                    RouteValueDictionary["culture"] = Lang;
                }
            } else {
                RouteValueDictionary.Add("culture", Lang);
            }

            return UrlHelper.RouteUrl(RouteValueDictionary);
        }
    }
}