using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Zoulou.Culture {
    public class CultureFilter : IAuthorizationFilter {
        private readonly string defaultCulture;

        public CultureFilter(string defaultCulture) {
            this.defaultCulture = defaultCulture;
        }

        public void OnAuthorization(AuthorizationContext filterContext) {
            var values = filterContext.RouteData.Values;
            string culture = "";

            if((string)values["culture"] is null) {
                culture = this.defaultCulture;
                filterContext.RouteData.Values.Add("culture", this.defaultCulture);
            } else {
                culture = (string)values["culture"];
            }

            CultureInfo ci = new CultureInfo(culture);

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }
    }
}