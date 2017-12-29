using System;
using System.Collections.Generic;
using System.Text;

namespace PKMDomainModel_GoogleSheets
{
    class TypeRepository
    {
        private List<Type> _List;
        private Dictionary<Type, Double> _TypeMatchups;
        private static List<Type> _AllTypeList;

        public TypeRepository(List<Type> list) {
            this._List = list;
        }

        public Dictionary<Type, Double> GetAttackingTypeMatchups(List<Type> attackingList) {
            if(this._TypeMatchups != null) {
                return this._TypeMatchups;
            } else {
                //fetch types matchups in db
                return null;
            }
        }

        public static List<Type> GetAllTypes() {
            if (TypeRepository._AllTypeList != null) {
                return TypeRepository._AllTypeList;
            } else {
                //fetch types matchups in db
                return null;
            }
        }
    }
}
