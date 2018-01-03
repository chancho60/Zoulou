using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zoulou.Controllers {
    public class LocalizedControllerActivator : IControllerActivator {
        private string _DefaultLanguage = "fr";

        public IController Create(RequestContext requestContext, Type controllerType) {
            string lang = (requestContext.RouteData.Values["lang"] != null) ? requestContext.RouteData.Values["lang"].ToString() : _DefaultLanguage;

            if (lang != _DefaultLanguage) {
                try {
                    Thread.CurrentThread.CurrentCulture =
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                } catch (Exception e) {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}