﻿using Sandbox.Definitions;
using System.Collections.Generic;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{
    public static class IngotsConstants
    {

        public static readonly UniqueEntityId BONEMEAL_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), OreConstants.BONES_SUBTYPEID);

        public static readonly UniqueEntityId CARBON_POWDER_ID = new UniqueEntityId(typeof(MyObjectBuilder_Ingot), OreConstants.CARBON_SUBTYPEID);

        public static readonly IngotDefinition BONEMEAL_DEFINITION = new IngotDefinition()
        {
            Id = BONEMEAL_ID,
            Name = LanguageProvider.GetEntry(LanguageEntries.BONEMEAL_NAME),
            Description = LanguageProvider.GetEntry(LanguageEntries.BONEMEAL_DESCRIPTION),
            CanPlayerOrder = true,
            MinimalPricePerUnit = 2,
            OfferAmount = new Vector2I(10000, 30000),
            OrderAmount = new Vector2I(2500, 7500),
            AcquisitionAmount = new Vector2I(5000, 15000),
            Mass = 1f,
            Volume = 0.05f
        };

        public static readonly Dictionary<UniqueEntityId, IngotDefinition> INGOTS_DEFINITIONS = new Dictionary<UniqueEntityId, IngotDefinition>()
        {
            { BONEMEAL_ID, BONEMEAL_DEFINITION }
        };

        public static void TryOverrideDefinitions()
        {
            PhysicalItemDefinitionOverride.TryOverrideDefinitions<IngotDefinition, MyPhysicalItemDefinition>(INGOTS_DEFINITIONS);
        }

        public static void RegisterShopItens()
        {
            ExtendedSurvivalCoreAPI.AddItemToShop(new StationShopItemInfo()
            {
                Id = BONEMEAL_ID.DefinitionId,
                Rarity = ItemRarity.Common,
                CanBuy = true,
                CanSell = true,
                CanOrder = true,
                ForceMinimalPrice = true,
                TargetFactions = new FactionType[] { FactionType.Farming }
            });
        }

    }

}