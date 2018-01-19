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

        public Row(DatabaseClient Client, string SpreadsheetId, int? SheetId, int RowId) {
            this.Client = Client;
            this.SpreadsheetId = SpreadsheetId;
            this.SheetId = SheetId;
            this.RowId = RowId;
        }

        public void Update() {
            //  TODO : Fix row update
            /*var Uri = "https://sheets.googleapis.com/v4/spreadsheets/" + this.SpreadsheetId + ":batchUpdate";

            object Obj = new {
                requests = new {
                    updateCells = new {
                        start = new {
                            sheetId = this.SheetId,
                            columnIndex = 0,
                            rowIndex = this.RowId,
                        },
                        rows = new {
                            values = new {
                                userEnteredValue = new {
                                    stringValue = "Test"
                                },
                            }
                        },
                        fields = "*"
                    }
                }
            };

            foreach(var test in Element.GetType().GetProperties()) {
                var testing = test.GetValue(Element);
            }

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            var Request = Client.RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent);
            Request.Wait();
            var Result = Client.RequestFactory.SheetsService.DeserializeResponse<BatchUpdateSpreadsheetResponse>(Request.Result);*/
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
