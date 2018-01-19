using Zoulou.Helpers;

namespace Zoulou.Models.MMEG {
    public class Element : Base {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public Element(int Id) {
            this.Id = Id;
            this.Name = ((Elements)Id).ToString();
            this.DisplayName = EnumHelper<Elements>.GetDisplayValue((Elements)Id);
        }
    }
}