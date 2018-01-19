using Zoulou.Helpers;

namespace Zoulou.Models.MMEG {
    public class Shape : Base {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public Shape(int Id) {
            this.Id = Id;
            this.Name = ((Shapes)Id).ToString();
            this.DisplayName = EnumHelper<Shapes>.GetDisplayValue((Shapes)Id);
        }
    }
}