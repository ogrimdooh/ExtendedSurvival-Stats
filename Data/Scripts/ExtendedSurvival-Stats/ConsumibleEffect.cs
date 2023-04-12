using System;

namespace ExtendedSurvival.Stats
{
    public class ConsumibleEffect
    {

        public FoodEffectTarget EffectTarget { get; set; } = FoodEffectTarget.Health;
        public FoodEffectType EffectType { get; set; } = FoodEffectType.Instant;
        public float Ammount { get; set; }
        public float TimeToEffect { get; set; }

        public void Increment(ConsumibleEffect other, float multiplier = 1)
        {
            if (other.EffectTarget == EffectTarget && other.EffectType == EffectType)
            {
                Ammount += other.Ammount * multiplier;
                TimeToEffect = Math.Max(TimeToEffect, other.TimeToEffect * multiplier);
            }
        }

        public ConsumibleEffect GetNew(float multiplier = 1)
        {
            return new ConsumibleEffect()
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