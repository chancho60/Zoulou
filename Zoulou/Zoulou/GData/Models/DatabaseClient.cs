using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;
using Google.Apis.Sheets.v4.Data;
using Newtonsoft.Json;
using Zoulou.GData.Impl;
using Zoulou.GData.Interfaces;

namespace Zoulou.GData.Models {
    public class DatabaseClient : IDatabaseClient {
        public readonly GDataDBRequestFactory RequestFactory;

        public DatabaseClient(string ServiceAccountEmail, string ServiceAccountCredentialFilePath) {
            if(ServiceAccountEmail == null)
                throw new ArgumentNullException("ServiceAccountEmail");
            if(ServiceAccountCredentialFilePath == null)
                throw new ArgumentNullException("ServiceAccountCredentialFilePath");

            RequestFactory = new GDataDBRequestFactory(ServiceAccountEmail, ServiceAccountCredentialFilePath);
        }

        public IDatabase CreateDatabase(string SpreadsheetName) {
            var Uri = "https://sheets.googleapis.com/v4/spreadsheets/";

            object Obj = new { properties = new {
                    title = SpreadsheetName
                }
            };

            var Content = JsonConvert.SerializeObject(Obj);
            var HttpContent = new StringContent(Content, Encoding.UTF8, "application/json");
            var Request = RequestFactory.GetHttpClient().PostAsync(Uri, HttpContent);
            Request.Wait();

            var SpreadsheetId = RequestFactory.SheetsService.DeserializeResponse<Spreadsheet>(Request.Result).Result.SpreadsheetId;
            if(SpreadsheetId == null)
                return null;

            return new Database(this, SpreadsheetId);
        }

        public IDatabase GetDatabase(string SpreadsheetName) {
            //  TODO : Use SheetsService DeserializeResponse
            var Uri = "https://www.googleapis.com/drive/v3/files?q=mimeType%3D'application%2Fvnd.google-apps.spreadsheet'";

            var RawResponse = RequestFactory.GetHttpClient().GetAsync(Uri).Result.Content.ReadAsStringAsync();
            RawResponse.Wait();
            var XmlResponse = JsonConvert.DeserializeXNode(RawResponse.Result, "drive");

            var SpreadsheetId = ExtractSpreadsheetId(XmlResponse.Elements(), SpreadsheetName);
            if(SpreadsheetId == null)
                return null;

            return new Database(this, SpreadsheetId);
        }

        public static string ExtractSpreadsheetId(IEnumerable<XElement> Entries, string SpreadsheetName) {
            return Entries
                .SelectMany(e => e.Elements("files"))
                .Where(e => e.Element("name").Value == SpreadsheetName)
                .Select(e => e.Element("id").Value)
                .FirstOrDefault();
        }
    }
}