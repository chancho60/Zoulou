using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages;

namespace Zoulou.Models.MMEG {
    public class Skill : Base {
        public int Id { get; set; }
        public string NameKey { get; set; }
        public string DescKey { get; set; }
        public int? Cooldown { get; set; }
        public int? EffectId { get; set; }

        public Skill(Dictionary<string, object> NamedRange) {
            Id = (NamedRange.ContainsKey("Id") ? NamedRange["Id"].ToString().AsInt() : -1);
            NameKey = NamedRange["NameKey"].ToString();
            DescKey = NamedRange["DescKey"].ToString();
            Cooldown = NamedRange["Cooldown"].ToString().AsInt();
            EffectId = (NamedRange.ContainsKey("EffectId") ? NamedRange["EffectId"].ToString().AsInt() : -1);
        }

        public Skill() {

        }
    }
}