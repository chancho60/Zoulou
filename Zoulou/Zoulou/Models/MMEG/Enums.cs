using System.ComponentModel.DataAnnotations;

namespace Zoulou.Models.MMEG {
    public enum Elements {
        [Display(Name = "Fire")]
        Fire = 1,
        [Display(Name = "Water")]
        Water = 2,
        [Display(Name = "Air")]
        Air = 3,
        [Display(Name = "Earth")]
        Earth = 4,
        [Display(Name = "Light")]
        Light = 5,
        [Display(Name = "Dark")]
        Dark = 6,
    }

    public enum Rarities {
        [Display(Name = "Blue")]
        Blue = 1,
        [Display(Name = "Green")]
        Green = 2,
        [Display(Name = "Yellow")]
        Yellow = 3,
        [Display(Name = "Purple")]
        Purple = 4,
    }

    public enum Roles {
        [Display(Name = "Attacker")]
        Attacker = 1,
        [Display(Name = "Defender")]
        Defender = 2,
        [Display(Name = "Saboteur")]
        Saboteur = 3,
        [Display(Name = "Support")]
        Support = 4,
    }

    public enum Shapes {
        [Display(Name = "Hexagon")]
        Hexagon = 1,
        [Display(Name = "Square")]
        Square = 2,
        [Display(Name = "Teardrop")]
        Teardrop = 3,
    }

    public enum Stats {
        [Display(Name = "ATK")]
        ATK = 1,
        [Display(Name = "DEF")]
        DEF = 2,
        [Display(Name = "HP")]
        HP = 3,
        [Display(Name = "SPD")]
        SPD = 4,
        [Display(Name = "CRIT")]
        CRIT = 5,
        [Display(Name = "CRITD")]
        CRITD = 6,
        [Display(Name = "ACC")]
        ACC = 7,
        [Display(Name = "RES")]
        RES = 8,
    }
}