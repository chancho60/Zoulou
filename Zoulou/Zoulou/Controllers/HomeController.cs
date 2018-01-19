using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Zoulou.Models;
using Zoulou.Models.MMEG;

namespace Zoulou.Controllers {
    public class HomeController : BaseController {
        public ActionResult Index() {

            return View();
        }
    }
}