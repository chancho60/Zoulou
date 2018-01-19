using System.Collections.Generic;
using System.Web.WebPages;
using Zoulou.GData.Interfaces;
using Zoulou.Models.MMEG;
using System.Linq;
using System.Linq.Dynamic;

namespace Zoulou.Repositories.MMEG {
    public class CreatureRepository : BaseRepository {
        protected ITable<Creature> Table;

        public CreatureRepository() : base("MMEG") {
            Table = Database.GetTable<Creature>("Creature");
        }
        
        public Creature GetCreatureById(string Id) {
            return Table.FindById(Id).Element;
        }

        public List<Creature> GetCreatures() {
            Table.Add(new Creature() { NameEn = "Test", DEF = 10, BaseRank = 1, SPD = 20, HP = 15 });
            return Table.FindAll().Select(C => C.Element).ToList();
        }

        public Skill GetSkillById(string Id) {
            /*if(Skills != null && Skills.Count > 0) {
                foreach(var Row in Skills) {
                    if(Row[0].ToString() == Id) {
                        return new Skill() {
                            Id = Row[0].ToString().AsInt(),
                            NameKey = Row[1].ToString(),
                            DescKey = Row[2].ToString(),
                            Cooldown = Row[3].ToString().AsInt()
                        };
                    }
                }
            }*/
            return new Skill();
        }
    }
}