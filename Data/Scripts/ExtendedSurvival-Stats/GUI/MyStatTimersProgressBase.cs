using Sandbox.ModAPI;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatTimersProgressBase : MyStatCompoundProgressBase
    {
        
        protected override string[] GetStatsNames()
        {
            return new string[] { "WetTime", "WoundedTime", "", "", "", "", "", "" };
        }

        protected override bool IsActive(int index)
        {
            switch (index)
            {
                case 0:
                    return IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0 && GetBodyTrackerLevel() >= 1;
                case 1:
                    return IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0 && GetBodyTrackerLevel() >= 2;
                case 2:
                    return IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0 && GetBodyTrackerLevel() >= 3;
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    return IsWithHelmet() && Stats[index] != null && Stats[index].Value > 0 && GetBodyTrackerLevel() >= 4;
            }
            return false;
        }

        protected override string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                    return CurrentValue == 1 ? 
                        LanguageProvider.GetEntry(LanguageEntries.STATTIMERSPROGRESS_COMPLETELYWET_NAME) : 
                        (
                            CurrentValue > 0 ? string.Format("{0:0}%", (float)(CurrentValue * 100.0)) : 
                            LanguageProvider.GetEntry(LanguageEntries.STATTIMERSPROGRESS_COMPLETELYDRY_NAME)
                        );
                case 1:
                    return CurrentValue == 1 ? 
                        LanguageProvider.GetEntry(LanguageEntries.STATTIMERSPROGRESS_INFECTED_NAME) : 
                        (
                            CurrentValue > 0 ? 
                            string.Format("{0:0}%", (float)(CurrentValue * 100.0)) : 
                            LanguageProvider.GetEntry(LanguageEntries.STATTIMERSPROGRESS_NOINJURIES_NAME)
                        );
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