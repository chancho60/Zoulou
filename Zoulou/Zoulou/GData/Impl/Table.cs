using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Table<T> : ITable<T> where T : new() {
        private readonly DatabaseClient Client;
        private readonly string SpreadsheetId;
        private readonly int? SheetId;
        private readonly string SheetName;

        public Table(DatabaseClient Client, string SpreadsheetId, int? SheetId, string SheetName) {
            if(Client == null)
                throw new ArgumentNullException("Client");
            if(SpreadsheetId == null)
                throw new ArgumentNullException("SpreadsheetId");
            if(SheetId == null)
                throw new ArgumentNullException("SheetId");
            if(SheetName == null)
                throw new ArgumentNullException("SheetName");

            this.Client = Client;
            this.SpreadsheetId = SpreadsheetId;
            this.SheetId = SheetId;
            this.SheetName = SheetName;
        }

        public void Delete() {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + ":batchUpdate";

            object Obj = new {
                requests = new {
                    deleteSheet = new {
                        sheetId = this.SheetId
                    }
                }
            };

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            Client.RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent).Wait();
        }

        public void Clear() {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + "/values/" + SheetName + ":clear";
            Client.RequestFactory.GetHttpClient().PostAsync(Uri, null).Wait();
        }

        public void Rename(string SheetName) {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + ":batchUpdate";

            object Obj = new {
                updateSheetProperties = new {
                    properties = new {
                        sheetId = this.SheetId,
                        title = SheetName
                    }
                }
            };

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            Client.RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent).Wait();
        }

        public IRow<T> Add(T e) {
            //  TODO : Find how to add row.
            return null;
        }

        public IRow<T> Get(int RowNumber) {
            var q = new Query {
                Start = RowNumber,
                Count = 1,
            };
            var results = Find(q);
            if(results.Count == 0)
                return null;
            return results[0];
        }

        public IList<IRow<T>> FindAll() {
            return Find(new Query());
        }

        public IList<IRow<T>> FindAll(int Start, int Count) {
            return Find(new Query {
                Start = Start,
                Count = Count,
            });
        }

        public IList<IRow<T>> Find(Query q) {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + "/values/" + SheetName;

            var Request = Client.RequestFactory.GetHttpClient().GetAsync(Uri);
            Request.Wait();

            var ValueRange = Client.RequestFactory.SheetsService.DeserializeResponse<ValueRange>(Request.Result).Result.Values;

            var Result = new List<IRow<T>>();
            IList<IList<object>> Rows = ValueRange.Skip(1).ToList();

            if(q.Start > 0)
                Rows = Rows.Skip(q.Start).ToList();
            if(q.Count > 0) {
                Rows = Rows.Take(q.Count).ToList();
            }

            foreach(var Row in Rows) {
                Result.Add(new Row<T>(Client, this.SpreadsheetId, SheetId, Rows.IndexOf(Row)+1) { Element = (T)Activator.CreateInstance(typeof(T), Row) });
            }

            return Result;
        }
    }
}