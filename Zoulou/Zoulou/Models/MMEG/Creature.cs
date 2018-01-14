using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;

namespace Zoulou.Models.MMEG {
    public class Creature : Base {
        public int Id;
        public int SpeciesId;
        public int EvolutionId;
        public int EvolutionStage;
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public int BaseRank { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPD { get; set; }
        public int CRIT { get; set; }
        public int CRITD { get; set; }
        public int ACC { get; set; }
        public int RES { get; set; }
        public int Total { get { return HP + ATK + DEF + SPD + CRIT + CRITD + ACC + RES; } set {; } }

        public Creature(IList<object> Data) {
            Id = Data[0].ToString().AsInt();
            SpeciesId = Data[3].ToString().AsInt();
            EvolutionId = Data[6].ToString().AsInt();
            EvolutionStage = Data[7].ToString().AsInt();
            NameEn = Data[1].ToString();
            NameFr = Data[2].ToString();
            BaseRank = Data[21].ToString().AsInt();
            HP = Data[8].ToString().AsInt();
            ATK = Data[9].ToString().AsInt();
            DEF = Data[10].ToString().AsInt();
            SPD = Data[11].ToString().AsInt();
            CRIT = Data[12].ToString().AsInt();
            CRITD = Data[13].ToString().AsInt();
            ACC = Data[14].ToString().AsInt();
            RES = Data[15].ToString().AsInt();
            /*Element = new Element(Row[4].ToString().AsInt());
            Role = new Role(Row[5].ToString().AsInt());
            Skills = new List<Skill>() {
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
        public virtual List<Skill> Skills { get; set; }
    }
}