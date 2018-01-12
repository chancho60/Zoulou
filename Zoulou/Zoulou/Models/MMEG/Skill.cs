using System.ComponentModel.DataAnnotations;

namespace Zoulou.Models.MMEG {
    public class Skill : Base {
        [Required]
        public int Id { get; set; }
        public string NameKey { get; set; }
        public string DescKey { get; set; }
        public int Cooldown { get; set; }
        public int EffectId { get; set; }
    }
}