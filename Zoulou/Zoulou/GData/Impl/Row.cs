using System.Collections.Generic;
using Google.Apis.Sheets.v4.Data;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Row<T> : IRow<T> where T : new() {
        private readonly DatabaseClient Client;
        public T Element { get; set; }
        public readonly string Id;

        //public Row(DatabaseClient client, string etag, Uri id, Uri edit, ) {
        public Row(DatabaseClient Client, string Id) {
            this.Client = Client;
            this.Id = Id;
        }

        public void Update() {
            //  TODO : Find how to update a row.
            /*Request RequestBody = new Request() {
                UpdateCells = new UpdateCellsRequest() {
                    Range = new GridRange() {
                        SheetId = 0,
                        StartRowIndex = 1,
                        EndRowIndex = 1,
                    }
                }
            };*/
        }

        public void Delete() {
            //  TODO : Find how to delete a row.
            Request RequestBody = new Request() {
                DeleteDimension = new DeleteDimensionRequest() {
                    Range = new DimensionRange() {
                        SheetId = 0,
                        Dimension = "ROWS",
                        StartIndex = 1,
                        EndIndex = 1,
                    }
                }
            };

            List<Request> RequestContainer = new List<Request>();
            RequestContainer.Add(RequestBody);

            BatchUpdateSpreadsheetRequest DeleteRequest = new BatchUpdateSpreadsheetRequest();
            DeleteRequest.Requests = RequestContainer;

            Client.SheetsService.Spreadsheets.BatchUpdate(DeleteRequest, Id).Execute();
        }
    }
}