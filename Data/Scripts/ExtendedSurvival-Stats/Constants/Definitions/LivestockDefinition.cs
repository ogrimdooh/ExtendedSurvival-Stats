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
                values.AppendLine(LanguageProvider.GetEntry(LanguageEntries.LIVESTOCKDEFINITION_HERBIVOROUS_DESCRIPTION));
            }
            else if (LivestockConstants.ANIMALS_CARNIVORES_IDS.Contains(Id))
            {
                values.AppendLine(" ");
                values.AppendLine(LanguageProvider.GetEntry(LanguageEntries.LIVESTOCKDEFINITION_CARNIVOROUS_DESCRIPTION));
            } 
            else if (LivestockConstants.ANIMALS_BIRDS_IDS.Contains(Id))
            {
                values.AppendLine(" ");
                values.AppendLine(LanguageProvider.GetEntry(LanguageEntries.LIVESTOCKDEFINITION_BIRD_DESCRIPTION));
            }
            if (IsDeadBody)
            {
                values.AppendLine(" ");
                values.AppendLine(string.Format(
                    LanguageProvider.GetEntry(LanguageEntries.LIVESTOCKDEFINITION_CARCASS_DESCRIPTION), 
                    (StartConservationTime / 1000).ToString("#0.0")
                ));
            }
            else
            {
                values.AppendLine(" ");
                values.AppendLine(LanguageProvider.GetEntry(LanguageEntries.LIVESTOCKDEFINITION_DESCRIPTION));
            }
            return values.ToString();
        }

        public ItemExtraInfo GetItemExtraInfo()
        {
            var extraInfo = new ItemExtraInfo()
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
                extraInfo.AddDefinitionId = new List<ItemExtraDefinitionAmmountInfo>()
                {
                    new ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = ItensConstants.SPOILED_MATERIAL_ID.DefinitionId,
                        Ammount = Mass * 0.12f
                    },
                    new ItemExtraDefinitionAmmountInfo()
                    {
                        DefinitionId = OreConstants.BONES_ID.DefinitionId,
                        Ammount = Mass * 0.08f
                    }
                };
            }
            else
            {
                extraInfo.AddDefinitionId = new List<ItemExtraDefinitionAmmountInfo>()
                    {
                        new ItemExtraDefinitionAmmountInfo()
                        {
                            DefinitionId = DeadId.DefinitionId,
                            Ammount = 1
                        }
                    };
                extraInfo.CustomAttributes = new List<ItemExtraCustomAttributeInfo>()
                    {
                        new ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_EAT_FACTOR_ID,
                            Value = LivestockConstants.BASE_EAT_FACTOR
                        },
                        new ItemExtraCustomAttributeInfo()
                        {
                            Key = LivestockConstants.CREATURE_ABSORCION_FACTOR_ID,
                            Value = LivestockConstants.BASE_ABSORCION_FACTOR
                        },
                        new ItemExtraCustomAttributeInfo()
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