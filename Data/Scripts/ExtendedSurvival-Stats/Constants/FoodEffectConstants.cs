using System;
using System.Collections.Generic;
using static ExtendedSurvival.Stats.StatsConstants;

namespace ExtendedSurvival.Stats
{
    public static class FoodEffectConstants
    {

        [Flags]
        public enum FoodEffects
        {

            None = 0,
            FreshFruit = 1 << 1,
            RawVegetable = 1 << 2,
            WildMushroom = 1 << 3,
            PoisonMushroom = 1 << 4,            
            JuicyRed = 1 << 5,
            StraightFromTheCow = 1 << 6,
            RawMeat = 1 << 7,
            ViscousAndDelicious = 1 << 8,
            GlubGlub = 1 << 9,
            RefreshingJuice = 1 << 10,
            Bubbly = 1 << 11,
            EyesOpen = 1 << 12,
            MariosParty = 1 << 13,
            BreakingTheShell = 1 << 14,
            BreakfastOfChampions = 1 << 15,
            PoPoPo = 1 << 16,
            SooBig = 1 << 17,
            Barbecue = 1 << 18,
            TastyLikeSawdust = 1 << 19,
            Blessed = 1 << 20,
            Sanctified = 1 << 21,
            MamaMia = 1 << 22,
            HooMamaMia = 1 << 23,
            WowMamaMia = 1 << 24,
            SafeVegan = 1 << 25,
            WinterProtection = 1 << 26,
            MomsFood = 1 << 27,
            BalancedDiet = 1 << 28,
            SundayFood = 1 << 29,
            WinterIsComing = 1 << 30,
            
        }

        [Flags]
        public enum FoodEffectsPart2
        {

            None = 0,
            GoombasEnd = 1 << 1,
            GoombasProtection = 1 << 2,
            MouseChoice = 1 << 3,
            BestFriend = 1 << 4,
            SeaCockroach = 1 << 5,
            CampFeeling = 1 << 6,
            ExplosiveJuiciness = 1 << 7,
            GoombasBreath = 1 << 8,
            WinterBreath = 1 << 9,
            FingerLicking = 1 << 10,
            MesmerizingSmell = 1 << 11,
            TastyLikeButter = 1 << 12,
            TastyLikeBeefJerky = 1 << 13,
            ImprovedMetabolism = 1 << 14,
            TastyLikePoop = 1 << 15,
            TastyLikeCharcoal = 1 << 16

        }

