using System.ComponentModel.DataAnnotations;

namespace Zoulou.Models.PKM {
    public enum Types {
        [Display(Name = "Normal")]
        Normal = 1,
        [Display(Name = "Fire")]
        Fire = 2,
        [Display(Name = "Water")]
        Water = 3,
        [Display(Name = "Electric")]
        Electric = 4,
        [Display(Name = "Grass")]
        Grass = 5,
        [Display(Name = "Ice")]
        Ice = 6,
        [Display(Name = "Fighting")]
        Fighting = 7,
        [Display(Name = "Poison")]
        Poison = 8,
        [Display(Name = "Ground")]
        Ground = 9,
        [Display(Name = "Flying")]
        Flying = 10,
        [Display(Name = "Psychic")]
        Psychic = 11,
        [Display(Name = "Bug")]
        Bug = 12,
        [Display(Name = "Rock")]
        Rock = 13,
        [Display(Name = "Ghost")]
        Ghost = 14,
        [Display(Name = "Dragon")]
        Dragon = 15,
        [Display(Name = "Dark")]
        Dark = 16,
        [Display(Name = "Steel")]
        Steel = 17,
        [Display(Name = "Fairy")]
        Fairy = 18,
    }
}