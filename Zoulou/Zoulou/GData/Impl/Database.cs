using System.Collections.Generic;
using System.Linq;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Database : IDatabase {
        private readonly DatabaseClient Client;
        private readonly Spreadsheet Spreadsheet;
        private readonly string SpreadsheetId;

        public Database(DatabaseClient Client, string SpreadsheetId) {
            this.SpreadsheetId = SpreadsheetId;
            this.Client = Client;
            this.Spreadsheet = Client.SheetsService.Spreadsheets.Get(SpreadsheetId).Execute();
        }

        //public ITable<T> CreateTable<T>(string Name, string Range) where T : new() {
        public void CreateTable(string Name) {
            /*Request RequestBody = new Request() {
                AddSheet = new AddSheetRequest() {
                    Properties = new SheetProperties() {
                        Title = Name,
                    }
                }
            };

            List<Request> RequestContainer = new List<Request>();
            RequestContainer.Add(RequestBody);

            BatchUpdateSpreadsheetRequest BatchUpdate = new BatchUpdateSpreadsheetRequest();
            BatchUpdate.Requests = RequestContainer;

            var Response = Client.SheetsService.Spreadsheets.BatchUpdate(BatchUpdate, SpreadsheetId).Execute();*/

            var RequestBody = new Google.Apis.Sheets.v4.Data.Spreadsheet() {
                Properties = new SpreadsheetProperties() {
                    Title = Name
                }
            };

            SpreadsheetsResource.CreateRequest Request = Client.SheetsService.Spreadsheets.Create(RequestBody);

            var Response = Request.Execute();
        }

        public ITable<T> GetTable<T>(string Name, string Range) where T : new() {
            var Result = Spreadsheet.Sheets.Where(S => S.Properties.Title == Name).FirstOrDefault();

            return new Table<T>(Client, Result, SpreadsheetId, Range);
        }

        public void Delete() {
            //  TODO : Find how to delete a Spreadsheet
        }
    }
}