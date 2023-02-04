using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using VRage.ObjectBuilders;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PlayerData
    {

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class StatData
        {

            [XmlElement]
            public string Name { get; set; }
            [XmlElement]
            public float Value { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class IngestedFoodPropertyData
        {

            [XmlElement]
            public float Max { get; set; }
            [XmlElement]
            public float Current { get; set; }
            [XmlElement]
            public float ConsumeRate { get; set; }
            [XmlElement]
            public bool IsPositive { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class IngestedFoodData
        {

            [XmlElement]
            public SerializableDefinitionId Id { get; set; }

            [XmlElement]
            public IngestedFoodPropertyData Solid { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Liquid { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Protein { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Carbohydrate { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Lipids { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Vitamins { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Minerals { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData Calories { get; set; }

        }

        [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
        public class ActiveConsumibleEffectData
        {

            [XmlElement]
            public SerializableDefinitionId Id { get; set; }

            [XmlElement]
            public int EffectTarget { get; set; }
            [XmlElement]
            public IngestedFoodPropertyData CurrentValue { get; set; }

        }

        [XmlElement]
        public long PlayerId { get; set; }
        [XmlElement]
        public ulong SteamPlayerId { get; set; }
        [XmlArray("Stats"), XmlArrayItem("Stat", typeof(StatData))]
        public List<StatData> Stats { get; set; } = new List<StatData>();
        [XmlArray("IngestedFoods"), XmlArrayItem("Food", typeof(IngestedFoodData))]
        public List<IngestedFoodData> IngestedFoods { get; set; } = new List<IngestedFoodData>();
        public List<ActiveConsumibleEffectData> ActiveFoodEffects { get; set; } = new List<ActiveConsumibleEffectData>();

        public void SetStatValue(string name, float value)
        {
            if (Stats.Any(x => x.Name == name))
                Stats.FirstOrDefault(x => x.Name == name).Value = value;
            else
                Stats.Add(new StatData()
                {
                    Name = name,
                    Value = value
                });
        }

        public float GetStatValue(string name)
        {
            if (Stats.Any(x => x.Name == name))
                return Stats.FirstOrDefault(x => x.Name == name).Value;
            return 0;
        }

    }

}