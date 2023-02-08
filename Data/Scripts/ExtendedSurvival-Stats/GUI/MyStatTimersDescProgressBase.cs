namespace ExtendedSurvival.Stats
{
    public abstract class MyStatTimersDescProgressBase : MyStatTimersProgressBase
    {

        protected override string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                    return LanguageProvider.GetEntry(LanguageEntries.STATTIMERS_WETLEVEL_NAME);
                case 1:
                    return LanguageProvider.GetEntry(LanguageEntries.STATTIMERS_UNTREATEDWOUND_NAME);
                case 2:
                    return "";
                case 3:
                    return "";
                case 4:
                    return "";
                case 5:
                    return "";
                case 6:
                    return "";
                case 7:
                    return "";
            }
            return "";
        }

    }

}