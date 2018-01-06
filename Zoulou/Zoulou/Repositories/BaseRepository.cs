using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Zoulou.Models;

namespace Zoulou.Repositories {
    public partial class BaseRepository {
        public static GoogleEntity ge = new GoogleEntity();
    }
}