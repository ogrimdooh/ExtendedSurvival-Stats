using Sandbox.Game;
using Sandbox.Game.Components;
using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI;
using System;
using System.Linq;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerInventoryController
    {

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

        public static void DoProcessItemConsume(long playerId, MyCharacterStatComponent statComponent, UniqueEntityId itemId)
        {
            if (FoodConstants.FOOD_DEFINITIONS.ContainsKey(itemId))
            {
                PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
                var statControl = PlayerActionsController.GetStatsEasyAcess(playerId);
                bool hasVomit = false;
                if (statControl.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Queasy))
                {
                    var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Queasy.ToString());
                    var chanceToVomit = stack * StatsConstants.CHANCE_TO_VOMIT;
                    if (PlayerActionsController.CheckChance(chanceToVomit))
                    {
                        PlayerMetabolismController.DoVomit(playerId);
                        hasVomit = true;
                    }
                }
                if (statControl.CurrentDiseaseEffects.IsFlagSet(StatsConstants.DiseaseEffects.Dysentery))
                {
                    var stack = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatStack(playerId, StatsConstants.DiseaseEffects.Dysentery.ToString());
                    var chanceToVomit = stack * StatsConstants.CHANCE_TO_VOMIT / 2;
                    var chanceToPoop = stack * StatsConstants.CHANCE_TO_POOP;
                    if (!hasVomit && PlayerActionsController.CheckChance(chanceToVomit))
                    {
                        PlayerMetabolismController.DoVomit(playerId);
                    }
                    if (PlayerActionsController.CheckChance(chanceToPoop))
                    {
                        PlayerMetabolismController.DoShitYourself(playerId);
                    }
                }
            }
            if (MedicalConstants.MEDICAL_DEFINITIONS.ContainsKey(itemId))
            {
                PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
                var statControl = PlayerActionsController.GetStatsEasyAcess(playerId);
                var def = MedicalConstants.MEDICAL_DEFINITIONS[itemId];
                if (def.ReduceDisease != null && def.ReduceDisease.Any())
                {
                    foreach (var disease in def.ReduceDisease.Keys)
                    {
                        if (statControl.CurrentDiseaseEffects.IsFlagSet(disease))
                        {
                            var timeToRemove = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, disease.ToString());
                            if (timeToRemove > 0)
                            {
                                timeToRemove -= (long)def.ReduceDisease[disease];
                                if (timeToRemove <= 0)
                                    statControl.MedicalDetector.ClearEffects();
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, disease.ToString(), Math.Max(timeToRemove, 0));
                            }
                        }
                    }
                }
                if (def.ReduceDamage != null && def.ReduceDamage.Any())
                {
                    foreach (var damage in def.ReduceDamage.Keys)
                    {
                        if (statControl.CurrentDamageEffects.IsFlagSet(damage))
                        {
                            var timeToRemove = AdvancedStatsAndEffectsAPI.GetPlayerFixedStatRemainTime(playerId, damage.ToString());
                            if (timeToRemove > 0)
                            {
                                timeToRemove -= (long)def.ReduceDamage[damage];
                                if (timeToRemove <= 0)
                                    statControl.MedicalDetector.ClearEffects();
                                AdvancedStatsAndEffectsAPI.SetPlayerFixedStatRemainTime(playerId, damage.ToString(), Math.Max(timeToRemove, 0));
                            }
                        }
                    }
                }
            }
        }

    }

}
