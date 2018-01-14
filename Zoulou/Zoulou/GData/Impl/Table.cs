using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Table<T> : ITable<T> where T : new() {
        private readonly DatabaseClient Client;
        private readonly Sheet Sheet;
        private readonly string SpreadsheetId;
        private readonly string Range;
        private readonly ValueRange ValueRange;

        public Table(DatabaseClient Client, Sheet Sheet, string SpreadsheetId, string Range) {
            if(Client == null)
                throw new ArgumentNullException("Client");
            if(Sheet == null)
                throw new ArgumentNullException("Sheet");
            if(Sheet == null)
                throw new ArgumentNullException("SpreadsheetId");
            if(Sheet == null)
                throw new ArgumentNullException("Range");

            this.Client = Client;
            this.Sheet = Sheet;
            this.SpreadsheetId = SpreadsheetId;
            this.Range = Range;
            this.ValueRange = Client.SheetsService.Spreadsheets.Values.Get(SpreadsheetId, Range).Execute();
        }

        public void Delete() {
            Request RequestBody = new Request() {
                DeleteSheet = new DeleteSheetRequest() {
                    SheetId = Sheet.Properties.SheetId
                }
            };

            List<Request> RequestContainer = new List<Request>();
            RequestContainer.Add(RequestBody);

            BatchUpdateSpreadsheetRequest BatcUpdateRequest = new BatchUpdateSpreadsheetRequest();
            BatcUpdateRequest.Requests = RequestContainer;

            var Response = Client.SheetsService.Spreadsheets.BatchUpdate(BatcUpdateRequest, SpreadsheetId).Execute();
        }

        public void Clear() {
            /*Request RequestBody = new Request() {
                DeleteDimension = new DeleteDimensionRequest() {
                    Range = new DimensionRange() {
                        SheetId = Sheet.Properties.SheetId,
                        Dimension = "ROWS",
                        StartIndex = 0,
                        EndIndex = Sheet.Properties.GridProperties.RowCount
                    }
                }
            };

            List<Request> RequestContainer = new List<Request>();
            RequestContainer.Add(RequestBody);

            BatchUpdateSpreadsheetRequest BatchUpdate = new BatchUpdateSpreadsheetRequest();
            BatchUpdate.Requests = RequestContainer;

            var Response = Client.SheetsService.Spreadsheets.BatchUpdate(BatchUpdate, SpreadsheetId).Execute();*/

            var RequestBody = new Google.Apis.Sheets.v4.Data.ClearValuesRequest();

            SpreadsheetsResource.ValuesResource.ClearRequest Request = Client.SheetsService.Spreadsheets.Values.Clear(RequestBody, SpreadsheetId, Range);

            var Response = Request.Execute();
        }

        public void Rename(string Name) {
            Request RequestBody = new Request() {
                UpdateSheetProperties = new UpdateSheetPropertiesRequest() {
                    Properties = new SheetProperties() {
                        SheetId = Sheet.Properties.SheetId,
                        Title = Name
                    }
                }
            };

            List<Request> RequestContainer = new List<Request>();
            RequestContainer.Add(RequestBody);

            BatchUpdateSpreadsheetRequest BatchUpdate = new BatchUpdateSpreadsheetRequest();
            BatchUpdate.Requests = RequestContainer;

            var Response = Client.SheetsService.Spreadsheets.BatchUpdate(BatchUpdate, SpreadsheetId).Execute();
        }

        public IRow<T> Add(T e) {
            //  TODO : Find how to add value to a range or sheet.
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
            var Result = new List<IRow<T>>();
            IEnumerable<IList<object>> Rows = ValueRange.Values.Skip(1);

            if(q.Start > 0)
                Rows = Rows.Skip(q.Start);
            if(q.Count > 0) {
                Rows = Rows.Take(q.Count);
            }

            foreach(var Row in Rows) {
                Result.Add(new Row<T>(Client, Row[0].ToString()) { Element = (T)Activator.CreateInstance(typeof(T), Row) });
            }

            return Result;
        }
    }
}