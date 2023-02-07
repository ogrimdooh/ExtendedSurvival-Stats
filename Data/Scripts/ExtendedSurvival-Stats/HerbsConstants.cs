using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class HerbsConstants
    {

        public const string ARNICA_SUBTYPEID = "Arnica";
        public static readonly UniqueEntityId ARNICA_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ARNICA_SUBTYPEID);

        public const string CHAMOMILE_SUBTYPEID = "Chamomile";
        public static readonly UniqueEntityId CHAMOMILE_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), CHAMOMILE_SUBTYPEID);

        public const string ALOEVERA_SUBTYPEID = "AloeVera";
        public static readonly UniqueEntityId ALOEVERA_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ALOEVERA_SUBTYPEID);

        public const string MINT_SUBTYPEID = "Mint";
        public static readonly UniqueEntityId MINT_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), MINT_SUBTYPEID);

        public const string ERYTHROXYLUM_SUBTYPEID = "Erythroxylum";
        public static readonly UniqueEntityId ERYTHROXYLUM_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ore), ERYTHROXYLUM_SUBTYPEID);

        public static readonly HerbDefinition ARNICA_DEFINITION = new HerbDefinition()
        {
            Id = ARNICA_ID,
            Name = "Arnica",
            Description = "Arnica is a rare common flower and has anti-inflammatory and anti-biotic applications.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 250,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.1f,
            Volume = 0.01f
        };

        public static readonly HerbDefinition CHAMOMILE_DEFINITION = new HerbDefinition()
        {
            Id = CHAMOMILE_ID,
            Name = "Chamomile",
            Description = "Chamomile is a very common flower and has calming and digestive effects.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 90,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.1f,
            Volume = 0.01f
        };

        public static readonly HerbDefinition ALOEVERA_DEFINITION = new HerbDefinition()
        {
            Id = ALOEVERA_ID,
            Name = "Aloe vera",
            Description = "Aloe vera is a herb and has a wide application in medicine.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.1f,
            Volume = 0.01f
        };

        public static readonly HerbDefinition MINT_DEFINITION = new HerbDefinition()
        {
            Id = MINT_ID,
            Name = "Mint",
            Description = "Mint is a very common herb and has refreshing and digestive effects.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 90,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.1f,
            Volume = 0.01f
        };

        public static readonly HerbDefinition ERYTHROXYLUM_DEFINITION = new HerbDefinition()
        {
            Id = ERYTHROXYLUM_ID,
            Name = "Erythroxylum",
            Description = "Erythroxylum is a common herb with numbing effects.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 125,
            OfferAmount = new Vector2I(1000, 3000),
            OrderAmount = new Vector2I(250, 750),
            AcquisitionAmount = new Vector2I(500, 1500),
            Mass = 0.1f,
            Volume = 0.01f
        };

        public static readonly Dictionary<UniqueEntityId, HerbDefinition> HERBS_DEFINITIONS = new Dictionary<UniqueEntityId, HerbDefinition>()
        {
            { ARNICA_ID, ARNICA_DEFINITION },
            { CHAMOMILE_ID, CHAMOMILE_DEFINITION },
            { ALOEVERA_ID, ALOEVERA_DEFINITION },
            { MINT_ID, MINT_DEFINITION },
            { ERYTHROXYLUM_ID, ERYTHROXYLUM_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var herb in HERBS_DEFINITIONS.Keys)
                {
                    var herbDef = HERBS_DEFINITIONS[herb];
                    // Item definition
                    var itemDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(herb.subtypeId.String);
                    if (itemDef != null)
                    {
                        itemDef.Volume = herbDef.GetVolume();
                        itemDef.Mass = herbDef.GetMass();
                        itemDef.DisplayNameEnum = null;
                        itemDef.DisplayNameString = herbDef.Name;
                        itemDef.DescriptionEnum = null;
                        itemDef.DescriptionString = null;
                        itemDef.MinimumAcquisitionAmount = herbDef.AcquisitionAmount.X;
                        itemDef.MaximumAcquisitionAmount = herbDef.AcquisitionAmount.Y;
                        itemDef.MinimumOrderAmount = herbDef.OrderAmount.X;
                        itemDef.MaximumOrderAmount = herbDef.OrderAmount.Y;
                        itemDef.MinimumOfferAmount = herbDef.OfferAmount.X;
                        itemDef.MaximumOfferAmount = herbDef.OfferAmount.Y;
                        itemDef.MinimalPricePerUnit = herbDef.MinimalPricePerUnit;
                        itemDef.CanPlayerOrder = herbDef.CanPlayerOrder;
                        itemDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + herbDef.GetFullDescription());
                        itemDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(HerbsConstants), $"TryOverrideRecipes item not found. Food=[{herb}]");
                    // Add itens to faction types
                    if (herbDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(herb);
                        targetFaction.OrdersList.Add(herb);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(HerbsConstants), ex);
            }
        }

    }

}