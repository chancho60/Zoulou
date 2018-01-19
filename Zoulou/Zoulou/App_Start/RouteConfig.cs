using System.Web.Mvc;
using System.Web.Routing;
using Zoulou.Culture;

namespace Zoulou {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapLocalizedMvcAttributeRoutes(
                urlPrefix: "{culture}/",
                defaults: new { culture = "en" },
                constraints: new { culture = new CultureConstraint(defaultCulture: "en", pattern: "[A-z]{2}") }
            );

            routes.MapRoute(
                name: "DefaultWithCulture",
                url: "{culture}/{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" },
                constraints: new { culture = new CultureConstraint(defaultCulture: "en", pattern: "[A-z]{2}") }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { culture = "en", controller = "Home", action = "Index" }
            );
        }
    }
}
