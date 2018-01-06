using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
    public class StatRepository : BaseRepository {
        IList<IList<object>> Values = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Stats");
        private List<Stat> Stats = new List<Stat>();

        public List<Stat> getStats() {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    Stats.Add(new Stat { StatId = Row[0].ToString(), StatName = Row[1].ToString() });
                }
            }

            return Stats;
        }

        public Stat getStatById(string Id) {
            if(Values != null && Values.Count > 0) {
                foreach(var Row in Values) {
                    if(Row[0].ToString() == Id) {
                        return new Stat { StatId = Row[0].ToString(), StatName = Row[1].ToString() };
                    }
                }
            }

            return new Stat();
        }
    }
}