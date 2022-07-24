using System.Xml.Serialization;

namespace ExtendedSurvival
{

    public abstract class AttributeSettings
    {

        [XmlElement]
        public float DrainMultiplier { get; set; } = 1.0f;

    }

}
