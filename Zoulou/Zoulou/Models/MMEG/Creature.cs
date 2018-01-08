﻿using System.Collections.Generic;

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

        public virtual Element Element { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Skill> Skills { get; set; }
    }
}