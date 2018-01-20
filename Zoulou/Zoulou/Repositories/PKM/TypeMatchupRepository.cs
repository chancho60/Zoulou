using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Zoulou.GData.Interfaces;
using Zoulou.Repositories;

namespace Zoulou.Models.PKM {
    class TypeMatchupRepository : BaseRepository {
        protected static IList<IRow<TypeMatchup>> TypeMatchups;

        public TypeMatchupRepository() : base("PKM") {
            if (TypeMatchups == null)
                TypeMatchups = Database.GetTable<TypeMatchup>("TypeMatchups").FindAll();
        }

        public List<TypeMatchup> GetTypeMatchups() {
            return TypeMatchups.Select(C => C.Element).ToList();
        }

        public List<TypeMatchup> GetTypeMatchupsFromList(List<Types> types) {
            return null;
        }
    }
}