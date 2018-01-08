namespace Zoulou.Models.MMEG {
    public class Skill : Base {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameFr { get; set; }
        public string DescEn { get; set; }
        public string DescFr { get; set; }
        public int Cooldown { get; set; }
    }
}