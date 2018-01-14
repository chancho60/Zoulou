using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Zoulou.GData.Impl;
using Zoulou.GData.Interfaces;

namespace Zoulou.GData.Models {
    public class DatabaseClient : IDatabaseClient {
        private static string[] Scopes = new[] {
            SheetsService.Scope.Spreadsheets,
        };
        public readonly SheetsService SheetsService;
        private readonly GoogleCredential Credential;

        public DatabaseClient() {
            this.Credential = GoogleCredential.FromFile(HttpRuntime.AppDomainAppPath + "Key.json").CreateScoped(Scopes);

            this.SheetsService = new SheetsService(new BaseClientService.Initializer {
                HttpClientInitializer = this.Credential,
                ApplicationName = "Zoulou"
            });
        }

        public IDatabase CreateDatabase(string Name) {
            var Body = new Google.Apis.Sheets.v4.Data.Spreadsheet();
            Body.Properties.Title = Name;
            var Response = this.SheetsService.Spreadsheets.Create(Body).Execute();

            return new Database(this, Response.SpreadsheetId);
        }

        public IDatabase GetDatabase(string Id) {
            return new Database(this, Id);
        }
    }
}