using System;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using System.Web.Routing;

namespace Zoulou.Helpers {
    public static class CultureMenu {
        public static string RouteCultureUrl(this UrlHelper UrlHelper, RouteValueDictionary RouteValueDictionary, string Lang) {
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