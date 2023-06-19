using System;
using VRage;

namespace ExtendedSurvival.Stats
{

    public class EnglishLanguageTemplate : BaseLanguageTemplate
    {

        public EnglishLanguageTemplate() 
            : base(MyLanguagesEnum.English)
        {
        }

        protected override void DoLoadEntries()
        {
			#region GENERALS
			AddEntry(
				LanguageEntries.TERMS_YES_NAME,
				"Yes"
			);
			AddEntry(
				LanguageEntries.TERMS_NO_NAME,
				"No"
			);
			AddEntry(
				LanguageEntries.TERMS_FULL_NAME,
				"Full"
			);
			AddEntry(
				LanguageEntries.TERMS_EMPTY_NAME,
				"Empty"
			);
			#endregion
			#region CUBE_BLOCKS
			AddEntry(
                LanguageEntries.CUBEBLOCK_SMALL_CAGE,
                "Small Cage"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_LARGE_CAGE,
                "Large Cage"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_CAGE_DESCRIPTION,
                "Cage are blocks used to store and keep captured animals alive. " +
                "When you feed the animals they will eat to stay alive, and in some " +
                "cases produce products."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_COMPOSTER,
                "Composter"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_COMPOSTER_DESCRIPTION,
                "Composters are blocks that can speed up up to {0}x the " +
                "rotting of itens. If it had organic material in the inventory, " +
                "will spawn fish baits in time cicle, this cicles can ranges from " +
                "{1}s to {2}s based in amount of organic material." +
                "The energy cost varies based in inventory volume, " +
                "from {3}kW/h up to {4}kW/h."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FARM,
                "Farm"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FARM_DESCRIPTION,
                "Farms are blocks that generate vegetables, mushrooms and herbs " +
                "when seeds, ice and fertilizers are placed in the inventory. " +
                "Resource cost increases by {0}% for extra seed type and rotting " +
                "time decreases by {0}% when producing."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_TREEFARM,
                "Tree Farm"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_TREEFARM_DESCRIPTION,
                "Tree farms are blocks that can grow and keep trees alive to produce " +
                "fruit when you have ice and fertilizer in your inventory. " +
                "Rotting time decreases by {0}% when producing."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FISHTRAP,
				"Fish Trap"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FISHTRAP_DESCRIPTION,
                "Fish traps are blocks that can capture fish by consuming baits, they need " +
                "to be submerged and connected to submerged collectors to work. " +
                "The fishing cycles are {0}s and cost of energy can vary from {1}kW/h up to {2}kW/h."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR,
                "Food Processor"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_BASIC,
                "Basic Food Processor"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_INDUSTRIAL,
                "Industrial Food Processor"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_DESCRIPTION,
                "Food processors are blocks that can prepare and cook food. " +
                "At the end of production, if you have a refrigerator connected, " +
                "it will store food automatically."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE,
                "Slaughterhouse"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_BASIC,
                "Basic Slaughterhouse"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_INDUSTRIAL,
                "Industrial Slaughterhouse"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_DESCRIPTION,
                "Slaughterhouses are blocks that can slaughter farmed " +
                "animals and extract their meat. At the end of production, " +
                "if you have a refrigerator connected, it will store food " +
                "automatically."
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_SMALL_REFRIGERATOR,
                "Small Refrigerator"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_LARGE_REFRIGERATOR,
                "Large Refrigerator"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_REFRIGERATOR_DESCRIPTION,
                "Refrigerator are blocks that can keep items from rotting. " +
                "The energy cost varies based in inventory volume, " +
                "from {0}kW/h up to {1}kW/h."
            );
			AddEntry(
				LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR,
				"Thermal Fluid Generator"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR_DESCRIPTION,
				"Thermal Fluid Generators are blocks responsible for refill " +
				"bottles of thermal gas consuming thermal fluid."
			);
			#endregion
			#region EQUIPMENTS
			AddEntry(
                LanguageEntries.BODYTRACKER_NAME,
                "Body Tracker"
            );
            AddEntry(
                LanguageEntries.BODYTRACKER_DESCRIPTION,
                "An accessory responsible for monitoring the state of the body and" + Environment.NewLine +
                "showing it on the spacesuit helmet display." + Environment.NewLine +
                "Can detect:" + Environment.NewLine +
                "- Wet level;" + Environment.NewLine +
                "- Body temperature;" + Environment.NewLine +
                "- Basic negative effects;" + Environment.NewLine + Environment.NewLine +
                "Note: Accessories need to be in the player's inventory to work."
            );
            AddEntry(
                LanguageEntries.ENHANCEDBODYTRACKER_NAME,
                "Enhanced Body Tracker"
            );
            AddEntry(
                LanguageEntries.ENHANCEDBODYTRACKER_DESCRIPTION,
                "An accessory responsible for monitoring the state of the body and" + Environment.NewLine +
                "showing it on the spacesuit helmet display." + Environment.NewLine +
                "Can detect:" + Environment.NewLine +
                "- Wet level;" + Environment.NewLine +
                "- Body temperature;" + Environment.NewLine +
                "- Body energy;" + Environment.NewLine +
                "- Body water;" + Environment.NewLine +
                "- Untreated wound;" + Environment.NewLine +
                "- Intermediate negative effects;" + Environment.NewLine + Environment.NewLine +
                "Note: Accessories need to be in the player's inventory to work."
            );
            AddEntry(
                LanguageEntries.PROFICIENTBODYTRACKER_NAME,
                "Proficient Body Tracker"
            );
            AddEntry(
                LanguageEntries.PROFICIENTBODYTRACKER_DESCRIPTION,
                "An accessory responsible for monitoring the state of the body and" + Environment.NewLine +
                "showing it on the spacesuit helmet display." + Environment.NewLine +
                "Can detect:" + Environment.NewLine +
                "- Wet level;" + Environment.NewLine +
                "- Body temperature;" + Environment.NewLine +
                "- Body energy;" + Environment.NewLine +
                "- Body water;" + Environment.NewLine +
                "- Body weight;" + Environment.NewLine +
                "- Body efficiency;" + Environment.NewLine +
                "- Body fatigue;" + Environment.NewLine +
                "- Untreated wound;" + Environment.NewLine +
                "- Advanced negative effects;" + Environment.NewLine + Environment.NewLine +
                "Note: Accessories need to be in the player's inventory to work."
            );
            AddEntry(
                LanguageEntries.ELITEBODYTRACKER_NAME,
                "Elite Body Tracker"
            );
            AddEntry(
                LanguageEntries.ELITEBODYTRACKER_DESCRIPTION,
                "An accessory responsible for monitoring the state of the body and" + Environment.NewLine +
                "showing it on the spacesuit helmet display." + Environment.NewLine +
                "Can detect:" + Environment.NewLine +
                "- Wet level;" + Environment.NewLine +
                "- Body temperature;" + Environment.NewLine +
                "- Body energy;" + Environment.NewLine +
                "- Body water;" + Environment.NewLine +
                "- Body weight;" + Environment.NewLine +
                "- Body efficiency;" + Environment.NewLine +
                "- Body fatigue;" + Environment.NewLine +
                "- Body immunity;" + Environment.NewLine +
                "- Body muscle;" + Environment.NewLine +
                "- Body fat;" + Environment.NewLine +
                "- Untreated wound;" + Environment.NewLine +
                "- All negative effects;" + Environment.NewLine + Environment.NewLine +
                "Note: Accessories need to be in the player's inventory to work."
            );
			AddEntry(
				LanguageEntries.COLDTHERMALBOTTLE_NAME,
				"Cold Thermal Bottle"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALBOTTLE_DESCRIPTION,
				"Used by cooling modules to maintain suit temperature when in" + Environment.NewLine +
				"extremely cold environments."
			);
			AddEntry(
				LanguageEntries.HOTTHERMALBOTTLE_NAME,
				"Hot Thermal Bottle"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALBOTTLE_DESCRIPTION,
				"Used by cooling modules to maintain suit temperature when in" + Environment.NewLine +
				"extremely hot environments."
			);
			#endregion
			#region FISHING
			AddEntry(
                LanguageEntries.FISH_NAME,
                "Fish"
            );
            AddEntry(
                LanguageEntries.FISH_DESCRIPTION,
                "Fish are abundant in most bodies of water. They can be found" + Environment.NewLine + 
                "in nearly all aquatic environments."
            );
            AddEntry(
                LanguageEntries.ALIENFISH_NAME,
                "Alien Fish"
            );
            AddEntry(
                LanguageEntries.ALIENFISH_DESCRIPTION,
                "Fish are abundant in most bodies of water. They can be found" + Environment.NewLine +
                "in nearly all aquatic environments."
            );
            AddEntry(
                LanguageEntries.NOBLEFISH_NAME,
                "Noble Fish"
            );
            AddEntry(
                LanguageEntries.NOBLEFISH_DESCRIPTION,
                "Noble fish are more difficult to catch. They can be found in" + Environment.NewLine + 
                "deeper waters."
            );
            AddEntry(
                LanguageEntries.ALIENNOBLEFISH_NAME,
                "Alien Noble Fish"
            );
            AddEntry(
                LanguageEntries.ALIENNOBLEFISH_DESCRIPTION,
                "Noble fish are more difficult to catch. They can be found in" + Environment.NewLine + 
                "deeper waters."
            );
            AddEntry(
                LanguageEntries.SHRIMP_NAME,
                "Shrimp"
            );
            AddEntry(
                LanguageEntries.SHRIMP_DESCRIPTION,
                "Shrimp are crustaceans with elongated bodies and a primarily" + Environment.NewLine + 
                "swimming mode of locomotion."
            );
            AddEntry(
                LanguageEntries.FISH_BAIT_SMALL_NAME,
                "Fish Bait"
            );
            AddEntry(
                LanguageEntries.FISH_BAIT_SMALL_DESCRIPTION,
                "A kind of small worm, some fish may find it appetizing."
            );
            AddEntry(
                LanguageEntries.FISH_NOBLE_BAIT_NAME,
                "Noble Fish Bait"
            );
            AddEntry(
                LanguageEntries.FISH_NOBLE_BAIT_DESCRIPTION,
                "A kind of small worm, some fish may find it appetizing."
            );
            #region FishBaitDefinition
            AddEntry(
                LanguageEntries.FISHBAITDEFINITION_DESCRIPTION,
                "Can be used in traps to catch fish." + Environment.NewLine +
                "Will consume from {0} to {1} per cycle." + Environment.NewLine +
                "Can capture up to {2} fish per cicle." + Environment.NewLine +
                "Valid targets:"
            );
            AddEntry(
                LanguageEntries.FISHBAITDEFINITION_FISH_DESCRIPTION,
                "- {1}% to get {0} at minimum depth of {2}m"
            );
            AddEntry(
                LanguageEntries.FISHBAITDEFINITION_DECOMPOSITION_DESCRIPTION,
                "It can be generated in composters." + Environment.NewLine +
				"{0}% chance to spawn {1} to {2} per cycle, consuming from " + Environment.NewLine +
				"{3} to {4} organic material."
			);
            #endregion
            #region FishDefinition
            AddEntry(
                LanguageEntries.FISHDEFINITION_DESCRIPTION,
                "Rotting time: {0}s" + Environment.NewLine + Environment.NewLine +
                "Can be captured in traps:"
            );
            AddEntry(
                LanguageEntries.FISHDEFINITION_BAIT_DESCRIPTION,
                "- {1}% using {0} at minimum depth of {2}m"
            );
            AddEntry(
                LanguageEntries.FISHDEFINITION_NOTE_DESCRIPTION,
                "Note: They can have their meat extracted in food processors."
            );
			#endregion
			#endregion
			#region FOODS
			AddEntry(
				LanguageEntries.APPLE_NAME,
				"Apple"
			);
			AddEntry(
				LanguageEntries.APPLE_DESCRIPTION,
				"Apple is a red and appetizing fruit," + Environment.NewLine + 
				"it has a low caloric value."
			);
			AddEntry(
				LanguageEntries.BROCCOLI_NAME,
				"Broccoli"
			);
			AddEntry(
				LanguageEntries.BROCCOLI_DESCRIPTION,
				"Broccoli is an edible green plant in the cabbage family," + Environment.NewLine +
				"it is a particularly rich source of vitamin."
			);
			AddEntry(
				LanguageEntries.BEETROOT_NAME,
				"Beetroot"
			);
			AddEntry(
				LanguageEntries.BEETROOT_DESCRIPTION,
				"Beetroot is the taproot portion of a beet plant," + Environment.NewLine +
				"it is a particularly rich source of minerals."
			);
			AddEntry(
				LanguageEntries.CAROOT_NAME,
				"Caroot"
			);
			AddEntry(
				LanguageEntries.CAROOT_DESCRIPTION,
				"Caroot is a root vegetable, it is a particularly rich" + Environment.NewLine +
				"source of minerals."
			);
			AddEntry(
				LanguageEntries.SHIITAKE_NAME,
				"Shiitake"
			);
			AddEntry(
				LanguageEntries.SHIITAKE_DESCRIPTION,
				"Shiitake is an edible mushroom, it is a particularly" + Environment.NewLine +
				"rich source of protein."
			);
			AddEntry(
				LanguageEntries.CHAMPIGNONS_NAME,
				"Champignon"
			);
			AddEntry(
				LanguageEntries.CHAMPIGNONS_DESCRIPTION,
				"Champignon is an edible mushroom, it is a particularly" + Environment.NewLine +
				"rich source of protein."
			);
			AddEntry(
				LanguageEntries.AMANITAMUSCARIA_NAME,
				"Amanita Muscaria"
			);
			AddEntry(
				LanguageEntries.AMANITAMUSCARIA_DESCRIPTION,
				"Amanita muscaria is poisonous mushroom, not recommended to eat," + Environment.NewLine +
				"but has great chemical and medical application."
			);
			AddEntry(
				LanguageEntries.TOMATO_NAME,
				"Tomato"
			);
			AddEntry(
				LanguageEntries.TOMATO_DESCRIPTION,
				"The tomato is the edible berry, it has a low caloric value."
			);
			AddEntry(
				LanguageEntries.CEREAL_NAME,
				"Cereal"
			);
			AddEntry(
				LanguageEntries.CEREAL_DESCRIPTION,
				"Cereal is a highly nutritious grain."
			);
			AddEntry(
				LanguageEntries.WHEATSACK_NAME,
				"Wheat Sack"
			);
			AddEntry(
				LanguageEntries.WHEATSACK_DESCRIPTION,
				"Wheat grain is a staple food used to make flour, and with it, bread."
			);
			AddEntry(
				LanguageEntries.COFFEESACK_NAME,
				"Coffee Sack"
			);
			AddEntry(
				LanguageEntries.COFFEESACK_DESCRIPTION,
				"Coffee is a stimulant, because it has caffeine, it can be an" + Environment.NewLine +
				"alternative to maintain body heat in cold places."
			);
			AddEntry(
				LanguageEntries.MILK_NAME,
				"Milk"
			);
			AddEntry(
				LanguageEntries.MILK_DESCRIPTION,
				"Milk is a white liquid food produced by the mammary" + Environment.NewLine +
				"glands of mammals."
			);
			AddEntry(
				LanguageEntries.MEAT_NAME,
				"Meat"
			);
			AddEntry(
				LanguageEntries.MEAT_DESCRIPTION,
				"Meat has been one of the main sources of protein since" + Environment.NewLine +
				"prehistoric times."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_NAME,
				"Alien Meat"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_DESCRIPTION,
				"It is a strange meat and has a strong smell," + Environment.NewLine +
				"but the taste is normal."
			);
			AddEntry(
				LanguageEntries.CHICKENMEAT_NAME,
				"Chicken Meat"
			);
			AddEntry(
				LanguageEntries.CHICKENMEAT_DESCRIPTION,
				"Chicken is the most common type of poultry in the world."
			);
			AddEntry(
				LanguageEntries.BACON_NAME,
				"Bacon"
			);
			AddEntry(
				LanguageEntries.BACON_DESCRIPTION,
				"Bacon is a type of salt-cured pork made from various cuts," + Environment.NewLine +
				"typically the belly or less fatty parts of the back."
			);
			AddEntry(
				LanguageEntries.NOBLE_MEAT_NAME,
				"Noble Meat"
			);
			AddEntry(
				LanguageEntries.NOBLE_MEAT_DESCRIPTION,
				"Noble cut of meat, with a high concentration of protein."
			);
			AddEntry(
				LanguageEntries.ALIEN_NOBLE_MEAT_NAME,
				"Alien Noble Meat"
			);
			AddEntry(
				LanguageEntries.ALIEN_NOBLE_MEAT_DESCRIPTION,
				"It is a noble cut of a strange meat, the smell is" + Environment.NewLine +
				"more acceptable and tastier."
			);
			AddEntry(
				LanguageEntries.EGG_NAME,
				"Egg"
			);
			AddEntry(
				LanguageEntries.EGG_DESCRIPTION,
				"Eggs are a very rich food from a nutritional point of view."
			);
			AddEntry(
				LanguageEntries.ALIEN_EGG_NAME,
				"Alien Egg"
			);
			AddEntry(
				LanguageEntries.ALIEN_EGG_DESCRIPTION,
				"It's actually quite a big egg, but it's best not to" + Environment.NewLine +
				"think too hard about where it comes from."
			);
			AddEntry(
				LanguageEntries.SHRIMPMEAT_NAME,
				"Shrimp Meat"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEAT_DESCRIPTION,
				"One of the most consumed seafood worldwide, shrimp is" + Environment.NewLine +
				"rich in nutrients and has several health benefits."
			);
			AddEntry(
				LanguageEntries.FISHMEAT_NAME,
				"Fish Meat"
			);
			AddEntry(
				LanguageEntries.FISHMEAT_DESCRIPTION,
				"Fish has been an important dietary source of protein and" + Environment.NewLine +
				"other nutrients throughout human history."
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEAT_NAME,
				"Noble Fish Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEAT_DESCRIPTION,
				"High quality fish meat, with a high concentration of protein."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDFAT_NAME,
				"Concentrated Fat"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDFAT_DESCRIPTION,
				"Concentration of fat, which can be used to make other products."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDPROTEIN_NAME,
				"Concentrated Protein"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDPROTEIN_DESCRIPTION,
				"Concentration of protein, which can be used to make other products."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDVITAMIN_NAME,
				"Concentrated Vitamin"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDVITAMIN_DESCRIPTION,
				"Concentration of vitamins, which can be used to make other products."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_NAME,
				"Small Water Flask"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION,
				"A small flask with water."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_NAME,
				"Medium Water Flask"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION,
				"A medium flask with water."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_NAME,
				"Big Water Flask"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_DESCRIPTION,
				"A big flask with water."
			);
			AddEntry(
				LanguageEntries.APPLE_JUICE_NAME,
				"Apple Juice"
			);
			AddEntry(
				LanguageEntries.APPLE_JUICE_DESCRIPTION,
				"A big flask with juice extracted from apples."
			);
			AddEntry(
				LanguageEntries.SODA_NAME,
				"Apple Soda"
			);
			AddEntry(
				LanguageEntries.SODA_DESCRIPTION,
				"A refreshing apple-based soda."
			);
			AddEntry(
				LanguageEntries.COFFEE_CAN_NAME,
				"Cofee Can"
			);
			AddEntry(
				LanguageEntries.COFFEE_CAN_DESCRIPTION,
				"A thermos of hot coffee."
			);
			AddEntry(
				LanguageEntries.DOUGH_NAME,
				"Dough"
			);
			AddEntry(
				LanguageEntries.DOUGH_DESCRIPTION,
				"A dough made with milk and eggs."
			);
			AddEntry(
				LanguageEntries.ALIEN_DOUGH_NAME,
				"Alien Dough"
			);
			AddEntry(
				LanguageEntries.ALIEN_DOUGH_DESCRIPTION,
				"A dough made with milk and alien eggs."
			);
			AddEntry(
				LanguageEntries.CAKEDOUGH_NAME,
				"Cake Dough"
			);
			AddEntry(
				LanguageEntries.CAKEDOUGH_DESCRIPTION,
				"A cake dough made with milk and eggs."
			);
			AddEntry(
				LanguageEntries.ALIEN_CAKEDOUGH_NAME,
				"Alien Cake Dough"
			);
			AddEntry(
				LanguageEntries.ALIEN_CAKEDOUGH_DESCRIPTION,
				"A cake dough made with milk and alien eggs."
			);
			AddEntry(
				LanguageEntries.RAW_BROCCOLI_BOWL_NAME,
				"Raw Broccoli Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_BROCCOLI_BOWL_DESCRIPTION,
				"A bowl with minced broccoli."
			);
			AddEntry(
				LanguageEntries.RAW_CARROT_BOWL_NAME,
				"Raw Carrot Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_CARROT_BOWL_DESCRIPTION,
				"A bowl with minced carrot."
			);
			AddEntry(
				LanguageEntries.RAW_BEETROOT_BOWL_NAME,
				"Raw Beetroot Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_BEETROOT_BOWL_DESCRIPTION,
				"A bowl with minced beetroot."
			);
			AddEntry(
				LanguageEntries.RAW_MEAT_BOWL_NAME,
				"Raw Meat Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_MEAT_BOWL_DESCRIPTION,
				"A bowl with minced meat."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_MEAT_BOWL_NAME,
				"Raw Alien Meat Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_MEAT_BOWL_DESCRIPTION,
				"A bowl with minced alien meat."
			);
			AddEntry(
				LanguageEntries.RAW_NOBLE_MEAT_BOWL_NAME,
				"Raw Noble Meat Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_NOBLE_MEAT_BOWL_DESCRIPTION,
				"A bowl with minced noble meat."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_NAME,
				"Raw Alien Noble Meat Bowl"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_DESCRIPTION,
				"A bowl with minced alien noble meat."
			);
			AddEntry(
				LanguageEntries.RAWFISHMEATBOWL_NAME,
				"Raw Fish Meat Bowl"
			);
			AddEntry(
				LanguageEntries.RAWFISHMEATBOWL_DESCRIPTION,
				"A bowl with minced fish meat."
			);
			AddEntry(
				LanguageEntries.RAWNOBLEFISHMEATBOWL_NAME,
				"Raw Noble Fish Meat Bowl"
			);
			AddEntry(
				LanguageEntries.RAWNOBLEFISHMEATBOWL_DESCRIPTION,
				"A bowl with minced noble fish meat."
			);
			AddEntry(
				LanguageEntries.RAW_SAUSAGE_NAME,
				"Raw Sausage"
			);
			AddEntry(
				LanguageEntries.RAW_SAUSAGE_DESCRIPTION,
				"A sausage full of raw meat."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_SAUSAGE_NAME,
				"Raw Alien Sausage"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_SAUSAGE_DESCRIPTION,
				"A sausage full of raw alien meat."
			);
			AddEntry(
				LanguageEntries.ROAST_CHAMPIGNON_NAME,
				"Roast Champignons"
			);
			AddEntry(
				LanguageEntries.ROAST_CHAMPIGNON_DESCRIPTION,
				"A simple and tasty way to eat mushrooms."
			);
			AddEntry(
				LanguageEntries.ROAST_SHIITAKE_NAME,
				"Roast Shiitakes"
			);
			AddEntry(
				LanguageEntries.ROAST_SHIITAKE_DESCRIPTION,
				"A simple and tasty way to eat mushrooms."
			);
			AddEntry(
				LanguageEntries.FRIED_EGG_NAME,
				"Fried Egg"
			);
			AddEntry(
				LanguageEntries.FRIED_EGG_DESCRIPTION,
				"One of the most primitive ways to eat an egg."
			);
			AddEntry(
				LanguageEntries.FRIED_ALIEN_EGG_NAME,
				"Fried Alien Egg"
			);
			AddEntry(
				LanguageEntries.FRIED_ALIEN_EGG_DESCRIPTION,
				"The color is strange but it's still a fried egg."
			);
			AddEntry(
				LanguageEntries.ROASTEDBACON_NAME,
				"Roast Bacon"
			);
			AddEntry(
				LanguageEntries.ROASTEDBACON_DESCRIPTION,
				"Bacon is life!"
			);
			AddEntry(
				LanguageEntries.ROASTEDCHICKEN_NAME,
				"Roast Chicken"
			);
			AddEntry(
				LanguageEntries.ROASTEDCHICKEN_DESCRIPTION,
				"Light, low-fat meat."
			);
			AddEntry(
				LanguageEntries.ROASTED_SAUSAGE_NAME,
				"Roast Sausage"
			);
			AddEntry(
				LanguageEntries.ROASTED_SAUSAGE_DESCRIPTION,
				"Processed and well-seasoned meat, it can be eaten alone or as a condiment."
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_SAUSAGE_NAME,
				"Roast Alien Sausage"
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_SAUSAGE_DESCRIPTION,
				"After processing and seasoning, even with the strange color, the taste is very good."
			);
			AddEntry(
				LanguageEntries.ROASTED_MEAT_NAME,
				"Roast Meat"
			);
			AddEntry(
				LanguageEntries.ROASTED_MEAT_DESCRIPTION,
				"Since the beginning of civilization roasted meat has been a source of food for humans."
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_MEAT_NAME,
				"Roast Alien Meat"
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_MEAT_DESCRIPTION,
				"Even though it's a strange meat, a barbecue is a barbecue."
			);
			AddEntry(
				LanguageEntries.CEREALBAR_NAME,
				"Cereal Bar"
			);
			AddEntry(
				LanguageEntries.CEREALBAR_DESCRIPTION,
				"A bar made with cereals, simple and easy to produce."
			);
			AddEntry(
				LanguageEntries.WATERBREAD_NAME,
				"Water Bread"
			);
			AddEntry(
				LanguageEntries.WATERBREAD_DESCRIPTION,
				"One of the oldest condiments developed by man."
			);
			AddEntry(
				LanguageEntries.BREAD_NAME,
				"Bread"
			);
			AddEntry(
				LanguageEntries.BREAD_DESCRIPTION,
				"A milk bread, soft and tasty."
			);
			AddEntry(
				LanguageEntries.ALIEN_BREAD_NAME,
				"Alien Bread"
			);
			AddEntry(
				LanguageEntries.ALIEN_BREAD_DESCRIPTION,
				"A milk bread using alien eggs, even with the strange color is soft and tasty."
			);
			AddEntry(
				LanguageEntries.PASTA_NAME,
				"Pasta"
			);
			AddEntry(
				LanguageEntries.PASTA_DESCRIPTION,
				"A good pasta dough to be cooked with other condiments."
			);
			AddEntry(
				LanguageEntries.ALIEN_PASTA_NAME,
				"Alien Pasta"
			);
			AddEntry(
				LanguageEntries.ALIEN_PASTA_DESCRIPTION,
				"A good pasta dough using alien eggs to be cooked with other condiments."
			);
			AddEntry(
				LanguageEntries.VEGETABLEPASTA_NAME,
				"Vegetable Pasta"
			);
			AddEntry(
				LanguageEntries.VEGETABLEPASTA_DESCRIPTION,
				"A delicious pasta with tomatoes and broccoli."
			);
			AddEntry(
				LanguageEntries.VEGETABLEALIENPASTA_NAME,
				"Vegetable Alien Pasta"
			);
			AddEntry(
				LanguageEntries.VEGETABLEALIENPASTA_DESCRIPTION,
				"A delicious pasta using alien eggs with tomatoes and broccoli."
			);
			AddEntry(
				LanguageEntries.MEATPASTA_NAME,
				"Meat Pasta"
			);
			AddEntry(
				LanguageEntries.MEATPASTA_DESCRIPTION,
				"A delicious pasta with tomatoes and meat."
			);
			AddEntry(
				LanguageEntries.ALIENMEATPASTA_NAME,
				"Alien Meat Pasta"
			);
			AddEntry(
				LanguageEntries.ALIENMEATPASTA_DESCRIPTION,
				"A delicious pasta using alien eggs with tomatoes and alien meat."
			);
			AddEntry(
				LanguageEntries.CHEESE_NAME,
				"Cheese"
			);
			AddEntry(
				LanguageEntries.CHEESE_DESCRIPTION,
				"Cheese is a solid food made from milk."
			);
			AddEntry(
				LanguageEntries.SALAD_NAME,
				"Salad"
			);
			AddEntry(
				LanguageEntries.SALAD_DESCRIPTION,
				"Chopped and disinfected vegetables, a light and fresh meal."
			);
			AddEntry(
				LanguageEntries.VEGETABLE_SOUP_BOWL_NAME,
				"Vegetable Soup"
			);
			AddEntry(
				LanguageEntries.VEGETABLE_SOUP_BOWL_DESCRIPTION,
				"Soup is nutritious and can warm the body easily."
			);
			AddEntry(
				LanguageEntries.STEW_NAME,
				"Stew"
			);
			AddEntry(
				LanguageEntries.STEW_DESCRIPTION,
				"A good beef stew."
			);
			AddEntry(
				LanguageEntries.ALIEN_STEW_NAME,
				"Alien Stew"
			);
			AddEntry(
				LanguageEntries.ALIEN_STEW_DESCRIPTION,
				"A good alien beef stew."
			);
			AddEntry(
				LanguageEntries.MEAT_VEGETABLES_NAME,
				"Meat With Vegetables"
			);
			AddEntry(
				LanguageEntries.MEAT_VEGETABLES_DESCRIPTION,
				"Tasty meat served with well-cooked vegetables."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_VEGETABLES_NAME,
				"Alien Meat With Vegetables"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_VEGETABLES_DESCRIPTION,
				"Tasty alien meat served with well-cooked vegetables."
			);
			AddEntry(
				LanguageEntries.MEATLOAF_NAME,
				"Meatloaf"
			);
			AddEntry(
				LanguageEntries.MEATLOAF_DESCRIPTION,
				"A tasty meatloaf."
			);
			AddEntry(
				LanguageEntries.ALIENMEATLOAF_NAME,
				"Alien Meatloaf"
			);
			AddEntry(
				LanguageEntries.ALIENMEATLOAF_DESCRIPTION,
				"A tasty alien meatloaf."
			);
			AddEntry(
				LanguageEntries.MEAT_SOUP_BOWL_NAME,
				"Meat Soup"
			);
			AddEntry(
				LanguageEntries.MEAT_SOUP_BOWL_DESCRIPTION,
				"The flavor of the meat makes the soup tastier."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_SOUP_BOWL_NAME,
				"Alien Meat Soup"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_SOUP_BOWL_DESCRIPTION,
				"The flavor of the alien meat makes the soup tastier."
			);
			AddEntry(
				LanguageEntries.MUSHROOMPATE_BOWL_NAME,
				"Mushroom Pate"
			);
			AddEntry(
				LanguageEntries.MUSHROOMPATE_BOWL_DESCRIPTION,
				"A pate made with mushrooms."
			);
			AddEntry(
				LanguageEntries.MEAT_MUSHROOMS_NAME,
				"Meat With Mushrooms"
			);
			AddEntry(
				LanguageEntries.MEAT_MUSHROOMS_DESCRIPTION,
				"Tasty meat with sautéed mushrooms."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_MUSHROOMS_NAME,
				"Alien Meat With Mushrooms"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_MUSHROOMS_DESCRIPTION,
				"Tasty alien meat with sautéed mushrooms."
			);
			AddEntry(
				LanguageEntries.SANDWICH_NAME,
				"Sausage Sandwich"
			);
			AddEntry(
				LanguageEntries.SANDWICH_DESCRIPTION,
				"Sliced sausage sandwich with cheese and tomato."
			);
			AddEntry(
				LanguageEntries.ALIEN_SANDWICH_NAME,
				"Alien Sausage Sandwich"
			);
			AddEntry(
				LanguageEntries.ALIEN_SANDWICH_DESCRIPTION,
				"Sliced alien sausage sandwich with cheese and tomato."
			);
			AddEntry(
				LanguageEntries.ROASTEDSHRIMP_NAME,
				"Fried Shrimps"
			);
			AddEntry(
				LanguageEntries.ROASTEDSHRIMP_DESCRIPTION,
				"Fried shrimp is very tasty."
			);
			AddEntry(
				LanguageEntries.ROASTEDFISH_NAME,
				"Roast Fish"
			);
			AddEntry(
				LanguageEntries.ROASTEDFISH_DESCRIPTION,
				"A well-roasted fish meat."
			);
			AddEntry(
				LanguageEntries.ROASTEDNOBLEFISH_NAME,
				"Roast Noble Fish"
			);
			AddEntry(
				LanguageEntries.ROASTEDNOBLEFISH_DESCRIPTION,
				"A well-roasted noble fish meat."
			);
			AddEntry(
				LanguageEntries.FISHMUSHROOM_NAME,
				"Fish With Mushrooms"
			);
			AddEntry(
				LanguageEntries.FISHMUSHROOM_DESCRIPTION,
				"Tasty fish with sautéed mushrooms."
			);
			AddEntry(
				LanguageEntries.FISHSOUPBOWL_NAME,
				"Fish Soup"
			);
			AddEntry(
				LanguageEntries.FISHSOUPBOWL_DESCRIPTION,
				"The flavor of the noble fish meat makes the soup tastier."
			);
			AddEntry(
				LanguageEntries.SHRIMPSOUPBOWL_NAME,
				"Shrimp Soup"
			);
			AddEntry(
				LanguageEntries.SHRIMPSOUPBOWL_DESCRIPTION,
				"The flavor of the shrimps with fish meat makes the soup tastier."
			);
			AddEntry(
				LanguageEntries.APPLEPIE_NAME,
				"Apple Pie"
			);
			AddEntry(
				LanguageEntries.APPLEPIE_DESCRIPTION,
				"A pie made with apples."
			);
			AddEntry(
				LanguageEntries.ALIEN_APPLEPIE_NAME,
				"Alien Apple Pie"
			);
			AddEntry(
				LanguageEntries.ALIEN_APPLEPIE_DESCRIPTION,
				"A pie made with apples and alien eggs in the dough."
			);
			AddEntry(
				LanguageEntries.CHICKENPIE_NAME,
				"Chicken Pie"
			);
			AddEntry(
				LanguageEntries.CHICKENPIE_DESCRIPTION,
				"A pie made with chicken and bacon."
			);
			AddEntry(
				LanguageEntries.ALIEN_CHICKENPIE_NAME,
				"Alien Chicken Pie"
			);
			AddEntry(
				LanguageEntries.ALIEN_CHICKENPIE_DESCRIPTION,
				"A pie made with chicken and bacon and alien eggs in the dough."
			);
			AddEntry(
				LanguageEntries.FATPORRIDGE_NAME,
				"Fat Porridge"
			);
			AddEntry(
				LanguageEntries.FATPORRIDGE_DESCRIPTION,
				"Porridge made from concentrated fat, a great way to gain weight."
			);
			AddEntry(
				LanguageEntries.PROTEINBAR_NAME,
				"Protein Bar"
			);
			AddEntry(
				LanguageEntries.PROTEINBAR_DESCRIPTION,
				"A cereal bar enriched with a high amount of protein."
			);
			AddEntry(
				LanguageEntries.VITAMINPILLS_NAME,
				"Vitamin Pills"
			);
			AddEntry(
				LanguageEntries.VITAMINPILLS_DESCRIPTION,
				"Vitamin replacement pills."
			);
			AddEntry(
				LanguageEntries.TOMATOTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Vitamin From Tomato"
			);
			AddEntry(
				LanguageEntries.APPLETOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Vitamin From Apple"
			);
			AddEntry(
				LanguageEntries.ALIENEGGTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Alien Egg"
			);
			AddEntry(
				LanguageEntries.EGGTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Egg"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Shrimp Meat"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Shrimp Meat"
			);
			AddEntry(
				LanguageEntries.FISHMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Fish Meat"
			);
			AddEntry(
				LanguageEntries.FISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Fish Meat"
			);
			AddEntry(
				LanguageEntries.ALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Alien Meat"
			);
			AddEntry(
				LanguageEntries.ALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Alien Meat"
			);
			AddEntry(
				LanguageEntries.MEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Meat"
			);
			AddEntry(
				LanguageEntries.MEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Meat"
			);
			AddEntry(
				LanguageEntries.CHICKENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Chicken Meat"
			);
			AddEntry(
				LanguageEntries.CHICKENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Chicken Meat"
			);
			AddEntry(
				LanguageEntries.MILKTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Milk"
			);
			AddEntry(
				LanguageEntries.MILKTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Milk"
			);
			AddEntry(
				LanguageEntries.BACONTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Bacon"
			);
			AddEntry(
				LanguageEntries.BACONTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Bacon"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Noble Fish Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Noble Fish Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Alien Noble Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Alien Noble Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Concentrated Protein From Noble Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Concentrated Fat From Noble Meat"
			);
			#region FoodDefinition
			AddEntry(
				LanguageEntries.FOODDEFINITION_DESCRIPTION,
				"Liquid: {0}L" + Environment.NewLine +
				"Solid: {1}Kg" + Environment.NewLine +
				"Stomach: {2}%" + Environment.NewLine + Environment.NewLine +
				"Protein: {3}g" + Environment.NewLine +
				"Carbohydrate: {4}g" + Environment.NewLine +
				"Lipids: {5}g" + Environment.NewLine +
				"Vitamins: {6}g" + Environment.NewLine +
				"Minerals: {7}g" + Environment.NewLine +
				"Calories: {8}Cal" + Environment.NewLine + Environment.NewLine +
				"Digestion Time: {9}s"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_ROTTING_DESCRIPTION,
				"Rotting time: {0}s"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_EFFECT_INSTANT_DESCRIPTION,
				"{1} {0} instantly"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_EFFECT_OVERTIME_DESCRIPTION,
				"{1} {0} over {2}s"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_DISEASECHANCE_DESCRIPTION,
				"{0} chance to get {1} when eat"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION,
				"Can cure {0} when eat"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_MUSHROOMS_DESCRIPTION,
				"Mushrooms can be multiplied by putting together" + Environment.NewLine +
				"fertilizer and ice on farms." + Environment.NewLine +
				"Need sunlight: {0}" + Environment.NewLine +
				"Favorite Fertilizer: {1}"
			);
			#endregion
			#endregion
			#region HERBS
			AddEntry(
				LanguageEntries.ARNICA_NAME,
				"Arnica"
			);
			AddEntry(
				LanguageEntries.ARNICA_DESCRIPTION,
				"Arnica is a rare common flower and has anti-inflammatory and anti-biotic applications."
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_NAME,
				"Chamomile"
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_DESCRIPTION,
				"Chamomile is a very common flower and has calming and digestive effects."
			);
			AddEntry(
				LanguageEntries.ALOEVERA_NAME,
				"Aloe vera"
			);
			AddEntry(
				LanguageEntries.ALOEVERA_DESCRIPTION,
				"Aloe vera is a herb and has a wide application in medicine."
			);
			AddEntry(
				LanguageEntries.MINT_NAME,
				"Mint"
			);
			AddEntry(
				LanguageEntries.MINT_DESCRIPTION,
				"Mint is a very common herb and has refreshing and digestive effects."
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_NAME,
				"Erythroxylum"
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_DESCRIPTION,
				"Erythroxylum is a common herb with numbing effects."
			);
			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.BONEMEAL_NAME,
				"Bone Meal"
			);
			AddEntry(
				LanguageEntries.BONEMEAL_DESCRIPTION,
				"Bone meal is a mixture of finely and coarsely ground animal bones " + Environment.NewLine +
				"and slaughter-house waste products."
			);
			#endregion
			#region LIVESTOCK
			AddEntry(
				LanguageEntries.COWMALE_NAME,
				"Ox"
			);
			AddEntry(
				LanguageEntries.COWMALE_DESCRIPTION,
				"It is a male bovine and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.COWFEMALE_NAME,
				"Cow"
			);
			AddEntry(
				LanguageEntries.COWFEMALE_DESCRIPTION,
				"It is a female bovine and can be used for breeding, milk" + Environment.NewLine +
				"production or butchery."
			);
			AddEntry(
				LanguageEntries.COWBABY_NAME,
				"Calf"
			);
			AddEntry(
				LanguageEntries.COWBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.DEERMALE_NAME,
				"Male Deer"
			);
			AddEntry(
				LanguageEntries.DEERMALE_DESCRIPTION,
				"It is a male deer and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.DEERFEMALE_NAME,
				"Female Deer"
			);
			AddEntry(
				LanguageEntries.DEERFEMALE_DESCRIPTION,
				"It is a female deer and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.DEERBABY_NAME,
				"Deer Calf"
			);
			AddEntry(
				LanguageEntries.DEERBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.HORSEMALE_NAME,
				"Male Horse"
			);
			AddEntry(
				LanguageEntries.HORSEMALE_DESCRIPTION,
				"It is a male horse and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.HORSEFEMALE_NAME,
				"Female Horse"
			);
			AddEntry(
				LanguageEntries.HORSEFEMALE_DESCRIPTION,
				"It is a female horse and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.HORSEBABY_NAME,
				"Horse Calf"
			);
			AddEntry(
				LanguageEntries.HORSEBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.SHEEPMALE_NAME,
				"Male Sheep"
			);
			AddEntry(
				LanguageEntries.SHEEPMALE_DESCRIPTION,
				"It is a male sheep and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.SHEEPFEMALE_NAME,
				"Female Sheep"
			);
			AddEntry(
				LanguageEntries.SHEEPFEMALE_DESCRIPTION,
				"It is a female sheep and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.SHEEPBABY_NAME,
				"Sheep Calf"
			);
			AddEntry(
				LanguageEntries.SHEEPBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.SPIDERMALE_NAME,
				"Male Spider"
			);
			AddEntry(
				LanguageEntries.SPIDERMALE_DESCRIPTION,
				"It is a male spider and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.SPIDERFEMALE_NAME,
				"Female Spider"
			);
			AddEntry(
				LanguageEntries.SPIDERFEMALE_DESCRIPTION,
				"It is a female spider and can be used for breeding, egg production" + Environment.NewLine +
				"or butchery."
			);
			AddEntry(
				LanguageEntries.SPIDERBABY_NAME,
				"Spider Calf"
			);
			AddEntry(
				LanguageEntries.SPIDERBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.WOLFMALE_NAME,
				"Male Wolf"
			);
			AddEntry(
				LanguageEntries.WOLFMALE_DESCRIPTION,
				"It is a male wolf and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.WOLFFEMALE_NAME,
				"Female Wolf"
			);
			AddEntry(
				LanguageEntries.WOLFFEMALE_DESCRIPTION,
				"It is a female wolf and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.WOLFBABY_NAME,
				"Wolf Calf"
			);
			AddEntry(
				LanguageEntries.WOLFBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.COWDEAD_NAME,
				"Dead Cow"
			);
			AddEntry(
				LanguageEntries.COWDEAD_DESCRIPTION,
				"A cow carcass."
			);
			AddEntry(
				LanguageEntries.DEERDEAD_NAME,
				"Dead Deer"
			);
			AddEntry(
				LanguageEntries.DEERDEAD_DESCRIPTION,
				"A deer carcass."
			);
			AddEntry(
				LanguageEntries.HORSEDEAD_NAME,
				"Dead Horse"
			);
			AddEntry(
				LanguageEntries.HORSEDEAD_DESCRIPTION,
				"A horse carcass."
			);
			AddEntry(
				LanguageEntries.SHEEPDEAD_NAME,
				"Dead Sheep"
			);
			AddEntry(
				LanguageEntries.SHEEPDEAD_DESCRIPTION,
				"A sheep carcass."
			);
			AddEntry(
				LanguageEntries.SPIDERDEAD_NAME,
				"Dead Spider"
			);
			AddEntry(
				LanguageEntries.SPIDERDEAD_DESCRIPTION,
				"A spider carcass."
			);
			AddEntry(
				LanguageEntries.WOLFDEAD_NAME,
				"Dead Wolf"
			);
			AddEntry(
				LanguageEntries.WOLFDEAD_DESCRIPTION,
				"A wolf carcass."
			);
			AddEntry(
				LanguageEntries.COWBABYDEAD_NAME,
				"Dead Calf"
			);
			AddEntry(
				LanguageEntries.COWBABYDEAD_DESCRIPTION,
				"A calf carcass."
			);
			AddEntry(
				LanguageEntries.DEERBABYDEAD_NAME,
				"Dead Deer Calf"
			);
			AddEntry(
				LanguageEntries.DEERBABYDEAD_DESCRIPTION,
				"A deer calf carcass."
			);
			AddEntry(
				LanguageEntries.HORSEBABYDEAD_NAME,
				"Dead Horse Calf"
			);
			AddEntry(
				LanguageEntries.HORSEBABYDEAD_DESCRIPTION,
				"A horse calf carcass."
			);
			AddEntry(
				LanguageEntries.SHEEPBABYDEAD_NAME,
				"Dead Sheep Calf"
			);
			AddEntry(
				LanguageEntries.SHEEPBABYDEAD_DESCRIPTION,
				"A sheep calf carcass."
			);
			AddEntry(
				LanguageEntries.SPIDERBABYDEAD_NAME,
				"Dead Spider Calf"
			);
			AddEntry(
				LanguageEntries.SPIDERBABYDEAD_DESCRIPTION,
				"A spider calf carcass."
			);
			AddEntry(
				LanguageEntries.WOLFBABYDEAD_NAME,
				"Dead Wolf Calf"
			);
			AddEntry(
				LanguageEntries.WOLFBABYDEAD_DESCRIPTION,
				"A wolf calf carcass."
			);
			AddEntry(
				LanguageEntries.PIGBABYDEAD_NAME,
				"Dead Pig Calf"
			);
			AddEntry(
				LanguageEntries.PIGBABYDEAD_DESCRIPTION,
				"A pig calf carcass."
			);
			AddEntry(
				LanguageEntries.CHICKENBABYDEAD_NAME,
				"Dead Chicken Calf"
			);
			AddEntry(
				LanguageEntries.CHICKENBABYDEAD_DESCRIPTION,
				"A chicken calf carcass."
			);
			AddEntry(
				LanguageEntries.PIGDEAD_NAME,
				"Dead Pig"
			);
			AddEntry(
				LanguageEntries.PIGDEAD_DESCRIPTION,
				"A pig calf carcass."
			);
			AddEntry(
				LanguageEntries.CHICKENDEAD_NAME,
				"Dead Chicken"
			);
			AddEntry(
				LanguageEntries.CHICKENDEAD_DESCRIPTION,
				"A chicken calf carcass."
			);
			AddEntry(
				LanguageEntries.PIGMALE_NAME,
				"Male Pig"
			);
			AddEntry(
				LanguageEntries.PIGMALE_DESCRIPTION,
				"It is a male pig and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.PIGFEMALE_NAME,
				"Female Pig"
			);
			AddEntry(
				LanguageEntries.PIGFEMALE_DESCRIPTION,
				"It is a female pig and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.PIGBABY_NAME,
				"Pig Calf"
			);
			AddEntry(
				LanguageEntries.PIGBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			AddEntry(
				LanguageEntries.CHICKENMALE_NAME,
				"Male Chicken"
			);
			AddEntry(
				LanguageEntries.CHICKENMALE_DESCRIPTION,
				"It is a male chicken and can be used for breeding or butchery."
			);
			AddEntry(
				LanguageEntries.CHICKENFEMALE_NAME,
				"Female Chicken"
			);
			AddEntry(
				LanguageEntries.CHICKENFEMALE_DESCRIPTION,
				"It is a female chicken and can be used for breeding, egg production" + Environment.NewLine +
				"or butchery."
			);
			AddEntry(
				LanguageEntries.CHICKENBABY_NAME,
				"Chicken Calf"
			);
			AddEntry(
				LanguageEntries.CHICKENBABY_DESCRIPTION,
				"It is a calf, after being fed it will grow into an adult animal" + Environment.NewLine +
				"or can be used for butchery."
			);
			#region LivestockDefinition
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_HERBIVOROUS_DESCRIPTION,
				"This is a herbivorous animal, and can feed on plant-based feed."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_CARNIVOROUS_DESCRIPTION,
				"This is a carnivorous animal, and can feed on meat-based feed."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_BIRD_DESCRIPTION,
				"This is a bird, and can feed on grain-based feed."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_CARCASS_DESCRIPTION,
				"Note: An animal carcass will rot over time, so as not to lose" + Environment.NewLine +
				"the meat it can be processed in a slaughterhouse." + Environment.NewLine +
				"Rotting time: {0}s"
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_DESCRIPTION,
				"Note: An animal needs to be placed in a Cage, and will need to" + Environment.NewLine +
				"regularly receive rations in the block's inventory according" + Environment.NewLine +
				"to its diet."
			);
			AddEntry(
				LanguageEntries.LIVESTOCK_BUTCHERY_DESCRIPTION,
				"Butchery {0}"
			);
			AddEntry(
				LanguageEntries.LIVESTOCK_SLAUGHTER_DESCRIPTION,
				"Slaughter {0}"
			);
			#endregion
			#endregion
			#region MEDICAL
			AddEntry(
				LanguageEntries.BANDAGES_NAME,
				"Simple Bandages"
			);
			AddEntry(
				LanguageEntries.BANDAGES_DESCRIPTION,
				"Simple bandages that can be used for first aid."
			);
			AddEntry(
				LanguageEntries.POWER_BANDAGES_NAME,
				"Power Bandages"
			);
			AddEntry(
				LanguageEntries.POWER_BANDAGES_DESCRIPTION,
				"Simple bandages that can be used for first aid."
			);
			AddEntry(
				LanguageEntries.HEALTH_BUSTER_NAME,
				"Health Buster"
			);
			AddEntry(
				LanguageEntries.HEALTH_BUSTER_DESCRIPTION,
				"A powerful injectable that causes spontaneous regeneration" + Environment.NewLine +
				"in the body."
			);
			AddEntry(
				LanguageEntries.MEDKIT_NAME,
				"Medkit"
			);
			AddEntry(
				LanguageEntries.MEDKIT_DESCRIPTION,
				"An injectable capable of regenerating even bones."
			);
			AddEntry(
				LanguageEntries.HEALTHINJECTION_NAME,
				"Health Injection"
			);
			AddEntry(
				LanguageEntries.HEALTHINJECTION_DESCRIPTION,
				"A powerful injectable capable of curing infections, diseases" + Environment.NewLine +
				"and reducing fatigue."
			);
			AddEntry(
				LanguageEntries.HEALTHPOWERINJECTION_NAME,
				"Health Power Injection"
			);
			AddEntry(
				LanguageEntries.HEALTHPOWERINJECTION_DESCRIPTION,
				"A very powerful injectable that causes spontaneous regeneration" + Environment.NewLine +
				"in the body."
			);
			AddEntry(
				LanguageEntries.SIMPLEMEDICINE_NAME,
				"Simple Medicine"
			);
			AddEntry(
				LanguageEntries.SIMPLEMEDICINE_DESCRIPTION,
				"A useful remedy for digestive problems or mild pain."
			);
			AddEntry(
				LanguageEntries.MEDICINE_NAME,
				"Medicine"
			);
			AddEntry(
				LanguageEntries.MEDICINE_DESCRIPTION,
				"A useful remedy against poisons, and minor injuries."
			);
			#endregion
			#region ORES
			AddEntry(
				LanguageEntries.BONES_NAME,
				"Bones"
			);
			AddEntry(
				LanguageEntries.BONES_DESCRIPTION,
				"A bone is a rigid organ that constitutes part of the skeleton in most " + Environment.NewLine +
				"vertebrate animals."
			);
			AddEntry(
				LanguageEntries.FISH_BONES_NAME,
				"Fish Bones"
			);
			AddEntry(
				LanguageEntries.FISH_BONES_DESCRIPTION,
				"A bone is a rigid organ that constitutes part of the skeleton in most " + Environment.NewLine +
				"vertebrate animals."
			);
			AddEntry(
				LanguageEntries.POOP_NAME,
				"Poop"
			);
			AddEntry(
				LanguageEntries.POOP_DESCRIPTION,
				"The solid or semisolid remains of the food that could not be digested " + Environment.NewLine +
				"in the small intestine."
			);
			AddEntry(
				LanguageEntries.WHEAT_NAME,
				"Wheat"
			);
			AddEntry(
				LanguageEntries.WHEAT_DESCRIPTION,
				"Wheat grain is a staple food used to make flour, and with it, bread."
			);
			AddEntry(
				LanguageEntries.COFFEE_NAME,
				"Coffee"
			);
			AddEntry(
				LanguageEntries.COFFEE_DESCRIPTION,
				"Coffee is a stimulant, because it has caffeine, it can be an" + Environment.NewLine +
				"alternative to maintain body heat in cold places."
			);
			AddEntry(
				LanguageEntries.THERMALFLUID_NAME,
				"Thermal Fluid"
			);
			AddEntry(
				LanguageEntries.THERMALFLUID_DESCRIPTION,
				"Thermal fluid is a chemical used in a thermal cycle in" + Environment.NewLine +
				"refrigeration and air conditioning systems."
			);
			#endregion
			#region QUIMICALS
			AddEntry(
				LanguageEntries.PROPOFOL_NAME,
				"Propofol"
			);
			AddEntry(
				LanguageEntries.PROPOFOL_DESCRIPTION,
				"Propofol is a short-acting medication that results in a decreased level of consciousness."
			);
			AddEntry(
				LanguageEntries.LIDOCAINE_NAME,
				"Lidocaine"
			);
			AddEntry(
				LanguageEntries.LIDOCAINE_DESCRIPTION,
				"Lidocaine is a slow-acting medication that results in a decreased level of consciousness."
			);
			AddEntry(
				LanguageEntries.SMALLALOEVERAEXTRACT_NAME,
				"Small Aloe Vera Extract"
			);
			AddEntry(
				LanguageEntries.SMALLALOEVERAEXTRACT_DESCRIPTION,
				"Aloe vera extract has a wide application in medicine."
			);
			AddEntry(
				LanguageEntries.ALOEVERAEXTRACT_NAME,
				"Aloe Vera Extract"
			);
			AddEntry(
				LanguageEntries.ALOEVERAEXTRACT_DESCRIPTION,
				"Aloe vera extract has a wide application in medicine."
			);
			AddEntry(
				LanguageEntries.ARNICAEXTRACT_NAME,
				"Arnica Extract"
			);
			AddEntry(
				LanguageEntries.ARNICAEXTRACT_DESCRIPTION,
				"Arnica extract has anti-inflammatory and anti-biotic applications."
			);
			AddEntry(
				LanguageEntries.MINTEXTRACT_NAME,
				"Mint Extract"
			);
			AddEntry(
				LanguageEntries.MINTEXTRACT_DESCRIPTION,
				"Mint extract has refreshing and digestive effects."
			);
			AddEntry(
				LanguageEntries.CHAMOMILEEXTRACT_NAME,
				"Chamomile Extract"
			);
			AddEntry(
				LanguageEntries.CHAMOMILEEXTRACT_DESCRIPTION,
				"Chamomile extract has calming and digestive effects."
			);
			AddEntry(
				LanguageEntries.AMATOXINA_NAME,
				"Amatoxina"
			);
			AddEntry(
				LanguageEntries.AMATOXINA_DESCRIPTION,
				"Amatoxina is a toxic compounds found in poisonous mushrooms."
			);
			#endregion
			#region RATIONS
			AddEntry(
				LanguageEntries.MEATRATION_NAME,
				"Meat Ration"
			);
			AddEntry(
				LanguageEntries.MEATRATION_DESCRIPTION,
				"A meat-based feed, perfect for carnivorous animals."
			);
			AddEntry(
				LanguageEntries.VEGETABLERATION_NAME,
				"Vegetables Ration"
			);
			AddEntry(
				LanguageEntries.VEGETABLERATION_DESCRIPTION,
				"A vegetable-based feed, perfect for herbivorous animals."
			);
			AddEntry(
				LanguageEntries.GRAINSRATION_NAME,
				"Grains Ration"
			);
			AddEntry(
				LanguageEntries.GRAINSRATION_DESCRIPTION,
				"A grain-based feed, perfect for birds."
			);
			AddEntry(
				LanguageEntries.MEATRATION_CONSTRUCTION_NAME,
				"Meat Ration"
			);
			AddEntry(
				LanguageEntries.ALIENMEATRATION_CONSTRUCTION_NAME,
				"Alien Meat Ration"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATRATION_CONSTRUCTION_NAME,
				"Noble Meat Ration"
			);
			AddEntry(
				LanguageEntries.ALIENNOBLEMEATRATION_CONSTRUCTION_NAME,
				"Alien Noble Meat Ration"
			);
			AddEntry(
				LanguageEntries.FISHMEATRATION_CONSTRUCTION_NAME,
				"Fish Meat Ration"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATRATION_CONSTRUCTION_NAME,
				"Noble Fish Meat Ration"
			);
			AddEntry(
				LanguageEntries.BROCCOLIRATION_CONSTRUCTION_NAME,
				"Broccoli Ration"
			);
			AddEntry(
				LanguageEntries.BEETROOTRATION_CONSTRUCTION_NAME,
				"Beetroot Ration"
			);
			AddEntry(
				LanguageEntries.CARROTRATION_CONSTRUCTION_NAME,
				"Carrot Ration"
			);
			AddEntry(
				LanguageEntries.WHEATRATION_CONSTRUCTION_NAME,
				"Wheat Ration"
			);
			AddEntry(
				LanguageEntries.CEREALRATION_CONSTRUCTION_NAME,
				"Cereal Ration"
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.BOWL_NAME,
				"Bowl"
			);
			AddEntry(
				LanguageEntries.BOWL_DESCRIPTION,
				"Bowl are containers mainly used for storing and preparing food."
			);
			AddEntry(
				LanguageEntries.ALUMINUMCAN_NAME,
				"Aluminum Can"
			);
			AddEntry(
				LanguageEntries.ALUMINUMCAN_DESCRIPTION,
				"Aluminum cans are used to store beverages safely without risking rot."
			);
			AddEntry(
				LanguageEntries.BOWLOFWOOD_CONSTRUCTION_NAME,
				"Bowl Of Wood"
			);
			AddEntry(
				LanguageEntries.BOWLOFGLASS_CONSTRUCTION_NAME,
				"Bowl Of Glass"
			);
			AddEntry(
				 LanguageEntries.SMALLALUMINUMCANISTER_NAME,
				 "Small Aluminum Canister"
			 );
			AddEntry(
				LanguageEntries.SMALLALUMINUMCANISTER_DESCRIPTION,
				"Small aluminum canisters are used to safe store fluids."
			);
			#endregion
			#region SEEDS
			AddEntry(
				LanguageEntries.ARNICA_SEEDS_NAME,
				"Arnica Seeds"
			);
			AddEntry(
				LanguageEntries.ARNICA_SEEDS_DESCRIPTION,
				"Arnica seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.BEETROOT_SEEDS_NAME,
				"Beetroot Seeds"
			);
			AddEntry(
				LanguageEntries.BEETROOT_SEEDS_DESCRIPTION,
				"Beetroot seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.BROCCOLI_SEEDS_NAME,
				"Broccoli Seeds"
			);
			AddEntry(
				LanguageEntries.BROCCOLI_SEEDS_DESCRIPTION,
				"Broccoli seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.CARROT_SEEDS_NAME,
				"Carrot Seeds"
			);
			AddEntry(
				LanguageEntries.CARROT_SEEDS_DESCRIPTION,
				"Carrot seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.COFFEE_SEEDS_NAME,
				"Coffee Seeds"
			);
			AddEntry(
				LanguageEntries.COFFEE_SEEDS_DESCRIPTION,
				"Coffee seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.MINT_SEEDS_NAME,
				"Mint Seeds"
			);
			AddEntry(
				LanguageEntries.MINT_SEEDS_DESCRIPTION,
				"Mint seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.TOMATO_SEEDS_NAME,
				"Tomato Seeds"
			);
			AddEntry(
				LanguageEntries.TOMATO_SEEDS_DESCRIPTION,
				"Tomato seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.WHEAT_SEEDS_NAME,
				"Wheat Seeds"
			);
			AddEntry(
				LanguageEntries.WHEAT_SEEDS_DESCRIPTION,
				"Wheat seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_SEEDS_NAME,
				"Chamomile Seeds"
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_SEEDS_DESCRIPTION,
				"Chamomile seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.ALOEVERA_SEEDS_NAME,
				"Aloevera Seeds"
			);
			AddEntry(
				LanguageEntries.ALOEVERA_SEEDS_DESCRIPTION,
				"Aloevera seeds can be grown with fertilizer and ice on farms."
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_SEEDS_NAME,
				"Erythroxylum Seeds"
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_SEEDS_DESCRIPTION,
				"Erythroxylum seeds can be grown with fertilizer and ice on farms."
			);
			#region SeedDefinition
			AddEntry(
				LanguageEntries.SEEDDEFINITION_DESCRIPTION,
				"Need sunlight: {0}" + Environment.NewLine +
				"Favorite Fertilizer: {1}"
			);
			#endregion
			#endregion
			#region FERTILIZERS
			AddEntry(
				LanguageEntries.FERTILIZER_NAME,
				"Organic Fertilizer"
			);
			AddEntry(
				LanguageEntries.FERTILIZER_DESCRIPTION,
				"Fertilizer made from organic matter."
			);
			AddEntry(
				LanguageEntries.MINERALFERTILIZER_NAME,
				"Mineral Fertilizer"
			);
			AddEntry(
				LanguageEntries.MINERALFERTILIZER_DESCRIPTION,
				"Fertilizer made from mineral matter."
			);
			AddEntry(
				LanguageEntries.SUPERFERTILIZER_NAME,
				"Super Fertilizer"
			);
			AddEntry(
				LanguageEntries.SUPERFERTILIZER_DESCRIPTION,
				"Mixture of mineral and organic fertilizers," + Environment.NewLine +
				"can be used efficiently with all seeds."
			);
			AddEntry(
				LanguageEntries.BONEFERTILIZER_CONSTRUCTION_NAME,
				"Organic Fertilizer From Bone Meal"
			);
			AddEntry(
				LanguageEntries.POOPFERTILIZER_CONSTRUCTION_NAME,
				"Organic Fertilizer From Poop"
			);
			AddEntry(
				LanguageEntries.SPOILEDMATERIALFERTILIZER_CONSTRUCTION_NAME,
				"Organic Fertilizer From Organic Material"
			);
			AddEntry(
				LanguageEntries.MAGNESIUMFERTILIZER_CONSTRUCTION_NAME,
				"Mineral Fertilizer From Magnesium"
			);
			AddEntry(
				LanguageEntries.POTASSIUMFERTILIZER_CONSTRUCTION_NAME,
				"Mineral Fertilizer From Potassium"
			);
			AddEntry(
				LanguageEntries.FERTILIZER_CONSTRUCTION_NAME,
				"Mineral Fertilizer From Sulfur"
			);
			#region FertilizerDefinition
			AddEntry(
				LanguageEntries.FERTILIZERDEFINITION_POWER_DESCRIPTION,
				"Provides a {0}% production multiplier when used." + Environment.NewLine +
				"It is compatible with all plants."
			);
			AddEntry(
				LanguageEntries.FERTILIZERDEFINITION_DESCRIPTION,
				"Provides a {0}% production multiplier when used" + Environment.NewLine +
				"with compatible plants." + Environment.NewLine +
				"It is compatible with:"
			);
			#endregion
			#endregion
			#region TREES
			AddEntry(
				LanguageEntries.TREEDEAD_NAME,
				"Dead Tree"
			);
			AddEntry(
				LanguageEntries.TREEDEAD_DESCRIPTION,
				"A dead tree can be turned into wood in a grinder."
			);
			AddEntry(
				LanguageEntries.APPLETREESEEDLING_NAME,
				"Apple Tree Seedling"
			);
			AddEntry(
				LanguageEntries.APPLETREESEEDLING_DESCRIPTION,
				"Can grow into an apple tree if placed with fertilizer" + Environment.NewLine +
				"and ice in a tree farm."
			);
			AddEntry(
				LanguageEntries.APPLETREE_NAME,
				"Apple Tree"
			);
			AddEntry(
				LanguageEntries.APPLETREE_DESCRIPTION,
				"Can generate apples and saplings if placed with fertilizer" + Environment.NewLine +
				"and ice in a tree farm, also can be turned into wood in a" + Environment.NewLine +
				"grinder."
			);
			AddEntry(
				LanguageEntries.TREEDEAD_DESCONSTRUCTION_NAME,
				"Wood Logs From Dead Tree"
			);
			AddEntry(
				LanguageEntries.APPLETREE_DESCONSTRUCTION_NAME,
				"Wood Logs From Apple Tree"
			);
			#region TreeDefinition
			AddEntry(
				LanguageEntries.TREEDEFINITION_DESCRIPTION,
				"Need sunlight: {0}" + Environment.NewLine +
				"Favorite Fertilizer: {1}"
			);
			#endregion
			#endregion
			#region WEAPONS
			AddEntry(
				LanguageEntries.PROPOFOLDART_NAME,
				"Propofol Dart"
			);
			AddEntry(
				LanguageEntries.PROPOFOLDART_DESCRIPTION,
				"A Propofol-based tranquilizer dart."
			);
			AddEntry(
				LanguageEntries.LIDOCAINDART_NAME,
				"Lidocain Dart"
			);
			AddEntry(
				LanguageEntries.LIDOCAINDART_DESCRIPTION,
				"A Lidocain-based tranquilizer dart."
			);
			AddEntry(
				LanguageEntries.BBBULLET_NAME,
				"BB-6mm Bullet"
			);
			AddEntry(
				LanguageEntries.BBBULLET_DESCRIPTION,
				"A 6mm iron pellet bullet."
			);
			AddEntry(
				LanguageEntries.PISTOL_PROPOFOL_MAGZINE_NAME,
				"Pistol DRT-Propofol Magzine"
			);
			AddEntry(
				LanguageEntries.PISTOL_PROPOFOL_MAGZINE_DESCRIPTION,
				"A pistol clip with Propofol tranquilizer darts."
			);
			AddEntry(
				LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_NAME,
				"Pistol DRT-Lidocain Magzine"
			);
			AddEntry(
				LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_DESCRIPTION,
				"A pistol clip with Lidocain tranquilizer darts."
			);
			AddEntry(
				LanguageEntries.PISTOL_BB_MAGZINE_NAME,
				"Pistol BB-6mm Magzine"
			);
			AddEntry(
				LanguageEntries.PISTOL_BB_MAGZINE_DESCRIPTION,
				"A pistol clip with 6mm iron pellet bullets."
			);
			AddEntry(
				LanguageEntries.LIDOCAINPISTOLITEM_NAME,
				"Pistol DRT-Lidocain"
			);
			AddEntry(
				LanguageEntries.LIDOCAINPISTOLITEM_DESCRIPTION,
				"A gun for hunting animals with Lidocain tranquilizer darts."
			);
			AddEntry(
				LanguageEntries.PROPOFOLPISTOLITEM_NAME,
				"Pistol DRT-Propofol"
			);
			AddEntry(
				LanguageEntries.PROPOFOLPISTOLITEM_DESCRIPTION,
				"A gun for hunting animals with Propofol tranquilizer darts."
			);
			AddEntry(
				LanguageEntries.BBPISTOLITEM_NAME,
				"Pistol BB-6mm"
			);
			AddEntry(
				LanguageEntries.BBPISTOLITEM_DESCRIPTION,
				"A gun for hunting animals with 6mm iron pellet bullets."
			);
			#endregion
			#region STATS
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_FLU_NAME,
				"Flu"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_PNEUMONIA_NAME,
				"Pneumonia"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_DYSENTERY_NAME,
				"Dysentery"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_POISON_NAME,
				"Poison"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_INFECTED_NAME,
				"Infected"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPOTHERMIA_NAME,
				"Hypothermia"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPERTHERMIA_NAME,
				"Hyperthermia"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_STARVATION_NAME,
				"Starvation"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVERESTARVATION_NAME,
				"Severe Starvation"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_DEHYDRATION_NAME,
				"Dehydration"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVEREDEHYDRATION_NAME,
				"Severe Dehydration"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_OBESITY_NAME,
				"Obesity"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVEREOBESITY_NAME,
				"Severe Obesity"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_RICKETS_NAME,
				"Rickets"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVERERICKETS_NAME,
				"Severe Rickets"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPOLIPIDEMIA_NAME,
				"Hypolipidemia"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_QUEASY_NAME,
				"Queasy"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_POOPONCLOTHES_NAME,
				"Poop On Clothes"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_PEEONCLOTHES_NAME,
				"Pee On Clothes"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_OVERHEATING_NAME,
				"Overheating"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_ONFIRE_NAME,
				"On Fire"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_COLD_NAME,
				"Cold"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_FROSTY_NAME,
				"Frosty"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_WET_NAME,
				"Wet"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOCOLD_NAME,
				"Exposed to Cold"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOFREEZE_NAME,
				"Exposed to Freeze"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOHOT_NAME,
				"Exposed to Hot"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOBOILING_NAME,
				"Exposed to Boiling"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RECOVERINGFROMEXPOSURE_NAME,
				"Recovering from Exposure"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOCOLD_NAME,
				"Lesser Resistance To Cold"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOCOLD_NAME,
				"Resistance To Cold"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOCOLD_NAME,
				"Greater Resistance To Cold"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOHOT_NAME,
				"Lesser Resistance To Hot"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOHOT_NAME,
				"Resistance To Hot"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOHOT_NAME,
				"Greater Resistance To Hot"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_CONTUSION_NAME,
				"Contusion"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_WOUNDED_NAME,
				"Wounded"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_DEEPWOUNDED_NAME,
				"Deep Wounded"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_BROKENBONES_NAME,
				"Broken Bones"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_HUNGRY_NAME,
				"Hungry"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FAMISHED_NAME,
				"Famished"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_THIRSTY_NAME,
				"Thirsty"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_DEHYDRATING_NAME,
				"Dehydrating"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_DISORIENTED_NAME,
				"Disoriented"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_SUFFOCATION_NAME,
				"Suffocation"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLSTOMACH_NAME,
				"Full Stomach"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_STOMACHBURSTING_NAME,
				"Stomach Bursting"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLGUT_NAME,
				"Full Gut"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_GUTBURST_NAME,
				"Gut Burst"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLBLADDER_NAME,
				"Full Bladder"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_BLADDERBURST_NAME,
				"Bladder Burst"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_TIRED_NAME,
				"Tired"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_EXTREMELYTIRED_NAME,
				"Extremely Tired"
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL0_NAME,
				"I am feeling good and healthy."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL1_NAME,
				"I'm not feeling very well."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL2_NAME,
				"There's something wrong with me."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL3_NAME,
				"I need to do something before it's too late."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL4_NAME,
				"I need to find help, I think I'm dying."
			);
			AddEntry(
				LanguageEntries.FEELING_INFO_NAME,
				"Known effects:"
			);
			AddEntry(
				LanguageEntries.BOILING_NAME,
				"Boiling"
			);
			AddEntry(
				LanguageEntries.TOOHOT_NAME,
				"Too Hot"
			);
			AddEntry(
				LanguageEntries.WARMINGUP_NAME,
				"Warming Up"
			);
			AddEntry(
				LanguageEntries.FREEZING_NAME,
				"Freezing"
			);
			AddEntry(
				LanguageEntries.VERYCOLD_NAME,
				"Very Cold"
			);
			AddEntry(
				LanguageEntries.COOLINGDOWN_NAME,
				"Cooling Down"
			);
			AddEntry(
				LanguageEntries.STABLE_NAME,
				"Stable"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_WETLEVEL_NAME,
				"Wet Level"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_UNTREATEDWOUND_NAME,
				"Untreated Wound"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_TOXICEXPOSURE_NAME,
				"Toxic Exposure"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_RADIOACTIVEEXPOSURE_NAME,
				"Radioactive Exposure"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_COMPLETELYWET_NAME,
				"Completely Wet"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_COMPLETELYDRY_NAME,
				"Completely Dry"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_INFECTED_NAME,
				"Infected"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_NOINJURIES_NAME,
				"No Injuries"
			);
			AddEntry(
				LanguageEntries.HUNGER_NAME,
				"Hunger"
			);
			AddEntry(
				LanguageEntries.THIRST_NAME,
				"Thirst"
			);
			AddEntry(
				LanguageEntries.STAMINA_NAME,
				"Stamina"
			);
			AddEntry(
				LanguageEntries.FATIGUE_NAME,
				"Fatigue"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_NAME,
				"Survival Effects"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_NAME,
				"Damage Effects"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_NAME,
				"Temperature Effects"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_NAME,
				"Disease Effects"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_NAME,
				"Other Effects"
			);
			AddEntry(
				LanguageEntries.WOUNDEDTIME_NAME,
				"Wounded Time"
			);
			AddEntry(
				LanguageEntries.TEMPERATURETIME_NAME,
				"Temperature Time"
			);
			AddEntry(
				LanguageEntries.WETTIME_NAME,
				"Wet Time"
			);
			AddEntry(
				LanguageEntries.BODYENERGY_NAME,
				"Energy"
			);
			AddEntry(
				LanguageEntries.BODYWATER_NAME,
				"Water"
			);
			AddEntry(
				LanguageEntries.BODYPERFORMANCE_NAME,
				"Efficiency"
			);
			AddEntry(
				LanguageEntries.BODYIMMUNE_NAME,
				"Immunity"
			);
			AddEntry(
				LanguageEntries.STOMACH_NAME,
				"Stomach"
			);
			AddEntry(
				LanguageEntries.INTESTINE_NAME,
				"Intestine"
			);
			AddEntry(
				LanguageEntries.BLADDER_NAME,
				"Bladder"
			);
			AddEntry(
				LanguageEntries.BODYWEIGHT_NAME,
				"Weight"
			);
			AddEntry(
				LanguageEntries.BODYMUSCLES_NAME,
				"Muscles"
			);
			AddEntry(
				LanguageEntries.BODYFAT_NAME,
				"Fat"
			);
			AddEntry(
				LanguageEntries.FOODDETECTOR_NAME,
				"Food Detector"
			);
			AddEntry(
				LanguageEntries.MEDICALDETECTOR_NAME,
				"Medical Detector"
			);
			AddEntry(
				LanguageEntries.BODYCALORIES_NAME,
				"Calories"
			);
			AddEntry(
				LanguageEntries.TORPOR_NAME,
				"Torpor"
			);
			AddEntry(
				LanguageEntries.BODYPROTEIN_NAME,
				"Protein"
			);
			AddEntry(
				LanguageEntries.BODYCARBOHYDRATE_NAME,
				"Carbohydrate"
			);
			AddEntry(
				LanguageEntries.BODYLIPIDS_NAME,
				"Lipids"
			);
			AddEntry(
				LanguageEntries.BODYMINERALS_NAME,
				"Minerals"
			);
			AddEntry(
				LanguageEntries.BODYVITAMINS_NAME,
				"Vitamins"
			);
			AddEntry(
				LanguageEntries.INTOXICATIONTIME_NAME,
				"Intoxication Level"
			);
			AddEntry(
				LanguageEntries.RADIATIONTIME_NAME,
				"Radioactivity Level"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALFLUID_NAME,
				"Cold Thermal Fluid"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALFLUID_NAME,
				"Hot Thermal Fluid"
			); 
			AddEntry(
				LanguageEntries.ENERGYSHIELD_NAME,
				"Energy Shield"
			);		
			#endregion
			#region Weather
			AddEntry(
				LanguageEntries.WEATHEREFFECTSLEVEL_LIGHT_NAME,
				"Light"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTSLEVEL_HEAVY_NAME,
				"Heavy"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTS_RAIN_NAME,
				"Rain"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTS_THUNDERSTORM_NAME,
				"Storm"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_ATMOSPHERE_NAME,
				"Atmosphere"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_SHIPORSTATION_NAME,
				"Pressurized"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_SPACE_NAME,
				"Space"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_UNDERWATER_NAME,
				"Underwater"
			);
			AddEntry(
				LanguageEntries.UI_ENVIROMENT_DISPLAY,
				"Environment: "
			);
			AddEntry(
				LanguageEntries.UI_WEATHER_DISPLAY,
				"Weather: "
			);
			#endregion
			#region Armors
			AddEntry(
				LanguageEntries.SCAVENGERARMOR_NAME,
				"Scavenger Armor"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMOR_DESCRIPTION,
				"A very common armor model for those who don't have many" + Environment.NewLine +
				"resources and need extra protection."
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMORLIGHT_NAME,
				"Scavenger Armor [Light]"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMORHEAVY_NAME,
				"Scavenger Armor [Reinforced]"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMOREXPANDED_NAME,
				"Scavenger Armor [Expanded]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOR_NAME,
				"Hunter's Armor"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOR_DESCRIPTION,
				"A very effective armor for experienced hunters."
			);
			AddEntry(
				LanguageEntries.HUNTERARMORLIGHT_NAME,
				"Hunter's Armor [Light]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMORHEAVY_NAME,
				"Hunter's Armor [Reinforced]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOREXPANDED_NAME,
				"Hunter's Armor [Expanded]"
			);
			AddEntry(
				LanguageEntries.ARMOR_DESCRIPTION,
				"Note: Armors need to be in the player's inventory to work."
			);
			AddEntry(
				LanguageEntries.ARMORLIGHT_DESCRIPTION,
				"Light armor has less defense points, but has less volume" + Environment.NewLine +
				"and lower stamina expenditure."
			);
			AddEntry(
				LanguageEntries.ARMORHEAVY_DESCRIPTION,
				"Reinforced armor has more defense points, but has greater" + Environment.NewLine +
				"volume and higher stamina expenditure."
			);
			AddEntry(
				LanguageEntries.ARMOREXPANDED_DESCRIPTION,
				"Expanded armor has more module slots, but has higher volume," + Environment.NewLine +
				"lower defense and higher stamina expenditure."
			);
			AddEntry(
				LanguageEntries.ARMORCATEGORY_WORK_NAME,
				"Work"
			);
			AddEntry(
				LanguageEntries.ARMORCATEGORY_COMBAT_NAME,
				"Combat"
			);
			AddEntry(
				LanguageEntries.ARMORDESC_CATEGORY_ENTRY,
				"Category: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_MODULES_ENTRY,
				"Total Modules: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_STAMINA_ENTRY,
				"Stamina Cost: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_RESISTENCE_ENTRY,
				"{0} {1} resistance."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_EFFECT_ENTRY,
				"{0} of {1}."
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_GATHERING_NAME,
				"Gathering"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_CARGOLOAD_NAME,
				"Cargo Load"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_MOVEMENTSPEED_NAME,
				"Movement Speed"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_CREATUREDAMAGE_NAME,
				"Damage To Creatures"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_TORPORBONUS_NAME,
				"Torpor Bonus"
			);
			AddEntry(
				LanguageEntries.ARMORDESC_UI_EQUIPED,
				"Armor Equipped: {0} [{1} Empty Modules]."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_UI_SHIELD_EQUIPED,
				"Shield Equipped [{0} Max Points]."
			);			
			#endregion
			#region Armor Modules
			AddEntry(
				LanguageEntries.COLDTHERMALREGULATOR_NAME,
				"Cold Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.ENHANCEDCOLDTHERMALREGULATOR_NAME,
				"Enhanced Cold Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.PROFICIENTCOLDTHERMALREGULATOR_NAME,
				"Proficient Cold Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.ELITECOLDTHERMALREGULATOR_NAME,
				"Elite Cold Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION,
				"Used to maintain the suit's temperature when in extremely cold" + Environment.NewLine +
				"environments and consumes thermal fluid in the process."
			);
			AddEntry(
				LanguageEntries.HOTTHERMALREGULATOR_NAME,
				"Hot Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.ENHANCEDHOTTHERMALREGULATOR_NAME,
				"Enhanced Hot Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.PROFICIENTHOTTHERMALREGULATOR_NAME,
				"Proficient Hot Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.ELITEHOTTHERMALREGULATOR_NAME,
				"Elite Hot Thermal Regulator"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION,
				"Used to maintain the suit's temperature when in extremely hot" + Environment.NewLine +
				"environments and consumes thermal fluid in the process."
			);
			AddEntry(
				LanguageEntries.SHIELDGENERATOR_NAME,
				"Shield Generator"
			);
			AddEntry(
				LanguageEntries.SHIELDGENERATOR_DESCRIPTION,
				"Used to absorb impacts, attacks and projectiles can be the" + Environment.NewLine +
				"difference in survival. An armor can only have one shield" + Environment.NewLine +
				"generator, but there are shield expansion modules." + Environment.NewLine +
				"It takes a delay of {0} seconds without taking any damage" + Environment.NewLine +
				"for the shield to start recharging."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDGENERATOR_NAME,
				"Enhanced Shield Generator"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDGENERATOR_NAME,
				"Proficient Shield Generator"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDGENERATOR_NAME,
				"Elite Shield Generator"
			);
			AddEntry(
				LanguageEntries.SHIELDCAPACITOR_NAME,
				"Shield Capacitor"
			);
			AddEntry(
				LanguageEntries.SHIELDCAPACITOR_DESCRIPTION,
				"Used to increase a shield's maximum capacity and reload" + Environment.NewLine +
				"speed, but increases energy cost."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDCAPACITOR_NAME,
				"Enhanced Shield Capacitor"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDCAPACITOR_NAME,
				"Proficient Shield Capacitor"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDCAPACITOR_NAME,
				"Elite Shield Capacitor"
			);
			AddEntry(
				LanguageEntries.SHIELDTRANSISTOR_NAME,
				"Shield Transistor"
			);
			AddEntry(
				LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION,
				"Used to lower the energy cost of a shield, but increase" + Environment.NewLine +
				"the total cooldown."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDTRANSISTOR_NAME,
				"Enhanced Shield Transistor"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDTRANSISTOR_NAME,
				"Proficient Shield Transistor"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDTRANSISTOR_NAME,
				"Elite Shield Transistor"
			);
			AddEntry(
				LanguageEntries.SHIELDSPIKE_NAME,
				"Shield Spike"
			);
			AddEntry(
				LanguageEntries.SHIELDSPIKE_DESCRIPTION,
				"Used to return part of the melee damage taken to the attacker."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDSPIKE_NAME,
				"Enhanced Shield Spike"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDSPIKE_NAME,
				"Proficient Shield Spike"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDSPIKE_NAME,
				"Elite Shield Spike"
			);
			AddEntry(
				LanguageEntries.ARMORMODULE_DESCRIPTION,
				"Note: Armor modules need to be in the player's inventory to work."
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_EFFICIENCY_NAME,
				"Efficiency"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_CAPACITY_NAME,
				"Capacity"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_RECHARGESPEED_NAME,
				"Recharge Speed"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTION_NAME,
				"Energy Consumption"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_CAPACITYBONUS_NAME,
				"Capacity Bonus"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_RECHARGESPEEDBONUS_NAME,
				"Recharge Speed Bonus"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTIONBONUS_NAME,
				"Energy Consumption Bonus"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_SPIKEDAMAGE_NAME,
				"Spike Damage"
			);
			#endregion
			#region Damage Types
			AddEntry(
				LanguageEntries.DAMAGETYPE_CREATURE_NAME,
				"Creature"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_BULLET_NAME,
				"Bullet"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_EXPLOSION_NAME,
				"Explosion"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_RADIOACTIVITY_NAME,
				"Radioactivity"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_FIRE_NAME,
				"Fire"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_TOXICITY_NAME,
				"Toxicity"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_FALL_NAME,
				"Fall"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_TOOL_NAME,
				"Tool"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_ENVIRONMENT_NAME,
				"Enviroment"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_OTHER_NAME,
				"Other"
			);
			#endregion
		}

    }

}
