using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using VRage.Game;
using VRage.Game.ModAPI;

namespace ExtendedSurvival.Stats
{
    public static class PlayerHealthController
    {

        public static void ProcessHealth(long playerId, MyCharacterStatComponent statComponent)
        {
            PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
            var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);

            var maxDamage = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(statsEasyAcess.CurrentDamageEffects);
            var finalRegen = StatsConstants.BASE_HEALTH_REGEN_FACTOR;
            var maxRegen = 1f;
            var maxValue = statComponent.Health.MaxValue;
            if (maxDamage != StatsConstants.DamageEffects.None)
            {
                finalRegen *= PlayerActionsController.StatsMultiplier(playerId, HealthController.HealthValueModifier.RegenerationFactor);
                maxRegen = PlayerActionsController.StatsMultiplier(playerId, HealthController.HealthValueModifier.MaximumRegenerationHealth);
                maxValue *= PlayerActionsController.StatsMultiplier(playerId, HealthController.HealthValueModifier.MaxHealth);
            }
            var currentStatusValue = statComponent.Health.Value / statComponent.Health.MaxValue;
            if (currentStatusValue < maxRegen)
            {
                statComponent.Health.Increase(finalRegen, null);
            }
            if (statComponent.Health.Value > maxValue)
            {
                statComponent.Health.Value = maxValue;
            }
        }

        private const float MAX_HEALTH_REGEN_AT_SURVIVAL_KIT = 0.5f;
        public static void PlayerHealthRecharging(long playerId, MyCharacterStatComponent statComponent)
        {
            var maxLife = MAX_HEALTH_REGEN_AT_SURVIVAL_KIT * statComponent.Health.MaxValue;
            var lastHealthChanged = AdvancedStatsAndEffectsAPI.GetLastHealthChange(playerId);
            if (lastHealthChanged.X > maxLife)
            {
                if (lastHealthChanged.Y > maxLife)
                    statComponent.Health.Value = lastHealthChanged.Y;
                else
                    statComponent.Health.Value = maxLife;
            }
        }

        public static void DoReciveDamage(IMyCharacter character, ref MyDamageInformation damage)
        {
            var playerId = character.GetPlayerId();
            var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
            if (armorInfo != null && armorInfo.HasArmor)
            {
                var damageType = ArmorSystemConstants.GetDamageType(damage.Type);
                if (armorInfo.Shield.HasShield && ExtendedSurvivalCoreAPI.Registered)
                {
                    var stats = PlayerActionsController.GetStatsEasyAcess(playerId);
                    if (stats != null && stats.EnergyShield.Value > 0)
                    {
                        var currentShield = stats.EnergyShield.Value * armorInfo.Shield.MaxShield;
                        var baseDamage = damage.Amount;
                        if (currentShield > damage.Amount)
                        {
                            currentShield -= damage.Amount;
                            damage.Amount = 0;
                        }
                        else
                        {
                            damage.Amount -= currentShield;
                            baseDamage = currentShield;
                            currentShield = 0;
                        }
                        stats.EnergyShield.Value = currentShield / armorInfo.Shield.MaxShield;
                        var shieldInfo = PlayerShieldController.GetPlayerShieldInfo(playerId);
                        shieldInfo.LastHit = ExtendedSurvivalCoreAPI.GetGameTime();
                        if (armorInfo.Shield.HasSpike)
                        {
                            var spikeDamage = baseDamage * armorInfo.Shield.SpikeTurn;
                            if (spikeDamage > 0)
                            {
                                IMyCharacter attackerCharacter = null;
                                if (damageType == ArmorSystemConstants.DamageType.Creature)
                                {
                                    var attacker = MyAPIGateway.Entities.GetEntityById(damage.AttackerId);
                                    if (attacker != null)
                                    {
                                        attackerCharacter = attacker as IMyCharacter;
                                    }
                                }
                                else if (damageType == ArmorSystemConstants.DamageType.Tool)
                                {
                                    var attackerTool = MyAPIGateway.Entities.GetEntityById(damage.AttackerId);
                                    if (attackerTool != null)
                                    {
                                        var handTool = attackerTool as Sandbox.ModAPI.Weapons.IMyEngineerToolBase;
                                        if (handTool != null)
                                        {
                                            var attacker = MyAPIGateway.Entities.GetEntityById(handTool.OwnerId);
                                            if (attacker != null)
                                            {
                                                attackerCharacter = attacker as IMyCharacter;
                                            }
                                        }
                                        else
                                        {
                                            var handDrill = attackerTool as Sandbox.ModAPI.Weapons.IMyHandDrill;
                                            if (handDrill != null)
                                            {
                                                var attacker = MyAPIGateway.Entities.GetEntityById((handDrill as IMyGunBaseUser).OwnerId);
                                                if (attacker != null)
                                                {
                                                    attackerCharacter = attacker as IMyCharacter;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (attackerCharacter != null)
                                {
                                    attackerCharacter.DoDamage(spikeDamage, MyDamageType.Radioactivity, true, attackerId: character.EntityId);
                                }
                            }
                        }
                    }
                }
                if (damage.Amount > 0)
                {
                    if (damageType != ArmorSystemConstants.DamageType.None)
                    {
                        if (armorInfo.ArmorDefinition.Resistences.ContainsKey(damageType))
                        {
                            var amountToChange = damage.Amount * armorInfo.ArmorDefinition.Resistences[damageType];
                            damage.Amount -= amountToChange;
                        }
                    }
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

        public static void CheckHealthDamage(long playerId, MyCharacterStatComponent statComponent, float damage)
        {
            PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
            var percentDamage = damage / statComponent.Health.MaxValue;
            var finalHealth = statComponent.Health.Value - damage;
            if (finalHealth > 0 && !PlayerDeathController.PlayerHasDied(playerId)) /* No effect on isntant death */
            {
                var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
                var percentValue = finalHealth / statComponent.Health.MaxValue;
                if (percentDamage >= 0.6f || percentValue <= 0.15f)
                {
                    AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.BrokenBones.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.DeepWounded.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Wounded.ToString(), 0, true);
                    AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                }
                else if (percentDamage >= 0.4f || percentValue <= 0.3f)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.DeepWounded.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Wounded.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                    }
                }
                else if (percentDamage >= 0.2f || percentValue <= 0.45f)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones) &&
                        !StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.Wounded.ToString(), 0, true);
                        AdvancedStatsAndEffectsAPI.RemoveFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                    }
                }
                else if (percentDamage >= 0.1f || percentValue <= 0.6f)
                {
                    if (!StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones) &&
                        !StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) &&
                        !StatsConstants.IsFlagSet(statsEasyAcess.CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                    {
                        AdvancedStatsAndEffectsAPI.AddFixedEffect(playerId, StatsConstants.DamageEffects.Contusion.ToString(), 0, true);
                    }
                }
            }
        }

        public static void CheckValuesToDoDamage(long playerId, IMyCharacter character, MyCharacterStatComponent statComponent)
        {
            if (character.CanTakeDamage())
            {
                try
                {
                    PlayerActionsController.RefreshPlayerStatComponent(playerId, statComponent);
                    var statsEasyAcess = PlayerActionsController.GetStatsEasyAcess(playerId);
                    if (statsEasyAcess.BodyWater.Value == 0)
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

    }

}
