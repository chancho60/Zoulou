using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM {
    class Type {
        public Guid TypeId;
        public Guid NameId;
        public Guid DefinitionId;
        public Guid GameId;

        public Type(Guid TypeId) {
            this.TypeId = TypeId;
        }

        public Type(Guid TypeId, Guid NameId, Guid DefinitionId, Guid GameId) {
            this.TypeId = TypeId;
            this.NameId = NameId;
            this.DefinitionId = DefinitionId;
            this.GameId = GameId;
        }

        public String Name { get; set; }
    }
}