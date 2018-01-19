using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;
using Zoulou.Repositories.MMEG;

namespace Zoulou.Models.MMEG {
    public class Creature : Base {
        private static SkillRepository _SkillRepository;
        private static SkillRepository SkillRepository {
            get {
                return _SkillRepository ??
                    (_SkillRepository = new SkillRepository());
            }
        }

        public int Id { get; set; }
        public int SpeciesId { get; set; }
        public int EvolutionId { get; set; }
        public int EvolutionStage { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public int? BaseRank { get; set; }
        public int? HP { get; set; }
        public int? ATK { get; set; }
        public int? DEF { get; set; }
        public int? SPD { get; set; }
        public int? CRIT { get; set; }
        public int? CRITD { get; set; }
        public int? ACC { get; set; }
        public int? RES { get; set; }
        public int? Total { get { return HP + ATK + DEF + SPD + CRIT + CRITD + ACC + RES; } }

        public Creature(Dictionary<string, object> NamedRange) {
            Id = (NamedRange.ContainsKey("Id")? NamedRange["Id"].ToString().AsInt(): -1);
            SpeciesId = NamedRange["SpeciesId"].ToString().AsInt();
            EvolutionId = NamedRange["EvolutionId"].ToString().AsInt();
            EvolutionStage = NamedRange["EvolutionStage"].ToString().AsInt();
            NameEn = NamedRange["NameEn"].ToString();
            NameFr = NamedRange["NameFr"].ToString();
            BaseRank = NamedRange["BaseRank"].ToString().AsInt();
            HP = NamedRange["HP"].ToString().AsInt();
            ATK = NamedRange["ATK"].ToString().AsInt();
            DEF = NamedRange["DEF"].ToString().AsInt();
            SPD = NamedRange["SPD"].ToString().AsInt();
            CRIT = NamedRange["CRIT"].ToString().AsInt();
            CRITD = NamedRange["CRITD"].ToString().AsInt();
            ACC = NamedRange["ACC"].ToString().AsInt();
            RES = NamedRange["RES"].ToString().AsInt();
            Element = new Element(NamedRange["ElementId"].ToString().AsInt());
            Role = new Role(NamedRange["RoleId"].ToString().AsInt());
            Skills = new List<Skill>() {
                SkillRepository.GetSkillById((NamedRange.ContainsKey("Spell1Id")? NamedRange["Spell1Id"].ToString().AsInt(): -1)),
                SkillRepository.GetSkillById((NamedRange.ContainsKey("Spell1AId")? NamedRange["Spell1AId"].ToString().AsInt(): -1)),
                SkillRepository.GetSkillById((NamedRange.ContainsKey("Spell1BId")? NamedRange["Spell1BId"].ToString().AsInt(): -1)),
                SkillRepository.GetSkillById((NamedRange.ContainsKey("Spell2Id")? NamedRange["Spell2Id"].ToString().AsInt(): -1)),
                SkillRepository.GetSkillById((NamedRange.ContainsKey("Spell3Id")? NamedRange["Spell3Id"].ToString().AsInt(): -1))
            };
        }

        public Creature() {

        }

        public virtual Element Element { get; set; }

        public virtual Role Role { get; set; }

        public virtual List<Skill> Skills { get; set; }
    }
}