using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Zoulou.Models.MMEG {
    public class CreatureRepository : BaseRepository {
        private IList<IList<object>> Creatures = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Creatures");
        private IList<IList<object>> Elements = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Elements");
        private IList<IList<object>> Roles = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Roles");
        private IList<IList<object>> Skills = ge.getWorksheet("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo", "Skills");

        public Creature getCreatureById(int Id) {
            foreach(var Row in Creatures) {
                if(Row[0].ToString() == Id.ToString()) {
                    return new Creature() {
                        Id = Row[0].ToString().AsInt(),
                        EvolutionId = Row[5].ToString().AsInt(),
                        NameEn = Row[1].ToString(),
                        NameFr = Row[2].ToString(),
                        BaseRank = Row[19].ToString().AsInt(),
                        HP = Row[6].ToString().AsInt(),
                        ATK = Row[7].ToString().AsInt(),
                        DEF = Row[8].ToString().AsInt(),
                        SPD = Row[9].ToString().AsInt(),
                        CRIT = Row[10].ToString().AsInt(),
                        CRITD = Row[11].ToString().AsInt(),
                        ACC = Row[12].ToString().AsInt(),
                        RES = Row[13].ToString().AsInt(),
                        Total = Row[6].ToString().AsInt() + Row[7].ToString().AsInt() + Row[8].ToString().AsInt() + Row[9].ToString().AsInt() + Row[10].ToString().AsInt() + Row[11].ToString().AsInt() + Row[12].ToString().AsInt() + Row[13].ToString().AsInt(),
                        Element = this.getElementById(Row[3].ToString()),
                        Role = this.getRoleById(Row[4].ToString()),
                        Skills = new List<Skill>() {
                            this.getSkillById(Row[14].ToString()),
                            this.getSkillById(Row[15].ToString()),
                            this.getSkillById(Row[16].ToString()),
                            this.getSkillById(Row[17].ToString()),
                            this.getSkillById(Row[18].ToString())
                        }
                    };
                }
            }
            return null;
        }

        public List<Creature> getCreatures() {
            var List = new List<Creature>();

            if(Creatures != null && Creatures.Count > 0) {
                foreach(var Row in Creatures) {
                    List.Add(new Creature() {
                        Id = Row[0].ToString().AsInt(),
                        EvolutionId = Row[5].ToString().AsInt(),
                        NameEn = Row[1].ToString(),
                        NameFr = Row[2].ToString(),
                        BaseRank = Row[19].ToString().AsInt(),
                        HP = Row[6].ToString().AsInt(),
                        ATK = Row[7].ToString().AsInt(),
                        DEF = Row[8].ToString().AsInt(),
                        SPD = Row[9].ToString().AsInt(),
                        CRIT = Row[10].ToString().AsInt(),
                        CRITD = Row[11].ToString().AsInt(),
                        ACC = Row[12].ToString().AsInt(),
                        RES = Row[13].ToString().AsInt(),
                        Total = Row[6].ToString().AsInt() + Row[7].ToString().AsInt() + Row[8].ToString().AsInt() + Row[9].ToString().AsInt() + Row[10].ToString().AsInt() + Row[11].ToString().AsInt() + Row[12].ToString().AsInt() + Row[13].ToString().AsInt(),
                        Element = this.getElementById(Row[3].ToString()),
                        Role = this.getRoleById(Row[4].ToString()),
                        Skills = new List<Skill>() {
                            this.getSkillById(Row[14].ToString()),
                            this.getSkillById(Row[15].ToString()),
                            this.getSkillById(Row[16].ToString()),
                            this.getSkillById(Row[17].ToString()),
                            this.getSkillById(Row[18].ToString())
                        }
                    });
                }
            }

            return List;
        }

        public Element getElementById(string Id) {
            if(Elements != null && Elements.Count > 0) {
                foreach(var Row in Elements) {
                    if(Row[0].ToString() == Id) {
                        return new Element() {
                            Id = Row[0].ToString(),
                            NameEn = Row[1].ToString(),
                            NameFr = Row[2].ToString()
                        };
                    }
                }
            }
            return new Element();
        }

        public Role getRoleById(string Id) {
            if(Roles != null && Roles.Count > 0) {
                foreach(var Row in Roles) {
                    if(Row[0].ToString() == Id) {
                        return new Role() {
                            Id = Row[0].ToString(),
                            NameEn = Row[1].ToString(),
                            NameFr = Row[2].ToString()
                        };
                    }
                }
            }
            return new Role();
        }

        public Skill getSkillById(string Id) {
            if(Skills != null && Skills.Count > 0) {
                foreach(var Row in Skills) {
                    if(Row[0].ToString() == Id) {
                        return new Skill() {
                            Id = Row[0].ToString(),
                            NameEn = Row[1].ToString(),
                            NameFr = Row[2].ToString()
                        };
                    }
                }
            }
            return new Skill();
        }
    }
}