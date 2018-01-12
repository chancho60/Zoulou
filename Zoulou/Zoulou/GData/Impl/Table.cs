using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Table<T> : ITable<T> where T : new() {
        private readonly DatabaseClient Client;
        private readonly SpreadsheetsResource SpreadSheet;
        private readonly string SpreadsheetId;
        private readonly string SpreadsheetRange;

        public Table(DatabaseClient Client, SpreadsheetsResource SpreadSheet, string SpreadsheetId, string SpreadsheetRange) {
            if(Client == null)
                throw new ArgumentNullException("Client");
            if(SpreadSheet == null)
                throw new ArgumentNullException("SpreadSheet");
            if(SpreadsheetId == null)
                throw new ArgumentNullException("SpreadsheetId");
            if(SpreadsheetRange == null)
                throw new ArgumentNullException("SpreadsheetRange");

            this.Client = Client;
            this.SpreadSheet = SpreadSheet;
            this.SpreadsheetId = SpreadsheetId;
            this.SpreadsheetRange = SpreadsheetRange;
        }

        public void Delete() {
        }

        public void Clear() {
            var Body = new ClearValuesRequest();
            SpreadSheet.Values.Clear(Body, SpreadsheetId, SpreadsheetRange).Execute();
        }

        public void Rename(string Name) {
        }

        public IRow<T> Add(T e) {
            var Body = new ValueRange();
            //Body.Values.Add();
            SpreadSheet.Values.Append(Body, SpreadsheetId, SpreadsheetRange).Execute();

            return new Row<T>("test");
        }

        public IRow<T> Get(int rowNumber) {
            var q = new Query {
                Count = 1,
                Start = rowNumber,
            };
            var results = Find(q);
            if(results.Count == 0)
                return null;
            return results[0];
        }

        public IList<IRow<T>> FindAll() {
            return Find(new Query());
        }

        public IList<IRow<T>> FindAll(int start, int count) {
            return Find(new Query {
                Start = start,
                Count = count,
            });
        }

        public IList<IRow<T>> Find(string query) {
            return Find(new Query { FreeQuery = query });
        }

        public IList<IRow<T>> FindStructured(string query) {
            return Find(new Query { StructuredQuery = query });
        }

        public IList<IRow<T>> FindStructured(string query, int start, int count) {
            return Find(new Query {
                StructuredQuery = query,
                Start = start,
                Count = count,
            });
        }


        public static string SerializeQuery(Query q) {
            var b = new StringBuilder();

            if(q.FreeQuery != null)
                b.Append("q=" + Utils.UrlEncode(q.FreeQuery) + "&");
            if(q.StructuredQuery != null)
                b.Append("sq=" + Utils.UrlEncode(q.StructuredQuery) + "&");
            if(q.Start > 0)
                b.Append("start-index=" + q.Start + "&");
            if(q.Count > 0)
                b.Append("max-results=" + q.Count + "&");
            if(q.Order != null) {
                if(q.Order.ColumnName != null)
                    b.Append("orderby=column:" + Utils.UrlEncode(q.Order.ColumnName) + "&");
                if(q.Order.Descending)
                    b.Append("reverse=true&");
            }

            return b.ToString();
        }

        public IList<IRow<T>> Find(Query q) {
            var Result = new List<IRow<T>>();
            ValueRange Response = SpreadSheet.Values.Get(SpreadsheetId, SpreadsheetRange).Execute();

            foreach(var Row in Response.Values) {
                Result.Add(new Row<T>(Row[0].ToString()) { Element = (T)Activator.CreateInstance(typeof(T), Row) });
            }

            return Result;
        }
    }
}