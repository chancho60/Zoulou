using System.Collections.Generic;

namespace Zoulou.Models.MMEG {
    public partial class Glyph : Base {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Modifier { get; set; }

        public virtual Shape Shape { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual Stat Stat { get; set; }

        public Glyph(int Id, int ShapeId, int RarityId, int StatId, int Level) {
            this.Id = Id;
            this.Level = Level;

            this.Shape = new Shape(ShapeId);
            this.Rarity = new Rarity(RarityId);
            this.Stat = new Stat(StatId);
        }

        public Glyph(IList<object> data) {

        }

        public Glyph() {

        }
    }
}