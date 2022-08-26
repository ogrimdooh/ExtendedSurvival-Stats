using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatSimpleProgressBase : MyStatBase
    {

        protected bool IsWithHelmet()
        {
            return MyAPIGateway.Session.Player?.Character?.EnabledHelmet ?? false;
        }

        protected abstract string GetStatName();

        protected virtual bool IsActive()
        {
            return true;
        }

        private MyEntityStatComponent statComp;
        protected MyEntityStatComponent StatComp
        {
            get
            {
                if (statComp == null)
                    statComp = MyAPIGateway.Session.Player?.Character?.Components.Get<MyEntityStatComponent>();
                return statComp;
            }
        }

        private MyEntityStat stat;
        protected MyEntityStat Stat
        {
            get
            {
                if (StatComp != null && stat == null)
                {
                    StatComp.TryGetStat(MyStringHash.GetOrCompute(GetStatName()), out stat);
                }
                return stat;
            }
        }

        protected virtual float GetCurrentValue()
        {
            return IsActive() ? Stat.Value / Stat.MaxValue : -1;
        }

        public override void Update()
        {
            statComp = null;
            stat = null;
            if (Stat != null)
                CurrentValue = GetCurrentValue();
        }

        public override string ToString() => string.Format("{0:0}", (float)(CurrentValue * Stat.MaxValue));

    }

}