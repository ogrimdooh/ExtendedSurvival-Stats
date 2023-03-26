using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class FoodSettings
    {

        [XmlElement]
        public float ProteinsMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float CarbohydratesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float LipidsMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float VitaminsMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float MineralsMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float CaloriesMultiplier { get; set; } = 1.0f;

        [XmlElement]
        public float TimeToConsumeMultiplier { get; set; } = 1.0f;

        [XmlArray("Volumes"), XmlArrayItem("Food", typeof(EntityStorage))]
        public List<FoodVolumeSettings> Volumes { get; set; } = new List<FoodVolumeSettings>();

    }

}
