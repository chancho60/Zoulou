using System.Collections.Generic;
using System.Web.WebPages;
using Zoulou.GData.Interfaces;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
    public class CreatureRepository : BaseRepository {
        public CreatureRepository() : base("MMEG") {

        }
        
        public Creature getCreatureById(int Id) {
            /*foreach(var Row in Creatures) {
                if(Row[0].ToString() == Id.ToString()) {
                    return new Creature() {
                        Id = Row[0].ToString().AsInt(),
                        SpeciesId = Row[3].ToString().AsInt(),
                        EvolutionId = Row[6].ToString().AsInt(),
                        EvolutionStage = Row[7].ToString().AsInt(),
                        NameEn = Row[1].ToString(),
                        NameFr = Row[2].ToString(),
                        BaseRank = Row[21].ToString().AsInt(),
                        HP = Row[8].ToString().AsInt(),
                        ATK = Row[9].ToString().AsInt(),
                        DEF = Row[10].ToString().AsInt(),
                        SPD = Row[11].ToString().AsInt(),
                        CRIT = Row[12].ToString().AsInt(),
                        CRITD = Row[13].ToString().AsInt(),
                        ACC = Row[14].ToString().AsInt(),
                        RES = Row[15].ToString().AsInt(),
                        Element = new Element(Row[4].ToString().AsInt()),
                        Role = new Role(Row[5].ToString().AsInt()),
                        Skills = new List<Skill>() {
                            this.getSkillById(Row[16].ToString()),
                            this.getSkillById(Row[17].ToString()),
                            this.getSkillById(Row[18].ToString()),
                            this.getSkillById(Row[19].ToString()),
                            this.getSkillById(Row[20].ToString())
                        }
                    };
                }
            }*/
            return null;
        }

        public IList<IRow<Creature>> getCreatures() {
            var CList = Database.GetTable<Creature>("Creature").FindAll();
            CList[0].Update();

            /*if(Creatures != null && Creatures.Count > 0) {
                foreach(var Row in Creatures) {
                    List.Add(new Creature() {
                        Id = Row[0].ToString().AsInt(),
                        SpeciesId = Row[3].ToString().AsInt(),
                        EvolutionId = Row[6].ToString().AsInt(),
                        EvolutionStage = Row[7].ToString().AsInt(),
                        NameEn = Row[1].ToString(),
                        NameFr = Row[2].ToString(),
                        BaseRank = Row[21].ToString().AsInt(),
                        HP = Row[8].ToString().AsInt(),
                        ATK = Row[9].ToString().AsInt(),
                        DEF = Row[10].ToString().AsInt(),
                        SPD = Row[11].ToString().AsInt(),
                        CRIT = Row[12].ToString().AsInt(),
                        CRITD = Row[13].ToString().AsInt(),
                        ACC = Row[14].ToString().AsInt(),
                        RES = Row[15].ToString().AsInt(),
                        Element = new Element(Row[4].ToString().AsInt()),
                        Role = new Role(Row[5].ToString().AsInt()),
                        Skills = new List<Skill>() {
                            this.getSkillById(Row[16].ToString()),
                            this.getSkillById(Row[17].ToString()),
                            this.getSkillById(Row[18].ToString()),
                            this.getSkillById(Row[19].ToString()),
                            this.getSkillById(Row[20].ToString())
                        }
                    });
                }
            }*/

            //return List;
            return null;
        }

        public Skill getSkillById(string Id) {
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