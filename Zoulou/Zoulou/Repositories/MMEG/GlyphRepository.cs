using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
    public class GlyphRepository : BaseRepository {
        private IList<IList<object>> Glyphs = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Glyphs");
        private IList<IList<object>> Shapes = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Shapes");
        private IList<IList<object>> Stats = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Stats");
        private IList<IList<object>> Rarities = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Rarities");

        public Glyph getGlyphById(string Id) {
            foreach(var Row in Glyphs) {
                if(Row[0].ToString() == Id) {
                    return new Glyph() {
                        GlyphId = Row[0].ToString(),
                        ShapeId = Row[1].ToString(),
                        RarityId = Row[2].ToString(),
                        StatId = Row[3].ToString(),
                        Level = Row[4].ToString()
                    };
                }
            }
            return null;
        }

        /*public List<Glyph> getGlyphs() {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    Glyphs.Add(new Glyph {
                        GlyphId = Row[0].ToString(),
                        Rarity = rar.getRarityById(Row[2].ToString()),
                        Stat = str.getStatById(Row[3].ToString()),
                        Level = Row[4].ToString()
                    });
                }
            }

            return Glyphs;
        }*/
        public List<Shape> getShapes() {
            var ShapeList = new List<Shape>();

            if(Shapes != null && Shapes.Count > 0) {
                foreach(var Row in Shapes) {
                    ShapeList.Add(new Shape {
                        ShapeId = Row[0].ToString(),
                        ShapeName = Row[1].ToString()
                    });
                }
            }

            return ShapeList;
        }

        public List<Rarity> getRarities() {
            var RarityList = new List<Rarity>();

            if(Rarities != null && Rarities.Count > 0) {
                foreach(var Row in Rarities) {
                    RarityList.Add(new Rarity {
                        RarityId = Row[0].ToString(),
                        RarityName = Row[1].ToString()
                    });
                }
            }

            return RarityList;
        }

        public List<Stat> getStats() {
            var StatList = new List<Stat>();

            if(Stats != null && Stats.Count > 0) {
                foreach(var Row in Stats) {
                    StatList.Add(new Stat {
                        StatId = Row[0].ToString(),
                        StatName = Row[1].ToString(),
                        StatModifier = Row[2].ToString()
                    });
                }
            }

            return StatList;
        }
    }
}