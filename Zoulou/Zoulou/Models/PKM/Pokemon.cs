using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    public class Pokemon {
        private Guid _PokemonId;
        private Guid _UnitId;
        private Guid _NameId;
        private Guid _DefinitionId;
        private Guid _GameId;

        private Int16 _Number;
        private TypeRepository _Types;
        //Repository of Moves
        //Repository of Abilities
    }
}