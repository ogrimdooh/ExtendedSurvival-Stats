using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatCompoundProgressBase : MyStatBase
    {

        protected abstract int GetTargetIndex();
        protected abstract string[] GetStatsNames();
        protected abstract bool IsActive(int index);

        protected virtual string GetDescription(int index)
        {
            return string.Format("{0:0}", (float)(CurrentValue * Stat.MaxValue));
        }

        protected int CurrentIndex { get; set; }

        protected List<int> ActiveIndexs = new List<int>();
        protected void LoadActiveIndexs()
        {
            ActiveIndexs.Clear();
            if (Stats != null && Stats.Count > 0)
            {
                for (int i = 0; i < Stats.Count; i++)
                {
                    if (IsActive(i))
                        ActiveIndexs.Add(i);
                }
            }
        }

        protected virtual bool IsActive()
        {
            return IsActive(CurrentIndex);
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

        protected List<MyEntityStat> Stats { get; set; }
        protected MyEntityStat Stat
        {
            get
            {
                ReloadStats();
                if (CurrentIndex >= 0 && CurrentIndex < Stats.Count)
                    return Stats[CurrentIndex];
                return null;
            }
        }

        private void ResetStats()
        {
            statComp = null;
            Stats = null;
            ReloadStats();
        }

        private void ReloadStats()
        {
            if (StatComp != null && Stats == null)
            {
                Stats = new List<MyEntityStat>();
                foreach (var statName in GetStatsNames())
                {
                    MyEntityStat stat = null;
                    StatComp.TryGetStat(MyStringHash.GetOrCompute(statName), out stat);
                    Stats.Add(stat);
                }
            }
        }

        protected virtual float GetCurrentValue()
        {
            return IsActive() ? Stat.Value / Stat.MaxValue : -1;
        }

        public override void Update()
        {
            ResetStats();
            LoadActiveIndexs();
            var targetIndex = GetTargetIndex();
            if (targetIndex <= ActiveIndexs.Count - 1)
            {
                CurrentIndex = ActiveIndexs[targetIndex];
            }
            else
            {
                CurrentIndex = -1;
            }
            if (IsActive())
                CurrentValue = GetCurrentValue();
            else
                CurrentValue = -1;
        }

        public override string ToString() => GetDescription(CurrentIndex);

    }

}