using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Zoulou.GData.Impl;
using Zoulou.GData.Interfaces;

namespace Zoulou.GData.Models {
    //public class DatabaseClient : IDatabaseClient {
    public class DatabaseClient {

        public DatabaseClient() {
        }

        public Database CreateDatabase(string name) {
            return new Database(this, "new");
        }

        public Database GetDatabase(string Id) {
            return new Database(this, Id);
        }
    }
}