namespace ExtendedSurvival.Stats
{
    public abstract class MyStatTimersDescProgressBase : MyStatTimersProgressBase
    {

        protected override string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                    return LanguageProvider.GetEntry(LanguageEntries.COLDTHERMALFLUID_NAME);
                case 1:
                    return LanguageProvider.GetEntry(LanguageEntries.HOTTHERMALFLUID_NAME);
                case 2:
                    return LanguageProvider.GetEntry(LanguageEntries.ENERGYSHIELD_NAME);
                case 3:
                    return LanguageProvider.GetEntry(LanguageEntries.STATTIMERS_TOXICEXPOSURE_NAME);
                case 4:
                    return LanguageProvider.GetEntry(LanguageEntries.STATTIMERS_UNTREATEDWOUND_NAME);
                case 5:
                    return LanguageProvider.GetEntry(LanguageEntries.STATTIMERS_RADIOACTIVEEXPOSURE_NAME);
                case 6:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYLIPIDS_NAME);
                case 7:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYVITAMINS_NAME);
                case 8:
                    return LanguageProvider.GetEntry(LanguageEntries.BODYMINERALS_NAME);
            }
            return "";
        }

    }

}