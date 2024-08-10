using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Text;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerEffects : MyStatBase
    {

        protected override string GetId()
        {
            return "player_effects";
        }

        MyEntityStat SurvivalEffects;
        MyEntityStat DamageEffects;
        MyEntityStat TemperatureEffects;
        MyEntityStat DiseaseEffects;
        MyEntityStat OtherEffects;
        MyEntityStat FoodEffects;
        MyEntityStat FoodEffects2;
        MyEntityStatComponent StatComponent;
        private PlayerArmorController.PlayerEquipInfo ArmorInfo;

        public StatsConstants.SurvivalEffects CurrentSurvivalEffects
        {
            get
            {
                return SurvivalEffects != null ? (StatsConstants.SurvivalEffects)((int)SurvivalEffects.Value) : StatsConstants.SurvivalEffects.None;
            }
        }

        public StatsConstants.DamageEffects CurrentDamageEffects
        {
            get
            {
                return DamageEffects != null ? (StatsConstants.DamageEffects)((int)DamageEffects.Value) : StatsConstants.DamageEffects.None;
            }
        }

        public StatsConstants.TemperatureEffects CurrentTemperatureEffects
        {
            get
            {
                return TemperatureEffects != null ? (StatsConstants.TemperatureEffects)((int)TemperatureEffects.Value) : StatsConstants.TemperatureEffects.None;
            }
        }

        public StatsConstants.DiseaseEffects CurrentDiseaseEffects
        {
            get
            {
                return DiseaseEffects != null ? (StatsConstants.DiseaseEffects)((int)DiseaseEffects.Value) : StatsConstants.DiseaseEffects.None;
            }
        }

        public StatsConstants.OtherEffects CurrentOtherEffects
        {
            get
            {
                return OtherEffects != null ? (StatsConstants.OtherEffects)((int)OtherEffects.Value) : StatsConstants.OtherEffects.None;
            }
        }

        public FoodEffectConstants.FoodEffects CurrentFoodEffects
        {
            get
            {
                return FoodEffects != null ? (FoodEffectConstants.FoodEffects)((int)FoodEffects.Value) : FoodEffectConstants.FoodEffects.None;
            }
        }

        public FoodEffectConstants.FoodEffectsPart2 CurrentFoodEffects2
        {
            get
            {
                return FoodEffects2 != null ? (FoodEffectConstants.FoodEffectsPart2)((int)FoodEffects2.Value) : FoodEffectConstants.FoodEffectsPart2.None;
            }
        }

        public bool IsValid
        {
            get
            {
                return StatComponent != null &&
                    SurvivalEffects != null &&
                    DamageEffects != null &&
                    TemperatureEffects != null &&
                    DiseaseEffects != null &&
                    OtherEffects != null &&
                    FoodEffects != null &&
                    FoodEffects2 != null &&
                    ExtendedSurvivalStatsSession.Static != null;
            }
        }

        private MyEntityStat GetPlayerStat(string statName)
        {
            MyEntityStat stat;
            StatComponent.TryGetStat(MyStringHash.GetOrCompute(statName), out stat);
            return stat;
        }

        public override void Update()
        {
            StatComponent = MyAPIGateway.Session.Player?.Character?.Components.Get<MyEntityStatComponent>();
            if (StatComponent == null)
            {
                CurrentValue = 0;
                return;
            }
            SurvivalEffects = GetPlayerStat(StatsConstants.FixedStats.StatsGroup01.ToString());
            DamageEffects = GetPlayerStat(StatsConstants.FixedStats.StatsGroup02.ToString());
            TemperatureEffects = GetPlayerStat(StatsConstants.FixedStats.StatsGroup03.ToString());
            DiseaseEffects = GetPlayerStat(StatsConstants.FixedStats.StatsGroup04.ToString());
            OtherEffects = GetPlayerStat(StatsConstants.FixedStats.StatsGroup05.ToString());
            FoodEffects = GetPlayerStat(StatsConstants.FixedStats.StatsGroup06.ToString());
            FoodEffects2 = GetPlayerStat(StatsConstants.FixedStats.StatsGroup07.ToString());
            if (IsValid)
            {
                ArmorInfo = PlayerArmorController.GetEquipedArmor(useCache: true);
                var newValue = SurvivalEffects.Value +
                    DamageEffects.Value +
                    TemperatureEffects.Value +
                    DiseaseEffects.Value +
                    OtherEffects.Value +
                    FoodEffects.Value +
                    FoodEffects2.Value +
                    (IsWithHelmet() ? 1 + ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatUpdateHash() : 0) +
                    GetBodyTrackerLevel() +
                    WeatherConstants.CurrentWeatherInfo.GetHashCode() +
                    (ArmorInfo?.ArmorDefinition?.Id?.GetHashCode() ?? 0);
                if (newValue < 0)
                    newValue *= -1;
                CurrentValue = newValue;
            }
            else
            {
                CurrentValue = -1;
            }
        }

        public override string ToString()
        {
            StringBuilder sbEffects = new StringBuilder();
            StringBuilder sbFeeling = new StringBuilder();
            int totalPositive = 0;
            int totalNegative = 0;
            int notTrackedEffects = 0;
            if (IsValid)
            {
                var bodyTrackLevel = GetBodyTrackerLevel();
                int toalEffects = 0;
                if (CurrentSurvivalEffects != StatsConstants.SurvivalEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentSurvivalEffects))
                    {
                        totalNegative++;
                        toalEffects += StatsConstants.GetSurvivalEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetSurvivalEffectTrackLevel(effect))
                        {
                            var text = StatsConstants.GetSurvivalEffectDescription(effect);
                            if (StatsConstants.GetSurvivalEffectCanStack(effect))
                            {
                                text += " (" + ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatStack(effect.ToString()).ToString() + ")";
                            }
                            if (StatsConstants.GetSurvivalEffectIsInverseTime(effect))
                            {
                                var timeToRemove = ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatRemainTime(effect.ToString());
                                var timeToShow = TimeSpan.FromMilliseconds(timeToRemove);
                                var mask = @"mm\:ss";
                                if (timeToShow.TotalMinutes > 60)
                                {
                                    mask = @"hh\:mm\:ss";
                                }
                                text += " [" + timeToShow.ToString(mask) + "]";
                            }
                            sbEffects.AppendLine(text);
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (CurrentTemperatureEffects != StatsConstants.TemperatureEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentTemperatureEffects))
                    {
                        if (StatsConstants.TEMPERATURE_EFFECTS[effect].IsPositive)
                        {
                            totalPositive++;
                        }
                        else
                        {
                            totalNegative++;
                        }
                        toalEffects += StatsConstants.GetTemperatureEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetTemperatureEffectTrackLevel(effect))
                        {
                            var text = StatsConstants.GetTemperatureEffectDescription(effect);
                            if (StatsConstants.TEMPERATURE_EFFECTS[effect].CanSelfRemove || StatsConstants.TEMPERATURE_EFFECTS[effect].IsInverseTime)
                            {
                                var timeToRemove = ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatRemainTime(effect.ToString());
                                var timeToShow = TimeSpan.FromMilliseconds(timeToRemove);
                                var mask = @"mm\:ss";
                                if (timeToShow.TotalMinutes > 60)
                                {
                                    mask = @"hh\:mm\:ss";
                                }
                                text += " [" + timeToShow.ToString(mask) + "]";
                            }
                            sbEffects.AppendLine(text);
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (CurrentDamageEffects != StatsConstants.DamageEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentDamageEffects))
                    {
                        totalNegative++;
                        toalEffects += StatsConstants.GetDamageEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetDamageEffectTrackLevel(effect))
                        {
                            var text = StatsConstants.GetDamageEffectDescription(effect);
                            if (StatsConstants.CanDamageEffectSelfRemove(effect))
                            {
                                var timeToRemove = ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatRemainTime(effect.ToString());
                                var timeToShow = TimeSpan.FromMilliseconds(timeToRemove);
                                var mask = @"mm\:ss";
                                if (timeToShow.TotalMinutes > 60)
                                {
                                    mask = @"hh\:mm\:ss";
                                }
                                text += " [" + timeToShow.ToString(mask) + "]";
                            }
                            sbEffects.AppendLine(text);
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (CurrentDiseaseEffects != StatsConstants.DiseaseEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentDiseaseEffects))
                    {
                        totalNegative++;
                        toalEffects += StatsConstants.GetDiseaseEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetDiseaseEffectTrackLevel(effect))
                        {
                            var text = StatsConstants.GetDiseaseEffectDescription(effect);
                            if (StatsConstants.CanDiseaseEffectStack(effect))
                            {
                                text += " (" + ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatStack(effect.ToString()).ToString() + ")";
                            }
                            if (StatsConstants.CanDiseaseEffectSelfRemove(effect))
                            {
                                var timeToRemove = ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatRemainTime(effect.ToString());
                                var timeToShow = TimeSpan.FromMilliseconds(timeToRemove);
                                var mask = @"mm\:ss";
                                if (timeToShow.TotalMinutes > 60)
                                {
                                    mask = @"hh\:mm\:ss";
                                }
                                text += " [" + timeToShow.ToString(mask) + "]";
                            }
                            sbEffects.AppendLine(text);
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (CurrentOtherEffects != StatsConstants.OtherEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentOtherEffects))
                    {
                        totalNegative++;
                        toalEffects += StatsConstants.GetOtherEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetOtherEffectTrackLevel(effect))
                        {
                            sbEffects.AppendLine(StatsConstants.GetOtherEffectDescription(effect));
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (CurrentFoodEffects != FoodEffectConstants.FoodEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentFoodEffects))
                    {
                        if (FoodEffectConstants.FOOD_EFFECTS[effect].IsPositive)
                        {
                            totalPositive++;
                        }
                        else
                        {
                            totalNegative++;
                        }
                        toalEffects += FoodEffectConstants.GetFoodEffectsFeelingLevel(effect);
                        if (bodyTrackLevel >= FoodEffectConstants.GetFoodEffectsTrackLevel(effect))
                        {
                            var text = FoodEffectConstants.GetFoodEffectsDescription(effect);
                            if (FoodEffectConstants.FOOD_EFFECTS[effect].CanSelfRemove || FoodEffectConstants.FOOD_EFFECTS[effect].IsInverseTime)
                            {
                                var timeToRemove = ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatRemainTime(effect.ToString());
                                var timeToShow = TimeSpan.FromMilliseconds(timeToRemove);
                                var mask = @"mm\:ss";
                                if (timeToShow.TotalMinutes > 60)
                                {
                                    mask = @"hh\:mm\:ss";
                                }
                                text += " [" + timeToShow.ToString(mask) + "]";
                            }
                            sbEffects.AppendLine(text);
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (CurrentFoodEffects2 != FoodEffectConstants.FoodEffectsPart2.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentFoodEffects2))
                    {
                        if (FoodEffectConstants.FOOD_EFFECTS2[effect].IsPositive)
                        {
                            totalPositive++;
                        }
                        else
                        {
                            totalNegative++;
                        }
                        toalEffects += FoodEffectConstants.GetFoodEffectsFeelingLevel(effect);
                        if (bodyTrackLevel >= FoodEffectConstants.GetFoodEffectsTrackLevel(effect))
                        {
                            var text = FoodEffectConstants.GetFoodEffectsDescription(effect);
                            if (FoodEffectConstants.FOOD_EFFECTS2[effect].CanSelfRemove || FoodEffectConstants.FOOD_EFFECTS2[effect].IsInverseTime)
                            {
                                var timeToRemove = ExtendedSurvivalStatsSession.Static.GetPlayerFixedStatRemainTime(effect.ToString());
                                var timeToShow = TimeSpan.FromMilliseconds(timeToRemove);
                                var mask = @"mm\:ss";
                                if (timeToShow.TotalMinutes > 60)
                                {
                                    mask = @"hh\:mm\:ss";
                                }
                                text += " [" + timeToShow.ToString(mask) + "]";
                            }
                            sbEffects.AppendLine(text);
                        }
                        else
                        {
                            notTrackedEffects++;
                        }
                    }
                }
                if (bodyTrackLevel > 0)
                {
                    sbFeeling.AppendLine(string.Format(LanguageProvider.GetEntry(LanguageEntries.BODYTRACKER_UI_EQUIPED), bodyTrackLevel));
                    sbFeeling.AppendLine();
                }
                else
                {
                    sbFeeling.AppendLine(LanguageProvider.GetEntry(LanguageEntries.BODYTRACKER_UI_NOEQUIPED));
                    sbFeeling.AppendLine();
                }
                if (ArmorInfo != null && ArmorInfo.HasArmor)
                {
                    sbFeeling.AppendLine(ArmorInfo.GetDisplayInfo());
                    sbFeeling.AppendLine();
                }
                if (WeatherConstants.CurrentWeatherInfo != null)
                {
                    sbFeeling.AppendLine(WeatherConstants.CurrentWeatherInfo.GetDisplayInfo(bodyTrackLevel));
                    sbFeeling.AppendLine();
                }
                var feeling = StatsConstants.GetFeelingByTotalEffects(toalEffects);
                if (feeling.Length > 0)
                {
                    sbFeeling.AppendLine(feeling);
                    sbFeeling.AppendLine();
                }
                if (sbEffects.Length > 0)
                {
                    sbFeeling.AppendLine(LanguageProvider.GetEntry(LanguageEntries.FEELING_INFO_NAME));
                    sbFeeling.AppendLine();
                }
                if (totalPositive > 0 || totalNegative > 0)
                {
                    sbFeeling.Append(LanguageProvider.GetEntry(LanguageEntries.TOTAL_EFFECT_UID));
                    if (totalPositive > 0)
                    {
                        sbFeeling.Append(string.Format(LanguageProvider.GetEntry(LanguageEntries.TOTAL_POSITIVE_EFFECT_UID), totalPositive));
                    }
                    if (totalNegative > 0)
                    {
                        sbFeeling.Append(string.Format(LanguageProvider.GetEntry(LanguageEntries.TOTAL_NEGATIVE_EFFECT_UID), totalNegative));
                    }
                    if (notTrackedEffects > 0)
                    {
                        sbFeeling.Append(string.Format(LanguageProvider.GetEntry(LanguageEntries.TOTAL_NOTTRACKED_EFFECT_UID), notTrackedEffects));
                    }
                    sbFeeling.AppendLine();
                }
                else
                {
                    sbFeeling.AppendLine(LanguageProvider.GetEntry(LanguageEntries.NO_EFFECT_UID));
                }
            }
            return IsWithHelmet() ? sbFeeling.ToString() + sbEffects.ToString() : "";
        }

    }

}