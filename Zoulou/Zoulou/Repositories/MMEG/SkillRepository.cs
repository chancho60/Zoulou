using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;
using Zoulou.GData.Interfaces;
using Zoulou.Models.MMEG;

namespace Zoulou.Repositories.MMEG {
    public class SkillRepository : BaseRepository {
        protected static IList<IRow<Skill>> Skills;

        public SkillRepository() : base("MMEG") {
            if(Skills == null)
                Skills = Database.GetTable<Skill>("Skill").FindAll();
        }

        public Skill GetSkillById(int Id) {
            return Skills.Where(C => C.Element.Id == Id).Select(C => C.Element).FirstOrDefault();
        }

        public List<Skill> getSkills() {
            return Skills.Select(C => C.Element).ToList();
        }
    }
}