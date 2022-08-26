using Sandbox.ModAPI;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatTimersProgressBase : MyStatCompoundProgressBase
    {
        
        protected override string[] GetStatsNames()
        {
            return new string[] { "WetTime", "WoundedTime", "IntakeBodyFood", "IntakeBodyWater", "IntakeCarbohydrates", "IntakeProtein", "IntakeLipids", "IntakeVitamins", "IntakeMinerals" };
        }

        protected override bool IsActive(int index)
        {
            switch (index)
            {
                case 0:
                    return ExtendedSurvivalSettings.Instance.WetEnabled && IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0;
                case 1:
                    return ExtendedSurvivalSettings.Instance.DamageEffectsEnabled && IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                    return ExtendedSurvivalSettings.Instance.UseNutrition && IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0;
            }
            return false;
        }

        protected override string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                    return CurrentValue == 1 ? "Completely Wet" : (CurrentValue > 0 ? string.Format("{0:0}%", (float)(CurrentValue * 100.0)) : "Completely Dry");
                case 1:
                    return CurrentValue == 1 ? "Infected" : (CurrentValue > 0 ? string.Format("{0:0}%", (float)(CurrentValue * 100.0)) : "No Injuries");
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