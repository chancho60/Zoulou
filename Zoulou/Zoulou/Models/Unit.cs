using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models {
    public class Unit : Base {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
    }
}