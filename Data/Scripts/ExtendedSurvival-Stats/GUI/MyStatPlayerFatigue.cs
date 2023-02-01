﻿namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerFatigue : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "Fatigue";
        }

        protected override string GetId()
        {
            return "player_fatigue";
        }

        protected override bool IsActive()
        {
            return ExtendedSurvivalSettings.Instance.StaminaEnabled && IsWithHelmet() && GetBodyTrackerLevel() >= 4;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }

}