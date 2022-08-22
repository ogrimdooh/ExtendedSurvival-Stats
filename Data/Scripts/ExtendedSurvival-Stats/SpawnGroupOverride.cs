using Sandbox.Definitions;
using System;

namespace ExtendedSurvival.Stats
{
    public class SpawnGroupOverride
    {

        private static readonly string[] spawnGroups = new string[] 
        {
            "Earthlike_Animals",
            "Earthlike_Animals_Deer",
            "Earthlike_Animals_Sheep",
            "Earthlike_Animals_Cow_Horse",
            "Earthlike_Animals_Wolf",
            "CreatureSpawn-EarthLike-InternalDaySpawns",
            "CreatureSpawn-EarthLike-InternalNightSpawns",
            "Planet Agaris_Animals",
            "Planet Agaris_Animals_Deer",
            "Planet Agaris_Animals_Sheep",
            "Planet Agaris_Animals_Cow_Horse",
            "Planet Agaris_Animals_Wolf",
            "CreatureSpawn-Planet Agaris-InternalDaySpawns",
            "CreatureSpawn-Planet Agaris-InternalNightSpawns",
            "Earthlike_Animals_Medieval_Deer",
            "Earthlike_Animals_Medieval_Sheep",
            "Earthlike_Animals_Medieval_Cow_Horse",
            "Earthlike_Animals_Medieval_Wolf"
        };

        public static void SetDefinitions()
        {
            var spawns = MyDefinitionManager.Static.GetSpawnGroupDefinitions();
            foreach (var item in spawns)
            {
                if (spawnGroups.Contains(item.Id.SubtypeName))
                    item.Enabled = false;
            }
        }

    }

}