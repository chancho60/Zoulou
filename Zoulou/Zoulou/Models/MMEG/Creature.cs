using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;

namespace Zoulou.Models.MMEG {
    public class Creature : Base {
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
            /*Skills = new List<Skill>() {
                this.getSkillById(Row[16].ToString()),
                this.getSkillById(Row[17].ToString()),
                this.getSkillById(Row[18].ToString()),
                this.getSkillById(Row[19].ToString()),
                this.getSkillById(Row[20].ToString())
            }*/
        }

        public Creature() {

        }

        public virtual Element Element { get; set; }

        public virtual Role Role { get; set; }

        //  TODO : Get Creature Skills
        //public virtual List<Skill> Skills { get; set; }
    }
}