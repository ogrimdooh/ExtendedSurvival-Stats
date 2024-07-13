using Sandbox.Game.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VRage.Game.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{

    public static class PlayerActionsController
    {

        public static void ProcessEffectsTimers(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, long timePassed)
        {
            RefreshPlayerStatComponent(playerId, statComponent);

            var weatherInfo = PlayerWeatherController.ProcessPlayerWeather(playerId, character);

            if (timePassed > 0)
            {
                var playerStats = GetStatsEasyAcess(playerId);
                if (playerStats == null)
                    return;
                var armor = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
                PlayerWoundedController.IncDecWoundedTimer(playerId, timePassed, statsEasyAcess[playerId]);
                PlayerTemperatureController.IncDevTemperatureTimer(playerStats, playerId, timePassed, weatherInfo, armor);
                PlayerShieldController.UpdateShieldStats(playerStats, armor, playerId);
            }

            PlayerDiseaseController.CheckIfGetDiseases(playerId);
            PlayerMetabolismController.CheckAllDigestionStats(playerId);
            PlayerFatigueController.CheckFatigue(playerId, statsEasyAcess[playerId]);
            PlayerOxygenController.CheckOxygenValue(playerId, character, weatherInfo.CurrentEnvironmentType);
        }

        public static bool CheckChance(float chance)
        {
            return MyUtils.GetRandomFloat(0, 1) <= chance;
        }

        public static void DoProcessPlayerRemoveFixedEffect(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, string id, byte stack, bool max)
        {
            try
            {
                RefreshPlayerStatComponent(playerId, statComponent);
                var playerStats = GetStatsEasyAcess(playerId);
                if (playerStats == null)
                    return;
                StatsConstants.DamageEffects effect = StatsConstants.DamageEffects.None;
                if (StatsConstants.IsStringInFlag(id, out effect))
                {
                    if (!playerStats.MedicalDetector.HasAnyEffect() && !PlayerDeathController.PlayerHasDied(playerId))
                    {
                        if (StatsConstants.ON_SELFREMOVE_APPLY_DAMAGE.ContainsKey(effect))
                        {
                            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.ON_SELFREMOVE_APPLY_DAMAGE[effect].ToString(), 0, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
            }
        }

        private static ConcurrentDictionary<long, PlayerStatsEasyAcess> statsEasyAcess = new ConcurrentDictionary<long, PlayerStatsEasyAcess>();

        public static PlayerStatsEasyAcess GetStatsEasyAcess(long playerId)
        {
            if (statsEasyAcess.ContainsKey(playerId) && statsEasyAcess[playerId].IsValid)
                return statsEasyAcess[playerId];
            return null;
        }

        public static void RefreshPlayerStatComponent(long playerId, MyCharacterStatComponent statComponent)
        {
            if (!statsEasyAcess.ContainsKey(playerId))
                statsEasyAcess[playerId] = new PlayerStatsEasyAcess(playerId, statComponent);
            else
                statsEasyAcess[playerId].StatComponent = statComponent;
        }

        public static void DoPlayerCycle(long playerId, long spendTime, MyCharacterStatComponent statComponent)
        {
            RefreshPlayerStatComponent(playerId, statComponent);

            PlayerMetabolismController.DoDigestion(playerId, spendTime, statsEasyAcess[playerId]);

            StaminaController.ClearSpendedStamina(playerId);
            PlayerDeathController.ClearWaitFullCycle(playerId);
        }

        public enum ValueModifierGroup
        {

            SurvivalEffects = 1,
            DamageEffects = 2,
            TemperatureEffects = 3,
            DiseaseEffects = 4,
            OtherEffects = 5,
            FoodEffects = 6,
            FoodEffectsPart2 = 7

        }

        public sealed class PlayerValueModifierEntry
        {

            public ValueModifierGroup Group { get; set; }
            public int Key { get; set; }
            public bool Negative { get; set; }
            public bool UseStacks { get; set; }
            public float BaseValue { get; set; }

            private int GetStacks(long playerId)
            {
                switch (Group)
                {
                    case ValueModifierGroup.SurvivalEffects:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((StatsConstants.SurvivalEffects)Key).ToString());
                    case ValueModifierGroup.DamageEffects:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((StatsConstants.DamageEffects)Key).ToString());
                    case ValueModifierGroup.TemperatureEffects:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((StatsConstants.TemperatureEffects)Key).ToString());
                    case ValueModifierGroup.DiseaseEffects:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((StatsConstants.DiseaseEffects)Key).ToString());
                    case ValueModifierGroup.OtherEffects:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((StatsConstants.OtherEffects)Key).ToString());
                    case ValueModifierGroup.FoodEffects:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((FoodEffectConstants.FoodEffects)Key).ToString());
                    case ValueModifierGroup.FoodEffectsPart2:
                        return AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, ((FoodEffectConstants.FoodEffectsPart2)Key).ToString());
                }
                return 1;
            }

            public float DoCalc(long playerId, PlayerStatsEasyAcess statsEasyAcess)
            {
                float finalValue = 0;
                switch (Group)
                {
                    case ValueModifierGroup.SurvivalEffects:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentSurvivalEffects, (StatsConstants.SurvivalEffects)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                    case ValueModifierGroup.DamageEffects:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, (StatsConstants.DamageEffects)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                    case ValueModifierGroup.TemperatureEffects:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentTemperatureEffects, (StatsConstants.TemperatureEffects)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                    case ValueModifierGroup.DiseaseEffects:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentDiseaseEffects, (StatsConstants.DiseaseEffects)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                    case ValueModifierGroup.OtherEffects:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentOtherEffects, (StatsConstants.OtherEffects)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                    case ValueModifierGroup.FoodEffects:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentFoodEffects, (FoodEffectConstants.FoodEffects)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                    case ValueModifierGroup.FoodEffectsPart2:
                        if (StatsConstants.IsFlagSet(statsEasyAcess.CurrentFoodEffectsPart2, (FoodEffectConstants.FoodEffectsPart2)Key))
                        {
                            finalValue = BaseValue;
                        }
                        break;
                }
                if (finalValue != 0 && UseStacks)
                {
                    finalValue *= GetStacks(playerId);
                }
                if (Negative)
                {
                    finalValue *= -1;
                }
                return finalValue;
            }

        }

        public sealed class PlayerValueModifier
        {

            public PlayerValueModifierEntry[] Entries { get; set; }
            public float BaseValue { get; set; } = 1;
            public bool HasMinValue { get; set; } = true;
            public float MinValue { get; set; } = 0;
            public bool HasMaxValue { get; set; }
            public float MaxValue { get; set; }
            public string DisplayName { get; set; }
            public Func<float, string> FormatValueDelegate { get; set; }
            
            public float DoCalc(long playerId)
            {
                var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
                var finalValue = BaseValue + Entries.Sum(x => x.DoCalc(playerId, statsEasyAcess));
                if (HasMinValue)
                {
                    finalValue = Math.Max(finalValue, MinValue);
                }
                if (HasMaxValue)
                {
                    finalValue = Math.Min(finalValue, MaxValue);
                }
                return finalValue;
            }

        }

        private static readonly Dictionary<HealthController.HealthValueModifier, PlayerValueModifier> HealthModifiers = new Dictionary<HealthController.HealthValueModifier, PlayerValueModifier>()
        {
            {
                HealthController.HealthValueModifier.RegenerationFactor,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.HEALTHVALUEMODIFIER_REGENERATIONFACTOR_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Contusion,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Wounded,
                            Negative = true,
                            BaseValue =  0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.DeepWounded,
                            Negative = true,
                            BaseValue =  0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.BrokenBones,
                            Negative = true,
                            BaseValue =  0.7f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Infected,
                            Negative = true,
                            BaseValue =  0.25f,
                            UseStacks = true
                        }
                    }
                }
            },
            {
                HealthController.HealthValueModifier.MaximumRegenerationHealth,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.HEALTHVALUEMODIFIER_MAXIMUMREGENERATIONHEALTH_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Contusion,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Wounded,
                            Negative = true,
                            BaseValue =  0.4f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.DeepWounded,
                            Negative = true,
                            BaseValue =  0.6f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.BrokenBones,
                            Negative = true,
                            BaseValue =  0.8f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Infected,
                            Negative = true,
                            BaseValue =  0.05f,
                            UseStacks = true
                        }
                    }
                }
            },
            {
                HealthController.HealthValueModifier.MaxHealth,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.HEALTHVALUEMODIFIER_MAXHEALTH_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Contusion,
                            Negative = true,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Wounded,
                            Negative = true,
                            BaseValue =  0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.DeepWounded,
                            Negative = true,
                            BaseValue =  0.45f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.BrokenBones,
                            Negative = true,
                            BaseValue =  0.6f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Infected,
                            Negative = true,
                            BaseValue =  0.05f,
                            UseStacks = true
                        }
                    }
                }
            }
        };

        private static readonly Dictionary<StaminaController.StaminaValueModifier, PlayerValueModifier> StaminaModifiers = new Dictionary<StaminaController.StaminaValueModifier, PlayerValueModifier>()
        {
            {
                StaminaController.StaminaValueModifier.HigherStaminaExpenditure,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.STAMINAVALUEMODIFIER_HIGHERSTAMINAEXPENDITURE_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Thirsty,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Dehydrating,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Hungry,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Famished,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.FullStomach,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.StomachBursting,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.FullGut,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.GutBurst,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.FullBladder,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.BladderBurst,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.Overheating,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.OnFire,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.Cold,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.Frosty,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Queasy,
                            BaseValue = 0.15f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Dysentery,
                            BaseValue = 0.3f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Starvation,
                            BaseValue = 0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereStarvation,
                            BaseValue = 0.4f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Obesity,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereObesity,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Rickets,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereRickets,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.OtherEffects,
                            Key = (int)StatsConstants.OtherEffects.PoopOnClothes,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.OtherEffects,
                            Key = (int)StatsConstants.OtherEffects.PeeOnClothes,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RawMeat,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.EyesOpen,
                            Negative = true,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MariosParty,
                            Negative = true,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasEnd,
                            Negative = true,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasProtection,
                            Negative = true,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasBreath,
                            Negative = true,
                            BaseValue = 0.5f
                        }
                    }
                }
            },
            {
                StaminaController.StaminaValueModifier.MaximumStaminaReduction,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.STAMINAVALUEMODIFIER_MAXIMUMSTAMINAREDUCTION_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Disoriented,
                            BaseValue = 0.25f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Suffocation,
                            BaseValue = 0.5f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Tired,
                            BaseValue = 0.25f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.ExtremelyTired,
                            BaseValue = 0.5f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Contusion,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Wounded,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.DeepWounded,
                            Negative = true,
                            BaseValue =  0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.BrokenBones,
                            Negative = true,
                            BaseValue =  0.4f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Flu,
                            Negative = true,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Pneumonia,
                            Negative = true,
                            BaseValue =  0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Infected,
                            Negative = true,
                            BaseValue =  0.15f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Obesity,
                            Negative = true,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereObesity,
                            Negative = true,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Rickets,
                            Negative = true,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereRickets,
                            Negative = true,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Hypolipidemia,
                            Negative = true,
                            BaseValue = 0.5f
                        }
                    }
                }
            },
            {
                StaminaController.StaminaValueModifier.LongerStaminaRechargeTime,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.STAMINAVALUEMODIFIER_LONGERSTAMINARECHARGETIME_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Disoriented,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Suffocation,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.FullStomach,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.StomachBursting,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.FullGut,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.GutBurst,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.FullBladder,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.BladderBurst,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Tired,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.ExtremelyTired,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Queasy,
                            BaseValue = 0.25f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Dysentery,
                            BaseValue = 0.5f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Hypolipidemia,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.OtherEffects,
                            Key = (int)StatsConstants.OtherEffects.PeeOnClothes,
                            BaseValue = 0.075f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.OtherEffects,
                            Key = (int)StatsConstants.OtherEffects.PoopOnClothes,
                            BaseValue = 0.15f
                        }
                    }
                }
            },
            {
                StaminaController.StaminaValueModifier.StaminaRegeneration,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.STAMINAVALUEMODIFIER_STAMINAREGENERATION_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Contusion,
                            Negative = true,
                            BaseValue = 0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.Wounded,
                            Negative = true,
                            BaseValue = 0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.DeepWounded,
                            Negative = true,
                            BaseValue = 0.3f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DamageEffects,
                            Key = (int)StatsConstants.DamageEffects.BrokenBones,
                            Negative = true,
                            BaseValue = 0.4f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RawVegetable,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.StraightFromTheCow,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.ViscousAndDelicious,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.EyesOpen,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BreakingTheShell,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.PoPoPo,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Blessed,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SafeVegan,
                            BaseValue = 0.75f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WinterIsComing,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MouseChoice,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.ImprovedMetabolism,
                            BaseValue = 0.75f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Sanctified,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.HooMamaMia,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WinterProtection,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.WinterBreath,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.FingerLicking,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MesmerizingSmell,
                            BaseValue = 0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.BestFriend,
                            BaseValue = 0.5f
                        }
                    }
                }
            },
            {
                StaminaController.StaminaValueModifier.MaximumStaminaBonus,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.STAMINAVALUEMODIFIER_MAXIMUMSTAMINABONUS_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return ((int)value).ToString();
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.FreshFruit,
                            BaseValue =  50f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.StraightFromTheCow,
                            BaseValue =  50f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikePoop,
                            BaseValue =  25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikeCharcoal,
                            BaseValue =  25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RefreshingJuice,
                            BaseValue =  100f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Bubbly,
                            BaseValue =  50f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.EyesOpen,
                            BaseValue =  75f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BreakfastOfChampions,
                            BaseValue =  125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MouseChoice,
                            BaseValue =  100f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikeButter,
                            BaseValue =  200f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SooBig,
                            BaseValue =  100f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.FingerLicking,
                            BaseValue =  100f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MesmerizingSmell,
                            BaseValue =  100f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.BestFriend,
                            BaseValue =  100f
                        }
                    }
                }
            },
            {
                StaminaController.StaminaValueModifier.IncreasedFatigue,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.STAMINAVALUEMODIFIER_INCREASEDFATIGUE_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.PoisonMushroom,
                            BaseValue =  0.25f,
                            Negative = false
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WildMushroom,
                            BaseValue =  0.25f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MariosParty,
                            BaseValue =  0.5f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasEnd,
                            BaseValue =  0.75f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasProtection,
                            BaseValue =  0.75f,
                            Negative = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasBreath,
                            BaseValue =  0.75f,
                            Negative = true
                        }
                    }
                }
            }
        };

        private static readonly Dictionary<StatsConstants.ValidStats, PlayerValueModifier> ValidStatsModifiers = new Dictionary<StatsConstants.ValidStats, PlayerValueModifier>()
        {
            {
                StatsConstants.ValidStats.BodyWater,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.BODYWATER_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Thirsty,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Dehydrating,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.Overheating,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.OnFire,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Queasy,
                            BaseValue = 0.075f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Dysentery,
                            BaseValue = 0.075f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Dehydration,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereDehydration,
                            BaseValue = 0.3f
                        }
                    }
                }
            },
            {
                StatsConstants.ValidStats.BodyCalories,
                new PlayerValueModifier()
                {
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.BODYCALORIES_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Hungry,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.SurvivalEffects,
                            Key = (int)StatsConstants.SurvivalEffects.Famished,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.Cold,
                            BaseValue = 0.125f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.TemperatureEffects,
                            Key = (int)StatsConstants.TemperatureEffects.Frosty,
                            BaseValue = 0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Queasy,
                            BaseValue = 0.075f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Dysentery,
                            BaseValue = 0.075f,
                            UseStacks = true
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.Starvation,
                            BaseValue = 0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.DiseaseEffects,
                            Key = (int)StatsConstants.DiseaseEffects.SevereStarvation,
                            BaseValue = 0.3f
                        }
                    }
                }
            }
        };

        private static readonly Dictionary<PlayerMetabolismController.MetabolismValueModifier, PlayerValueModifier> MetabolismModifiers = new Dictionary<PlayerMetabolismController.MetabolismValueModifier, PlayerValueModifier>()
        {
            {
                PlayerMetabolismController.MetabolismValueModifier.WaterConsumption,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.METABOLISMVALUEMODIFIER_WATERCONSUMPTION_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.FreshFruit,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RawMeat,
                            Negative = false,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.JuicyRed,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.ViscousAndDelicious,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.SeaCockroach,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.CampFeeling,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.ExplosiveJuiciness,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikeCharcoal,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RefreshingJuice,
                            Negative = true,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Bubbly,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MariosParty,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BreakingTheShell,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MamaMia,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SafeVegan,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasEnd,
                            Negative = true,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikeButter,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.ImprovedMetabolism,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.HooMamaMia,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WowMamaMia,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BalancedDiet,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasProtection,
                            Negative = true,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasBreath,
                            Negative = true,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.WinterBreath,
                            Negative = true,
                            BaseValue =  0.1f
                        }
                    }
                }
            },
            {
                PlayerMetabolismController.MetabolismValueModifier.EnergyConsumption,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = LanguageProvider.GetEntry(LanguageEntries.METABOLISMVALUEMODIFIER_ENERGYCONSUMPTION_NAME),
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RawVegetable,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RawMeat,
                            Negative = false,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.JuicyRed,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.GlubGlub,
                            Negative = true,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikePoop,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MamaMia,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SafeVegan,
                            Negative = true,
                            BaseValue =  0.4f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WinterIsComing,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikeBeefJerky,
                            Negative = true,
                            BaseValue =  0.1f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.HooMamaMia,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WowMamaMia,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BalancedDiet,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WinterProtection,
                            Negative = true,
                            BaseValue =  0.2f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.WinterBreath,
                            Negative = true,
                            BaseValue =  0.2f
                        }
                    }
                }
            }
        };

        private static readonly Dictionary<ArmorSystemConstants.DamageType, PlayerValueModifier> ResistencesModifiers = new Dictionary<ArmorSystemConstants.DamageType, PlayerValueModifier>()
        {
            {
                ArmorSystemConstants.DamageType.Creature,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_CREATURE_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Barbecue,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Sanctified,
                            BaseValue =  0.25f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Fall,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_FALL_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Barbecue,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Blessed,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SundayFood,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MouseChoice,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Sanctified,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WinterProtection,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.FingerLicking,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.BestFriend,
                            BaseValue =  0.25f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Environment,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_ENVIRONMENT_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.SeaCockroach,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Blessed,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Sanctified,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WinterProtection,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.FingerLicking,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.BestFriend,
                            BaseValue =  0.25f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Fire,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_FIRE_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.CampFeeling,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SooBig,
                            BaseValue =  0.25f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Explosion,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_EXPLOSION_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.ExplosiveJuiciness,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BreakfastOfChampions,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MomsFood,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SundayFood,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SooBig,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BalancedDiet,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasBreath,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.WinterBreath,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MesmerizingSmell,
                            BaseValue =  0.25f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Bullet,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_BULLET_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.PoPoPo,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MomsFood,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SundayFood,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.SooBig,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WowMamaMia,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BalancedDiet,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.GoombasProtection,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.MesmerizingSmell,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.BestFriend,
                            BaseValue =  0.25f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Radioactivity,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_RADIOACTIVITY_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Tool,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_TOOL_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Toxicity,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_TOXICITY_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            },
            {
                ArmorSystemConstants.DamageType.Other,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.DAMAGETYPE_OTHER_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_RESISTANCE_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            }
        };

        private static readonly Dictionary<ArmorSystemConstants.ArmorEffect, PlayerValueModifier> ArmorEffectsModifiers = new Dictionary<ArmorSystemConstants.ArmorEffect, PlayerValueModifier>()
        {
            {
                ArmorSystemConstants.ArmorEffect.Gathering,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_GATHERING_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_BONUS_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.TastyLikeSawdust,
                            BaseValue =  0.05f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.RefreshingJuice,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.Bubbly,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BreakfastOfChampions,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.PoPoPo,
                            BaseValue =  0.15f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffectsPart2,
                            Key = (int)FoodEffectConstants.FoodEffectsPart2.TastyLikeBeefJerky,
                            BaseValue =  0.5f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.ArmorEffect.HandWeaponDamage,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_HANDWEAPONDAMAGE_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_BONUS_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.BreakingTheShell,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.MamaMia,
                            BaseValue =  0.25f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.HooMamaMia,
                            BaseValue =  0.5f
                        },
                        new PlayerValueModifierEntry()
                        {
                            Group = ValueModifierGroup.FoodEffects,
                            Key = (int)FoodEffectConstants.FoodEffects.WowMamaMia,
                            BaseValue =  0.5f
                        }
                    }
                }
            },
            {
                ArmorSystemConstants.ArmorEffect.CreatureDamage,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_CREATUREDAMAGE_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_BONUS_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            },
            {
                ArmorSystemConstants.ArmorEffect.TorporBonus,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_TORPORBONUS_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_BONUS_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            },
            {
                ArmorSystemConstants.ArmorEffect.CargoLoad,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_CARGOLOAD_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_BONUS_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            },
            {
                ArmorSystemConstants.ArmorEffect.MovementSpeed,
                new PlayerValueModifier()
                {
                    BaseValue = 0,
                    HasMinValue = false,
                    DisplayName = $"{LanguageProvider.GetEntry(LanguageEntries.ARMOREFFECT_MOVEMENTSPEED_NAME)} {LanguageProvider.GetEntry(LanguageEntries.TERMS_BONUS_NAME)}",
                    FormatValueDelegate = (value) =>
                    {
                        return value.ToString("P1");
                    },
                    Entries = new PlayerValueModifierEntry[]
                    {

                    }
                }
            }
        };

        public static float StatsMultiplier(long playerId, PlayerMetabolismController.MetabolismValueModifier option)
        {
            if (MetabolismModifiers.ContainsKey(option))
            {
                return MetabolismModifiers[option].DoCalc(playerId);
            }
            return 1;
        }

        public static float StatsMultiplier(long playerId, HealthController.HealthValueModifier option)
        {
            if (HealthModifiers.ContainsKey(option))
            {
                return HealthModifiers[option].DoCalc(playerId);
            }
            return 1;
        }

        public static float StatsMultiplier(long playerId, StaminaController.StaminaValueModifier option)
        {
            if (StaminaModifiers.ContainsKey(option))
            {
                return StaminaModifiers[option].DoCalc(playerId);
            }
            return 1;
        }

        public static float StatsMultiplier(long playerId, StatsConstants.ValidStats option)
        {
            if (ValidStatsModifiers.ContainsKey(option))
            {
                return ValidStatsModifiers[option].DoCalc(playerId);
            }
            return 1;
        }

        public static float StatsMultiplier(long playerId, ArmorSystemConstants.DamageType option)
        {
            if (ResistencesModifiers.ContainsKey(option))
            {
                return ResistencesModifiers[option].DoCalc(playerId);
            }
            return 1;
        }

        public static float StatsMultiplier(long playerId, ArmorSystemConstants.ArmorEffect option)
        {
            if (ArmorEffectsModifiers.ContainsKey(option))
            {
                return ArmorEffectsModifiers[option].DoCalc(playerId);
            }
            return 1;
        }

        public class StatMultiplierInfo
        {

            public string Name { get; set; }
            public float Value { get; set; }
            public string FormatedValue { get; set; }

        }

        private static ConcurrentDictionary<FoodEffectConstants.FoodEffects, StatMultiplierInfo[]> _statMultiplierInfoByFoodEffectsCache = new ConcurrentDictionary<FoodEffectConstants.FoodEffects, StatMultiplierInfo[]>();
        private static ConcurrentDictionary<FoodEffectConstants.FoodEffectsPart2, StatMultiplierInfo[]> _statMultiplierInfoByFoodEffectsCache2 = new ConcurrentDictionary<FoodEffectConstants.FoodEffectsPart2, StatMultiplierInfo[]>();

        public static StatMultiplierInfo[] GetStatMultiplierInfo(FoodEffectConstants.FoodEffectsPart2 foodEffect)
        {
            if (_statMultiplierInfoByFoodEffectsCache2.ContainsKey(foodEffect))
                return _statMultiplierInfoByFoodEffectsCache2[foodEffect];
            var retorno = new List<StatMultiplierInfo>();
            /* HealthModifiers */
            foreach (var key in HealthModifiers.Keys)
            {
                if (HealthModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect))
                {
                    var target = HealthModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = HealthModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = HealthModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* StaminaModifiers */
            foreach (var key in StaminaModifiers.Keys)
            {
                if (StaminaModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect))
                {
                    var target = StaminaModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = StaminaModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = StaminaModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* ValidStatsModifiers */
            foreach (var key in ValidStatsModifiers.Keys)
            {
                if (ValidStatsModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect))
                {
                    var target = ValidStatsModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = ValidStatsModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = ValidStatsModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* MetabolismModifiers */
            foreach (var key in MetabolismModifiers.Keys)
            {
                if (MetabolismModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect))
                {
                    var target = MetabolismModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = MetabolismModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = MetabolismModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* ResistencesModifiers */
            foreach (var key in ResistencesModifiers.Keys)
            {
                if (ResistencesModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect))
                {
                    var target = ResistencesModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = ResistencesModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = ResistencesModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* ArmorEffectsModifiers */
            foreach (var key in ArmorEffectsModifiers.Keys)
            {
                if (ArmorEffectsModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect))
                {
                    var target = ArmorEffectsModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffectsPart2 && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = ArmorEffectsModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = ArmorEffectsModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            _statMultiplierInfoByFoodEffectsCache2[foodEffect] = retorno.ToArray();
            return _statMultiplierInfoByFoodEffectsCache2[foodEffect];
        }

        public static StatMultiplierInfo[] GetStatMultiplierInfo(FoodEffectConstants.FoodEffects foodEffect)
        {
            if (_statMultiplierInfoByFoodEffectsCache.ContainsKey(foodEffect))
                return _statMultiplierInfoByFoodEffectsCache[foodEffect];
            var retorno = new List<StatMultiplierInfo>();
            /* HealthModifiers */
            foreach (var key in HealthModifiers.Keys)
            {
                if (HealthModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect))
                {
                    var target = HealthModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = HealthModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = HealthModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* StaminaModifiers */
            foreach (var key in StaminaModifiers.Keys)
            {
                if (StaminaModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect))
                {
                    var target = StaminaModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = StaminaModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = StaminaModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* ValidStatsModifiers */
            foreach (var key in ValidStatsModifiers.Keys)
            {
                if (ValidStatsModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect))
                {
                    var target = ValidStatsModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = ValidStatsModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = ValidStatsModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* MetabolismModifiers */
            foreach (var key in MetabolismModifiers.Keys)
            {
                if (MetabolismModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect))
                {
                    var target = MetabolismModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = MetabolismModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = MetabolismModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* ResistencesModifiers */
            foreach (var key in ResistencesModifiers.Keys)
            {
                if (ResistencesModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect))
                {
                    var target = ResistencesModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = ResistencesModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = ResistencesModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            /* ArmorEffectsModifiers */
            foreach (var key in ArmorEffectsModifiers.Keys)
            {
                if (ArmorEffectsModifiers[key].Entries.Any(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect))
                {
                    var target = ArmorEffectsModifiers[key].Entries.FirstOrDefault(x => x.Group == ValueModifierGroup.FoodEffects && x.Key == (int)foodEffect);
                    var finalValue = target.BaseValue * (target.Negative ? -1 : 1);
                    retorno.Add(new StatMultiplierInfo()
                    {
                        Name = ArmorEffectsModifiers[key].DisplayName,
                        Value = finalValue,
                        FormatedValue = ArmorEffectsModifiers[key].FormatValueDelegate(finalValue)
                    });
                }
            }
            _statMultiplierInfoByFoodEffectsCache[foodEffect] = retorno.ToArray();
            return _statMultiplierInfoByFoodEffectsCache[foodEffect];
        }

    }

}
