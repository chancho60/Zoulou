using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Zoulou.Models.PKM {
    class TypeMatchup {
        public Guid Id;
        public Int32 AttackingType;
        public Int32 DefendingType;
        public Double Modifier;

        public TypeMatchup(Dictionary<string, object> NamedRange) {
            Id = Guid.Parse(NamedRange["Id"].ToString());
            AttackingType = NamedRange["AtkType"].ToString().AsInt();
            DefendingType = NamedRange["DefType"].ToString().AsInt();
            Modifier = Double.Parse(NamedRange["Modifier"].ToString());
        }

        public TypeMatchup() {
        }
    }
}