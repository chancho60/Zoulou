using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Linq;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;

namespace Zoulou.GData.Impl {
    public class Database : IDatabase {
        private readonly string Id;
        private readonly DatabaseClient Client;
        private readonly GoogleCredential Credential;
        protected static string[] Scopes = new[] {
            DriveService.Scope.Drive,
            DriveService.Scope.DriveFile,
            SheetsService.Scope.Spreadsheets,
        };
        private readonly DriveService DriveService;
        private readonly SheetsService SheetsService;

        public Database(DatabaseClient Client, string Id) {
            this.Id = Id;
            this.Client = Client;
            this.Credential = GoogleCredential.FromFile(HttpRuntime.AppDomainAppPath + "Key.json").CreateScoped(Scopes);

            this.DriveService = new DriveService(new BaseClientService.Initializer {
                HttpClientInitializer = this.Credential,
                ApplicationName = "Zoulou"
            });

            this.SheetsService = new SheetsService(new BaseClientService.Initializer {
                HttpClientInitializer = this.Credential,
                ApplicationName = "Zoulou"
            });
        }

        public ITable<T> CreateTable<T>(string Name) where T : new() {
            return new Table<T>(Client, SheetsService.Spreadsheets, Id, Name);
        }

        public ITable<T> GetTable<T>(string Name) where T : new() {
            return new Table<T>(Client, SheetsService.Spreadsheets, Id, Name);

        }

        public void Delete() {
        }
    }
}