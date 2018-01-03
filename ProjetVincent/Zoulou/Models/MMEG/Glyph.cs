using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.MMEG {
    public partial class Glyph : Base {
        public string GlyphId { get; set; }
        public string ShapeId { get; set; }
        public string RarityId { get; set; }
        public string StatId { get; set; }
        public string Level { get; set; }

        public virtual Shape Shape { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual Stat Stat { get; set; }
    }
}