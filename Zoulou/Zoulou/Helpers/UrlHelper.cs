using System.Web.Mvc;
using System.Web.Routing;

namespace Zoulou.Helpers {
    public static class UrlHelper {
        public static string RouteCultureUrl(this System.Web.Mvc.UrlHelper UrlHelper, RouteValueDictionary RouteValueDictionary, string Lang) {
            return UrlHelper.RouteUrl(new { controller = RouteValueDictionary["controller"], action = RouteValueDictionary["action"], culture = Lang });
        }
    }
}