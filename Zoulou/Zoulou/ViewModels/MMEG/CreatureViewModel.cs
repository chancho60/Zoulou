using System.Collections.Generic;
using Zoulou.GData.Impl;
using Zoulou.GData.Interfaces;
using Zoulou.Models.MMEG;

namespace Zoulou.ViewModels.MMEG {
    public class CreatureViewModel {
        public Creature Creature { get; set; }
        public List<Creature> Creatures { get; set; }
        public List<Creature> CreaturesFiltered { get; set; }
        public Dictionary<string, bool> Elements { get; set; }
        public Dictionary<string, bool> Roles { get; set; }

        public CreatureViewModel() {
            Elements = new Dictionary<string, bool>() { { "1", true }, { "2", true }, { "3", true }, { "4", true }, { "5", false }, { "6", false } };
            Roles = new Dictionary<string, bool>() { { "1", true }, { "2", true }, { "3", true }, { "4", true } };
        }
    }
}