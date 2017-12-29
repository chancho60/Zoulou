using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models {
    public class Names {
        public Guid NameId { get; set; }
        public String NameFR { get; set; }
        public String NameEN { get; set; }

        public Names(Guid nameId, String nameFR, String nameEN) {
            this.NameId = nameId;
            this.NameFR = nameFR;
            this.NameEN = nameEN;
        }
    }
}