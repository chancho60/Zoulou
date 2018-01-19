using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    class Move {
        private Guid _MoveId;
        private Guid _SkillId;
        private Guid _NameId;
        private Guid _DefinitionId;
        private Guid _GameId;

        //private TypeRepository _Types;
        private Byte _Power;
        private Byte _PP;
        private String _DamageType; //Status, Special or Physical

        //List of effects??
    }
}