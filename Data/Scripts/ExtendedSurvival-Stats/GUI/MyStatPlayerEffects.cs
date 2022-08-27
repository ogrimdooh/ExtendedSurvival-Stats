using Sandbox.Game.Components;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using System.Text;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public class MyStatPlayerEffects : MyStatBase
    {

        protected override string GetId()
        {
            return "player_effects";
        }

        MyEntityStat SurvivalEffects;
        MyEntityStat DamageEffects;
        MyEntityStat TemperatureEffects;
        MyEntityStat DiseaseEffects;
        MyEntityStat OtherEffects;
        MyEntityStatComponent StatComponent;

        public StatsConstants.SurvivalEffects CurrentSurvivalEffects
        {
            get
            {
                return SurvivalEffects != null ? (StatsConstants.SurvivalEffects)((int)SurvivalEffects.Value) : StatsConstants.SurvivalEffects.None;
            }
        }

        public StatsConstants.DamageEffects CurrentDamageEffects
        {
            get
            {
                return DamageEffects != null ? (StatsConstants.DamageEffects)((int)DamageEffects.Value) : StatsConstants.DamageEffects.None;
            }
        }

        public StatsConstants.TemperatureEffects CurrentTemperatureEffects
        {
            get
            {
                return TemperatureEffects != null ? (StatsConstants.TemperatureEffects)((int)TemperatureEffects.Value) : StatsConstants.TemperatureEffects.None;
            }
        }

        public StatsConstants.DiseaseEffects CurrentDiseaseEffects
        {
            get
            {
                return DiseaseEffects != null ? (StatsConstants.DiseaseEffects)((int)DiseaseEffects.Value) : StatsConstants.DiseaseEffects.None;
            }
        }

        public StatsConstants.OtherEffects CurrentOtherEffects
        {
            get
            {
                return OtherEffects != null ? (StatsConstants.OtherEffects)((int)OtherEffects.Value) : StatsConstants.OtherEffects.None;
            }
        }

        public bool IsValid
        {
            get
            {
                return StatComponent != null &&
                    SurvivalEffects != null &&
                    DamageEffects != null &&
                    TemperatureEffects != null &&
                    DiseaseEffects != null &&
                    OtherEffects != null;
            }
        }

        private MyEntityStat GetPlayerStat(string statName)
        {
            MyEntityStat stat;
            StatComponent.TryGetStat(MyStringHash.GetOrCompute(statName), out stat);
            return stat;
        }

        public override void Update()
        {
            StatComponent = MyAPIGateway.Session.Player?.Character?.Components.Get<MyEntityStatComponent>();
            if (StatComponent == null)
            {
                CurrentValue = 0;
                return;
            }
            SurvivalEffects = GetPlayerStat("SurvivalEffects");
            DamageEffects = GetPlayerStat("DamageEffects");
            TemperatureEffects = GetPlayerStat("TemperatureEffects");
            DiseaseEffects = GetPlayerStat("DiseaseEffects");
            OtherEffects = GetPlayerStat("OtherEffects");
            if (IsValid)
            {
                CurrentValue = SurvivalEffects.Value +
                    DamageEffects.Value +
                    TemperatureEffects.Value +
                    DiseaseEffects.Value +
                    OtherEffects.Value +
                    (IsWithHelmet() ? 1 : 0) +
                    GetBodyTrackerLevel();
            }
            else
            {
                CurrentValue = -1;
            }
        }

        public override string ToString()
        {
            StringBuilder sbEffects = new StringBuilder();
            StringBuilder sbFeeling = new StringBuilder();
            if (IsValid)
            {
                var bodyTrackLevel = GetBodyTrackerLevel();
                int toalEffects = 0;
                if (CurrentSurvivalEffects != StatsConstants.SurvivalEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentSurvivalEffects))
                    {
                        toalEffects += StatsConstants.GetSurvivalEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetSurvivalEffectTrackLevel(effect))
                        {
                            sbEffects.AppendLine(StatsConstants.GetSurvivalEffectDescription(effect));
                        }
                    }
                }
                if (CurrentTemperatureEffects != StatsConstants.TemperatureEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentTemperatureEffects))
                    {
                        toalEffects += StatsConstants.GetTemperatureEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetTemperatureEffectTrackLevel(effect))
                        {
                            sbEffects.AppendLine(StatsConstants.GetTemperatureEffectDescription(effect));
                        }
                    }
                }
                if (CurrentDamageEffects != StatsConstants.DamageEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentDamageEffects))
                    {
                        toalEffects += StatsConstants.GetDamageEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetDamageEffectTrackLevel(effect))
                        {
                            sbEffects.AppendLine(StatsConstants.GetDamageEffectDescription(effect));
                        }
                    }
                }
                if (CurrentDiseaseEffects != StatsConstants.DiseaseEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentDiseaseEffects))
                    {
                        toalEffects += StatsConstants.GetDiseaseEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetDiseaseEffectTrackLevel(effect))
                        {
                            sbEffects.AppendLine(StatsConstants.GetDiseaseEffectDescription(effect));
                        }
                    }
                }
                if (CurrentOtherEffects != StatsConstants.OtherEffects.None)
                {
                    foreach (var effect in StatsConstants.GetFlags(CurrentOtherEffects))
                    {
                        toalEffects += StatsConstants.GetOtherEffectFeelingLevel(effect);
                        if (bodyTrackLevel >= StatsConstants.GetOtherEffectTrackLevel(effect))
                        {
                            sbEffects.AppendLine(StatsConstants.GetOtherEffectDescription(effect));
                        }
                    }
                }
                sbFeeling.AppendLine(StatsConstants.GetFeelingByTotalEffects(toalEffects));
                if (sbEffects.Length > 0)
                {
                    sbFeeling.AppendLine();
                    sbFeeling.AppendLine("Known effects:");
                    sbFeeling.AppendLine();
                }
            }
            return IsWithHelmet() ? sbFeeling.ToString() + sbEffects.ToString() : "";
        }

    }

}