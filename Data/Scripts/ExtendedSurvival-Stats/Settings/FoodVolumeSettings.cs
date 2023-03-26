using ProtoBuf;
using System.Xml.Serialization;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class FoodVolumeSettings
    {

        [XmlElement]
        public SerializableDefinitionId Id { get; set; }

        [XmlElement]
        public float Multiplier { get; set; } = 1.0f;

    }

}
