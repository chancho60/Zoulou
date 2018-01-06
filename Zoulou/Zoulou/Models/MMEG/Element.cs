using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.MMEG {
    public class Element : Base {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
    }
}