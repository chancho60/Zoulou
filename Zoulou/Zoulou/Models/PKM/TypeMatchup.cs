using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    class TypeMatchup {
        public Guid AttackingTypeId;
        public String AttackingType;
        public Guid DefendingTypeId;
        public String DefendingType;
        public Double Modifier;

        public TypeMatchup(Guid atkId, Guid defId, Double modifier) {
            this.AttackingTypeId = atkId;
            this.DefendingTypeId = defId;
            this.Modifier = modifier;
        }
    }
}