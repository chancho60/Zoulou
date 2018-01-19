using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Zoulou.GData.Impl;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Models;
using Zoulou.Models;

namespace Zoulou.Repositories {
    public partial class BaseRepository {
        protected static DatabaseClient DatabaseClient;
        protected static IDatabase Database;

        public BaseRepository(string SpreadsheetName) {
            if(DatabaseClient == null)
                DatabaseClient = new DatabaseClient("dataentity@formal-fragment-189316.iam.gserviceaccount.com", HttpRuntime.AppDomainAppPath + "Key.json");

            if(Database == null)
                Database = DatabaseClient.GetDatabase(SpreadsheetName);
        }
    }
}