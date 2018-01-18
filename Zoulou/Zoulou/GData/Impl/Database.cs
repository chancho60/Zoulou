using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Database : IDatabase {
        private readonly DatabaseClient Client;
        private readonly string SpreadsheetId;

        public Database(DatabaseClient Client, string SpreadsheetId) {
            this.Client = Client;
            this.SpreadsheetId = SpreadsheetId;
        }
        
        public ITable<T> CreateTable<T>(string SheetName) where T : new() {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + ":batchUpdate";

            object Obj = new {
                requests = new {
                    addSheet = new {
                        properties = new {
                            title = SheetName
                        }
                    }
                }
            };

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            var Request = Client.RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent);
            Request.Wait();

            var SheetId = Client.RequestFactory.SheetsService.DeserializeResponse<BatchUpdateSpreadsheetResponse>(Request.Result).Result.Replies[0].AddSheet.Properties.SheetId;
            if(SheetId == null)
                return null;

            return new Table<T>(Client, SpreadsheetId, SheetId, SheetName);
        }

        public ITable<T> GetTable<T>(string SheetName) where T : new() {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId;

            var Request = Client.RequestFactory.GetHttpClient().GetAsync(Uri);
            Request.Wait();

            var SheetId = Client.RequestFactory.SheetsService.DeserializeResponse<Spreadsheet>(Request.Result).Result.Sheets.Where(S => S.Properties.Title == SheetName).Select(S => S.Properties.SheetId).FirstOrDefault();
            if(SheetId == null)
                return null;

            return new Table<T>(Client, SpreadsheetId, SheetId, SheetName);
        }

        public void Delete() {
            var Uri = "https://www.googleapis.com/drive/v3/files/" + this.SpreadsheetId + "?q=mimeType%3D'application%2Fvnd.google-apps.spreadsheet'";
            Client.RequestFactory.GetHttpClient().DeleteAsync(Uri).Wait();
        }
    }
}