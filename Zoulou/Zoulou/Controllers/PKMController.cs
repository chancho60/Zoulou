using System.Web.Mvc;

namespace Zoulou.Controllers {
    public class PKMController : BaseController {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Pokemon() {
            return View();
        }
    }
}