using System.Collections.Generic;
using System.Web.WebPages;
using Zoulou.GData.Interfaces;
using Zoulou.Models.MMEG;
using System.Linq;
using System.Linq.Dynamic;

namespace Zoulou.Repositories.MMEG {
    public class CreatureRepository : BaseRepository {
        protected static IList<IRow<Creature>> Creatures;

        public CreatureRepository() : base("MMEG") {
            if(Creatures == null) 
                Creatures = Database.GetTable<Creature>("Creature").FindAll();
        }
        
        public Creature GetCreatureById(int Id) {
            return Creatures.Where(C => C.Element.Id == Id).Select(C => C.Element).FirstOrDefault();
        }

        public List<Creature> GetCreatures() {
            return Creatures.Select(C => C.Element).ToList();
        }
    }
}