using VRage.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatBase : IMyHudStat
    {

        protected abstract string GetId();
        public abstract void Update();

        public MyStatBase()
        {
            Id = MyStringHash.GetOrCompute(GetId());
        }

        protected float m_currentValue;
        protected string m_valueStringCache;

        public MyStringHash Id { get; protected set; }

        public float CurrentValue
        {
            get { return m_currentValue; }
            protected set
            {
                if (m_currentValue == value)
                    return;
                m_currentValue = value;
                m_valueStringCache = null;
            }
        }

        public virtual float MaxValue => 1f;
        public virtual float MinValue => 0.0f;

        public string GetValueString()
        {
            if (m_valueStringCache == null)
                m_valueStringCache = ToString();
            return m_valueStringCache;
        }

    }

}