using System;

namespace ExtendedSurvival.Stats
{
    public class FoodEffect
    {

        public FoodEffectTarget EffectTarget { get; set; } = FoodEffectTarget.Health;
        public FoodEffectType EffectType { get; set; } = FoodEffectType.None;
        public float Ammount { get; set; }
        public float TimeToEffect { get; set; }

        public void Increment(FoodEffect other, float multiplier = 1)
        {
            if (other.EffectTarget == EffectTarget && other.EffectType == EffectType)
            {
                Ammount += other.Ammount * multiplier;
                TimeToEffect = Math.Max(TimeToEffect, other.TimeToEffect * multiplier);
            }
        }

        public FoodEffect GetNew(float multiplier = 1)
        {
            return new FoodEffect()
            {
                EffectTarget = EffectTarget,
                EffectType = EffectType,
                Ammount = Ammount * multiplier,
                TimeToEffect = TimeToEffect * multiplier
            };
        }

        public void Divide(float multiplier)
        {
            Ammount /= multiplier;
            TimeToEffect /= multiplier;
        }

    }

}