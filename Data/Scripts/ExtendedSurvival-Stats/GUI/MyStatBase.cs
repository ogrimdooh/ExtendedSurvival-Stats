using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.ModAPI;
using VRage.Utils;

namespace ExtendedSurvival.Stats
{
    public abstract class MyStatBase : IMyHudStat
    {

        protected MyInventory GetInventory()
        {
            return MyAPIGateway.Session.Player?.Character?.GetInventory() as MyInventory;
        }

        protected bool HasItem(UniqueEntityId itemId)
        {
            return (GetInventory()?.GetItemAmount(itemId.DefinitionId) ?? 0) > 0;
        }

        protected int GetBodyTrackerLevel()
        {
            if (HasItem(ItensConstants.ELITEBODYTRACKER_ID))
                return 4;
            if (HasItem(ItensConstants.PROFICIENTBODYTRACKER_ID))
                return 3;
            if (HasItem(ItensConstants.ENHANCEDBODYTRACKER_ID))
                return 2;
            if (HasItem(ItensConstants.BODYTRACKER_ID))
                return 1;
            return 0;
        }

        protected bool IsWithHelmet()
        {
            return MyAPIGateway.Session.Player?.Character?.EnabledHelmet ?? false;
        }

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