using Sandbox.Game;
using System.Collections.Concurrent;

namespace ExtendedSurvival.Stats
{
    public static class PlayerShieldController
    {

        private static readonly ConcurrentDictionary<long, PlayerShieldInfo> player_shield_status = new ConcurrentDictionary<long, PlayerShieldInfo>();

        public const long TIME_BEFORE_CAN_REGENERATE = 10000;
        public const long TIME_BETWEEN_EACH_REGENERATE = 1000;
        public class PlayerShieldInfo
        {
            public long LastHit { get; set; }
            public long LastRegen { get; set; }
            public bool CanRegenerate
            {
                get
                {
                    if (ExtendedSurvivalCoreAPI.Registered)
                    {
                        var gameTime = ExtendedSurvivalCoreAPI.GetGameTime();
                        if (LastHit == 0 || (gameTime - LastHit) > TIME_BEFORE_CAN_REGENERATE)
                        {
                            return LastRegen == 0 || (gameTime - LastRegen) > TIME_BETWEEN_EACH_REGENERATE;
                        }
                    }
                    return false;
                }
            }
        }

        public static PlayerShieldInfo GetPlayerShieldInfo(long playerId)
        {
            if (!player_shield_status.ContainsKey(playerId))
                player_shield_status[playerId] = new PlayerShieldInfo();
            return player_shield_status[playerId];
        }

        public static void UpdateShieldStats(PlayerStatsEasyAcess playerStats, PlayerArmorController.PlayerEquipInfo armor, long playerId)
        {
            if (playerStats != null)
            {
                if (armor != null && armor.HasArmor && armor.Shield.HasShield)
                {
                    var shieldInfo = GetPlayerShieldInfo(playerId);
                    var energy = MyVisualScriptLogicProvider.GetPlayersEnergyLevel(playerId);
                    var drainEnergy = armor.Shield.PowerCost / 10;
                    if (playerStats.EnergyShield.Value < 1 && energy >= drainEnergy && shieldInfo.CanRegenerate)
                    {
                        var currentAmount = armor.Shield.MaxShield * playerStats.EnergyShield.Value;
                        currentAmount += armor.Shield.RechargeRate;
                        playerStats.EnergyShield.Value = currentAmount / armor.Shield.MaxShield;
                        if (playerStats.EnergyShield.Value > 1)
                            playerStats.EnergyShield.Value = 1;
                        shieldInfo.LastRegen = ExtendedSurvivalCoreAPI.GetGameTime();
                        /* Power Consume */
                        MyVisualScriptLogicProvider.SetPlayersEnergyLevel(playerId, energy - drainEnergy);
                    }
                }
                else
                {
                    playerStats.EnergyShield.Value = 0;
                }
            }
        }

    }

}
