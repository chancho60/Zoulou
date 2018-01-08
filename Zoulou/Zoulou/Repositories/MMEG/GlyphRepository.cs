using System.Collections.Generic;
using System.Web.WebPages;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
    public class GlyphRepository : BaseRepository {
        private IList<IList<object>> Glyphs = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Glyphs");

        public Glyph getGlyphById(string Id) {
            foreach(var Row in Glyphs) {
                if(Row[0].ToString() == Id) {
                    return new Glyph(
                        Row[0].ToString().AsInt(), 
                        Row[1].ToString().AsInt(), 
                        Row[2].ToString().AsInt(), 
                        Row[3].ToString().AsInt(), 
                        Row[4].ToString().AsInt()
                        );
                }
            }
            return null;
        }
    }
}