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
            int BaseValue = 0;
            int Result = 0;

            if(Stat == "ACC" || Stat == "RES") {
                if(Rarity == "Blue") {
                    BaseValue = 2;
                } else if(Rarity == "Green") {
                    BaseValue = 3;
                } else if(Rarity == "Yellow") {
                    BaseValue = 5;
                } else {
                    BaseValue = 8;
                }

                Result = BaseValue + Level - 1;
            } else if(Stat == "ATK") {
                if(Rarity == "Blue") {
                    BaseValue = (Modifier == "+"? 90 : 2);
                } else if(Rarity == "Green") {
                    BaseValue = (Modifier == "+"? 120 : 2);
                } else if(Rarity == "Yellow") {
                    BaseValue = (Modifier == "+"? 160 : 3);
                } else {
                    BaseValue = (Modifier == "+"? 0 : 0);
                }

                Result = BaseValue;
            } else if(Stat == "DEF") {
                if(Rarity == "Blue") {
                    BaseValue = (Modifier == "+" ? 30 : 2);
                } else if(Rarity == "Green") {
                    BaseValue = (Modifier == "+" ? 45 : 2);
                } else if(Rarity == "Yellow") {
                    BaseValue = (Modifier == "+" ? 60 : 3);
                } else {
                    BaseValue = (Modifier == "+" ? 0 : 0);
                }

                Result = BaseValue;
            } else if(Stat == "HP") {
                if(Rarity == "Blue") {
                    BaseValue = (Modifier == "+" ? 240 : 3);
                } else if(Rarity == "Green") {
                    BaseValue = (Modifier == "+" ? 340 : 3);
                    Result = BaseValue;

                    for(var i = 2; i <= Level; i++) {
                        if(i == 7) {
                            Result += (int)Math.Round(i * 0.4);
                        } else if(i == 10) {
                            Result += (int)Math.Round(i * 0.4);
                        } else if(i == 13) {
                            Result += (int)Math.Round(i * 0.4);
                        } else if(i == 16) {
                            Result += (int)Math.Round(i * 0.4);
                        } else {
                            Result += ((((i - 1) % 9) + 1) % 2) + 1;
                        }
                    }
                } else if(Rarity == "Yellow") {
                    BaseValue = (Modifier == "+" ? 450 : 3);
                } else {
                    BaseValue = (Modifier == "+" ? 0 : 0);
                }                
            }

            return Result;
        }
    }
}