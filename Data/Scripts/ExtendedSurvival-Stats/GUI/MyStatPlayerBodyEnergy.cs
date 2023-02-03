using Sandbox.Game.Entities;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerBodyEnergy : MyStatSimpleProgressBase
    {

        private MyEntityStat BodyCalories;

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
            return IsWithHelmet() && GetBodyTrackerLevel() >= 2;
        }

        private MyEntityStat GetPlayerStat(string statName)
        {
            MyEntityStat stat;
            StatComp.TryGetStat(MyStringHash.GetOrCompute(statName), out stat);
            return stat;
        }

        public override void Update()
        {
            base.Update();
            BodyCalories = GetPlayerStat(StatsConstants.ValidStats.BodyCalories.ToString());
        }

        public override string ToString() => BodyCalories != null ? BodyCalories.Value.ToString("#0.00") : "-";

    }

}