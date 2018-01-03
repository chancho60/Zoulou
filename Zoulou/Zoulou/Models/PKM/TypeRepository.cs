using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    class TypeRepository : BaseRepository {
        private List<Type> _List;
        private List<TypeMatchup> _TypeMatchups;
        private static List<Type> _AllTypeList;

        public TypeRepository(List<Type> list):base() {
            this._List = list;
        }

        public static List<Type> GetAllTypes() {
            if (TypeRepository._AllTypeList != null) {
                return TypeRepository._AllTypeList;
            }
            else {
                List<Type> resultList = new List<Type>();

                var worksheet = ge.getWorksheet("1ZTO24BwIXAnQQpBx6e37t5Qj7tJjl-HU4Jsn9R4c9c8", "Types");

                for(var i = 1;i < worksheet.Count(); i++) {
                    var row = worksheet[i];

                    var id = Guid.Parse((String)row[0]);
                    var gameId = Guid.Parse((String)row[1]);
                    var nameId = Guid.Parse((String)row[2]);
                    var definitionId = Guid.Parse((String)row[3]);

                    var newType = TypeRepository.InitiateType(new Type(id, nameId, definitionId, gameId));

                    resultList.Add(newType);
                }

                TypeRepository._AllTypeList = resultList;
                return resultList;
            }
        }

        public List<TypeMatchup> GetTypeMatchups() {
            if (this._TypeMatchups != null) {
                return this._TypeMatchups;
            }
            else {
                var worksheet = ge.getWorksheet("1ZTO24BwIXAnQQpBx6e37t5Qj7tJjl-HU4Jsn9R4c9c8", "TypeMatchups");
                List<TypeMatchup> tempTypeMatchups = new List<TypeMatchup>();

                //Create list of concerned types ids
                List<Guid> listTypeIds = new List<Guid>();
                foreach(Type type in this._List) {
                    if (!listTypeIds.Contains(type.TypeId)) {
                        listTypeIds.Add(type.TypeId);
                    }
                }

                //Filter concerned matchups only
                for (var i = 1; i < worksheet.Count(); i++) {
                    var row = worksheet[i];

                    

                    Guid atkTypeId = Guid.Parse(row[1].ToString());
                    Guid defTypeId = Guid.Parse(row[2].ToString());
                    Double modifier = Double.Parse(row[3].ToString().Replace(',', '.'), CultureInfo.InvariantCulture);

                    if (listTypeIds.Contains(atkTypeId) || listTypeIds.Contains(defTypeId)) {
                        tempTypeMatchups.Add(TypeRepository.InitiateTypeMatchup(new TypeMatchup(atkTypeId, defTypeId, modifier)));
                    }
                }

                this._TypeMatchups = tempTypeMatchups;
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
            foreach (var type in TypeRepository.GetAllTypes()) {
                if (matchup.AttackingTypeId == type.TypeId) {
                    matchup.AttackingType = NameRepository.getNameFromId(type.NameId);
                }
                if (matchup.DefendingTypeId == type.TypeId) {
                    matchup.DefendingType = NameRepository.getNameFromId(type.NameId);
                }
            }

            return matchup;
        }
    }
}