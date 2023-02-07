using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRageMath;

namespace ExtendedSurvival.Stats
{

    public static class LivestockConstants
    {

        public enum AnimalGender
        {

            Baby = 0,
            Male = 1,
            Female = 2

        }

        public const string COWMALE_SUBTYPEID = "CowMale";
        public static readonly UniqueEntityId COWMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COWMALE_SUBTYPEID);

        public const string COWFEMALE_SUBTYPEID = "CowFemale";
        public static readonly UniqueEntityId COWFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COWFEMALE_SUBTYPEID);

        public const string COWBABY_SUBTYPEID = "CowBaby";
        public static readonly UniqueEntityId COWBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), COWBABY_SUBTYPEID);

        public const string DEERMALE_SUBTYPEID = "DeerMale";
        public static readonly UniqueEntityId DEERMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), DEERMALE_SUBTYPEID);

        public const string DEERFEMALE_SUBTYPEID = "DeerFemale";
        public static readonly UniqueEntityId DEERFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), DEERFEMALE_SUBTYPEID);

        public const string DEERBABY_SUBTYPEID = "DeerBaby";
        public static readonly UniqueEntityId DEERBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), DEERBABY_SUBTYPEID);

        public const string HORSEMALE_SUBTYPEID = "HorseMale";
        public static readonly UniqueEntityId HORSEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HORSEMALE_SUBTYPEID);

        public const string HORSEFEMALE_SUBTYPEID = "HorseFemale";
        public static readonly UniqueEntityId HORSEFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HORSEFEMALE_SUBTYPEID);

        public const string HORSEBABY_SUBTYPEID = "HorseBaby";
        public static readonly UniqueEntityId HORSEBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), HORSEBABY_SUBTYPEID);

        public const string SHEEPMALE_SUBTYPEID = "SheepMale";
        public static readonly UniqueEntityId SHEEPMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SHEEPMALE_SUBTYPEID);

        public const string SHEEPFEMALE_SUBTYPEID = "SheepFemale";
        public static readonly UniqueEntityId SHEEPFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SHEEPFEMALE_SUBTYPEID);

        public const string SHEEPBABY_SUBTYPEID = "SheepBaby";
        public static readonly UniqueEntityId SHEEPBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SHEEPBABY_SUBTYPEID);

        public const string SPIDERMALE_SUBTYPEID = "SpiderMale";
        public static readonly UniqueEntityId SPIDERMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SPIDERMALE_SUBTYPEID);

        public const string SPIDERFEMALE_SUBTYPEID = "SpiderFemale";
        public static readonly UniqueEntityId SPIDERFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SPIDERFEMALE_SUBTYPEID);

        public const string SPIDERBABY_SUBTYPEID = "SpiderBaby";
        public static readonly UniqueEntityId SPIDERBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), SPIDERBABY_SUBTYPEID);

        public const string WOLFMALE_SUBTYPEID = "WolfMale";
        public static readonly UniqueEntityId WOLFMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), WOLFMALE_SUBTYPEID);

        public const string WOLFFEMALE_SUBTYPEID = "WolfFemale";
        public static readonly UniqueEntityId WOLFFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), WOLFFEMALE_SUBTYPEID);

        public const string WOLFBABY_SUBTYPEID = "WolfBaby";
        public static readonly UniqueEntityId WOLFBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), WOLFBABY_SUBTYPEID);

        public const string COWDEAD_SUBTYPEID = "CowDead";
        public static readonly UniqueEntityId COWDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), COWDEAD_SUBTYPEID);

        public const string DEERDEAD_SUBTYPEID = "DeerDead";
        public static readonly UniqueEntityId DEERDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), DEERDEAD_SUBTYPEID);

        public const string HORSEDEAD_SUBTYPEID = "HorseDead";
        public static readonly UniqueEntityId HORSEDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HORSEDEAD_SUBTYPEID);

        public const string SHEEPDEAD_SUBTYPEID = "SheepDead";
        public static readonly UniqueEntityId SHEEPDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHEEPDEAD_SUBTYPEID);

        public const string SPIDERDEAD_SUBTYPEID = "SpiderDead";
        public static readonly UniqueEntityId SPIDERDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SPIDERDEAD_SUBTYPEID);

        public const string WOLFDEAD_SUBTYPEID = "WolfDead";
        public static readonly UniqueEntityId WOLFDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), WOLFDEAD_SUBTYPEID);

        public const string COWBABYDEAD_SUBTYPEID = "CowBabyDead";
        public static readonly UniqueEntityId COWBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), COWBABYDEAD_SUBTYPEID);

        public const string DEERBABYDEAD_SUBTYPEID = "DeerBabyDead";
        public static readonly UniqueEntityId DEERBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), DEERBABYDEAD_SUBTYPEID);

        public const string HORSEBABYDEAD_SUBTYPEID = "HorseBabyDead";
        public static readonly UniqueEntityId HORSEBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), HORSEBABYDEAD_SUBTYPEID);

        public const string SHEEPBABYDEAD_SUBTYPEID = "SheepBabyDead";
        public static readonly UniqueEntityId SHEEPBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SHEEPBABYDEAD_SUBTYPEID);

        public const string SPIDERBABYDEAD_SUBTYPEID = "SpiderBabyDead";
        public static readonly UniqueEntityId SPIDERBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), SPIDERBABYDEAD_SUBTYPEID);

        public const string WOLFBABYDEAD_SUBTYPEID = "WolfBabyDead";
        public static readonly UniqueEntityId WOLFBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), WOLFBABYDEAD_SUBTYPEID);

        public const string PIGBABYDEAD_SUBTYPEID = "PigBabyDead";
        public static readonly UniqueEntityId PIGBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PIGBABYDEAD_SUBTYPEID);

        public const string CHICKENBABYDEAD_SUBTYPEID = "ChickenBabyDead";
        public static readonly UniqueEntityId CHICKENBABYDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), CHICKENBABYDEAD_SUBTYPEID);

        public const string PIGDEAD_SUBTYPEID = "PigDead";
        public static readonly UniqueEntityId PIGDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), PIGDEAD_SUBTYPEID);

        public const string CHICKENDEAD_SUBTYPEID = "ChickenDead";
        public static readonly UniqueEntityId CHICKENDEAD_ID = new UniqueEntityId(typeof(MyObjectBuilder_PhysicalObject), CHICKENDEAD_SUBTYPEID);

        public const string PIGMALE_SUBTYPEID = "PigMale";
        public static readonly UniqueEntityId PIGMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), PIGMALE_SUBTYPEID);

        public const string PIGFEMALE_SUBTYPEID = "PigFemale";
        public static readonly UniqueEntityId PIGFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), PIGFEMALE_SUBTYPEID);

        public const string PIGBABY_SUBTYPEID = "PigBaby";
        public static readonly UniqueEntityId PIGBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), PIGBABY_SUBTYPEID);

        public const string CHICKENMALE_SUBTYPEID = "ChickenMale";
        public static readonly UniqueEntityId CHICKENMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), CHICKENMALE_SUBTYPEID);

        public const string CHICKENFEMALE_SUBTYPEID = "ChickenFemale";
        public static readonly UniqueEntityId CHICKENFEMALE_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), CHICKENFEMALE_SUBTYPEID);

        public const string CHICKENBABY_SUBTYPEID = "ChickenBaby";
        public static readonly UniqueEntityId CHICKENBABY_ID = new UniqueEntityId(typeof(MyObjectBuilder_GasContainerObject), CHICKENBABY_SUBTYPEID);

        public static readonly long BASE_DEADANIMAL_SPOIL_TIME = 20 * 60 * 1000;

        public static readonly LivestockDefinition COWMALE_DEFINITION = new LivestockDefinition()
        {
            Id = COWMALE_ID,
            DeadId = COWDEAD_ID,
            Name = "Ox",
            Description = "It is a male bovine and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "CowMale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition COWFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = COWFEMALE_ID,
            DeadId = COWDEAD_ID,
            Name = "Cow",
            Description = "It is a female bovine and can be used for breeding, milk" + Environment.NewLine + 
                          "production or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "CowFemale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition COWBABY_DEFINITION = new LivestockDefinition()
        {
            Id = COWBABY_ID,
            DeadId = COWBABYDEAD_ID,
            Name = "Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "CowBaby_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition DEERMALE_DEFINITION = new LivestockDefinition()
        {
            Id = DEERMALE_ID,
            DeadId = DEERDEAD_ID,
            Name = "Male Deer",
            Description = "It is a male deer and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "DeerMale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition DEERFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = DEERFEMALE_ID,
            DeadId = DEERDEAD_ID,
            Name = "Female Deer",
            Description = "It is a female deer and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "DeerFemale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition DEERBABY_DEFINITION = new LivestockDefinition()
        {
            Id = DEERBABY_ID,
            DeadId = DEERBABYDEAD_ID,
            Name = "Deer Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "DeerBaby_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition HORSEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = HORSEMALE_ID,
            DeadId = HORSEDEAD_ID,
            Name = "Male Horse",
            Description = "It is a male horse and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "HorseMale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition HORSEFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = HORSEFEMALE_ID,
            DeadId = HORSEDEAD_ID,
            Name = "Female Horse",
            Description = "It is a female horse and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "HorseFemale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition HORSEBABY_DEFINITION = new LivestockDefinition()
        {
            Id = HORSEBABY_ID,
            DeadId = HORSEBABYDEAD_ID,
            Name = "Horse Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "HorseBaby_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition SHEEPMALE_DEFINITION = new LivestockDefinition()
        {
            Id = SHEEPMALE_ID,
            DeadId = SHEEPDEAD_ID,
            Name = "Male Sheep",
            Description = "It is a male sheep and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "SheepMale_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition SHEEPFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = SHEEPFEMALE_ID,
            DeadId = SHEEPDEAD_ID,
            Name = "Female Sheep",
            Description = "It is a female sheep and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "SheepFemale_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition SHEEPBABY_DEFINITION = new LivestockDefinition()
        {
            Id = SHEEPBABY_ID,
            DeadId = SHEEPBABYDEAD_ID,
            Name = "Sheep Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 37500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 125f,
            Volume = 125f,
            RecipeName = "SheepBaby_Killing",
            RecipeTime = 1.28f
        };

        public static readonly LivestockDefinition SPIDERMALE_DEFINITION = new LivestockDefinition()
        {
            Id = SPIDERMALE_ID,
            DeadId = SPIDERDEAD_ID,
            Name = "Male Spider",
            Description = "It is a male spider and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "SpiderMale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition SPIDERFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = SPIDERFEMALE_ID,
            DeadId = SPIDERDEAD_ID,
            Name = "Female Spider",
            Description = "It is a female spider and can be used for breeding, egg production" + Environment.NewLine + 
                          "or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 150000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 500f,
            Volume = 500f,
            RecipeName = "SpiderFemale_Killing",
            RecipeTime = 5.12f
        };

        public static readonly LivestockDefinition SPIDERBABY_DEFINITION = new LivestockDefinition()
        {
            Id = SPIDERBABY_ID,
            DeadId = SPIDERBABYDEAD_ID,
            Name = "Spider Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 50000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "SpiderBaby_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition WOLFMALE_DEFINITION = new LivestockDefinition()
        {
            Id = WOLFMALE_ID,
            DeadId = WOLFDEAD_ID,
            Name = "Male Wolf",
            Description = "It is a male wolf and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "WolfMale_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition WOLFFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = WOLFFEMALE_ID,
            DeadId = WOLFDEAD_ID,
            Name = "Female Wolf",
            Description = "It is a female wolf and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "WolfFemale_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition WOLFBABY_DEFINITION = new LivestockDefinition()
        {
            Id = WOLFBABY_ID,
            DeadId = WOLFBABYDEAD_ID,
            Name = "Wolf Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 37500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 125f,
            Volume = 125f,
            RecipeName = "WolfBaby_Killing",
            RecipeTime = 1.28f
        };

        public static readonly LivestockDefinition PIGMALE_DEFINITION = new LivestockDefinition()
        {
            Id = PIGMALE_ID,
            DeadId = PIGDEAD_ID,
            Name = "Male Pig",
            Description = "It is a male pig and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "PigMale_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition PIGFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = PIGFEMALE_ID,
            DeadId = PIGDEAD_ID,
            Name = "Female Pig",
            Description = "It is a female pig and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 75000,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 250f,
            Volume = 250f,
            RecipeName = "PigFemale_Killing",
            RecipeTime = 2.56f
        };

        public static readonly LivestockDefinition PIGBABY_DEFINITION = new LivestockDefinition()
        {
            Id = PIGBABY_ID,
            DeadId = PIGBABYDEAD_ID,
            Name = "Pig Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 37500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 125f,
            Volume = 125f,
            RecipeName = "PigBaby_Killing",
            RecipeTime = 1.28f
        };

        public static readonly LivestockDefinition CHICKENMALE_DEFINITION = new LivestockDefinition()
        {
            Id = CHICKENMALE_ID,
            DeadId = CHICKENDEAD_ID,
            Name = "Male Chicken",
            Description = "It is a male chicken and can be used for breeding or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 7500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 10f,
            Volume = 10f,
            RecipeName = "ChickenMale_Killing",
            RecipeTime = 1.28f
        };

        public static readonly LivestockDefinition CHICKENFEMALE_DEFINITION = new LivestockDefinition()
        {
            Id = CHICKENFEMALE_ID,
            DeadId = CHICKENDEAD_ID,
            Name = "Female Chicken",
            Description = "It is a female chicken and can be used for breeding, egg production" + Environment.NewLine + 
                          "or butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 7500,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 10f,
            Volume = 10f,
            RecipeName = "ChickenMale_Killing",
            RecipeTime = 1.28f
        };

        public static readonly LivestockDefinition CHICKENBABY_DEFINITION = new LivestockDefinition()
        {
            Id = CHICKENBABY_ID,
            DeadId = CHICKENBABYDEAD_ID,
            Name = "Chicken Calf",
            Description = "It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine + 
                          "or can be used for butchery.",
            CanPlayerOrder = true,
            MinimalPricePerUnit = 750,
            OfferAmount = new Vector2I(20, 40),
            OrderAmount = new Vector2I(5, 10),
            AcquisitionAmount = new Vector2I(10, 20),
            Mass = 1f,
            Volume = 1f,
            RecipeName = "ChickenBaby_Killing",
            RecipeTime = 0.64f
        };

        public static readonly List<LivestockDefinition.RecipeItem> DEFAULT_ANIMAL_BODYRESULT = new List<LivestockDefinition.RecipeItem>()
            {
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.SPOILED_MATERIAL_ID,
                    Ammount = 0.12f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.BONES_ID,
                    Ammount = 0.08f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.MEAT_ID,
                    Ammount = 0.25f,
                    AlowFraction = false
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLE_MEAT_ID,
                    Ammount = 0.05f,
                    AlowFraction = false
                }
            };

        public static readonly List<LivestockDefinition.RecipeItem> DEFAULT_ALIEN_BODYRESULT = new List<LivestockDefinition.RecipeItem>()
            {
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.SPOILED_MATERIAL_ID,
                    Ammount = 0.12f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.BONES_ID,
                    Ammount = 0.08f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_MEAT_ID,
                    Ammount = 0.25f,
                    AlowFraction = false
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.ALIEN_NOBLE_MEAT_ID,
                    Ammount = 0.05f,
                    AlowFraction = false
                }
            };

        public static readonly List<LivestockDefinition.RecipeItem> DEFAULT_PIG_BODYRESULT = new List<LivestockDefinition.RecipeItem>()
            {
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.SPOILED_MATERIAL_ID,
                    Ammount = 0.12f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.BONES_ID,
                    Ammount = 0.08f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.MEAT_ID,
                    Ammount = 0.20f,
                    AlowFraction = false
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.NOBLE_MEAT_ID,
                    Ammount = 0.05f,
                    AlowFraction = false
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.BACON_ID,
                    Ammount = 0.05f,
                    AlowFraction = false
                }
            };

        public static readonly List<LivestockDefinition.RecipeItem> DEFAULT_CHICKEN_BODYRESULT = new List<LivestockDefinition.RecipeItem>()
            {
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.SPOILED_MATERIAL_ID,
                    Ammount = 0.12f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.BONES_ID,
                    Ammount = 0.08f
                },
                new LivestockDefinition.RecipeItem()
                {
                    Id = ItensConstants.CHICKENMEAT_ID,
                    Ammount = 0.30f,
                    AlowFraction = false
                }
            };

        public static readonly LivestockDefinition COWDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = COWDEAD_ID,
            Name = "Dead Cow",
            Description = "",
            Mass = 500f,
            Volume = 500f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "CowDead_Desconstruction",
            RecipeTime = 64.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition DEERDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = DEERDEAD_ID,
            Name = "Dead Deer",
            Description = "",
            Mass = 500f,
            Volume = 500f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "DeerDead_Desconstruction",
            RecipeTime = 64.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition HORSEDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = HORSEDEAD_ID,
            Name = "Dead Horse",
            Description = "",
            Mass = 500f,
            Volume = 500f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "HorseDead_Desconstruction",
            RecipeTime = 64.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition SHEEPDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = SHEEPDEAD_ID,
            Name = "Dead Sheep",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "SheepDead_Desconstruction",
            RecipeTime = 32.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition SPIDERDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = SPIDERDEAD_ID,
            Name = "Dead Spider",
            Description = "",
            Mass = 500f,
            Volume = 500f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "SpiderDead_Desconstruction",
            RecipeTime = 64.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition WOLFDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = WOLFDEAD_ID,
            Name = "Dead Wolf",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "WolfDead_Desconstruction",
            RecipeTime = 32.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition COWBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = COWBABYDEAD_ID,
            Name = "Dead Calf",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "CowBabyDead_Desconstruction",
            RecipeTime = 16.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition DEERBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = DEERBABYDEAD_ID,
            Name = "Dead Deer Calf",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "DeerBabyDead_Desconstruction",
            RecipeTime = 16.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition HORSEBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = HORSEBABYDEAD_ID,
            Name = "Dead Horse Calf",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "HorseBabyDead_Desconstruction",
            RecipeTime = 16.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition SHEEPBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = SHEEPBABYDEAD_ID,
            Name = "Dead Sheep Calf",
            Description = "",
            Mass = 125f,
            Volume = 125f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "SheepBabyDead_Desconstruction",
            RecipeTime = 8.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition SPIDERBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = SPIDERBABYDEAD_ID,
            Name = "Dead Spider Calf",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "SpiderBabyDead_Desconstruction",
            RecipeTime = 16.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition WOLFBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = WOLFBABYDEAD_ID,
            Name = "Dead Wolf Calf",
            Description = "",
            Mass = 125f,
            Volume = 125f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "WolfBabyDead_Desconstruction",
            RecipeTime = 8.0f,
            BodyResults = DEFAULT_ANIMAL_BODYRESULT
        };

        public static readonly LivestockDefinition PIGBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = PIGBABYDEAD_ID,
            Name = "Dead Pig Calf",
            Description = "",
            Mass = 125f,
            Volume = 125f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "PigBabyDead_Desconstruction",
            RecipeTime = 8.0f,
            BodyResults = DEFAULT_PIG_BODYRESULT
        };

        public static readonly LivestockDefinition CHICKENBABYDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = CHICKENBABYDEAD_ID,
            Name = "Dead Chicken Calf",
            Description = "",
            Mass = 1f,
            Volume = 1f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "ChickenBabyDead_Desconstruction",
            RecipeTime = 4.0f,
            BodyResults = DEFAULT_CHICKEN_BODYRESULT
        };

        public static readonly LivestockDefinition PIGDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = PIGDEAD_ID,
            Name = "Dead Pig",
            Description = "",
            Mass = 250f,
            Volume = 250f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "PigDead_Desconstruction",
            RecipeTime = 16.0f,
            BodyResults = DEFAULT_PIG_BODYRESULT
        };

        public static readonly LivestockDefinition CHICKENDEAD_DEFINITION = new LivestockDefinition()
        {
            Id = CHICKENDEAD_ID,
            Name = "Dead Chicken",
            Description = "",
            Mass = 10f,
            Volume = 10f,
            IsDeadBody = true,
            StartConservationTime = BASE_DEADANIMAL_SPOIL_TIME,
            RecipeName = "ChickenDead_Desconstruction",
            RecipeTime = 8.0f,
            BodyResults = DEFAULT_CHICKEN_BODYRESULT
        };

        public static readonly Dictionary<UniqueEntityId, LivestockDefinition> LIVESTOCK_DEFINITIONS = new Dictionary<UniqueEntityId, LivestockDefinition>()
        {
            { COWMALE_ID, COWMALE_DEFINITION },
            { COWFEMALE_ID, COWFEMALE_DEFINITION },
            { COWBABY_ID, COWBABY_DEFINITION },
            { DEERMALE_ID, DEERMALE_DEFINITION },
            { DEERFEMALE_ID, DEERFEMALE_DEFINITION },
            { DEERBABY_ID, DEERBABY_DEFINITION },
            { HORSEMALE_ID, HORSEMALE_DEFINITION },
            { HORSEFEMALE_ID, HORSEFEMALE_DEFINITION },
            { HORSEBABY_ID, HORSEBABY_DEFINITION },
            { SHEEPMALE_ID, SHEEPMALE_DEFINITION },
            { SHEEPFEMALE_ID, SHEEPFEMALE_DEFINITION },
            { SHEEPBABY_ID, SHEEPBABY_DEFINITION },
            { SPIDERMALE_ID, SPIDERMALE_DEFINITION },
            { SPIDERFEMALE_ID, SPIDERFEMALE_DEFINITION },
            { SPIDERBABY_ID, SPIDERBABY_DEFINITION },
            { WOLFMALE_ID, WOLFMALE_DEFINITION },
            { WOLFFEMALE_ID, WOLFFEMALE_DEFINITION },
            { WOLFBABY_ID, WOLFBABY_DEFINITION },
            { COWDEAD_ID, COWDEAD_DEFINITION },
            { DEERDEAD_ID, DEERDEAD_DEFINITION },
            { HORSEDEAD_ID, HORSEDEAD_DEFINITION },
            { SHEEPDEAD_ID, SHEEPDEAD_DEFINITION },
            { SPIDERDEAD_ID, SPIDERDEAD_DEFINITION },
            { WOLFDEAD_ID, WOLFDEAD_DEFINITION },
            { COWBABYDEAD_ID, COWBABYDEAD_DEFINITION },
            { DEERBABYDEAD_ID, DEERBABYDEAD_DEFINITION },
            { HORSEBABYDEAD_ID, HORSEBABYDEAD_DEFINITION },
            { SHEEPBABYDEAD_ID, SHEEPBABYDEAD_DEFINITION },
            { SPIDERBABYDEAD_ID, SPIDERBABYDEAD_DEFINITION },
            { WOLFBABYDEAD_ID, WOLFBABYDEAD_DEFINITION },
            { PIGBABYDEAD_ID, PIGBABYDEAD_DEFINITION },
            { CHICKENBABYDEAD_ID, CHICKENBABYDEAD_DEFINITION },
            { PIGDEAD_ID, PIGDEAD_DEFINITION },
            { CHICKENDEAD_ID, CHICKENDEAD_DEFINITION },
            { PIGMALE_ID, PIGMALE_DEFINITION },
            { PIGFEMALE_ID, PIGFEMALE_DEFINITION },
            { PIGBABY_ID, PIGBABY_DEFINITION },
            { CHICKENMALE_ID, CHICKENMALE_DEFINITION },
            { CHICKENFEMALE_ID, CHICKENFEMALE_DEFINITION },
            { CHICKENBABY_ID, CHICKENBABY_DEFINITION }
        };

        public static readonly List<UniqueEntityId> ANIMALS_HERBICORES_IDS = new List<UniqueEntityId>()
        {
            COWMALE_ID,
            COWFEMALE_ID,
            COWBABY_ID,
            DEERMALE_ID,
            DEERFEMALE_ID,
            DEERBABY_ID,
            HORSEMALE_ID,
            HORSEFEMALE_ID,
            HORSEBABY_ID,
            SHEEPMALE_ID,
            SHEEPFEMALE_ID,
            SHEEPBABY_ID,
            PIGMALE_ID,
            PIGFEMALE_ID,
            PIGBABY_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_CARNIVORES_IDS = new List<UniqueEntityId>()
        {
            SPIDERMALE_ID,
            SPIDERFEMALE_ID,
            SPIDERBABY_ID,
            WOLFMALE_ID,
            WOLFFEMALE_ID,
            WOLFBABY_ID,
            PIGMALE_ID,
            PIGFEMALE_ID,
            PIGBABY_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_BIRDS_IDS = new List<UniqueEntityId>()
        {
            CHICKENMALE_ID,
            CHICKENFEMALE_ID,
            CHICKENBABY_ID
        };

        public static readonly List<UniqueEntityId> ANIMALS_IDS = new List<UniqueEntityId>()
        {
            COWMALE_ID,
            COWFEMALE_ID,
            COWBABY_ID,
            DEERMALE_ID,
            DEERFEMALE_ID,
            DEERBABY_ID,
            HORSEMALE_ID,
            HORSEFEMALE_ID,
            HORSEBABY_ID,
            SHEEPMALE_ID,
            SHEEPFEMALE_ID,
            SHEEPBABY_ID,
            SPIDERMALE_ID,
            SPIDERFEMALE_ID,
            SPIDERBABY_ID,
            WOLFMALE_ID,
            WOLFFEMALE_ID,
            WOLFBABY_ID,
            PIGMALE_ID,
            PIGFEMALE_ID,
            PIGBABY_ID,
            CHICKENMALE_ID,
            CHICKENFEMALE_ID,
            CHICKENBABY_ID
        };

        public static readonly List<UniqueEntityId> DEAD_ANIMALS_IDS = new List<UniqueEntityId>()
        {
            COWDEAD_ID,
            DEERDEAD_ID,
            HORSEDEAD_ID,
            SHEEPDEAD_ID,
            SPIDERDEAD_ID,
            WOLFDEAD_ID,
            PIGDEAD_ID,
            CHICKENDEAD_ID,
            COWBABYDEAD_ID,
            DEERBABYDEAD_ID,
            HORSEBABYDEAD_ID,
            SHEEPBABYDEAD_ID,
            SPIDERBABYDEAD_ID,
            WOLFBABYDEAD_ID,
            PIGBABYDEAD_ID,
            CHICKENBABYDEAD_ID
        };

        public const string ANIMAL_CATEGORY = "ANIMALS";

        public const string PIG_ID = "Pig_Bot";
        public const string CHICKEN_ID = "Chicken_Bot";

        public const string COW_ID = "Cow_Bot";
        public const string DEER_ID = "deer_bot";
        public const string DEER_ID_2 = "deerbuck_bot";
        public const string SHEEP_ID = "Sheep_Bot";
        public const string HORSE_ID = "Horse_Bot";
        public const string WOLF_ID = "Space_Wolf";
        public const string SPIDER_ID = "Space_spider";
        public const string SPIDER_ID_2 = "Space_spider_black";
        public const string SPIDER_ID_3 = "Space_spider_brown";
        public const string SPIDER_ID_4 = "Space_spider_green";

        public const string CREATURE_HEALTH = "CreatureHealth";
        public const string TREE_HEALTH = "TreeHealth";

        public const string CREATURE_EAT_FACTOR_ID = "EatFactor";
        public const string CREATURE_ABSORCION_FACTOR_ID = "AbsorcionFactor";
        public const string CREATURE_POOP_FACTOR_ID = "PoopFactor";

        public const string BASE_EAT_FACTOR = "0.005";
        public const string BASE_POOP_FACTOR = "0.01";
        public const string BASE_ABSORCION_FACTOR = "0.01";
        public const float BASE_HUNGRY_FACTOR = 0.0025f;
        public const long BASE_TOLERANCE_TIME = 12;

        public const long FEED_TIME_CICLE = 5000;
        public const long REPRODUCTION_TIME_CICLE = 900000; // 15 minutes

        public struct AnimalInfo
        {

            public string botId;
            public Dictionary<AnimalGender, UniqueEntityId> genderIds;
            public int genderFormula;
            public float startItemHealth;
            public CustomProduction[] customProductions;

        }

        public struct CustomProduction
        {

            public AnimalGender gender;

            public UniqueEntityId product;
            public Vector2 baseFactor;
            public bool allowDecimal;
            public Vector2I chanceToGenerate;

            public bool hasRequiredProduct;
            public UniqueEntityId requiredProduct;
            public float requiredAmmount;

        }

        private static AnimalInfo BASE_PIG_INFO = new AnimalInfo()
        {
            botId = PIG_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, PIGBABY_ID },
                { AnimalGender.Male, PIGMALE_ID },
                { AnimalGender.Female, PIGFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_CHICKEN_INFO = new AnimalInfo()
        {
            botId = CHICKEN_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, CHICKENBABY_ID },
                { AnimalGender.Male, CHICKENMALE_ID },
                { AnimalGender.Female, CHICKENFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f,
            customProductions = new CustomProduction[]
            {
                new CustomProduction()
                {
                    gender = AnimalGender.Female,
                    chanceToGenerate = new Vector2I(10, 1000),
                    baseFactor = new Vector2(1, 1),
                    product = ItensConstants.EGG_ID
                }
            }
        };

        private static AnimalInfo BASE_COW_INFO = new AnimalInfo()
        {
            botId = COW_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, COWBABY_ID },
                { AnimalGender.Male, COWMALE_ID },
                { AnimalGender.Female, COWFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f,
            customProductions = new CustomProduction[] 
            { 
                new CustomProduction()
                {
                    gender = AnimalGender.Female,
                    chanceToGenerate = new Vector2I(10, 1000),
                    baseFactor = new Vector2(1, 1),
                    product = ItensConstants.MILK_ID,
                    hasRequiredProduct = true,
                    requiredAmmount = 1,
                    requiredProduct = ItensConstants.FLASK_BIG_ID
                }
            }
        };

        private static AnimalInfo BASE_DEER_INFO = new AnimalInfo()
        {
            botId = DEER_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, DEERBABY_ID },
                { AnimalGender.Male, DEERMALE_ID },
                { AnimalGender.Female, DEERFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_SHEEP_INFO = new AnimalInfo()
        {
            botId = SHEEP_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, SHEEPBABY_ID },
                { AnimalGender.Male, SHEEPMALE_ID },
                { AnimalGender.Female, SHEEPFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_HORSE_INFO = new AnimalInfo()
        {
            botId = HORSE_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, HORSEBABY_ID },
                { AnimalGender.Male, HORSEMALE_ID },
                { AnimalGender.Female, HORSEFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_WOLF_INFO = new AnimalInfo()
        {
            botId = WOLF_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, WOLFBABY_ID },
                { AnimalGender.Male, WOLFMALE_ID },
                { AnimalGender.Female, WOLFFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f
        };

        private static AnimalInfo BASE_SPIDER_INFO = new AnimalInfo()
        {
            botId = SPIDER_ID,
            genderIds = new Dictionary<AnimalGender, UniqueEntityId>()
            {
                { AnimalGender.Baby, SPIDERBABY_ID },
                { AnimalGender.Male, SPIDERMALE_ID },
                { AnimalGender.Female, SPIDERFEMALE_ID }
            },
            genderFormula = 50,
            startItemHealth = 0.6f,
            customProductions = new CustomProduction[] 
            { 
                new CustomProduction()
                {
                    gender = AnimalGender.Female,
                    chanceToGenerate = new Vector2I(10, 1000),
                    baseFactor = new Vector2(1, 1),
                    product = ItensConstants.ALIEN_EGG_ID
                }
            }
        };

        public static readonly Dictionary<string, AnimalInfo> ANIMALS = new Dictionary<string, AnimalInfo>()
        {
            { WOLF_ID, BASE_WOLF_INFO },
            { SPIDER_ID, BASE_SPIDER_INFO },
            { SPIDER_ID_2, BASE_SPIDER_INFO },
            { SPIDER_ID_3, BASE_SPIDER_INFO },
            { SPIDER_ID_4, BASE_SPIDER_INFO },
            { HORSE_ID, BASE_HORSE_INFO },
            { SHEEP_ID, BASE_SHEEP_INFO },
            { DEER_ID, BASE_DEER_INFO },
            { DEER_ID_2, BASE_DEER_INFO },            
            { COW_ID, BASE_COW_INFO },
            { PIG_ID, BASE_PIG_INFO },
            { CHICKEN_ID, BASE_CHICKEN_INFO }
        };

        private static UniqueEntityId[] productionIds = null;
        public static UniqueEntityId[] GetProductionIds()
        {
            if (productionIds == null)
            {
                var ids = new HashSet<UniqueEntityId>();
                foreach (var item in ANIMALS)
                {
                    foreach (var productions in item.Value.customProductions)
                    {
                        ids.Add(productions.product);
                        if (productions.requiredProduct != null)
                            ids.Add(productions.requiredProduct);
                    }
                }
                productionIds = ids.ToArray();
            }
            return productionIds;
        }

        public static AnimalInfo? GetAnimalInfo(UniqueEntityId itemId)
        {
            if (ANIMALS.Values.Any(x => x.genderIds.Any(y => y.Value == itemId)))
                return ANIMALS.Values.FirstOrDefault(x => x.genderIds.Any(y => y.Value == itemId));
            return null;
        }

        public static void TryOverrideDefinitions()
        {
            try
            {
                var targetFaction = FactionTypeConstants.FACTION_TYPES_DEFINITIONS[FactionTypeConstants.TRADER_ID];
                // Override medical definition
                foreach (var animal in LIVESTOCK_DEFINITIONS.Keys)
                {
                    var animalDef = LIVESTOCK_DEFINITIONS[animal];
                    // Item definition
                    var consumableDef = DefinitionUtils.TryGetDefinition<MyPhysicalItemDefinition>(animal.DefinitionId);
                    if (consumableDef != null)
                    {
                        consumableDef.Volume = animalDef.GetVolume();
                        consumableDef.Mass = animalDef.GetMass();
                        consumableDef.DisplayNameEnum = null;
                        consumableDef.DisplayNameString = animalDef.Name;
                        consumableDef.DescriptionEnum = null;
                        consumableDef.DescriptionString = null;
                        consumableDef.MinimumAcquisitionAmount = animalDef.AcquisitionAmount.X;
                        consumableDef.MaximumAcquisitionAmount = animalDef.AcquisitionAmount.Y;
                        consumableDef.MinimumOrderAmount = animalDef.OrderAmount.X;
                        consumableDef.MaximumOrderAmount = animalDef.OrderAmount.Y;
                        consumableDef.MinimumOfferAmount = animalDef.OfferAmount.X;
                        consumableDef.MaximumOfferAmount = animalDef.OfferAmount.Y;
                        consumableDef.MinimalPricePerUnit = animalDef.MinimalPricePerUnit;
                        consumableDef.CanPlayerOrder = animalDef.CanPlayerOrder;
                        consumableDef.ExtraInventoryTooltipLine.AppendLine(Environment.NewLine + animalDef.GetFullDescription());
                        consumableDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(LivestockConstants), $"TryOverrideRecipes item not found. Food=[{animal}]");
                    var recipeDef = DefinitionUtils.TryGetBlueprintDefinition(animalDef.RecipeName);
                    if (recipeDef != null)
                    {
                        recipeDef.BaseProductionTimeInSeconds = animalDef.RecipeTime;
                        recipeDef.DescriptionEnum = null;
                        recipeDef.DescriptionString = null;
                        recipeDef.DisplayNameEnum = null;
                        if (animalDef.IsDeadBody)
                        {
                            recipeDef.DisplayNameString = string.Format("Butchery {0}", animalDef.Name);
                            recipeDef.Prerequisites = new MyBlueprintDefinitionBase.Item[] {
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = animal.DefinitionId,
                                    Amount = 1
                                }
                            };
                            recipeDef.Results = animalDef.BodyResults.Select(x=> new MyBlueprintDefinitionBase.Item() {
                                Id = x.Id.DefinitionId,
                                Amount = (MyFixedPoint)x.GetAmmount(animalDef.GetMass())
                            }).ToArray();
                        }
                        else
                        {
                            recipeDef.DisplayNameString = string.Format("Slaughter {0}", animalDef.Name);
                            recipeDef.Prerequisites = new MyBlueprintDefinitionBase.Item[] {
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = animal.DefinitionId,
                                    Amount = 1
                                }
                            };
                            recipeDef.Results = new MyBlueprintDefinitionBase.Item[] {
                                new MyBlueprintDefinitionBase.Item()
                                {
                                    Id = animalDef.DeadId.DefinitionId,
                                    Amount = 1
                                }
                            };
                        }
                        recipeDef.Postprocess();
                    }
                    else
                        ExtendedSurvivalStatsLogging.Instance.LogInfo(typeof(LivestockConstants), $"TryOverrideDefinitions recipe not found. Recipe=[{animalDef.RecipeName}]");

                    
                    // Add itens to faction types
                    if (animalDef.CanPlayerOrder)
                    {
                        targetFaction.OffersList.Add(animal);
                        targetFaction.OrdersList.Add(animal);
                    }
                }
            }
            catch (System.Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(typeof(LivestockConstants), ex);
            }
        }

    }

}