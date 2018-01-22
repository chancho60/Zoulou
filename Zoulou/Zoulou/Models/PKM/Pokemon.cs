using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    public class Pokemon {
        private int _PokemonId;
        private Guid _UnitId;
        private Guid _NameId;
        private Guid _DefinitionId;
        private Guid _GameId;

        private Int16 _Number;
        //private TypeRepository _Types;
        //Repository of Moves
        //Repository of Abilities
        public string Name;
        public int HP;
        public int Atk;
        public int Def;
        public int SpA;
        public int SpD;
        public int Spe;
        public int Total { get { return HP + Atk + Def + SpA + SpD + Spe; } }

        public Pokemon(Dictionary<string, object> NamedRange) {
            //_PokemonId = Int32.Parse(NamedRange["Nat"].ToString());
            Name = NamedRange["Pokemon"].ToString();
            HP = Int32.Parse(NamedRange["HP"].ToString());
            Atk = Int32.Parse(NamedRange["Atk"].ToString());
            Def = Int32.Parse(NamedRange["Def"].ToString());
            SpA = Int32.Parse(NamedRange["SpA"].ToString());
            SpD = Int32.Parse(NamedRange["SpD"].ToString());
            Spe = Int32.Parse(NamedRange["Spe"].ToString());
        }

        public Pokemon() {
        }
    }
}