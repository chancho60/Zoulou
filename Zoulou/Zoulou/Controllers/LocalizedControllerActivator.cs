using System;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zoulou.Controllers {
    public class LocalizedControllerActivator : IControllerActivator {
        private string _DefaultLanguage = "En";

        public IController Create(RequestContext requestContext, Type controllerType) {
            string lang = (requestContext.RouteData.Values["lang"] != null) ? requestContext.RouteData.Values["lang"].ToString() : _DefaultLanguage;

            if (lang != Thread.CurrentThread.CurrentCulture.ToString()) {
                try {
                    CultureInfo Culture = CultureInfo.GetCultureInfo(lang);
                    Thread.CurrentThread.CurrentCulture = Culture;
                    Thread.CurrentThread.CurrentUICulture = Culture;
                } catch (Exception e) {
                    throw new NotSupportedException(String.Format("ERROR: Invalid language code '{0}'.", lang));
                }
            }

            return DependencyResolver.Current.GetService(controllerType) as IController;
        }
    }
}