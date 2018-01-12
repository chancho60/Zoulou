using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Zoulou.GData.Impl;
using Zoulou.GData.Models;
using Zoulou.Models;

namespace Zoulou.Repositories {
    public partial class BaseRepository {
        protected Database db;

        public BaseRepository(string Id) {
            db = new DatabaseClient().GetDatabase(Id);
        }
    }
}