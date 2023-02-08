namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerTemperatureTime : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "TemperatureTime";
        }

        protected override string GetId()
        {
            return "player_temperature_time";
        }

        protected override float GetCurrentValue()
        {
            return IsActive() ? (Stat.Value + Stat.MaxValue) / (Stat.MaxValue * 2) : -1;
        }

        public override string ToString()
        {
            if (Stat != null)
            {
                if (Stat.Value > StatsConstants.MIN_TO_GET_EFFECT_OVERHITING)
                    return LanguageProvider.GetEntry(LanguageEntries.BOILING_NAME);
                if (Stat.Value > StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
                    return LanguageProvider.GetEntry(LanguageEntries.TOOHOT_NAME);
                if (Stat.Value > 0)
                    return LanguageProvider.GetEntry(LanguageEntries.WARMINGUP_NAME);
                if (Stat.Value < StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
                    return LanguageProvider.GetEntry(LanguageEntries.FREEZING_NAME);
                if (Stat.Value < StatsConstants.MIN_TO_GET_EFFECT_COLD)
                    return LanguageProvider.GetEntry(LanguageEntries.VERYCOLD_NAME);
                if (Stat.Value < 0)
                    return LanguageProvider.GetEntry(LanguageEntries.COOLINGDOWN_NAME);
            }
            return LanguageProvider.GetEntry(LanguageEntries.STABLE_NAME);
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 1;
        }

    }

}