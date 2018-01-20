using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zoulou.GData.Interfaces;
using Zoulou.Models.PKM;

namespace Zoulou.Repositories.PKM {
    public class PokemonRepository : BaseRepository {
        protected static IList<IRow<Pokemon>> Pokemon;

        public PokemonRepository() : base("PKM") {
            if (Pokemon == null)
                Pokemon = Database.GetTable<Pokemon>("Pokemon").FindAll();
        }

        public List<Pokemon> GetAllPokemon() {
            return Pokemon.Select(C => C.Element).ToList();
        }
    }
}