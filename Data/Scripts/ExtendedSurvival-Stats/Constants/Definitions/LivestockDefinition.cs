using System;
using System.Collections.Generic;
using System.Text;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public class LivestockDefinition : SimpleDefinition
    {

        public enum RecipeItemAmmountType
        {

            Fixed = 0,
            MassPercent = 1

        }

        public class RecipeItem
        {

            public UniqueEntityId Id { get; set; }
            public float Ammount { get; set; }
            public RecipeItemAmmountType Type { get; set; } = RecipeItemAmmountType.MassPercent;
            public bool AlowFraction { get; set; } = true;

            public float GetAmmount(float mass)
            {
                var amount = Ammount;
                if (Type == RecipeItemAmmountType.MassPercent)
                    amount *= mass;
                if (AlowFraction)
                    return amount;
                return (long)amount;
            }

        }

        public UniqueEntityId DeadId { get; set; }
        public bool IsDeadBody { get; set; } = false;
        public long StartConservationTime { get; set; } = 0;
        public string RecipeName { get; set; }
        public float RecipeTime { get; set; }
        public List<RecipeItem> BodyResults { get; set; }

        private string GetDedailDescription()
        {
            var values = new StringBuilder();
            if (LivestockConstants.ANIMALS_HERBICORES_IDS.Contains(Id))
            {
                values.AppendLine(" ");
                values.AppendLine("This is a herbivorous animal, and can feed on plant-based feed.");
            }
            else if (LivestockConstants.ANIMALS_CARNIVORES_IDS.Contains(Id))
            {
                values.AppendLine(" ");
                values.AppendLine("This is a carnivorous animal, and can feed on meat-based feed.");
            } 
            else if (LivestockConstants.ANIMALS_BIRDS_IDS.Contains(Id))
            {
                values.AppendLine(" ");
                values.AppendLine("This is a bird, and can feed on grain-based feed.");
            }
            if (IsDeadBody)
            {
                values.AppendLine(" ");
                values.AppendLine("Note: An animal carcass will rot over time, so as not to lose" + Environment.NewLine + 
                                  "the meat it can be processed in a slaughterhouse.");
                values.AppendLine(string.Format("Rotting time: {0}s", (StartConservationTime / 1000).ToString("#0.0")));
            }
            else
            {
                values.AppendLine(" ");
                values.AppendLine("Note: An animal needs to be placed in a Cage, and will need to" + Environment.NewLine +
                                  "regularly receive rations in the block's inventory according" + Environment.NewLine + 
                                  "to its diet.");
            }
            return values.ToString();
        }

        public ExtendedSurvivalCoreAPI.ItemExtraInfo GetItemExtraInfo()
        {
            var extraInfo = new ExtendedSurvivalCoreAPI.ItemExtraInfo()
            {
                DefinitionId = Id.DefinitionId,
                StartConservationTime = StartConservationTime,
                NeedUpdate = true,
                NeedConservation = IsDeadBody,
                RemoveWhenSpoil = true,
                RemoveAmmount = 1,
                AddNewItemWhenSpoil = true
            };
            if (IsDeadBody)
            {
                extraInfo.AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                {
                    new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = ItensConstants.SPOILED_MATERIAL_ID.DefinitionId,
                        Ammount = Mass * 0.12f
                    },
                    new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = OreConstants.BONES_ID.DefinitionId,
                        Ammount = Mass * 0.08f
                    }
                };
            }
            else
            {
                extraInfo.AddDefinitionId = new List<ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = DeadId.DefinitionId,
                            Ammount = 1
                        }
                    };
                extraInfo.CustomAttributes = new List<ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo>()
                    {
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ExtendedSurvivalCoreAPI.ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_POOP_FACTOR_ID,
                            Value = LivestockConstants.BASE_POOP_FACTOR
                        }
                    };
            }
            return extraInfo;
        }

        public override string GetFullDescription()
        {
            return base.GetFullDescription() + GetDedailDescription();
        }

    }

}