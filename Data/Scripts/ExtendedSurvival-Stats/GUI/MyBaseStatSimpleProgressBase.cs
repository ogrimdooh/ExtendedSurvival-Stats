using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public abstract class MyBaseStatSimpleProgressBase : MyStatBase
    {

        protected abstract string GetStatName();
        protected abstract MyEntityStatComponent GetStatComp();

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
                    statComp = GetStatComp();
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
            else
                CurrentValue = -1;
        }

        public override string ToString() => string.Format("{0:0}", (float)(CurrentValue * Stat?.MaxValue ?? 0));

    }

}