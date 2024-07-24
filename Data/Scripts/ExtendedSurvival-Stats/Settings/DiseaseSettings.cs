using ProtoBuf;
using System.Xml.Serialization;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class DiseaseSettings
    {

        [XmlElement]
        public bool WeightDiseaseEnabled { get; set; } = true;

        [XmlElement]
        public FluSettings Flu { get; set; } = new FluSettings();

        [XmlElement]
        public PneumoniaSettings Pneumonia { get; set; } = new PneumoniaSettings();

        [XmlElement]
        public HypothermiaSettings Hypothermia { get; set; } = new HypothermiaSettings();

        [XmlElement]
        public HyperthermiaSettings Hyperthermia { get; set; } = new HyperthermiaSettings();

    }

}
