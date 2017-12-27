using System;
using System.Collections.Generic;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace Zoulou.Models {
    public partial class GoogleEntity {

        protected static string[] Scopes = new[] {
            DriveService.Scope.Drive,
            DriveService.Scope.DriveFile,
            SheetsService.Scope.Spreadsheets
        };

        public GoogleCredential Credential = GoogleCredential.FromFile(HttpRuntime.AppDomainAppPath + "Key.json").CreateScoped(Scopes);

        public IList<IList<object>> getDataFrom(String SpreadsheetId, String Range) {
            var service = new SheetsService(new BaseClientService.Initializer {
                HttpClientInitializer = this.Credential,
                ApplicationName = "Zoulou"
            });
            
            /*string SpreadsheetId = "1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo";
            string Range = "Glyphs!A1:F2";*/
            SpreadsheetsResource.ValuesResource.GetRequest Request = service.Spreadsheets.Values.Get(SpreadsheetId, Range);
            ValueRange Response = Request.Execute();
            IList<IList<object>> Values = Response.Values;

            return Values;
        }
    }
}