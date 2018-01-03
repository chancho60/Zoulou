using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.MMEG {
    public class RarityRepository : BaseRepository {
        IList<IList<object>> Values = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Rarities");
        private List<Rarity> Rarities = new List<Rarity>();

        public List<Rarity> getRarities() {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    Rarities.Add(new Rarity { RarityId = Row[0].ToString(), RarityName = Row[1].ToString() });
                }
            }

            return Rarities;
        }

        public Rarity getRarityById(string Id) {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    if(Row[0].ToString() == Id) {
                        return new Rarity { RarityId = Row[0].ToString(), RarityName = Row[1].ToString() };
                    }
                }
            }

            return new Rarity();
        }
    }
}