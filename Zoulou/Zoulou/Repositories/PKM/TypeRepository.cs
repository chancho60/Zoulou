using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Zoulou.Repositories;

namespace Zoulou.Models.PKM {
    class TypeRepository : BaseRepository {
        private List<Type> _List;
        private static List<TypeMatchup> _TypeMatchups;

        public TypeRepository() : base("1wbRWw42EHDwfoO7exgJMEWOv1KmaJM4GIIAfrDep2S8") {

        }

        public TypeRepository(List<Type> list) : base("1wbRWw42EHDwfoO7exgJMEWOv1KmaJM4GIIAfrDep2S8") {
            this._List = list;
        }

        public List<TypeMatchup> GetTypeMatchups() {
            if (TypeRepository._TypeMatchups != null) {
                return TypeRepository._TypeMatchups;
            }
            else {
                //var worksheet = ge.getWorksheet("1ZTO24BwIXAnQQpBx6e37t5Qj7tJjl-HU4Jsn9R4c9c8", "TypeMatchups");
                List<TypeMatchup> tempTypeMatchups = new List<TypeMatchup>();

                var test = this.db.GetTable<TypeMatchup>("TypeMatchups").FindAll();

                foreach( var row in test) {
                    tempTypeMatchups.Add(row.Element);
                }

                return tempTypeMatchups;
            }
        }
        
        //Fetch values from diverse sheets
        private static Type InitiateType(Type type) {
            type.Name = NameRepository.getNameFromId(type.NameId);

            return type;
        }

        //Fetch values from diverse sheets
        private static TypeMatchup InitiateTypeMatchup(TypeMatchup matchup) {
            /*foreach (var type in TypeRepository.GetAllTypes()) {
                if (matchup.AttackingTypeId == type.TypeId) {
                    matchup.AttackingType = NameRepository.getNameFromId(type.NameId);
                }
                if (matchup.DefendingTypeId == type.TypeId) {
                    matchup.DefendingType = NameRepository.getNameFromId(type.NameId);
                }
            }*/

            return matchup;
        }
    }
}