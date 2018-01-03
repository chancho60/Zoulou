using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.MMEG {
    public class GlyphViewModel {
        public List<Rarity> AvailableRarities { get; set; }
        public List<Shape> AvailableShapes { get; set; }
        public List<Stat> AvailableStats { get; set; }

        public int CalculateStat(string Stat, string Rarity, string Modifier, int Level) {
            var BaseValue = 0.0;
            var Result = 0.0;
            var Step = 0.0;
            var Formula = 0.0;

            if(Stat == "ACC" || Stat == "CRIT" || Stat == "RES") {
                if(Rarity == "Blue") {
                    BaseValue = 2;
                    Step = 1;
                } else if(Rarity == "Green") {
                    BaseValue = 3;
                    Step = 1;
                } else if(Rarity == "Yellow") {
                    BaseValue = 5;
                    Step = 1;
                } else {
                    BaseValue = 8;
                    Step = 1;
                }

                Formula = BaseValue + ((Level - 1) * Step);
            } else if(Stat == "CRITD") {
                if(Rarity == "Blue") {
                    BaseValue = 2;
                    Step = 2;
                    Formula = BaseValue - 1 + ((Level - 1) * Step);
                } else if(Rarity == "Green") {
                    BaseValue = 3;
                    Step = 2.33;
                    Formula = BaseValue + ((Level - 1) * Step);
                } else if(Rarity == "Yellow") {
                    BaseValue = 4;
                    Step = 3;
                    Formula = BaseValue + ((Level - 1) * Step);
                } else {
                    BaseValue = 6;
                    Step = 4;
                    Formula = BaseValue + ((Level - 1) * Step);
                }
            } else if(Stat == "SPD") {
                if(Rarity == "Blue") {
                    BaseValue = 5;
                    Step = 1;
                } else if(Rarity == "Green") {
                    BaseValue = 6;
                    Step = 1;
                } else if(Rarity == "Yellow") {
                    BaseValue = 8;
                    Step = 1;
                } else {
                    BaseValue = 12;
                    Step = 1;
                }

                Formula = BaseValue + ((Level - 1) * Step);
            } else if(Stat == "ATK") {
                if(Rarity == "Blue") {
                    if(Modifier == "%") {
                        BaseValue = 2;
                        Step = 3.846;
                        Formula = 1.01519 + 0.898442 * Level + 0.0301293 * Math.Pow(Level, 2) + 0.000685871 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 90;
                        Step = 18;
                        Formula = 74.1605 + 15.5741 * Level + 0.259259 * Math.Pow(Level, 2) + 0.00617284 * Math.Pow(Level, 3);
                    }
                } else if(Rarity == "Green") {
                    if(Modifier == "%") {
                        BaseValue = 2;
                        Step = 3.125;
                        Formula = 0.888889 + 1.05556 * Level + 0.0555556 * Math.Pow(Level, 2) - 2.05586 * Math.Pow(10, -16) * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 120;
                        Step = 18;
                        Formula = 103.102 + 16.6371 * Level + 0.303351 * Math.Pow(Level, 2) + 0.00514403 * Math.Pow(Level, 3);
                    }
                } else if(Rarity == "Yellow") {
                    if(Modifier == "%") {
                        BaseValue = 3;
                        Step = 0;
                        Formula = 0 + 0 * Level + 0 * Math.Pow(Level, 2) + 0 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 160;
                        Step = 22;
                        Formula = 138.851 + 20.6812 * Level + 0.390212 * Math.Pow(Level, 2) + 0.00617284 * Math.Pow(Level, 3);
                    }
                } else {
                    BaseValue = 0;
                    Step = 0;
                }
            } else if(Stat == "DEF") {
                if(Rarity == "Blue") {
                    if(Modifier == "%") {
                        BaseValue = 2;
                        Step = 3.846;
                        Formula = 1.01519 + 0.898442 * Level + 0.0301293 * Math.Pow(Level, 2) + 0.000685871 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 0;
                        Step = 0;
                        Formula = 0 + 0 * Level + 0 * Math.Pow(Level, 2) + 0 * Math.Pow(Level, 3);
                    }
                } else if(Rarity == "Green") {
                    if(Modifier == "%") {
                        BaseValue = 2;
                        Step = 3.125;
                        Formula = 0.888889 + 1.05556 * Level + 0.0555556 * Math.Pow(Level, 2) - 2.05586 * Math.Pow(10, -16) * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 45;
                        Step = 5;
                        Formula = 39.4437 + 5.48148 * Level + 0.0859788 * Math.Pow(Level, 2) + 0.00308642 * Math.Pow(Level, 3);
                    }
                } else if(Rarity == "Yellow") {
                    if(Modifier == "%") {
                        BaseValue = 3;
                        Step = 0;
                        Formula = 0 + 0 * Level + 0 * Math.Pow(Level, 2) + 0 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 0;
                        Step = 6;
                        Formula = 0 + 0 * Level + 0 * Math.Pow(Level, 2) + 0 * Math.Pow(Level, 3);
                    }
                } else {
                    BaseValue = 0;
                    Step = 0;
                }
            } else if(Stat == "HP") {
                if(Rarity == "Blue") {
                    if(Modifier == "%") {
                        BaseValue = 3;
                        Step = 3.03;
                        Formula = 1.90633 + 1.13463 * Level + 0.0121987 * Math.Pow(Level, 2) + 0.00240055 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 240;
                        Step = 28;
                        Formula = 207.827 + 31.3414 * Level + 0.674456 * Math.Pow(Level, 2) + 0.0219479 * Math.Pow(Level, 3);
                    }
                } else if(Rarity == "Green") {
                    if(Modifier == "%") {
                        BaseValue = 3;
                        Step = 2.703;
                        Formula = 1.97394 + 0.878895 * Level + 0.1092 * Math.Pow(Level, 2) - 0.00171468 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 340;
                        Step = 36;
                        Formula = 297.804 + 41.1296 * Level + 1.01323 * Math.Pow(Level, 2) + 0.0246914 * Math.Pow(Level, 3);
                    }
                } else if(Rarity == "Yellow") {
                    if(Modifier == "%") {
                        BaseValue = 3;
                        Step = 4;
                        Formula = 1.18705 + 1.7938 * Level + 0.0236626 * Math.Pow(Level, 2) + 0.00342936 * Math.Pow(Level, 3);
                    } else {
                        BaseValue = 450;
                        Step = 40;
                        Formula = 399.014 + 49.7963 * Level + 1.11243 * Math.Pow(Level, 2) + 0.0339506 * Math.Pow(Level, 3);
                    }
                } else {
                    BaseValue = 0;
                    Step = 0;
                }
            }

            for(var i = 1; i <= Level; i++) {
                if(i == 1) {
                    Result = Formula;
                } else if(i == 4) {
                    Result = Formula;
                } else if(i == 7) {
                    Result = Formula;
                } else if(i == 10) {
                    Result = Formula;
                } else if(i == 13) {
                    Result = Formula;
                } else if(i == 16) {
                    Result = Formula;
                } else {
                    Result += Step;
                }
            }

            return (int)Math.Round(Result);
        }
    }
}