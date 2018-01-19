using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Row<T> : IRow<T> where T : new() {
        private readonly DatabaseClient Client;
        public T Element { get; set; }
        public readonly string SpreadsheetId;
        public readonly int? SheetId;
        public readonly int RowId;
        private readonly IList<object> ColumnNames;

        public Row(DatabaseClient Client, string SpreadsheetId, int? SheetId, int RowId, IList<object> ColumnNames) {
            this.Client = Client;
            this.SpreadsheetId = SpreadsheetId;
            this.SheetId = SheetId;
            this.RowId = RowId;
            this.ColumnNames = ColumnNames;
        }

        public void Update() {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + ":batchUpdate";

            object Obj = new {
                requests = new {
                    updateCells = new {
                        start = new {
                            sheetId = this.SheetId,
                            columnIndex = 0,
                            rowIndex = this.RowId,
                        },
                        rows = new {
                            values = ColumnNames.Select(C => new { userEnteredValue = new { stringValue = Element.GetType().GetProperty(C.ToString())?.GetValue(Element)?.ToString() } })
                        },
                        fields = "*"
                    }
                }
            };

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            var Request = Client.RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent);
            Request.Wait();
            var Result = Client.RequestFactory.SheetsService.DeserializeResponse<BatchUpdateSpreadsheetResponse>(Request.Result);
        }

        public void Delete() {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + ":batchUpdate";

            object Obj = new {
                requests = new {
                    deleteDimension = new {
                        range = new {
                            sheetId = this.SheetId,
                            dimension = "ROWS",
                            startIndex = this.RowId,
                            endIndex = this.RowId + 1
                        }
                    }
                }
            };

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            Client.RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent).Wait();
        }
    }
}
