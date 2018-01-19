using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
    public class SkillRepository : BaseRepository {
        public SkillRepository() : base("1-dg6TbHNRoptK96CvXAa3ULlkKC8H_pOHz1QT0unNTo") {

        }

        public Skill getSkillById(int Id) {
            /*foreach(var Row in Skills) {
                if(Row[0].ToString() == Id.ToString()) {
                    return new Skill() {
                        Id = Row[0].ToString().AsInt(),
                        NameKey = Row[1].ToString(),
                        DescKey = Row[2].ToString(),
                        Cooldown = Row[3].ToString().AsInt(),
                        EffectId = Row[4].ToString().AsInt()
                    };
                }
            }*/
            return null;
        }

        public List<Skill> getSkills() {
            var List = new List<Skill>();

            /*if(Skills != null && Skills.Count > 0) {
                foreach(var Row in Skills) {
                    List.Add(new Skill() {
                        Id = Row[0].ToString().AsInt(),
                        NameKey = Row[1].ToString(),
                        DescKey = Row[2].ToString(),
                        Cooldown = Row[3].ToString().AsInt(),
                        EffectId = Row[4].ToString().AsInt()
                    });
                }
            }*/

            return List;
        }
    }
}