using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using Sandbox.Game;
using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Collections.Concurrent;
using VRage.Game;
using VRage.Game.ModAPI;
using VRage.Utils;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class PlayerActionsController
    {

        public static void DoCleanYourself(long playerId)
        {
            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.OtherEffects.PoopOnClothes.ToString(), 0, true);
            AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.OtherEffects.PeeOnClothes.ToString(), 0, true);
        }

        public static void DoBodyNeeds(MyCharacterStatComponent statComponent)
        {
            MyEntityStat Bladder;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Bladder.ToString()), out Bladder);
            MyEntityStat Intestine;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Intestine.ToString()), out Intestine);
            var CurrentBladderAmmount = Bladder.MaxValue / Bladder.Value;
            var CurrentIntestineAmmount = Intestine.MaxValue / Intestine.Value;
            if (CurrentBladderAmmount >= 0.075f)
                Bladder.Value = 0;
            if (CurrentIntestineAmmount >= 0.5f)
                Intestine.Value = 0;
        }

        public static void DoEmptyBladder(MyCharacterStatComponent statComponent)
        {
            MyEntityStat Bladder;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Bladder.ToString()), out Bladder);
            Bladder.Value = 0;
        }

        public static void DoEmptyIntestine(MyCharacterStatComponent statComponent)
        {
            MyEntityStat Intestine;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Intestine.ToString()), out Intestine);
            Intestine.Value = 0;
        }

        public static void DoEmptyStomach(long playerId)
        {
            AdvancedStatsAndEffectsAPI.ClearOverTimeConsumable(playerId);
        }

        public static void DoShitYourself(long playerId, MyCharacterStatComponent statComponent)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.OtherEffects.PoopOnClothes.ToString(), 0, true);
            DoEmptyIntestine(statComponent);
        }

        public static void DoTakeAPiss(long playerId, MyCharacterStatComponent statComponent)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.OtherEffects.PeeOnClothes.ToString(), 0, true);
            DoEmptyBladder(statComponent);
        }

        public static void DoVomit(long playerId)
        {
            AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Queasy.ToString(), 0, true);
            DoEmptyStomach(playerId);
        }

        public static void ProcessEffectsTimers(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent, long timePassed)
        {
            var weatherInfo = WeatherConstants.GetWeatherInfo(character);
            MyEntityStat WetTime;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.WetTime.ToString()), out WetTime);
            if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
            {
                switch (weatherInfo.WeatherEffect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        IncriseWetTimer(weatherInfo.WeatherEffect, weatherInfo.WeatherLevel, weatherInfo.WeatherIntensity, WetTime);
                        break;
                    default:
                        DecresaseWetTimer(character, weatherInfo.CurrentEnvironmentType, WetTime);
                        break;
                }
            }
            else if (character.Parent == null && weatherInfo.CurrentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
                IncriseUnderwaterWetTimer(WetTime);
            else
                DecresaseWetTimer(character, weatherInfo.CurrentEnvironmentType, WetTime);
            CheckWetEffect(playerId, WetTime);

            MyEntityStat TemperatureTime;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.TemperatureTime.ToString()), out TemperatureTime);
            MyEntityStat Stomach;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Stomach.ToString()), out Stomach);
            MyEntityStat Intestine;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Intestine.ToString()), out Intestine);
            MyEntityStat Bladder;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Bladder.ToString()), out Bladder);
            MyEntityStat BodyEnergy;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyEnergy.ToString()), out BodyEnergy);
            MyEntityStat BodyWater;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyWater.ToString()), out BodyWater);
            MyEntityStat Fatigue;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Fatigue.ToString()), out Fatigue);
            MyEntityStat BodyWeight;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyWeight.ToString()), out BodyWeight);

            MyEntityStat Hunger;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Hunger.ToString()), out Hunger);
            MyEntityStat Thirst;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Thirst.ToString()), out Thirst);


            MyEntityStat StatsGroup02; /* Damage Effects */
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup02.ToString()), out StatsGroup02);
            MyEntityStat StatsGroup04; /* Disease Effects */
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup04.ToString()), out StatsGroup04);
            MyEntityStat StatsGroup01; /* Survival Effects */
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup01.ToString()), out StatsGroup01);
            MyEntityStat StatsGroup03; /* Temperature Effects */
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup03.ToString()), out StatsGroup03);

            if (timePassed > 0)
            {
                MyEntityStat WoundedTime;
                statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.WoundedTime.ToString()), out WoundedTime);

                IncDecWoundedTimer((StatsConstants.DamageEffects)((int)StatsGroup02.Value), WoundedTime, timePassed);
                CheckWoundedEffect(playerId, WoundedTime);
                IncDevTemperatureTimer(playerId, TemperatureTime, timePassed, (StatsConstants.DiseaseEffects)((int)StatsGroup04.Value), weatherInfo);
                CheckTemperatureEffect(playerId, TemperatureTime);
            }
            CheckIfGetDiseases(
                playerId,
                (StatsConstants.DiseaseEffects)((int)StatsGroup04.Value),
                (StatsConstants.TemperatureEffects)((int)StatsGroup03.Value),
                (StatsConstants.SurvivalEffects)((int)StatsGroup01.Value),
                TemperatureTime,
                Stomach,
                Intestine,
                Bladder,
                BodyEnergy,
                BodyWater,
                Fatigue,
                BodyWeight
            );
            CheckHungerValues(playerId, Hunger);
            CheckThirstValues(playerId, Thirst);
            CheckOxygenValue(playerId, character, weatherInfo.CurrentEnvironmentType);
        }

        private static void CheckOxygenValue(long playerId, IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType)
        {
            float percentValue;
            bool usingSuit = character.EnabledHelmet;
            if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
            {
                percentValue = usingSuit ?
                    enterUnderWaterO2Level[playerId] :
                    0f;
            }
            else
            {
                percentValue = usingSuit ?
                    character.GetSuitGasFillLevel(ItensConstants.OXYGEN_ID.DefinitionId) :
                    character.OxygenLevel;
            }
            var checkValue = usingSuit ?
                new Vector2(0.05f, 0.2f) :
                new Vector2(0.1f, 0.8f);
            if (percentValue <= checkValue.X)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
            }
            else if (percentValue <= checkValue.Y)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Disoriented.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Suffocation.ToString(), 0, true);
            }
        }

        private static void CheckHungerValues(long playerId, MyEntityStat Hunger)
        {
            var percentValue = Hunger.Value / Hunger.MaxValue;
            if (percentValue <= 0.05f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
            }
            else if (percentValue <= 0.2f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Hungry.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Famished.ToString(), 0, true);
            }
        }

        private static void CheckThirstValues(long playerId, MyEntityStat Thirst)
        {
            var percentValue = Thirst.Value / Thirst.MaxValue;
            if (percentValue <= 0.05f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
            }
            else if (percentValue <= 0.2f)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Thirsty.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Dehydrating.ToString(), 0, true);
            }
        }

        private static void CheckTemperatureEffect(long playerId, MyEntityStat TemperatureTime)
        {
            if (TemperatureTime.Value >= StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
            }
            else if (TemperatureTime.Value >= StatsConstants.MIN_TO_GET_EFFECT_OVERHITING)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
            }
            else if (TemperatureTime.Value <= StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
            }
            else if (TemperatureTime.Value <= StatsConstants.MIN_TO_GET_EFFECT_COLD)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.OnFire.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Overheating.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Cold.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Frosty.ToString(), 0, true);
            }
        }

        private static void IncDevTemperatureTimer(long playerId, MyEntityStat TemperatureTime, long timePassed, StatsConstants.DiseaseEffects CurrentDiseaseEffects, WeatherConstants.WeatherInfo weatherInfo)
        {
            var temperature = weatherInfo.CurrentTemperature.Y;
            var finalValue = (float)timePassed;
            if (temperature > HungerConstants.THIRST_TEMPERATURE_RANGE ||
                temperature < HungerConstants.HUNGER_TEMPERATURE_RANGE)
            {
                if (temperature > HungerConstants.THIRST_HARD_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_THIRST_FACTOR.Y;
                else if (temperature > HungerConstants.THIRST_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_THIRST_FACTOR.X;
                else if (temperature < HungerConstants.HUNGER_HARD_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_HUNGER_FACTOR.Y;
                else if (temperature < HungerConstants.HUNGER_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_HUNGER_FACTOR.X;
                if (temperature > HungerConstants.THIRST_TEMPERATURE_RANGE)
                {
                    finalValue *= TemperatureTime.Value < 0 ? StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER : 1;
                    bool isHardTemperature = temperature > HungerConstants.THIRST_HARD_TEMPERATURE_RANGE;
                    if (isHardTemperature || TemperatureTime.Value < StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
                        TemperatureTime.Increase(finalValue, null);
                }
                else
                {
                    finalValue *= TemperatureTime.Value > 0 ? StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER : 1;
                    bool isHardTemperature = temperature < HungerConstants.HUNGER_HARD_TEMPERATURE_RANGE;
                    if (isHardTemperature || TemperatureTime.Value > StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
                        TemperatureTime.Decrease(finalValue, null);
                }
            }
            else
            {
                if (TemperatureTime.Value < 0)
                {
                    if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
                        finalValue *= StatsConstants.HYPOTHERMIA_CHANGE_MULTIPLIER;
                    finalValue *= StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER;
                    TemperatureTime.Increase(finalValue, null);
                    if (TemperatureTime.Value > 0)
                        TemperatureTime.Value = 0;
                }
                else if (TemperatureTime.Value > 0)
                {
                    if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                        finalValue *= StatsConstants.HYPERTHERMIA_CHANGE_MULTIPLIER;
                    finalValue *= StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER;
                    TemperatureTime.Decrease(finalValue, null);
                    if (TemperatureTime.Value < 0)
                        TemperatureTime.Value = 0;
                }
            }
            if (TemperatureTime.Value <= 0)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString(), 0, true);
            }
            if (TemperatureTime.Value >= 0)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString(), 0, true);
            }
        }

        private static void IncDecWoundedTimer(StatsConstants.DamageEffects CurrentDamageEffects, MyEntityStat WoundedTime, long timePassed)
        {
            if (StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.Wounded) ||
                StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) ||
                StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
            {
                if (WoundedTime.Value < WoundedTime.MaxValue)
                {
                    var finalValue = (float)timePassed;
                    var maxDamageEffect = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects);
                    WoundedTime.Increase(finalValue * StatsConstants.TIME_MULTIPLIER_FACTOR[maxDamageEffect], null);
                }
            }
            else
            {
                WoundedTime.Value = 0;
            }
        }


        private static void CheckWoundedEffect(long playerId, MyEntityStat WoundedTime)
        {
            if (WoundedTime.Value >= WoundedTime.MaxValue)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Infected.ToString(), 0, true);
            }
        }

        private static void CheckWetEffect(long playerId, MyEntityStat WetTime)
        {
            if (WetTime.Value >= StatsConstants.MIN_TO_GET_EFFECT_WET)
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
            else
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.TemperatureEffects.Wet.ToString(), 0, true);
        }

        private static void IncriseUnderwaterWetTimer(MyEntityStat WetTime)
        {
            if (WetTime.Value < WetTime.MaxValue)
            {
                float finalValue = StatsConstants.BASE_WET_FACTOR_UNDERWATER;
                WetTime.Increase(finalValue, null);
            }
        }

        private static void DecresaseWetTimer(IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType, MyEntityStat WetTime)
        {
            if (WetTime.Value > 0)
            {
                var decValue = StatsConstants.BASE_REMOVE_WET_FACTOR;
                if (character.EnvironmentOxygenLevel == 0)
                    decValue += StatsConstants.BASE_REMOVE_WET_FACTOR_NOO2_BONUS;
                if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
                    decValue *= StatsConstants.BASE_REMOVE_WET_FACTOR_IN_ATM;
                else if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.ShipOrStation)
                    decValue *= StatsConstants.BASE_REMOVE_WET_FACTOR_IN_SHIP;
                else if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Space)
                    decValue *= StatsConstants.BASE_REMOVE_WET_FACTOR_IN_VOID;
                WetTime.Decrease(decValue, null);
            }
        }

        private static void IncriseWetTimer(WeatherConstants.WeatherEffects effect, WeatherConstants.WeatherEffectsLevel level, float intensity, MyEntityStat WetTime)
        {
            if (WetTime.Value < WetTime.MaxValue)
            {
                float finalValue = 0;
                switch (effect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                        finalValue += StatsConstants.BASE_WET_FACTOR_RAIN * (1 + intensity);
                        finalValue *= level == WeatherConstants.WeatherEffectsLevel.Light ? StatsConstants.RAIN_WET_FACTOR.X : StatsConstants.RAIN_WET_FACTOR.Y;
                        break;
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        finalValue += StatsConstants.BASE_WET_FACTOR_THUNDER * (1 + intensity);
                        finalValue *= level == WeatherConstants.WeatherEffectsLevel.Light ? StatsConstants.THUNDER_WET_FACTOR.X : StatsConstants.THUNDER_WET_FACTOR.Y;
                        break;
                }
                WetTime.Increase(finalValue, null);
            }
        }

        private static readonly Random rnd = new Random();
        private static bool CheckChance(float chance)
        {
            return rnd.Next(1, 101) <= chance;
        }

        private static void CheckIfGetDiseases(long playerId, StatsConstants.DiseaseEffects CurrentDiseaseEffects, 
            StatsConstants.TemperatureEffects CurrentTemperatureEffects, StatsConstants.SurvivalEffects CurrentSurvivalEffects, 
            MyEntityStat TemperatureTime, MyEntityStat Stomach, MyEntityStat Intestine, MyEntityStat Bladder, 
            MyEntityStat BodyEnergy, MyEntityStat BodyWater, MyEntityStat Fatigue, MyEntityStat BodyWeight)
        {
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Pneumonia))
            {
                if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                {
                    var isWet = StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet);
                    var chance = StatsConstants.CHANCE_TO_GET_PNEUMONIA;
                    if (isWet)
                        chance += StatsConstants.PNEUMONIA_CHANCE_INCRISE;
                    float temperatureMultiplier = 1f - (TemperatureTime.CurrentRatio * 2);
                    if (temperatureMultiplier > 0 && CheckChance(chance * temperatureMultiplier))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Pneumonia.ToString(), 0, true);
                    }
                }
            }
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
            {
                if (TemperatureTime.Value <= TemperatureTime.MinValue)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Hypothermia.ToString(), 0, true);
                }
            }
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
            {
                if (TemperatureTime.Value >= TemperatureTime.MaxValue)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Hyperthermia.ToString(), 0, true);
                }
            }
            CheckStomach(playerId, CurrentSurvivalEffects, Stomach);
            CheckIntestine(playerId, CurrentSurvivalEffects, Intestine);
            CheckBladder(playerId, CurrentSurvivalEffects, Bladder);
            CheckStarvation(playerId, CurrentDiseaseEffects, BodyEnergy);
            CheckDehydration(playerId, CurrentDiseaseEffects, BodyWater);
            CheckFatigue(playerId, CurrentSurvivalEffects, Fatigue);
            CheckWeight(playerId, BodyWeight);
        }

        private static void CheckStomach(long playerId, StatsConstants.SurvivalEffects CurrentSurvivalEffects, MyEntityStat Stomach)
        {
            var percent = Stomach.Value / Stomach.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachBursting))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachBursting.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.StomachBursting.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullStomach.ToString(), 0, true);
                    }
                }
            }
        }

        public static void DoEatStartFood(long playerId)
        {
            AdvancedStatsAndEffectsAPI.DoPlayerConsume(playerId, ItensConstants.SANDWICH_ID.DefinitionId);
            AdvancedStatsAndEffectsAPI.DoPlayerConsume(playerId, ItensConstants.WATER_FLASK_SMALL_ID.DefinitionId);
        }

        private static void CheckIntestine(long playerId, StatsConstants.SurvivalEffects CurrentSurvivalEffects, MyEntityStat Intestine)
        {
            var percent = Intestine.Value / Intestine.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.GutBurst))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.GutBurst.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.GutBurst.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullGut.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckBladder(long playerId, StatsConstants.SurvivalEffects CurrentSurvivalEffects, MyEntityStat Bladder)
        {
            var percent = Bladder.Value / Bladder.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.BladderBurst))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.BladderBurst.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.BladderBurst.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.FullBladder.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckFatigue(long playerId, StatsConstants.SurvivalEffects CurrentSurvivalEffects, MyEntityStat Fatigue)
        {
            var percent = Fatigue.Value / Fatigue.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.ExtremelyTired))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.8f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.ExtremelyTired.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.8f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.ExtremelyTired.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.6f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent < 0.6f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.SurvivalEffects.Tired.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckWeight(long playerId, MyEntityStat BodyWeight)
        {
            var height = 1.8f;
            var bmi = BodyWeight.Value / (height * height);
            if (bmi >= 40)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi >= 30)
            {
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi <= 17)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else if (bmi <= 14)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
            else
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Obesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereObesity.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Rickets.ToString(), 0, true);
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereRickets.ToString(), 0, true);
            }
        }

        private static void CheckDehydration(long playerId, StatsConstants.DiseaseEffects CurrentDiseaseEffects, MyEntityStat BodyWater)
        {
            var percent = BodyWater.Value / BodyWater.MaxValue;
            var needToCheckDehydration = true;
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
            {
                if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckDehydration = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereDehydration.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckDehydration = false;
                if (percent > 0.05f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereDehydration.ToString(), 0, true);
                    needToCheckDehydration = true;
                }
            }
            if (needToCheckDehydration)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Dehydration.ToString(), 0, true);
                    }
                }
            }
        }

        private static void CheckStarvation(long playerId, StatsConstants.DiseaseEffects CurrentDiseaseEffects, MyEntityStat BodyEnergy)
        {
            var percent = BodyEnergy.Value / BodyEnergy.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
            {
                if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckStarvation = false;
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereStarvation.ToString(), 0, true);
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent > 0.05f)
                {
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.SevereStarvation.ToString(), 0, true);
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DiseaseEffects.Starvation.ToString(), 0, true);
                    }
                }
            }
        }

        private static ConcurrentDictionary<long, float> enterUnderWaterO2Level = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> enterUnderWaterO2Consumption = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, bool> enterUnderWater = new ConcurrentDictionary<long, bool>();

        private static float GasRefillRation
        {
            get
            {
                return MyCharacterOxygenComponent.GAS_REFILL_RATION * 1.25f;
            }
        }

        private static float GetNoO2DamageAmount(IMyCharacter character)
        {
            return (character.Definition as MyCharacterDefinition).DamageAmountAtZeroPressure;
        }

        public static void ProcessUnderwater(long playerId, IMyCharacter character, WeatherConstants.EnvironmentDetector currentEnvironmentType)
        {
            if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater && !character.IsDead)
            {
                var OxygenComponent = character.Components.Get<MyCharacterOxygenComponent>();
                if (!enterUnderWater[playerId])
                {
                    enterUnderWater[playerId] = true;
                    enterUnderWaterO2Level[playerId] = OxygenComponent.GetGasFillLevel(MyCharacterOxygenComponent.OxygenId);
                    enterUnderWaterO2Consumption[playerId] = (character.Definition as MyCharacterDefinition).OxygenConsumption / OxygenComponent.OxygenCapacity;
                }
                if (MyAPIGateway.Session.SessionSettings.EnableOxygen)
                {
                    if (character.EnabledHelmet)
                    {
                        if (enterUnderWaterO2Level[playerId] > 0)
                            enterUnderWaterO2Level[playerId] -= enterUnderWaterO2Consumption[playerId];
                    }
                    else if (character.CanTakeDamage())
                    {
                        character.DoDamage(GetNoO2DamageAmount(character), MyDamageType.Asphyxia, true);
                    }
                    if (enterUnderWaterO2Level[playerId] < 0)
                        enterUnderWaterO2Level[playerId] = 0;

                    if (OxygenComponent.SuitOxygenLevel < GasRefillRation)
                    {
                        if (ExtendedSurvivalCoreAPI.Registered)
                        {
                            var InventoryObserver = ExtendedSurvivalCoreAPI.GetInventoryObserver(character, 0);
                            if (InventoryObserver != Guid.Empty)
                            {
                                var bottles = ExtendedSurvivalCoreAPI.GetItemInfoByGasId(InventoryObserver, ItensConstants.OXYGEN_ID.DefinitionId);
                                if (bottles != null && bottles.Length > 0)
                                {
                                    var Inventory = character.GetInventory();
                                    foreach (var bottle in bottles)
                                    {
                                        var item = Inventory.GetItemByID(bottle.ItemId);
                                        if (item != null)
                                        {
                                            var gasContainer = item.Content as MyObjectBuilder_GasContainerObject;
                                            if (gasContainer != null)
                                            {
                                                var physicalItem = MyDefinitionManager.Static.GetPhysicalItemDefinition(gasContainer) as MyOxygenContainerDefinition;
                                                if (physicalItem.StoredGasId != ItensConstants.OXYGEN_ID.DefinitionId)
                                                    continue;
                                                float gasAmount = gasContainer.GasLevel * physicalItem.Capacity;
                                                float transferredAmount = Math.Min(gasAmount, (1f - enterUnderWaterO2Level[playerId]) * OxygenComponent.OxygenCapacity);
                                                gasContainer.GasLevel = Math.Max((gasAmount - transferredAmount) / physicalItem.Capacity, 0f);
                                                float trasnferredFillLevel = transferredAmount / OxygenComponent.OxygenCapacity;
                                                enterUnderWaterO2Level[playerId] += trasnferredFillLevel;
                                                if (enterUnderWaterO2Level[playerId] == 1f)
                                                    break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    OxygenComponent.SuitOxygenLevel = enterUnderWaterO2Level[playerId];

                    if (enterUnderWaterO2Level[playerId] <= 0 && character.CanTakeDamage())
                    {
                        character.DoDamage(GetNoO2DamageAmount(character), MyDamageType.Asphyxia, true);
                    }
                }
            }
            else
            {
                enterUnderWater[playerId] = false;
            }
        }

        public static float CurrentBaseCargoVolume
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier * 0.4f;
            }
        }

        public static float CurrentCargoVolume
        {
            get
            {
                return CurrentBaseCargoVolume;
            }
        }

        public static float CurrentBaseCargoMass
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier * 1000f;
            }
        }

        public static float CurrentCargoMass
        {
            get
            {
                return CurrentBaseCargoMass;
            }
        }

        public static void ProcessCargoMax(IMyCharacter character)
        {
            var Inventory = character.GetInventory() as MyInventory;
            if (Inventory != null)
            {
                if ((float)Inventory.MaxVolume != CurrentCargoVolume)
                {
                    var definition = new MyInventoryComponentDefinition
                    {
                        RemoveEntityOnEmpty = false,
                        MultiplierEnabled = false,
                        MaxItemCount = int.MaxValue,
                        Mass = CurrentCargoMass,
                        Volume = CurrentCargoVolume,
                        InputConstraint = new MyInventoryConstraint("PlayerInventory", null, false)
                    };
                    Inventory.Init(definition);
                }
            }
        }

        public static void CheckHealthValue(long playerId, MyCharacterStatComponent statComponent)
        {
            var percentValue = statComponent.Health.Value / statComponent.Health.MaxValue;
            if (percentValue == 1)
            {
                AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
            }
        }

        public static void CheckValuesToDoDamage(IMyCharacter character, MyCharacterStatComponent statComponent)
        {
            if (character.CanTakeDamage())
            {
                try
                {
                    MyEntityStat BodyWater;
                    statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyWater.ToString()), out BodyWater);
                    if (BodyWater.Value == 0)
                    {
                        character.Kill();
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalStatsLogging.Instance.LogError(typeof(PlayerActionsController), ex);
                }
            }
        }

        private static ConcurrentDictionary<long, float> sedentaryTime = new ConcurrentDictionary<long, float>();
        private static ConcurrentDictionary<long, float> waterToConsume = new ConcurrentDictionary<long, float>();

        public static void DoPlayerCycle(long playerId, long spendTime, MyCharacterStatComponent statComponent)
        {
            var staminaSpended = StaminaController.GetSpendedStamina(playerId);
            if (staminaSpended == 0)
            {
                if (!sedentaryTime.ContainsKey(playerId))
                    sedentaryTime[playerId] = 0;
                sedentaryTime[playerId] += spendTime;
            }
            else if (sedentaryTime[playerId] > 0)
            {
                sedentaryTime[playerId] -= spendTime * 10;
                if (sedentaryTime[playerId] < 0)
                    sedentaryTime[playerId] = 0;
            }

            MyEntityStat Stomach;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Stomach.ToString()), out Stomach);
            MyEntityStat Intestine;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Intestine.ToString()), out Intestine);
            MyEntityStat Bladder;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Bladder.ToString()), out Bladder);
            MyEntityStat BodyCalories;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyCalories.ToString()), out BodyCalories);
            MyEntityStat BodyWater;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyWater.ToString()), out BodyWater);
            MyEntityStat BodyProtein;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyProtein.ToString()), out BodyProtein);
            MyEntityStat BodyCarbohydrate;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyCarbohydrate.ToString()), out BodyCarbohydrate);
            MyEntityStat BodyLipids;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyLipids.ToString()), out BodyLipids);
            MyEntityStat BodyVitamins;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyVitamins.ToString()), out BodyVitamins);
            MyEntityStat BodyMinerals;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyMinerals.ToString()), out BodyMinerals);
            MyEntityStat BodyWeight;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyWeight.ToString()), out BodyWeight);
            MyEntityStat BodyEnergy;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.BodyEnergy.ToString()), out BodyEnergy);
            MyEntityStat Hunger;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Hunger.ToString()), out Hunger);
            MyEntityStat Thirst;
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.ValidStats.Thirst.ToString()), out Thirst);

            DoConsumeCicle(playerId, staminaSpended, BodyCalories, BodyWater, BodyProtein, BodyCarbohydrate, BodyLipids, BodyMinerals, BodyVitamins);
            DoBladderCicle(Bladder);
            DoCheckBodyState(playerId, Bladder, Intestine, Stomach, statComponent);
            DoStomachCicle(playerId, Stomach, BodyCalories, BodyWater, Hunger, Thirst, BodyEnergy);
            float weightChange = DoCheckBodyWeight(BodyCalories, BodyWeight);
            if (weightChange < 0)
            {
                /* The body always consumes muscle first during body loss with no protein reserve and is sedentary */

            }
            if (weightChange > 0)
            {
                /* The body always gain fat with no stamina spend or no protein reserve */

            }
            else
            {
                /* No body change, but transform fat into muscle with stamina spend and protein reserve */

            }
            StaminaController.ClearSpendedStamina(playerId);
        }

        private static void DoConsumeCicle(long playerId, float staminaSpended, MyEntityStat CaloriesAmmount, MyEntityStat WaterAmmount, 
            MyEntityStat ProteinAmmount, MyEntityStat CarbohydrateAmmount, MyEntityStat LipidsAmmount, 
            MyEntityStat MineralsAmmount, MyEntityStat VitaminsAmmount)
        {
            var _caloriesToConsume = PlayerBodyConstants.CaloriesConsumption.X;
            waterToConsume[playerId] = PlayerBodyConstants.WaterConsumption.X;
            var _proteinToConsume = PlayerBodyConstants.ProteinConsumption.X;
            var _carbohydrateToConsume = PlayerBodyConstants.CarbohydrateConsumption.X;
            var _lipidsToConsume = PlayerBodyConstants.LipidConsumption.X;
            var _mineralsToConsume = PlayerBodyConstants.MineralsConsumption.X;
            var _vitaminsToConsume = PlayerBodyConstants.VitaminsConsumption.X;
            if (staminaSpended > 0)
            {
                _caloriesToConsume += PlayerBodyConstants.CaloriesConsumption.Y * staminaSpended;
                waterToConsume[playerId] += PlayerBodyConstants.WaterConsumption.Y * staminaSpended;
                _proteinToConsume += PlayerBodyConstants.ProteinConsumption.Y * staminaSpended;
                _carbohydrateToConsume += PlayerBodyConstants.CarbohydrateConsumption.Y * staminaSpended;
                _lipidsToConsume += PlayerBodyConstants.LipidConsumption.Y * staminaSpended;
                _mineralsToConsume += PlayerBodyConstants.MineralsConsumption.Y * staminaSpended;
                _vitaminsToConsume += PlayerBodyConstants.VitaminsConsumption.Y * staminaSpended;
            }
            CaloriesAmmount.Value -= _caloriesToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            WaterAmmount.Value -= waterToConsume[playerId] / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            ProteinAmmount.Value -= _proteinToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            CarbohydrateAmmount.Value -= _carbohydrateToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            LipidsAmmount.Value -= _lipidsToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            MineralsAmmount.Value -= _mineralsToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
            VitaminsAmmount.Value -= _vitaminsToConsume / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
        }

        private static float GetCurrentHungerAmmount(float CaloriesAmmount, float CurrentStomachVolume)
        {
            // Less than the minimum
            if (CaloriesAmmount < PlayerBodyConstants.CaloriesReserveSize.X)
            {
                if (CurrentStomachVolume >= PlayerBodyConstants.StomachSize.Z)
                    return 1.0f;
                return CurrentStomachVolume / PlayerBodyConstants.StomachSize.Z;
            }
            // Greater than the maximum
            else if (CaloriesAmmount > PlayerBodyConstants.CaloriesReserveSize.Y)
            {
                if (CurrentStomachVolume >= PlayerBodyConstants.StomachSize.X)
                    return 1.0f;
                return CurrentStomachVolume / PlayerBodyConstants.StomachSize.X;
            }
            // In average
            else
            {
                if (CurrentStomachVolume >= PlayerBodyConstants.StomachSize.Y)
                    return 1.0f;
                return CurrentStomachVolume / PlayerBodyConstants.StomachSize.Y;
            }
        }

        private static float GetCurrentThirstAmmount(float WaterAmmount, float CurrentStomachLiquid)
        {
            // Is Dehydrating
            if (WaterAmmount < PlayerBodyConstants.WaterReserveSize.Y)
            {
                if (CurrentStomachLiquid >= PlayerBodyConstants.WaterReserveSize.W)
                    return 1.0f;
                return CurrentStomachLiquid / PlayerBodyConstants.WaterReserveSize.W;
            }
            // Is Thirsty
            else if (WaterAmmount < PlayerBodyConstants.WaterReserveSize.Z)
            {
                if (CurrentStomachLiquid >= PlayerBodyConstants.WaterReserveSize.Z)
                    return 1.0f;
                return CurrentStomachLiquid / PlayerBodyConstants.WaterReserveSize.Z;
            }
            // In average
            else
            {
                if (CurrentStomachLiquid >= PlayerBodyConstants.WaterReserveSize.Y)
                    return 1.0f;
                return CurrentStomachLiquid / PlayerBodyConstants.StomachSize.Y;
            }
        }

        private static float GetCurrentBodyEnergy(float CaloriesAmmount)
        {
            if (CaloriesAmmount < 0)
                return 0;
            if (CaloriesAmmount >= PlayerBodyConstants.CaloriesReserveSize.Y)
                return 1;
            return CaloriesAmmount / PlayerBodyConstants.CaloriesReserveSize.Y;
        }

        private static void DoStomachCicle(long playerId, MyEntityStat Stomach, MyEntityStat BodyCalories, MyEntityStat BodyWater, 
            MyEntityStat Hunger, MyEntityStat Thirst, MyEntityStat BodyEnergy)
        {
            var solid = AdvancedStatsAndEffectsAPI.GetRemainOverTimeConsumable(playerId, StatsConstants.VirtualStats.Solid.ToString());
            var liquid = AdvancedStatsAndEffectsAPI.GetRemainOverTimeConsumable(playerId, StatsConstants.VirtualStats.Liquid.ToString());
            Stomach.Value = solid + liquid;
            Hunger.Value = GetCurrentHungerAmmount(BodyCalories.Value, Stomach.Value) * Hunger.MaxValue;
            Thirst.Value = GetCurrentThirstAmmount(BodyWater.Value, liquid) * Thirst.MaxValue;
            BodyEnergy.Value = GetCurrentBodyEnergy(BodyCalories.Value) * BodyEnergy.MaxValue;
        }

        private static void DoBladderCicle(MyEntityStat Bladder)
        {
            Bladder.Value += PlayerBodyConstants.WaterToBladder / ExtendedSurvivalSettings.Instance.MetabolismSpeedMultiplier;
        }

        private static void DoCheckBodyState(long playerId, MyEntityStat Bladder, MyEntityStat Intestine, MyEntityStat Stomach, MyCharacterStatComponent statComponent)
        {
            if (Bladder.Value >= Bladder.MaxValue)
            {
                DoTakeAPiss(playerId, statComponent);
            }
            if (Intestine.Value >= Intestine.MaxValue)
            {
                DoShitYourself(playerId, statComponent);
            }
            if (Stomach.Value >= Stomach.MaxValue)
            {
                DoVomit(playerId);
            }
        }

        private static float DoCheckBodyWeight(MyEntityStat CaloriesAmmount, MyEntityStat CurrentWeight)
        {
            float bodyChance = 0;
            if (CaloriesAmmount.Value < PlayerBodyConstants.CaloriesReserveSize.X)
            {
                bodyChance -= PlayerBodyConstants.WeightChange.X;
            }
            else if (CaloriesAmmount.Value > PlayerBodyConstants.CaloriesReserveSize.Y)
            {
                bodyChance += PlayerBodyConstants.WeightChange.Y;
            }
            CurrentWeight.Value += bodyChance;
            return bodyChance;
        }

        public static void ProcessHealth(MyCharacterStatComponent statComponent)
        {
            MyEntityStat StatsGroup02; /* Damage Effects */
            statComponent.TryGetStat(MyStringHash.GetOrCompute(StatsConstants.FixedStats.StatsGroup02.ToString()), out StatsGroup02);
            var maxDamage = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue((StatsConstants.DamageEffects)((int)StatsGroup02.Value));
            var finalRegen = StatsConstants.BASE_HEALTH_REGEN_FACTOR;
            var maxRegen = 1f;
            if (maxDamage != StatsConstants.DamageEffects.None)
            {
                var regenAffect = StatsConstants.DAMAGE_HEALTH_REGEN_FACTOR[maxDamage];
                finalRegen *= regenAffect.X;
                maxRegen = regenAffect.Y;
            }
            var currentStatusValue = statComponent.Health.Value / statComponent.Health.MaxValue;
            if (currentStatusValue < maxRegen)
            {
                statComponent.Health.Increase(finalRegen, null);
            }
        }

        private const float MAX_HEALTH_REGEN_AT_SURVIVAL_KIT = 0.5f;
        public static void PlayerHealthRecharging(long playerId, MyCharacterStatComponent statComponent)
        {
            var maxLife = MAX_HEALTH_REGEN_AT_SURVIVAL_KIT * statComponent.Health.MaxValue;
            var lastHealthChanged  = AdvancedStatsAndEffectsAPI.GetLastHealthChange(playerId);
            if (lastHealthChanged.X > maxLife)
            {
                if (lastHealthChanged.Y > maxLife)
                    statComponent.Health.Value = lastHealthChanged.Y;
                else
                    statComponent.Health.Value = maxLife;
            }
        }

    }

}
