using Zoulou.Helpers;

namespace Zoulou.Models.MMEG {
    public class Stat : Base {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Modifier { get; set; }

        public Stat(int Id) {
            this.Id = Id;
            this.Name = ((Stats)Id).ToString();
            this.DisplayName = EnumHelper<Stats>.GetDisplayValue((Stats)Id);
        }
    }
}