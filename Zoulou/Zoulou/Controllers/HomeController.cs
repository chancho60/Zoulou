using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Zoulou.Models;

namespace Zoulou.Controllers {
    public class HomeController : BaseController {
        private GoogleEntity db = new GoogleEntity();

        public async Task<ActionResult> Index() {
            CancellationToken cToken = new CancellationToken();
            
            return await IndexAsync(cToken);
        }

        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken) {
            /*if(db.Credential != null) {

                var service = new SheetsService(new BaseClientService.Initializer {
                    HttpClientInitializer = db.Credential,
                    ApplicationName = "Zoulou"
                });

                string Result = "";
                string SpreadsheetId = "1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo";
                string Range = "Glyphs!A1:F2";
                SpreadsheetsResource.ValuesResource.GetRequest Request = service.Spreadsheets.Values.Get(SpreadsheetId, Range);
                ValueRange Response = Request.Execute();
                IList<IList<object>> Values = Response.Values;
                if(Values != null && Values.Count > 0) {
                    foreach(var Row in Values) {
                        Result += Row[0].ToString() + Row[1].ToString() + "</br>";
                    }
                }
                ViewBag.Message = Result;
                return View();
            } else {
                ViewBag.Message = "Error";
                //return new RedirectResult(result.RedirectUri);
            }*/
            return View();
        }
    }
}