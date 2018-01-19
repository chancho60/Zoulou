using System.Collections.Generic;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;

namespace Zoulou.Models {
    public partial class GoogleEntity {
        protected static string[] Scopes = new[] {
            SheetsService.Scope.Spreadsheets
        };

        protected static GoogleCredential Credential = GoogleCredential.FromFile(HttpRuntime.AppDomainAppPath + "Key.json").CreateScoped(Scopes);

        protected SheetsService Service = new SheetsService(new BaseClientService.Initializer {
            HttpClientInitializer = Credential,
            ApplicationName = "Zoulou"
        });

        public IList<IList<object>> getWorksheet(string SpreadsheetId, string Range) {
            SpreadsheetsResource.ValuesResource.GetRequest Request = Service.Spreadsheets.Values.Get(SpreadsheetId, Range);
            ValueRange Response = Request.Execute();
            return Response.Values;
        }

        public IList<ValueRange> getWorksheets(string SpreadsheetId, List<string> Ranges) {
            SpreadsheetsResource.ValuesResource.BatchGetRequest Request = Service.Spreadsheets.Values.BatchGet(SpreadsheetId);
            Request.Ranges = Ranges;
            BatchGetValuesResponse Response = Request.Execute();
            return Response.ValueRanges;
        }
    }
}