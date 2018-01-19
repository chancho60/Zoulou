using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zoulou.Repositories;

namespace Zoulou.Models {
    class NameRepository : BaseRepository {
        private static Dictionary<Guid, Names> _List;
        public NameRepository() : base("1ZTO24BwIXAnQQpBx6e37t5Qj7tJjl-HU4Jsn9R4c9c8") {

        }

        public static String getNameFromId(Guid id, String lang = "FR") {
            //Init static list
            /*if (NameRepository._List == null) {
                NameRepository._List = new Dictionary<Guid, Names>();
                var worksheet = ge.getWorksheet("1ZTO24BwIXAnQQpBx6e37t5Qj7tJjl-HU4Jsn9R4c9c8", "Names");

                for (var i = 1; i < worksheet.Count(); i++) {
                    var row = worksheet[i];

                    Guid nameId = Guid.Parse(row[0].ToString());

                    NameRepository._List.Add(nameId, new Names(nameId, row[1].ToString(), row[2].ToString()));
                }
            }*/

            //return name
            if (NameRepository._List.ContainsKey(id)) {
                if (lang == "FR") {
                    return NameRepository._List[id].NameFR;
                }
                else {
                    return NameRepository._List[id].NameEN;
                }
            } else {
                return "Name not found";
            }
        }
    }
}