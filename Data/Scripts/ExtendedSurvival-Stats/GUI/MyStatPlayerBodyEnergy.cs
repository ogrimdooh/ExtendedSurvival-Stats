using Sandbox.Game.Entities;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyEnergy : MyStatSimpleProgressBase
    {

        protected override string GetStatName()
        {
            return "BodyEnergy";
        }

        protected override string GetId()
        {
            return "player_bodyenergy";
        }

        protected override bool IsActive()
        {
            return IsWithHelmet() && GetBodyTrackerLevel() >= 1;
        }

        public override string ToString() => string.Format("{0:0}%", (float)(CurrentValue * 100.0));

    }
}