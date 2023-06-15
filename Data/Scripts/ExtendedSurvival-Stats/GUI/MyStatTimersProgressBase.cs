using Sandbox.ModAPI;
using System;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatTimersProgressBase : MyStatCompoundProgressBase
    {
        
        protected override string[] GetStatsNames()
        {
            return new string[] 
            { 
                "ColdThermalFluid",
                "HotThermalFluid", 
                "RadiationTime", 
                "IntoxicationTime",
                "BodyProtein",
                "BodyCarbohydrate",
                "BodyLipids",
                "BodyVitamins",
                "BodyMinerals",
                "BodyMinerals"
            };
        }

        protected override bool IsActive(int index)
        {
            try
            {
                var armor = PlayerArmorController.GetEquipedArmor(0, useCache: true);
                if (Stats != null)
                {
                    switch (index)
                    {
                        case 0:
                            return IsWithHelmet() && Stats[index] != null && GetBodyTrackerLevel() >= 1 && armor.HasValue && armor.Value.HasAnyModule(EquipmentConstants.COLDTHERMALREGULATORS_MODULES);
                        case 1:
                            return IsWithHelmet() && Stats[index] != null && GetBodyTrackerLevel() >= 1 && armor.HasValue && armor.Value.HasAnyModule(EquipmentConstants.HOTTHERMALREGULATORS_MODULES);
                        case 2:
                        case 3:
                            return IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0 && GetBodyTrackerLevel() >= 3;
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            return IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0 && GetBodyTrackerLevel() >= 4;
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
            return false;
        }

        protected override string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                case 1:
                    return CurrentValue.ToString("P2");
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    return CurrentValue == 1 ? "Full" : (CurrentValue > 0 ? string.Format("{0:0}%", (float)(CurrentValue * 100.0)) : "Empty");
            }
            return base.GetDescription(index);
        }

    }

}