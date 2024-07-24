﻿using ProtoBuf;

namespace ExtendedSurvival.Stats
{
    [ProtoContract(SkipConstructor = true, UseProtoMembersOnly = true)]
    public class HyperthermiaSettings : BaseTemperatureComplexDiseaseSettings
    {

        public HyperthermiaSettings()
        {
            BaseChance = 0.005f;
            ExtremeChance = 0.01f;
            WetInfluence = 2f;
            RicketsInfluence = 2f;
            SevereRicketsInfluence = 4f;
            ObesityInfluence = 2f;
            SevereObesityInfluence = 4f;
        }

    }

}
