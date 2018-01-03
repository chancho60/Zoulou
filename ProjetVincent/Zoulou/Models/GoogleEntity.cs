using System;
using System.Collections.Generic;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Zoulou.Models;

namespace Zoulou.Models {
    public partial class GoogleEntity {
        protected static string[] Scopes = new[] {
            DriveService.Scope.Drive,
            DriveService.Scope.DriveFile,
            SheetsService.Scope.Spreadsheets
        };

        protected static GoogleCredential Credential = GoogleCredential.FromFile(HttpRuntime.AppDomainAppPath + "Key.json").CreateScoped(Scopes);

        protected SheetsService service = new SheetsService(new BaseClientService.Initializer {
            HttpClientInitializer = Credential,
            ApplicationName = "Zoulou"
        });

        public IList<IList<object>> getWorksheet(string SpreadsheetId, string Range) {
            SpreadsheetsResource.ValuesResource.GetRequest Request = service.Spreadsheets.Values.Get(SpreadsheetId, Range);
            ValueRange Response = Request.Execute();
            return Response.Values;
        }
    }
}