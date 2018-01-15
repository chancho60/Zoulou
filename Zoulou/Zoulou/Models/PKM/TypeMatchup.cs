using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    class TypeMatchup {
        public Guid Id;
        public int AttackingTypeId;
        public String AttackingType;
        public int DefendingTypeId;
        public String DefendingType;
        public Double Modifier;

        public TypeMatchup() {

        }

        public TypeMatchup(IList<object> Data) {
            
            Id = Guid.Parse(Data[0].ToString());
            AttackingTypeId = Int32.Parse(Data[1].ToString());
            DefendingTypeId = Int32.Parse(Data[2].ToString());
            Modifier = Double.Parse(Data[3].ToString());
        }
    }
}