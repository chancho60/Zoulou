using Zoulou.Helpers;

namespace Zoulou.Models.MMEG {
    public class Rarity : Base {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public Rarity(int Id) {
            this.Id = Id;
            this.Name = ((Rarities)Id).ToString();
            this.DisplayName = EnumHelper<Rarities>.GetDisplayValue((Rarities)Id);
        }
    }
}