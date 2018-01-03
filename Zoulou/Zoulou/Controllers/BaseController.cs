using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Zoulou.Controllers {
    public class BaseController : Controller {
        public ActionResult SwitchLanguage(string lang, string controller) {
            switch (lang) {
                case "fr":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
                break;
                case "en":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");
                break;
                default:
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
                break;

            }
            return RedirectToAction("Index", controller);
        }

        public ActionResult Error() {
            return View("Error");
        }
    }
}