        public static Dictionary<FoodEffects, FixedStatDataInfo> FOOD_EFFECTS = new Dictionary<FoodEffects, FixedStatDataInfo>()
        {
            {
                FoodEffects.FreshFruit,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.FreshFruit),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.RawVegetable,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.RawVegetable),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.WildMushroom,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.WildMushroom),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 5 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.PoisonMushroom,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.PoisonMushroom),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 5 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = false
                }
            },
            {
                FoodEffects.JuicyRed,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.JuicyRed),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.StraightFromTheCow,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.StraightFromTheCow),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.RawMeat,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.RawMeat),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = false
                }
            },
            {
                FoodEffects.ViscousAndDelicious,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.ViscousAndDelicious),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.GlubGlub,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.GlubGlub),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.RefreshingJuice,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.RefreshingJuice),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.Bubbly,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.Bubbly),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.EyesOpen,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.EyesOpen),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.MariosParty,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.MariosParty),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.BreakingTheShell,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.BreakingTheShell),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.BreakfastOfChampions,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.BreakfastOfChampions),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.PoPoPo,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.PoPoPo),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.SooBig,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.SooBig),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.Barbecue,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.Barbecue),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.TastyLikeSawdust,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.TastyLikeSawdust),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.Blessed,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.Blessed),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.Sanctified,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.Sanctified),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.MamaMia,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.MamaMia),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.HooMamaMia,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.HooMamaMia),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.WowMamaMia,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.WowMamaMia),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.SafeVegan,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.SafeVegan),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.WinterProtection,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.WinterProtection),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.MomsFood,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.MomsFood),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.BalancedDiet,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.BalancedDiet),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.SundayFood,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.SundayFood),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffects.WinterIsComing,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffects.WinterIsComing),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            }
        };

        public static Dictionary<FoodEffectsPart2, FixedStatDataInfo> FOOD_EFFECTS2 = new Dictionary<FoodEffectsPart2, FixedStatDataInfo>()
        {
            {
                FoodEffectsPart2.GoombasEnd,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.GoombasEnd),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.GoombasProtection,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.GoombasProtection),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.MouseChoice,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.MouseChoice),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.BestFriend,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.BestFriend),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 40 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.SeaCockroach,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.SeaCockroach),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.CampFeeling,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.CampFeeling),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.ExplosiveJuiciness,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.ExplosiveJuiciness),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.GoombasBreath,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.GoombasBreath),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.WinterBreath,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.WinterBreath),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.FingerLicking,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.FingerLicking),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.MesmerizingSmell,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.MesmerizingSmell),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 30 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.TastyLikeButter,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.TastyLikeButter),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.TastyLikeBeefJerky,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.TastyLikeBeefJerky),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.ImprovedMetabolism,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.ImprovedMetabolism),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 20 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.TastyLikePoop,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.TastyLikePoop),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            },
            {
                FoodEffectsPart2.TastyLikeCharcoal,
                new FixedStatDataInfo()
                {
                    Name = GetFoodEffectsDescription(FoodEffectsPart2.TastyLikeCharcoal),
                    CanSelfRemove = true,
                    TimeToSelfRemove = 10 * 60 * 1000,
                    CompleteRemove = true,
                    IsPositive = true
                }
            }
        };

        public static string GetFoodEffectsDescription(FoodEffectsPart2 effect)
        {
            switch (effect)
            {
                case FoodEffectsPart2.GoombasEnd:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_GOOMBASEND_NAME);
                case FoodEffectsPart2.GoombasProtection:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_GOOMBASPROTECTION_NAME);
                case FoodEffectsPart2.MouseChoice:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_MOUSECHOICE_NAME);
                case FoodEffectsPart2.BestFriend:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_BESTFRIEND_NAME);
                case FoodEffectsPart2.SeaCockroach:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_SEACOCKROACH_NAME);
                case FoodEffectsPart2.CampFeeling:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_CAMPFEELING_NAME);
                case FoodEffectsPart2.ExplosiveJuiciness:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_EXPLOSIVEJUICINESS_NAME);
                case FoodEffectsPart2.GoombasBreath:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_GOOMBASBREATH_NAME);
                case FoodEffectsPart2.WinterBreath:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_WINTERBREATH_NAME);
                case FoodEffectsPart2.FingerLicking:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_FINGERLICKING_NAME);
                case FoodEffectsPart2.MesmerizingSmell:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_MESMERIZINGSMELL_NAME);
                case FoodEffectsPart2.TastyLikeButter:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_TASTYLIKEBUTTER_NAME);
                case FoodEffectsPart2.TastyLikeBeefJerky:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_TASTYLIKEBEEFJERKY_NAME);
                case FoodEffectsPart2.ImprovedMetabolism:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_IMPROVEDMETABOLISM_NAME);
                case FoodEffectsPart2.TastyLikePoop:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_TASTYLIKEPOOP_NAME);
                case FoodEffectsPart2.TastyLikeCharcoal:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTSPART2_TASTYLIKECHARCOAL_NAME);
            }
            return "";
        }

        public static string GetFoodEffectsDescription(FoodEffects effect)
        {
            switch (effect)
            {
                case FoodEffects.FreshFruit:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_FRESHFRUIT_NAME);
                case FoodEffects.RawVegetable:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_RAWVEGETABLE_NAME);
                case FoodEffects.WildMushroom:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_WILDMUSHROOM_NAME);
                case FoodEffects.PoisonMushroom:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_POISONMUSHROOM_NAME);
                case FoodEffects.JuicyRed:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_JUICYRED_NAME);
                case FoodEffects.StraightFromTheCow:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_STRAIGHTFROMTHECOW_NAME);
                case FoodEffects.RawMeat:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_RAWMEAT_NAME);
                case FoodEffects.ViscousAndDelicious:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_VISCOUSANDDELICIOUS_NAME);
                case FoodEffects.GlubGlub:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_GLUBGLUB_NAME);
                case FoodEffects.RefreshingJuice:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_REFRESHINGJUICE_NAME);
                case FoodEffects.Bubbly:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_BUBBLY_NAME);
                case FoodEffects.EyesOpen:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_EYESOPEN_NAME);
                case FoodEffects.MariosParty:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_MARIOSPARTY_NAME);
                case FoodEffects.BreakingTheShell:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_BREAKINGTHESHELL_NAME);
                case FoodEffects.BreakfastOfChampions:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_BREAKFASTOFCHAMPIONS_NAME);
                case FoodEffects.PoPoPo:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_POPOPO_NAME);
                case FoodEffects.SooBig:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_SOOBIG_NAME);
                case FoodEffects.Barbecue:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_BARBECUE_NAME);
                case FoodEffects.TastyLikeSawdust:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_TASTYLIKESAWDUST_NAME);
                case FoodEffects.Blessed:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_BLESSED_NAME);
                case FoodEffects.Sanctified:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_SANCTIFIED_NAME);
                case FoodEffects.MamaMia:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_MAMAMIA_NAME);
                case FoodEffects.HooMamaMia:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_HOOMAMAMIA_NAME);
                case FoodEffects.WowMamaMia:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_WOWMAMAMIA_NAME);
                case FoodEffects.SafeVegan:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_SAFEVEGAN_NAME);
                case FoodEffects.WinterProtection:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_WINTERPROTECTION_NAME);
                case FoodEffects.MomsFood:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_MOMSFOOD_NAME);
                case FoodEffects.BalancedDiet:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_BALANCEDDIET_NAME);
                case FoodEffects.SundayFood:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_SUNDAYFOOD_NAME);
                case FoodEffects.WinterIsComing:
                    return LanguageProvider.GetEntry(LanguageEntries.FOODEFFECTS_WINTERISCOMING_NAME);
            }
            return "";
        }

        public static int GetFoodEffectsFeelingLevel(FoodEffects effect)
        {
            return 0;
        }

        public static int GetFoodEffectsTrackLevel(FoodEffects effect)
        {
            return 0;
        }

        public static int GetFoodEffectsFeelingLevel(FoodEffectsPart2 effect)
        {
            return 0;
        }

        public static int GetFoodEffectsTrackLevel(FoodEffectsPart2 effect)
        {
            return 0;
        }

    }

}