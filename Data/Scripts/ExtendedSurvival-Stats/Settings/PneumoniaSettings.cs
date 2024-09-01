using ProtoBuf;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class PneumoniaSettings : BaseTemperatureDiseaseSettings
    {

        public PneumoniaSettings()
        {
            BaseChance = 0.0025f;
            ExtremeChance = 0.005f;
            WetInfluence = 1.25f;
        }

    }

}
