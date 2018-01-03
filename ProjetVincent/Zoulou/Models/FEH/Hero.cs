using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.FEH {
    public class Hero : Unit {
        public List<Stat> Stats { get; set; }
        //public List<Skill> Skills { get; set; }
        //public List<IV> IVs { get; set; }
        //public virtual Seal Seal { get; set; }
    }
}