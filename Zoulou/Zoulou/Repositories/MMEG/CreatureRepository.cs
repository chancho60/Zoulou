using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
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
                        Element = this.getElementById(Row[4].ToString()),
                        Role = this.getRoleById(Row[5].ToString()),
                        Skills = new List<Skill>() {
                            this.getSkillById(Row[16].ToString()),
                            this.getSkillById(Row[17].ToString()),
                            this.getSkillById(Row[18].ToString()),
                            this.getSkillById(Row[19].ToString()),
                            this.getSkillById(Row[20].ToString())
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
                        Element = this.getElementById(Row[4].ToString()),
                        Role = this.getRoleById(Row[5].ToString()),
                        Skills = new List<Skill>() {
                            this.getSkillById(Row[16].ToString()),
                            this.getSkillById(Row[17].ToString()),
                            this.getSkillById(Row[18].ToString()),
                            this.getSkillById(Row[19].ToString()),
                            this.getSkillById(Row[20].ToString())
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
                            Id = Row[0].ToString().AsInt(),
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
                            Id = Row[0].ToString().AsInt(),
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
                            Id = Row[0].ToString().AsInt(),
                            NameEn = Row[1].ToString(),
                            NameFr = Row[2].ToString(),
                            DescEn = Row[3].ToString(),
                            DescFr = Row[4].ToString(),
                            Cooldown = Row[5].ToString().AsInt()
                        };
                    }
                }
            }
            return new Skill();
        }
    }
}