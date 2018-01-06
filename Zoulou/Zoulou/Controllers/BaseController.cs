using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace Zoulou.Controllers {
    public class BaseController : Controller {
        public ActionResult Error() {
            return View("Error");
        }
    }
}