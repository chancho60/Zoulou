using Zoulou.Helpers;

namespace Zoulou.Models.MMEG {
    public class Role : Base {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public Role(int Id) {
            this.Id = Id;
            this.Name = ((Roles)Id).ToString();
            this.DisplayName = EnumHelper<Roles>.GetDisplayValue((Roles)Id);
        }
    }
}