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
                    return "Boiling";
                if (Stat.Value > StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
                    return "Too Hot";
                if (Stat.Value > 0)
                    return "Warming Up";
                if (Stat.Value < StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
                    return "Freezing";
                if (Stat.Value < StatsConstants.MIN_TO_GET_EFFECT_COLD)
                    return "Very Cold";
                if (Stat.Value < 0)
                    return "Cooling Down";
            }
            return "Stable";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.BodyTemperatureEnabled && IsWithHelmet() && GetBodyTrackerLevel() >= 1;
        }

    }

}