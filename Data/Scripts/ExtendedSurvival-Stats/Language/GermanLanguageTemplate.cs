﻿using System;
using VRage;

namespace ExtendedSurvival.Stats
{

    public class GermanLanguageTemplate : BaseLanguageTemplate
    {

        public GermanLanguageTemplate() 
            : base(MyLanguagesEnum.German)
        {
        }

        protected override void DoLoadEntries()
        {
			#region GENERALS
			AddEntry(
				LanguageEntries.TERMS_YES_NAME,
				"Ja"
			);
			AddEntry(
				LanguageEntries.TERMS_NO_NAME,
				"Nein"
			);
			AddEntry(
				LanguageEntries.TERMS_FULL_NAME,
				"Voll"
			);
			AddEntry(
				LanguageEntries.TERMS_EMPTY_NAME,
				"Leer"
			);
            AddEntry(
                LanguageEntries.TERMS_RESISTANCE_NAME,
                "die Beständigkeit"
            );
            AddEntry(
                LanguageEntries.TERMS_BONUS_NAME,
                "Bonus"
            );
            #endregion
            #region CUBE_BLOCKS
            AddEntry(
                LanguageEntries.CUBEBLOCK_SMALL_CAGE,
				"Kleiner Käfig"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_LARGE_CAGE,
				"Großer Käfig"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_CAGE_DESCRIPTION,
				"Käfige sind Blöcke, die verwendet werden, um gefangene Tiere zu " +
				"lagern und am Leben zu erhalten. Wenn Sie die Tiere füttern, fressen " +
				"sie, um am Leben zu bleiben, und produzieren in einigen Fällen " +
				"Produkte. "
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_COMPOSTER,
				"Komposter"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_COMPOSTER_DESCRIPTION,
				"Komposter sind Blöcke, die bis zum {0}x beschleunigen können " +
				"Verrottung von itens. Wenn es organisches Material im Inventar hatte, " +
				"werden Fischköder in Zeitzyklen spawnen, diese Zyklen können von reichen " +
				"{1}s bis {2}s basierend auf der Menge an organischem Material. " +
				"Die Energiekosten variieren je nach Bestandsvolumen, " +
				"von {3}kW/h bis zu {4}kW/h."
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FARM,
				"Bauernhof"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FARM_DESCRIPTION,
				"Farmen sind Blöcke, die Gemüse, Pilze und Kräuter erzeugen " +
				"wenn Samen, Eis und Düngemittel ins Inventar gelegt werden. " +
				"Die Ressourcenkosten steigen um {0}% für zusätzliche Samenart und Verrottung " +
				"Die Zeit verringert sich beim Produzieren um {0}%."
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_TREEFARM,
				"Baumfarm"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_TREEFARM_DESCRIPTION,
				"Baumfarmen sind Blöcke, die wachsen und Bäume am Leben erhalten können, um zu produzieren " +
				"Obst, wenn du Eis und Dünger in deinem Inventar hast. " +
				"Die Verrottungszeit verringert sich beim Produzieren um {0} %."
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FISHTRAP,
				"Fischfalle"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FISHTRAP_DESCRIPTION,
				"Reusen sind Blöcke, die Fische durch den Verzehr von Ködern fangen können, die sie brauchen " +
				"untergetaucht und an untergetauchte Kollektoren angeschlossen werden, um zu arbeiten. " +
				"Die Fangzyklen sind {0}s und die Energiekosten können von {1}kW/h bis zu {2}kW/h variieren."
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR,
				"Küchenmaschine"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_BASIC,
                "Einfache Küchenmaschine"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_INDUSTRIAL,
				"Industrielle Küchenmaschine"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_FOODPROCESSOR_DESCRIPTION,
				"Küchenmaschinen sind Blöcke, die Lebensmittel zubereiten und kochen können. " +
				"Am Ende der Produktion, wenn Sie einen Kühlschrank angeschlossen haben, " +
				"Es speichert Lebensmittel automatisch."
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE,
				"Schlachthof"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_BASIC,
				"Einfaches Schlachthaus"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_INDUSTRIAL,
				"Industrieller Schlachthof"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_DESCRIPTION,
				"Schlachthöfe sind Blöcke, die gezüchtet werden können " +
				"Tiere und extrahieren ihr Fleisch. Am Ende der Produktion, " +
				"Wenn Sie einen Kühlschrank angeschlossen haben, werden darin Lebensmittel gelagert " +
				"automatisch."
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_SMALL_REFRIGERATOR,
				"Kleiner Kühlschrank"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_LARGE_REFRIGERATOR,
				"Großer Kühlschrank"
			);
            AddEntry(
                LanguageEntries.CUBEBLOCK_EXTRALARGE_REFRIGERATOR,
                "Extra großer Kühlschrank"
            );
            AddEntry(
                LanguageEntries.CUBEBLOCK_REFRIGERATOR_DESCRIPTION,
				"Kühlschränke sind Blöcke, die verhindern können, dass Gegenstände verrotten. " +
				"Die Energiekosten variieren je nach Bestandsvolumen, " +
				"von {0}kW/h bis zu {1}kW/h."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR,
				"Thermoflüssigkeitsgenerator"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR_DESCRIPTION,
				"Thermoflüssigkeitsgeneratoren sind Blöcke, die für das Nachfüllen von " +
				"Thermogasflaschen verantwortlich sind, die Thermoflüssigkeit verbrauchen."
			);
			#endregion
			#region EQUIPMENTS
			AddEntry(
                LanguageEntries.BODYTRACKER_NAME,
				"Bodytracker"
			);
            AddEntry(
                LanguageEntries.BODYTRACKER_DESCRIPTION,
				"Ein Zubehör, das dafür verantwortlich ist, den Zustand des Körpers zu " + Environment.NewLine +
				"überwachen und auf dem Helmdisplay des Raumanzugs anzuzeigen." + Environment.NewLine +
				"Kann erkennen:" + Environment.NewLine +
				"- Nasses Niveau;" + Environment.NewLine +
				"- Körpertemperatur;" + Environment.NewLine +
				"- Grundlegende negative Auswirkungen;" + Environment.NewLine + Environment.NewLine +
				"Hinweis: Um Zubehörboni zu erhalten, müssen Sie es über die " + Environment.NewLine +
				"Ausrüstungsschnittstelle ausrüsten lassen."
			);
            AddEntry(
                LanguageEntries.ENHANCEDBODYTRACKER_NAME,
				"Verbesserter Bodytracker"
			);
            AddEntry(
                LanguageEntries.ENHANCEDBODYTRACKER_DESCRIPTION,
				"Ein Zubehör, das dafür verantwortlich ist, den Zustand des Körpers zu " + Environment.NewLine +
				"überwachen und auf dem Helmdisplay des Raumanzugs anzuzeigen." + Environment.NewLine +
				"Kann erkennen:" + Environment.NewLine +
				"- Nasses Niveau;" + Environment.NewLine +
				"- Körpertemperatur;" + Environment.NewLine +
				"- Körperenergie;" + Environment.NewLine +
				"- Körperwasser;" + Environment.NewLine +
				"- Unbehandelte Wunde;" + Environment.NewLine +
				"- Mittlere negative Auswirkungen;" + Environment.NewLine + Environment.NewLine +
				"Hinweis: Um Zubehörboni zu erhalten, müssen Sie es über die " + Environment.NewLine +
				"Ausrüstungsschnittstelle ausrüsten lassen."
			);
            AddEntry(
                LanguageEntries.PROFICIENTBODYTRACKER_NAME,
				"Kompetenter Bodytracker"
			);
            AddEntry(
                LanguageEntries.PROFICIENTBODYTRACKER_DESCRIPTION,
				"Ein Zubehör, das dafür verantwortlich ist, den Zustand des Körpers zu " + Environment.NewLine +
				"überwachen und auf dem Helmdisplay des Raumanzugs anzuzeigen." + Environment.NewLine +
				"Kann erkennen:" + Environment.NewLine +
				"- Nasses Niveau;" + Environment.NewLine +
				"- Körpertemperatur;" + Environment.NewLine +
				"- Körperenergie;" + Environment.NewLine +
				"- Körperwasser;" + Environment.NewLine +
				"- Körpergewicht;" + Environment.NewLine +
				"- Körperliche Leistungsfähigkeit;" + Environment.NewLine +
				"- Körperermüdung;" + Environment.NewLine +
				"- Unbehandelte Wunde;" + Environment.NewLine +
				"- Erweiterte negative Effekte;" + Environment.NewLine + Environment.NewLine +
				"Hinweis: Um Zubehörboni zu erhalten, müssen Sie es über die " + Environment.NewLine +
				"Ausrüstungsschnittstelle ausrüsten lassen."
			);
            AddEntry(
                LanguageEntries.ELITEBODYTRACKER_NAME,
				"Elite Bodytracker"
			);
            AddEntry(
                LanguageEntries.ELITEBODYTRACKER_DESCRIPTION,
				"Ein Zubehör, das dafür verantwortlich ist, den Zustand des Körpers zu " + Environment.NewLine +
				"überwachen und auf dem Helmdisplay des Raumanzugs anzuzeigen." + Environment.NewLine +
				"Kann erkennen:" + Environment.NewLine +
				"- Nasses Niveau;" + Environment.NewLine +
				"- Körpertemperatur;" + Environment.NewLine +
				"- Körperenergie;" + Environment.NewLine +
				"- Körperwasser;" + Environment.NewLine +
				"- Körpergewicht;" + Environment.NewLine +
				"- Körperliche Leistungsfähigkeit;" + Environment.NewLine +
				"- Körperermüdung;" + Environment.NewLine +
				"- Körperliche Immunität;" + Environment.NewLine +
				"- Körpermuskel;" + Environment.NewLine +
				"- Körperfett;" + Environment.NewLine +
				"- Unbehandelte Wunde;" + Environment.NewLine +
				"- Alles negative Auswirkungen;" + Environment.NewLine + Environment.NewLine +
				"Hinweis: Um Zubehörboni zu erhalten, müssen Sie es über die " + Environment.NewLine +
				"Ausrüstungsschnittstelle ausrüsten lassen."
			);
			AddEntry(
				LanguageEntries.COLDTHERMALBOTTLE_NAME,
				"Kalte Thermoflasche"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALBOTTLE_DESCRIPTION,
				"Wird von Kühlmodulen verwendet, um die Anzugtemperatur in extrem kalten" + Environment.NewLine +
				"Umgebungen aufrechtzuerhalten."
			);
			AddEntry(
				LanguageEntries.HOTTHERMALBOTTLE_NAME,
				"Heiße Thermoflasche"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALBOTTLE_DESCRIPTION,
				"Wird von Kühlmodulen verwendet, um die Anzugtemperatur in extrem heißen" + Environment.NewLine +
				"Umgebungen aufrechtzuerhalten."
			);
            AddEntry(
                LanguageEntries.SIMPLEHEALINGBOTTLE_NAME,
                "Einfache Heilflasche"
            );
            AddEntry(
                LanguageEntries.FULLSIMPLEHEALINGBOTTLE_NAME,
                "Einfache Heilflasche (Voll)"
            );
            AddEntry(
                LanguageEntries.SIMPLEHEALINGBOTTLE_DESCRIPTION,
                "Wird verwendet, um den Heilungsprozess zu beschleunigen. Um es verwenden " + Environment.NewLine +
                "zu können, muss es im Inventar eines Kryopods platziert werden."
            );
            AddEntry(
                LanguageEntries.TOXICITYFILTERBOTTLE_NAME,
                "Toxizitätsfilterflasche"
            );
            AddEntry(
                LanguageEntries.TOXICITYFILTERBOTTLE_DESCRIPTION,
                "Wird von Filtermodulen verwendet, um das giftige Material zu speichern, das " + Environment.NewLine +
                "in extrem giftigen Umgebungen in den Anzug eindringt."
            );
            AddEntry(
                LanguageEntries.FULLTOXICITYFILTERBOTTLE_NAME,
                "Toxizitätsfilterflasche (Voll)"
            );
            AddEntry(
                LanguageEntries.FULLTOXICITYFILTERBOTTLE_DESCRIPTION,
                "Eine Flasche mit giftigem Material kann im Labor entsorgt werden."
            );
            AddEntry(
                LanguageEntries.RADIOACTIVITYFILTERBOTTLE_NAME,
                "Radioaktivitätsfilterflasche"
            );
            AddEntry(
                LanguageEntries.RADIOACTIVITYFILTERBOTTLE_DESCRIPTION,
                "Wird von Filtermodulen verwendet, um das radioaktive Material zu speichern, " + Environment.NewLine +
                "das in extrem radioaktiven Umgebungen in den Anzug eindringt."
            );
            AddEntry(
                LanguageEntries.FULLRADIOACTIVITYFILTERBOTTLE_NAME,
                "Radioaktivitätsfilterflasche (Voll)"
            );
            AddEntry(
                LanguageEntries.FULLRADIOACTIVITYFILTERBOTTLE_DESCRIPTION,
                "Eine Flasche mit radioaktivem Material kann im Labor entsorgt werden."
            );
            #endregion
            #region FISHING
            AddEntry(
                LanguageEntries.FISH_NAME,
				"Fisch"
			);
            AddEntry(
                LanguageEntries.FISH_DESCRIPTION,
				"Fische sind in den meisten Gewässern reichlich vorhanden. " + Environment.NewLine +
				"Sie kommen in fast allen Gewässern vor."
			);
            AddEntry(
                LanguageEntries.ALIENFISH_NAME,
				"Außerirdischer Fisch"
			);
            AddEntry(
                LanguageEntries.ALIENFISH_DESCRIPTION,
				"Fische sind in den meisten Gewässern reichlich vorhanden. " + Environment.NewLine +
				"Sie kommen in fast allen Gewässern vor."
			);
            AddEntry(
                LanguageEntries.NOBLEFISH_NAME,
				"Edler Fisch"
			);
            AddEntry(
                LanguageEntries.NOBLEFISH_DESCRIPTION,
				"Edelfische sind schwieriger zu fangen. Sie können in tieferen " + Environment.NewLine +
				"Gewässern gefunden werden."
			);
            AddEntry(
                LanguageEntries.ALIENNOBLEFISH_NAME,
				"Außerirdischer Edelfisch"
			);
            AddEntry(
                LanguageEntries.ALIENNOBLEFISH_DESCRIPTION,
				"Edelfische sind schwieriger zu fangen. Sie können in tieferen " + Environment.NewLine +
				"Gewässern gefunden werden."
			);
            AddEntry(
                LanguageEntries.SHRIMP_NAME,
				"Garnele"
			);
            AddEntry(
                LanguageEntries.SHRIMP_DESCRIPTION,
				"Garnelen sind Krebstiere mit länglichen Körpern und einer " + Environment.NewLine +
				"hauptsächlich schwimmenden Fortbewegungsart."
			);
            AddEntry(
                LanguageEntries.FISH_BAIT_SMALL_NAME,
                "Fisch Köder"
            );
            AddEntry(
                LanguageEntries.FISH_BAIT_SMALL_DESCRIPTION,
				"Eine Art kleiner Wurm, manche Fische mögen ihn appetitlich finden."
			);
            AddEntry(
                LanguageEntries.FISH_NOBLE_BAIT_NAME,
				"Edler Fischköder"
			);
            AddEntry(
                LanguageEntries.FISH_NOBLE_BAIT_DESCRIPTION,
				"Eine Art kleiner Wurm, manche Fische mögen ihn appetitlich finden."
			);
            #region FishBaitDefinition
            AddEntry(
                LanguageEntries.FISHBAITDEFINITION_DESCRIPTION,
				"Kann in Fallen verwendet werden, um Fische zu fangen." + Environment.NewLine +
				"Verbraucht von {0} bis {1} pro Zyklus." + Environment.NewLine +
				"Kann bis zu {2} Fische pro Kreis fangen." + Environment.NewLine +
				"Gültige Ziele:"
			);
            AddEntry(
                LanguageEntries.FISHBAITDEFINITION_FISH_DESCRIPTION,
				"- {1}%, um {0} in einer Mindesttiefe von {2}m zu erhalten"
			);
            AddEntry(
                LanguageEntries.FISHBAITDEFINITION_DECOMPOSITION_DESCRIPTION,
				"Es kann in Kompostern erzeugt werden." + Environment.NewLine +
				"{0}% kann, {1} bis {2} pro Zyklus zu spawnen, verbrauch von " + Environment.NewLine +
				"{3} bis {4} organisches Material."
			);
            #endregion
            #region FishDefinition
            AddEntry(
                LanguageEntries.FISHDEFINITION_DESCRIPTION,
				"Rottezeit: {0}s" + Environment.NewLine + Environment.NewLine +
				"Kann in Fallen gefangen werden:"
			);
            AddEntry(
                LanguageEntries.FISHDEFINITION_BAIT_DESCRIPTION,
				"- {1}% mit {0} in einer Mindesttiefe von {2}m"
			);
            AddEntry(
                LanguageEntries.FISHDEFINITION_NOTE_DESCRIPTION,
				"Hinweis: Sie können ihr Fleisch in Küchenmaschinen extrahieren lassen."
			);
			#endregion
			#endregion
			#region FOODS
			AddEntry(
				LanguageEntries.APPLE_NAME,
				"Apfel"
			);
			AddEntry(
				LanguageEntries.APPLE_DESCRIPTION,
				"Apfel ist eine rote und appetitliche Frucht, sie hat " + Environment.NewLine +
				"einen niedrigen Kalorienwert."
			);
			AddEntry(
				LanguageEntries.BROCCOLI_NAME,
				"Brokkoli"
			);
			AddEntry(
				LanguageEntries.BROCCOLI_DESCRIPTION,
				"Brokkoli ist eine essbare grüne Pflanze aus der Familie der " + Environment.NewLine +
				"Kohlgewächse, sie ist eine besonders reichhaltige Vitaminquelle."
			);
			AddEntry(
				LanguageEntries.BEETROOT_NAME,
				"Rote Beete"
			);
			AddEntry(
				LanguageEntries.BEETROOT_DESCRIPTION,
				"Rote Beete ist der Pfahlwurzelanteil einer Rübenpflanze, sie " + Environment.NewLine +
				"ist eine besonders reichhaltige Mineralstoffquelle."
			);
			AddEntry(
				LanguageEntries.CAROOT_NAME,
				"Karotte"
			);
			AddEntry(
				LanguageEntries.CAROOT_DESCRIPTION,
				"Die Karotte ist ein Wurzelgemüse, sie ist eine besonders " + Environment.NewLine +
				"reichhaltige Mineralstoffquelle."
			);
			AddEntry(
				LanguageEntries.SHIITAKE_NAME,
				"Shiitake"
			);
			AddEntry(
				LanguageEntries.SHIITAKE_DESCRIPTION,
				"Shiitake ist ein Speisepilz, er ist eine besonders reichhaltige " + Environment.NewLine +
				"Proteinquelle."
			);
			AddEntry(
				LanguageEntries.CHAMPIGNONS_NAME,
				"Champignon"
			);
			AddEntry(
				LanguageEntries.CHAMPIGNONS_DESCRIPTION,
				"Champignon ist ein Speisepilz, er ist eine besonders reichhaltige " + Environment.NewLine +
				"Proteinquelle."
			);
			AddEntry(
				LanguageEntries.AMANITAMUSCARIA_NAME,
				"Amanita Muscaria"
			);
			AddEntry(
				LanguageEntries.AMANITAMUSCARIA_DESCRIPTION,
				"Amanita muscaria ist ein giftiger Pilz, der nicht zum Verzehr empfohlen " + Environment.NewLine +
				"wird, aber eine großartige chemische und medizinische Anwendung hat."
			);
			AddEntry(
				LanguageEntries.TOMATO_NAME,
				"Tomate"
			);
			AddEntry(
				LanguageEntries.TOMATO_DESCRIPTION,
				"Die Tomate ist die essbare Beere, sie hat einen geringen Kalorienwert."
			);
			AddEntry(
				LanguageEntries.CEREAL_NAME,
				"Getreide"
			);
			AddEntry(
				LanguageEntries.CEREAL_DESCRIPTION,
				"Getreide ist ein sehr nahrhaftes Getreide."
			);
			AddEntry(
				LanguageEntries.WHEATSACK_NAME,
				"Weizensack"
			);
			AddEntry(
				LanguageEntries.WHEATSACK_DESCRIPTION,
				"Weizenkorn ist ein Grundnahrungsmittel, aus dem Mehl und damit Brot " + Environment.NewLine +
				"hergestellt wird."
			);
			AddEntry(
				LanguageEntries.COFFEESACK_NAME,
				"Kaffeesack"
			);
			AddEntry(
				LanguageEntries.COFFEESACK_DESCRIPTION,
				"Kaffee ist ein Stimulans, da er Koffein enthält, kann er eine Alternative " + Environment.NewLine +
				"sein, um die Körperwärme an kalten Orten aufrechtzuerhalten."
			);
			AddEntry(
				LanguageEntries.MILK_NAME,
				"Milch"
			);
			AddEntry(
				LanguageEntries.MILK_DESCRIPTION,
				"Milch ist eine weiße, flüssige Nahrung, die von den Milchdrüsen von " + Environment.NewLine +
				"Säugetieren produziert wird."
			);
			AddEntry(
				LanguageEntries.MEAT_NAME,
				"Fleisch"
			);
			AddEntry(
				LanguageEntries.MEAT_DESCRIPTION,
				"Fleisch ist seit prähistorischen Zeiten eine der wichtigsten " + Environment.NewLine +
				"Proteinquellen."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_NAME,
				"Außerirdisches Fleisch"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_DESCRIPTION,
				"Es ist ein seltsames Fleisch und hat einen starken Geruch, aber " + Environment.NewLine +
				"der Geschmack ist normal."
			);
			AddEntry(
				LanguageEntries.CHICKENMEAT_NAME,
				"Hühnerfleisch"
			);
			AddEntry(
				LanguageEntries.CHICKENMEAT_DESCRIPTION,
				"Huhn ist die häufigste Geflügelart der Welt."
			);
			AddEntry(
				LanguageEntries.BACON_NAME,
				"Speck"
			);
			AddEntry(
				LanguageEntries.BACON_DESCRIPTION,
				"Speck ist eine Art von salzgepökeltem Schweinefleisch, das aus " + Environment.NewLine +
				"verschiedenen Teilstücken hergestellt wird, typischerweise dem " + Environment.NewLine +
				"Bauch oder den weniger fettigen Teilen des Rückens."
			);
			AddEntry(
				LanguageEntries.NOBLE_MEAT_NAME,
				"Edles Fleisch"
			);
			AddEntry(
				LanguageEntries.NOBLE_MEAT_DESCRIPTION,
				"Edles Fleischstück mit hoher Proteinkonzentration."
			);
			AddEntry(
				LanguageEntries.ALIEN_NOBLE_MEAT_NAME,
				"Außerirdisches edles Fleisch"
			);
			AddEntry(
				LanguageEntries.ALIEN_NOBLE_MEAT_DESCRIPTION,
				"Es ist ein edler Teil eines fremden Fleisches, der Geruch " + Environment.NewLine +
				"ist akzeptabler und schmackhafter."
			);
			AddEntry(
				LanguageEntries.EGG_NAME,
				"Ei"
			);
			AddEntry(
				LanguageEntries.EGG_DESCRIPTION,
				"Eier sind aus ernährungsphysiologischer Sicht ein sehr " + Environment.NewLine +
				"reichhaltiges Lebensmittel."
			);
			AddEntry(
				LanguageEntries.ALIEN_EGG_NAME,
				"Außerirdisches Ei"
			);
			AddEntry(
				LanguageEntries.ALIEN_EGG_DESCRIPTION,
				"Es ist eigentlich ein ziemlich großes Ei, aber es ist " + Environment.NewLine +
				"am besten, nicht zu sehr darüber nachzudenken, woher " + Environment.NewLine +
				"es kommt."
			);
			AddEntry(
				LanguageEntries.SHRIMPMEAT_NAME,
				"Garnelenfleisch"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEAT_DESCRIPTION,
				"Garnelen sind eine der am häufigsten konsumierten " + Environment.NewLine +
				"Meeresfrüchte weltweit. Sie sind reich an Nährstoffen " + Environment.NewLine +
				"und haben mehrere gesundheitliche Vorteile."
			);
			AddEntry(
				LanguageEntries.FISHMEAT_NAME,
				"Fisch Fleisch"
			);
			AddEntry(
				LanguageEntries.FISHMEAT_DESCRIPTION,
				"Fisch war im Laufe der Menschheitsgeschichte eine wichtige " + Environment.NewLine +
				"Nahrungsquelle für Proteine ​​und andere Nährstoffe."
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEAT_NAME,
				"Edles Fischfleisch"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEAT_DESCRIPTION,
				"Hochwertiges Fischfleisch mit einer hohen Proteinkonzentration."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDFAT_NAME,
				"Konzentriertes Fett"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDFAT_DESCRIPTION,
				"Fettkonzentration, die zur Herstellung anderer Produkte verwendet " + Environment.NewLine +
				"werden kann."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDPROTEIN_NAME,
				"Konzentriertes Protein"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDPROTEIN_DESCRIPTION,
				"Konzentration von Protein, das zur Herstellung anderer Produkte " + Environment.NewLine +
				"verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDVITAMIN_NAME,
				"Konzentriertes Vitamin"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDVITAMIN_DESCRIPTION,
				"Konzentration von Vitaminen, die zur Herstellung anderer Produkte " + Environment.NewLine +
				"verwendet werden können."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_NAME,
				"Kleine Wasserflasche"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION,
				"Eine kleine Flasche mit Wasser."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_NAME,
				"Mittlere Wasserflasche"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION,
				"Eine mittlere Flasche mit Wasser."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_NAME,
				"Große Wasserflasche"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_DESCRIPTION,
				"Eine große Flasche mit Wasser."
			);
			AddEntry(
				LanguageEntries.APPLE_JUICE_NAME,
				"Apfelsaft"
			);
			AddEntry(
				LanguageEntries.APPLE_JUICE_DESCRIPTION,
				"Eine große Flasche mit Apfelsaft."
			);
			AddEntry(
				LanguageEntries.SODA_NAME,
				"Apfelsoda"
			);
			AddEntry(
				LanguageEntries.SODA_DESCRIPTION,
				"Ein erfrischendes Soda auf Apfelbasis."
			);
			AddEntry(
				LanguageEntries.COFFEE_CAN_NAME,
				"Kaffee kann"
			);
			AddEntry(
				LanguageEntries.COFFEE_CAN_DESCRIPTION,
				"Eine Thermoskanne mit heißem Kaffee."
			);
			AddEntry(
				LanguageEntries.DOUGH_NAME,
				"Teig"
			);
			AddEntry(
				LanguageEntries.DOUGH_DESCRIPTION,
				"Ein Teig aus Milch und Eiern."
			);
			AddEntry(
				LanguageEntries.ALIEN_DOUGH_NAME,
				"Außerirdischer Teig"
			);
			AddEntry(
				LanguageEntries.ALIEN_DOUGH_DESCRIPTION,
				"Ein Teig aus Milch und außerirdischen Eiern."
			);
			AddEntry(
				LanguageEntries.CAKEDOUGH_NAME,
				"Kuchenteig"
			);
			AddEntry(
				LanguageEntries.CAKEDOUGH_DESCRIPTION,
				"Ein Kuchenteig aus Milch und Eiern."
			);
			AddEntry(
				LanguageEntries.ALIEN_CAKEDOUGH_NAME,
				"Außerirdischer Kuchenteig"
			);
			AddEntry(
				LanguageEntries.ALIEN_CAKEDOUGH_DESCRIPTION,
				"Ein Kuchenteig aus Milch und außerirdischen Eiern."
			);
			AddEntry(
				LanguageEntries.RAW_BROCCOLI_BOWL_NAME,
				"Rohe Brokkoli-Schüssel"
			);
			AddEntry(
				LanguageEntries.RAW_BROCCOLI_BOWL_DESCRIPTION,
				"Eine Schüssel mit gehacktem Brokkoli."
			);
			AddEntry(
				LanguageEntries.RAW_CARROT_BOWL_NAME,
				"Rohe Karottenschale"
			);
			AddEntry(
				LanguageEntries.RAW_CARROT_BOWL_DESCRIPTION,
				"Eine Schüssel mit gehackter Karotte."
			);
			AddEntry(
				LanguageEntries.RAW_BEETROOT_BOWL_NAME,
				"Rohe Rote-Bete-Schüssel"
			);
			AddEntry(
				LanguageEntries.RAW_BEETROOT_BOWL_DESCRIPTION,
				"Eine Schüssel mit gehackter Rote Bete."
			);
			AddEntry(
				LanguageEntries.RAW_MEAT_BOWL_NAME,
				"Schüssel für rohes Fleisch"
			);
			AddEntry(
				LanguageEntries.RAW_MEAT_BOWL_DESCRIPTION,
				"Eine Schüssel mit Hackfleisch."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_MEAT_BOWL_NAME,
				"Rohe Alien-Fleischschale"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_MEAT_BOWL_DESCRIPTION,
				"Eine Schüssel mit gehacktem Alien-Fleisch."
			);
			AddEntry(
				LanguageEntries.RAW_NOBLE_MEAT_BOWL_NAME,
				"Raw Noble Fleischschale"
			);
			AddEntry(
				LanguageEntries.RAW_NOBLE_MEAT_BOWL_DESCRIPTION,
				"Eine Schüssel mit edlem Hackfleisch."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_NAME,
				"Raw Alien Edle Fleischschale"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_DESCRIPTION,
				"Eine Schüssel mit gehacktem Alien-Edelfleisch."
			);
			AddEntry(
				LanguageEntries.RAWFISHMEATBOWL_NAME,
				"Rohe Fischfleischschale"
			);
			AddEntry(
				LanguageEntries.RAWFISHMEATBOWL_DESCRIPTION,
				"Eine Schüssel mit gehacktem Fischfleisch."
			);
			AddEntry(
				LanguageEntries.RAWNOBLEFISHMEATBOWL_NAME,
				"Rohe edle Fischfleischschale"
			);
			AddEntry(
				LanguageEntries.RAWNOBLEFISHMEATBOWL_DESCRIPTION,
				"Eine Schale mit gehacktem edlem Fischfleisch."
			);
			AddEntry(
				LanguageEntries.RAW_SAUSAGE_NAME,
				"Rohwurst"
			);
			AddEntry(
				LanguageEntries.RAW_SAUSAGE_DESCRIPTION,
				"Eine Wurst voller rohem Fleisch."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_SAUSAGE_NAME,
				"Rohe Alien-Wurst"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_SAUSAGE_DESCRIPTION,
				"Eine Wurst voller rohem Alien-Fleisch."
			);
			AddEntry(
				LanguageEntries.ROAST_CHAMPIGNON_NAME,
				"Gebratene Champignons"
			);
			AddEntry(
				LanguageEntries.ROAST_CHAMPIGNON_DESCRIPTION,
				"Eine einfache und leckere Art, Pilze zu essen."
			);
			AddEntry(
				LanguageEntries.ROAST_SHIITAKE_NAME,
				"Gebratene Shiitake"
			);
			AddEntry(
				LanguageEntries.ROAST_SHIITAKE_DESCRIPTION,
				"Eine einfache und leckere Art, Pilze zu essen."
			);
			AddEntry(
				LanguageEntries.FRIED_EGG_NAME,
				"Spiegelei"
			);
			AddEntry(
				LanguageEntries.FRIED_EGG_DESCRIPTION,
				"Eine der primitivsten Arten, ein Ei zu essen."
			);
			AddEntry(
				LanguageEntries.FRIED_ALIEN_EGG_NAME,
				"Gebratenes Alien-Ei"
			);
			AddEntry(
				LanguageEntries.FRIED_ALIEN_EGG_DESCRIPTION,
				"Die Farbe ist seltsam, aber es ist immer noch ein Spiegelei."
			);
			AddEntry(
				LanguageEntries.ROASTEDBACON_NAME,
				"Speck braten"
			);
			AddEntry(
				LanguageEntries.ROASTEDBACON_DESCRIPTION,
				"Speck ist Leben!"
			);
			AddEntry(
				LanguageEntries.ROASTEDCHICKEN_NAME,
				"Brathähnchen"
			);
			AddEntry(
				LanguageEntries.ROASTEDCHICKEN_DESCRIPTION,
				"Leichtes, fettarmes Fleisch."
			);
			AddEntry(
				LanguageEntries.ROASTED_SAUSAGE_NAME,
				"Bratwurst"
			);
			AddEntry(
				LanguageEntries.ROASTED_SAUSAGE_DESCRIPTION,
				"Verarbeitetes und gut gewürztes Fleisch, es kann allein oder als Gewürz gegessen werden."
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_SAUSAGE_NAME,
				"Gebratene Alien-Wurst"
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_SAUSAGE_DESCRIPTION,
				"Nach der Verarbeitung und Würze ist der Geschmack trotz der seltsamen Farbe sehr gut."
			);
			AddEntry(
				LanguageEntries.ROASTED_MEAT_NAME,
				"Gebratenes Fleisch"
			);
			AddEntry(
				LanguageEntries.ROASTED_MEAT_DESCRIPTION,
				"Seit Beginn der Zivilisation ist gebratenes Fleisch eine Nahrungsquelle für den Menschen."
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_MEAT_NAME,
				"Gebratenes Alien-Fleisch"
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_MEAT_DESCRIPTION,
				"Auch wenn es ein seltsames Fleisch ist, ein Barbecue ist ein Barbecue."
			);
			AddEntry(
				LanguageEntries.CEREALBAR_NAME,
				"Müsliriegel"
			);
			AddEntry(
				LanguageEntries.CEREALBAR_DESCRIPTION,
				"Ein Riegel aus Getreide, einfach und leicht herzustellen."
			);
			AddEntry(
				LanguageEntries.WATERBREAD_NAME,
				"Wasserbrot"
			);
			AddEntry(
				LanguageEntries.WATERBREAD_DESCRIPTION,
				"Eines der ältesten vom Menschen entwickelten Gewürze."
			);
			AddEntry(
				LanguageEntries.BREAD_NAME,
				"Brot"
			);
			AddEntry(
				LanguageEntries.BREAD_DESCRIPTION,
				"Ein Milchbrot, weich und lecker."
			);
			AddEntry(
				LanguageEntries.ALIEN_BREAD_NAME,
				"Außerirdisches Brot"
			);
			AddEntry(
				LanguageEntries.ALIEN_BREAD_DESCRIPTION,
				"Ein Milchbrot mit Alien-Eiern ist trotz der seltsamen Farbe weich und lecker."
			);
			AddEntry(
				LanguageEntries.PASTA_NAME,
				"Nudelteig"
			);
			AddEntry(
				LanguageEntries.PASTA_DESCRIPTION,
				"Ein guter Nudelteig, der mit anderen Gewürzen gekocht werden kann."
			);
			AddEntry(
				LanguageEntries.ALIEN_PASTA_NAME,
				"Außerirdischer Nudelteig"
			);
			AddEntry(
				LanguageEntries.ALIEN_PASTA_DESCRIPTION,
				"Ein guter Nudelteig mit außerirdischen Eiern, der mit anderen Gewürzen gekocht werden kann."
			);
			AddEntry(
				LanguageEntries.VEGETABLEPASTA_NAME,
				"Gemüsepasta"
			);
			AddEntry(
				LanguageEntries.VEGETABLEPASTA_DESCRIPTION,
				"Eine leckere Pasta mit Tomaten und Brokkoli."
			);
			AddEntry(
				LanguageEntries.VEGETABLEALIENPASTA_NAME,
				"Außerirdischer Gemüsepasta"
			);
			AddEntry(
				LanguageEntries.VEGETABLEALIENPASTA_DESCRIPTION,
				"Eine köstliche Pasta mit außerirdischen Eiern mit Tomaten und Brokkoli."
			);
			AddEntry(
				LanguageEntries.MEATPASTA_NAME,
				"Fleischnudeln"
			);
			AddEntry(
				LanguageEntries.MEATPASTA_DESCRIPTION,
				"Eine leckere Pasta mit Tomaten und Fleisch."
			);
			AddEntry(
				LanguageEntries.ALIENMEATPASTA_NAME,
				"Außerirdischer Fleischnudeln"
			);
			AddEntry(
				LanguageEntries.ALIENMEATPASTA_DESCRIPTION,
				"Eine köstliche Pasta aus Alien-Eiern mit Tomaten und Alien-Fleisch."
			);
			AddEntry(
				LanguageEntries.CHEESE_NAME,
				"Käse"
			);
			AddEntry(
				LanguageEntries.CHEESE_DESCRIPTION,
				"Käse ist ein festes Lebensmittel aus Milch."
			);
			AddEntry(
				LanguageEntries.SALAD_NAME,
				"Salat"
			);
			AddEntry(
				LanguageEntries.SALAD_DESCRIPTION,
				"Gehacktes und desinfiziertes Gemüse, eine leichte und frische Mahlzeit."
			);
			AddEntry(
				LanguageEntries.VEGETABLE_SOUP_BOWL_NAME,
				"Gemüsesuppe"
			);
			AddEntry(
				LanguageEntries.VEGETABLE_SOUP_BOWL_DESCRIPTION,
				"Suppe ist nahrhaft und kann den Körper leicht erwärmen."
			);
			AddEntry(
				LanguageEntries.STEW_NAME,
				"Eintopf"
			);
			AddEntry(
				LanguageEntries.STEW_DESCRIPTION,
				"Ein guter Rindfleischeintopf."
			);
			AddEntry(
				LanguageEntries.ALIEN_STEW_NAME,
				"Außerirdischer Eintopf"
			);
			AddEntry(
				LanguageEntries.ALIEN_STEW_DESCRIPTION,
				"Ein guter Außerirdischer Rindfleischeintopf."
			);
			AddEntry(
				LanguageEntries.MEAT_VEGETABLES_NAME,
				"Fleisch mit Gemüse"
			);
			AddEntry(
				LanguageEntries.MEAT_VEGETABLES_DESCRIPTION,
				"Schmackhaftes Fleisch, serviert mit gut gekochtem Gemüse."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_VEGETABLES_NAME,
				"Außerirdischer Fleisch mit Gemüse"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_VEGETABLES_DESCRIPTION,
				"Schmackhaftes Außerirdischer Fleisch, serviert mit gut gekochtem Gemüse."
			);
			AddEntry(
				LanguageEntries.MEATLOAF_NAME,
				"Hackbraten"
			);
			AddEntry(
				LanguageEntries.MEATLOAF_DESCRIPTION,
				"Ein leckerer Hackbraten."
			);
			AddEntry(
				LanguageEntries.ALIENMEATLOAF_NAME,
				"Außerirdischer Hackbraten"
			);
			AddEntry(
				LanguageEntries.ALIENMEATLOAF_DESCRIPTION,
				"Ein leckerer Außerirdischer Hackbraten."
			);
			AddEntry(
				LanguageEntries.MEAT_SOUP_BOWL_NAME,
				"Fleischsuppe"
			);
			AddEntry(
				LanguageEntries.MEAT_SOUP_BOWL_DESCRIPTION,
				"Der Geschmack des Fleisches macht die Suppe schmackhafter."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_SOUP_BOWL_NAME,
				"Außerirdischer Fleischsuppe"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_SOUP_BOWL_DESCRIPTION,
				"Der Geschmack des außerirdischen Fleisches macht die Suppe schmackhafter."
			);
			AddEntry(
				LanguageEntries.MUSHROOMPATE_BOWL_NAME,
				"Pilz-Pastete"
			);
			AddEntry(
				LanguageEntries.MUSHROOMPATE_BOWL_DESCRIPTION,
				"Eine Pastete mit Pilzen."
			);
			AddEntry(
				LanguageEntries.MEAT_MUSHROOMS_NAME,
				"Fleisch mit Pilzen"
			);
			AddEntry(
				LanguageEntries.MEAT_MUSHROOMS_DESCRIPTION,
				"Leckeres Fleisch mit sautierten Pilzen."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_MUSHROOMS_NAME,
				"Außerirdischer Fleisch mit Pilzen"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_MUSHROOMS_DESCRIPTION,
				"Leckeres Alienfleisch mit sautierten Pilzen."
			);
			AddEntry(
				LanguageEntries.SANDWICH_NAME,
				"Wurst-Sandwich"
			);
			AddEntry(
				LanguageEntries.SANDWICH_DESCRIPTION,
				"Geschnittenes Wurstsandwich mit Käse und Tomate."
			);
			AddEntry(
				LanguageEntries.ALIEN_SANDWICH_NAME,
				"Außerirdischer Wurst-Sandwich"
			);
			AddEntry(
				LanguageEntries.ALIEN_SANDWICH_DESCRIPTION,
				"Geschnittenes ausländisches Wurstsandwich mit Käse und Tomate."
			);
			AddEntry(
				LanguageEntries.ROASTEDSHRIMP_NAME,
				"Gebratene Garnelen"
			);
			AddEntry(
				LanguageEntries.ROASTEDSHRIMP_DESCRIPTION,
				"Gebratene Garnelen sind sehr lecker."
			);
			AddEntry(
				LanguageEntries.ROASTEDFISH_NAME,
				"Gebratener Fisch"
			);
			AddEntry(
				LanguageEntries.ROASTEDFISH_DESCRIPTION,
				"Ein gut gebratenes Fischfleisch."
			);
			AddEntry(
				LanguageEntries.ROASTEDNOBLEFISH_NAME,
				"Edelfisch braten"
			);
			AddEntry(
				LanguageEntries.ROASTEDNOBLEFISH_DESCRIPTION,
				"Ein gut gebratenes edles Fischfleisch."
			);
			AddEntry(
				LanguageEntries.FISHMUSHROOM_NAME,
				"Fisch mit Pilzen"
			);
			AddEntry(
				LanguageEntries.FISHMUSHROOM_DESCRIPTION,
				"Leckerer Fisch mit sautierten Pilzen."
			);
			AddEntry(
				LanguageEntries.FISHSOUPBOWL_NAME,
				"Fischsuppe"
			);
			AddEntry(
				LanguageEntries.FISHSOUPBOWL_DESCRIPTION,
				"Das Aroma des edlen Fischfleisches macht die Suppe schmackhafter."
			);
			AddEntry(
				LanguageEntries.SHRIMPSOUPBOWL_NAME,
				"Schrimpsuppe"
			);
			AddEntry(
				LanguageEntries.SHRIMPSOUPBOWL_DESCRIPTION,
				"Der Geschmack der Garnelen mit Fischfleisch macht die Suppe schmackhafter."
			);
			AddEntry(
				LanguageEntries.APPLEPIE_NAME,
				"Apfelkuchen"
			);
			AddEntry(
				LanguageEntries.APPLEPIE_DESCRIPTION,
				"Ein Kuchen mit Äpfeln."
			);
			AddEntry(
				LanguageEntries.ALIEN_APPLEPIE_NAME,
				"Außerirdischer Apfelkuchen"
			);
			AddEntry(
				LanguageEntries.ALIEN_APPLEPIE_DESCRIPTION,
				"Ein Kuchen mit Äpfeln und außerirdischen Eiern im Teig."
			);
			AddEntry(
				LanguageEntries.CHICKENPIE_NAME,
				"Hühnerpastete"
			);
			AddEntry(
				LanguageEntries.CHICKENPIE_DESCRIPTION,
				"Ein Kuchen mit Hühnchen und Speck."
			);
			AddEntry(
				LanguageEntries.ALIEN_CHICKENPIE_NAME,
				"Außerirdischer Hühnerkuchen"
			);
			AddEntry(
				LanguageEntries.ALIEN_CHICKENPIE_DESCRIPTION,
				"Ein Kuchen mit Hühnchen und Speck und außerirdischen Eiern im Teig."
			);
			AddEntry(
				LanguageEntries.FATPORRIDGE_NAME,
				"Fetter Brei"
			);
			AddEntry(
				LanguageEntries.FATPORRIDGE_DESCRIPTION,
				"Brei aus konzentriertem Fett, eine großartige Möglichkeit, um an Gewicht zuzunehmen."
			);
			AddEntry(
				LanguageEntries.PROTEINBAR_NAME,
				"Proteinriegel"
			);
			AddEntry(
				LanguageEntries.PROTEINBAR_DESCRIPTION,
				"Ein mit viel Protein angereicherter Müsliriegel."
			);
			AddEntry(
				LanguageEntries.VITAMINPILLS_NAME,
				"Vitamin Pillen"
			);
			AddEntry(
				LanguageEntries.VITAMINPILLS_DESCRIPTION,
				"Vitaminersatzpillen."
			);
			AddEntry(
				LanguageEntries.TOFU_NAME,
				"Tofu"
			);
			AddEntry(
				LanguageEntries.TOFU_DESCRIPTION,
				"Ein Haufen organischer Substanz, gereinigt und zu einer Art Käse verarbeitet."
			);
			AddEntry(
				LanguageEntries.MRE_NAME,
				"MRE – Notration"
			);
			AddEntry(
				LanguageEntries.MRE_DESCRIPTION,
				"Eine Nahrungsquelle, die Ihr Leben retten kann, Sie aber Ihrer Würde beraubt."
			);
			AddEntry(
				LanguageEntries.TOMATOTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Vitamin aus Tomate"
			);
			AddEntry(
				LanguageEntries.APPLETOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Vitamin aus Apfel"
			);
			AddEntry(
				LanguageEntries.ALIENEGGTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus außerirdischem Ei"
			);
			AddEntry(
				LanguageEntries.EGGTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Ei"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Garnelenfleisch"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Garnelenfleisch"
			);
			AddEntry(
				LanguageEntries.FISHMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Fischfleisch"
			);
			AddEntry(
				LanguageEntries.FISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Fischfleisch"
			);
			AddEntry(
				LanguageEntries.ALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus außerirdischem Fleisch"
			);
			AddEntry(
				LanguageEntries.ALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus außerirdischem Fleisch"
			);
			AddEntry(
				LanguageEntries.MEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Fleisch"
			);
			AddEntry(
				LanguageEntries.MEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Fleisch"
			);
			AddEntry(
				LanguageEntries.CHICKENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Hühnerfleisch"
			);
			AddEntry(
				LanguageEntries.CHICKENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Hühnerfleisch"
			);
			AddEntry(
				LanguageEntries.MILKTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Milch"
			);
			AddEntry(
				LanguageEntries.MILKTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Milch"
			);
			AddEntry(
				LanguageEntries.BACONTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Speck"
			);
			AddEntry(
				LanguageEntries.BACONTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Speck"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus edlem Fischfleisch"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus edlem Fischfleisch"
			);
			AddEntry(
				LanguageEntries.NOBLEALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus Alien Noble Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus Alien Noble Meat"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Konzentriertes Protein aus edlem Fleisch"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Konzentriertes Fett aus edlem Fleisch"
			);
			#region FoodDefinition
			AddEntry(
				LanguageEntries.FOODDEFINITION_DESCRIPTION,
				"Flüssig: {0}L" + Environment.NewLine +
				"Solide: {1}Kg" + Environment.NewLine +
				"Magen: {2}%" + Environment.NewLine + Environment.NewLine +
				"Eiweiß: {3}g" + Environment.NewLine +
				"Kohlenhydrat: {4}g" + Environment.NewLine +
				"Lipide: {5}g" + Environment.NewLine +
				"Vitamine: {6}g" + Environment.NewLine +
				"Mineralien: {7}g" + Environment.NewLine +
				"Kalorien: {8}Cal" + Environment.NewLine + Environment.NewLine +
				"Verdauungszeit: {9}s"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_ROTTING_DESCRIPTION,
				"Verrottungszeit: {0}s"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_EFFECT_INSTANT_DESCRIPTION,
				"{1} {0} sofort"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_EFFECT_OVERTIME_DESCRIPTION,
				"{1} {0} über {2}s"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_DISEASECHANCE_DESCRIPTION,
				"{0} kann, beim Essen {1} zu bekommen"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_CUREDISEASE_DESCRIPTION,
				"Kann {0} beim Essen heilen"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_REDUCEDISEASE_DESCRIPTION,
				"Kann {0} um {1} reduzieren"
			);
			AddEntry(
				LanguageEntries.FOODDEFINITION_MUSHROOMS_DESCRIPTION,
				"Pilze können vermehrt werden, indem man Dünger und " + Environment.NewLine +
				"Eis auf Farmen zusammenstellt." + Environment.NewLine +
				"Sonnenlicht brauchen: {0}" + Environment.NewLine +
				"Lieblingsdünger: {1}"
			);
			#endregion
			#endregion
			#region HERBS
			AddEntry(
				LanguageEntries.ARNICA_NAME,
				"Arnika"
			);
			AddEntry(
				LanguageEntries.ARNICA_DESCRIPTION,
				"Arnika ist eine seltene gemeinsame Blume und hat entzündungshemmende und " + Environment.NewLine +
				"antibiotische Anwendungen."
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_NAME,
				"Kamille"
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_DESCRIPTION,
				"Kamille ist eine sehr verbreitete Blume und wirkt beruhigend und " + Environment.NewLine +
				"verdauungsfördernd."
			);
			AddEntry(
				LanguageEntries.ALOEVERA_NAME,
				"Aloe Vera"
			);
			AddEntry(
				LanguageEntries.ALOEVERA_DESCRIPTION,
				"Aloe Vera ist ein Kraut und hat eine breite Anwendung in der Medizin."
			);
			AddEntry(
				LanguageEntries.MINT_NAME,
				"Minze"
			);
			AddEntry(
				LanguageEntries.MINT_DESCRIPTION,
				"Minze ist ein weit verbreitetes Kraut und hat eine erfrischende und " + Environment.NewLine +
				"verdauungsfördernde Wirkung."
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_NAME,
				"Erythroxylum"
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_DESCRIPTION,
				"Erythroxylum ist ein weit verbreitetes Kraut mit betäubender Wirkung."
			);
			#endregion
			#region INGOTS
			AddEntry(
				LanguageEntries.BONEMEAL_NAME,
				"Knochenmehl"
			);
			AddEntry(
				LanguageEntries.BONEMEAL_DESCRIPTION,
				"Knochenmehl ist eine Mischung aus fein und grob gemahlenen " + Environment.NewLine +
				"Tierknochen und Schlachtabfällen."
			);
			#endregion
			#region LIVESTOCK
			AddEntry(
				LanguageEntries.COWMALE_NAME,
				"Ochse"
			);
			AddEntry(
				LanguageEntries.COWMALE_DESCRIPTION,
				"Es ist ein männliches Rind und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.COWFEMALE_NAME,
				"Kuh"
			);
			AddEntry(
				LanguageEntries.COWFEMALE_DESCRIPTION,
				"Es ist ein weibliches Rind und kann für die Zucht, Milchproduktion " + Environment.NewLine +
				"oder Schlachtung verwendet werden."
			);
			AddEntry(
				LanguageEntries.COWBABY_NAME,
				"Kalb"
			);
			AddEntry(
				LanguageEntries.COWBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen Tier " + Environment.NewLine +
				"heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.DEERMALE_NAME,
				"Männlicher Hirsch"
			);
			AddEntry(
				LanguageEntries.DEERMALE_DESCRIPTION,
				"Es ist ein männlicher Hirsch und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.DEERFEMALE_NAME,
				"Weibliches Reh"
			);
			AddEntry(
				LanguageEntries.DEERFEMALE_DESCRIPTION,
				"Es ist ein weiblicher Hirsch und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.DEERBABY_NAME,
				"Hirschkalb"
			);
			AddEntry(
				LanguageEntries.DEERBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen Tier " + Environment.NewLine +
				"heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.HORSEMALE_NAME,
				"Männliches Pferd"
			);
			AddEntry(
				LanguageEntries.HORSEMALE_DESCRIPTION,
				"Es ist ein männliches Pferd und kann für die Zucht oder Schlachtung " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.HORSEFEMALE_NAME,
				"Weibliches Pferd"
			);
			AddEntry(
				LanguageEntries.HORSEFEMALE_DESCRIPTION,
				"Es ist ein weibliches Pferd und kann zur Zucht oder Schlachtung " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.HORSEBABY_NAME,
				"Pferdekalb"
			);
			AddEntry(
				LanguageEntries.HORSEBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen Tier " + Environment.NewLine +
				"heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.SHEEPMALE_NAME,
				"Männliche Schafe"
			);
			AddEntry(
				LanguageEntries.SHEEPMALE_DESCRIPTION,
				"Es ist ein männliches Schaf und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.SHEEPFEMALE_NAME,
				"Weibliche Schafe"
			);
			AddEntry(
				LanguageEntries.SHEEPFEMALE_DESCRIPTION,
				"Es ist ein weibliches Schaf und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.SHEEPBABY_NAME,
				"Schaf Kalb"
			);
			AddEntry(
				LanguageEntries.SHEEPBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen " + Environment.NewLine +
				"Tier heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.SPIDERMALE_NAME,
				"Männliche Spinne"
			);
			AddEntry(
				LanguageEntries.SPIDERMALE_DESCRIPTION,
				"Es ist eine männliche Spinne und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.SPIDERFEMALE_NAME,
				"Weibliche Spinne"
			);
			AddEntry(
				LanguageEntries.SPIDERFEMALE_DESCRIPTION,
				"Es ist eine weibliche Spinne und kann für die Zucht, Eierproduktion " + Environment.NewLine +
				"oder Schlachtung verwendet werden."
			);
			AddEntry(
				LanguageEntries.SPIDERBABY_NAME,
				"Spinnenkalb"
			);
			AddEntry(
				LanguageEntries.SPIDERBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen Tier " + Environment.NewLine +
				"heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.WOLFMALE_NAME,
				"Männlicher Wolf"
			);
			AddEntry(
				LanguageEntries.WOLFMALE_DESCRIPTION,
				"Es ist ein männlicher Wolf und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.WOLFFEMALE_NAME,
				"Weiblicher Wolf"
			);
			AddEntry(
				LanguageEntries.WOLFFEMALE_DESCRIPTION,
				"Es ist ein weiblicher Wolf und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.WOLFBABY_NAME,
				"Wolfjungen"
			);
			AddEntry(
				LanguageEntries.WOLFBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen Tier " + Environment.NewLine +
				"heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.COWDEAD_NAME,
				"Tote Kuh"
			);
			AddEntry(
				LanguageEntries.COWDEAD_DESCRIPTION,
				"Ein Kuhkadaver."
			);
			AddEntry(
				LanguageEntries.DEERDEAD_NAME,
				"Totes Reh"
			);
			AddEntry(
				LanguageEntries.DEERDEAD_DESCRIPTION,
				"Ein Hirschkadaver."
			);
			AddEntry(
				LanguageEntries.HORSEDEAD_NAME,
				"Totes Pferd"
			);
			AddEntry(
				LanguageEntries.HORSEDEAD_DESCRIPTION,
				"Ein Pferdekadaver."
			);
			AddEntry(
				LanguageEntries.SHEEPDEAD_NAME,
				"Tote Schafe"
			);
			AddEntry(
				LanguageEntries.SHEEPDEAD_DESCRIPTION,
				"Ein Schafkadaver."
			);
			AddEntry(
				LanguageEntries.SPIDERDEAD_NAME,
				"Tote Spinne"
			);
			AddEntry(
				LanguageEntries.SPIDERDEAD_DESCRIPTION,
				"Ein Spinnenkadaver."
			);
			AddEntry(
				LanguageEntries.WOLFDEAD_NAME,
				"Toter Wolf"
			);
			AddEntry(
				LanguageEntries.WOLFDEAD_DESCRIPTION,
				"Ein Wolfskadaver."
			);
			AddEntry(
				LanguageEntries.COWBABYDEAD_NAME,
				"Totes Kalb"
			);
			AddEntry(
				LanguageEntries.COWBABYDEAD_DESCRIPTION,
				"Ein Kalbskadaver."
			);
			AddEntry(
				LanguageEntries.DEERBABYDEAD_NAME,
				"Totes Hirschkalb"
			);
			AddEntry(
				LanguageEntries.DEERBABYDEAD_DESCRIPTION,
				"Ein Hirschkalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.HORSEBABYDEAD_NAME,
				"Totes Pferdekalb"
			);
			AddEntry(
				LanguageEntries.HORSEBABYDEAD_DESCRIPTION,
				"Ein Pferdekalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.SHEEPBABYDEAD_NAME,
				"Totes Schaf Kalb"
			);
			AddEntry(
				LanguageEntries.SHEEPBABYDEAD_DESCRIPTION,
				"Ein Schaf Kalb Kadaver."
			);
			AddEntry(
				LanguageEntries.SPIDERBABYDEAD_NAME,
				"Totes Spinnenkalb"
			);
			AddEntry(
				LanguageEntries.SPIDERBABYDEAD_DESCRIPTION,
				"Ein Spinnenkalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.WOLFBABYDEAD_NAME,
				"Totes Wolfskalb"
			);
			AddEntry(
				LanguageEntries.WOLFBABYDEAD_DESCRIPTION,
				"Ein Wolfskalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.PIGBABYDEAD_NAME,
				"Totes Schweinekalb"
			);
			AddEntry(
				LanguageEntries.PIGBABYDEAD_DESCRIPTION,
				"Ein Schweinekalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.CHICKENBABYDEAD_NAME,
				"Totes Hühnerkalb"
			);
			AddEntry(
				LanguageEntries.CHICKENBABYDEAD_DESCRIPTION,
				"Ein Hühnerkalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.PIGDEAD_NAME,
				"Totes Schwein"
			);
			AddEntry(
				LanguageEntries.PIGDEAD_DESCRIPTION,
				"Ein Schweinekalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.CHICKENDEAD_NAME,
				"Totes Huhn"
			);
			AddEntry(
				LanguageEntries.CHICKENDEAD_DESCRIPTION,
				"Ein Hühnerkalb-Kadaver."
			);
			AddEntry(
				LanguageEntries.PIGMALE_NAME,
				"Männliches Schwein"
			);
			AddEntry(
				LanguageEntries.PIGMALE_DESCRIPTION,
				"Es ist ein männliches Schwein und kann zur Zucht oder zum " + Environment.NewLine +
				"Schlachten verwendet werden."
			);
			AddEntry(
				LanguageEntries.PIGFEMALE_NAME,
				"Weibliches Schwein"
			);
			AddEntry(
				LanguageEntries.PIGFEMALE_DESCRIPTION,
				"Es ist ein weibliches Schwein und kann zur Zucht oder zum " + Environment.NewLine +
				"Schlachten verwendet werden."
			);
			AddEntry(
				LanguageEntries.PIGBABY_NAME,
				"Schwein Kalb"
			);
			AddEntry(
				LanguageEntries.PIGBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen " + Environment.NewLine +
				"Tier heranwächst oder zum Schlachten verwendet werden kann."
			);
			AddEntry(
				LanguageEntries.CHICKENMALE_NAME,
				"Männliches Huhn"
			);
			AddEntry(
				LanguageEntries.CHICKENMALE_DESCRIPTION,
				"Es ist ein männliches Huhn und kann zur Zucht oder zum Schlachten " + Environment.NewLine +
				"verwendet werden."
			);
			AddEntry(
				LanguageEntries.CHICKENFEMALE_NAME,
				"Weibliches Huhn"
			);
			AddEntry(
				LanguageEntries.CHICKENFEMALE_DESCRIPTION,
				"Es ist ein weibliches Huhn und kann für die Zucht, Eierproduktion " + Environment.NewLine +
				"oder Schlachtung verwendet werden."
			);
			AddEntry(
				LanguageEntries.CHICKENBABY_NAME,
				"Hühnerkalb"
			);
			AddEntry(
				LanguageEntries.CHICKENBABY_DESCRIPTION,
				"Es ist ein Kalb, das nach der Fütterung zu einem erwachsenen Tier " + Environment.NewLine +
				"heranwächst oder zum Schlachten verwendet werden kann."
			);
			#region LivestockDefinition
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_HERBIVOROUS_DESCRIPTION,
				"Dies ist ein pflanzenfressendes Tier und kann sich von pflanzlichem " + Environment.NewLine +
				"Futter ernähren."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_CARNIVOROUS_DESCRIPTION,
				"Dies ist ein fleischfressendes Tier und kann sich von fleischbasiertem " + Environment.NewLine +
				"Futter ernähren."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_BIRD_DESCRIPTION,
				"Dies ist ein Vogel und kann sich von Getreidefutter ernähren."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_CARCASS_DESCRIPTION,
				"Hinweis: Ein Tierkadaver verrottet mit der Zeit, um das Fleisch nicht " + Environment.NewLine +
				"zu verlieren, kann er in einem Schlachthof verarbeitet werden." + Environment.NewLine +
				"Verrottungszeit: {0}s"
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_DESCRIPTION,
				"Hinweis: Ein Tier muss in einen Käfig gesetzt werden und entsprechend " + Environment.NewLine +
				"seiner Ernährung regelmäßig Rationen im Inventar des Blocks erhalten."
			);
			AddEntry(
				LanguageEntries.LIVESTOCK_BUTCHERY_DESCRIPTION,
				"Metzgerei {0}"
			);
			AddEntry(
				LanguageEntries.LIVESTOCK_SLAUGHTER_DESCRIPTION,
				"Schlachten {0}"
			);
			#endregion
			#endregion
			#region MEDICAL
			AddEntry(
				LanguageEntries.BANDAGES_NAME,
				"Einfache Bandagen"
			);
			AddEntry(
				LanguageEntries.BANDAGES_DESCRIPTION,
				"Einfache Bandagen, die für die Erste Hilfe verwendet werden " + Environment.NewLine +
				"können."
			);
			AddEntry(
				LanguageEntries.POWER_BANDAGES_NAME,
				"Kraftbandagen"
			);
			AddEntry(
				LanguageEntries.POWER_BANDAGES_DESCRIPTION,
				"Einfache Bandagen, die für die Erste Hilfe verwendet werden " + Environment.NewLine +
				"können."
			);
			AddEntry(
				LanguageEntries.HEALTH_BUSTER_NAME,
				"Beschleuniger und Heilung"
			);
			AddEntry(
				LanguageEntries.HEALTH_BUSTER_DESCRIPTION,
				"Ein starkes Injektionsmittel, das eine spontane Regeneration im " + Environment.NewLine +
				"Körper bewirkt."
			);
			AddEntry(
				LanguageEntries.MEDKIT_NAME,
				"Erste-Hilfe-Set"
			);
			AddEntry(
				LanguageEntries.MEDKIT_DESCRIPTION,
				"Ein injizierbares Mittel, das sogar Knochen regenerieren kann."
			);
			AddEntry(
				LanguageEntries.HEALTHINJECTION_NAME,
				"Gesundheitsspritze"
			);
			AddEntry(
				LanguageEntries.HEALTHINJECTION_DESCRIPTION,
				"Ein starkes injizierbares Mittel, das Infektionen und Krankheiten " + Environment.NewLine +
				"heilen und Müdigkeit reduzieren kann."
			);
			AddEntry(
				LanguageEntries.HEALTHPOWERINJECTION_NAME,
				"Starke Gesundheitsinjektion"
			);
			AddEntry(
				LanguageEntries.HEALTHPOWERINJECTION_DESCRIPTION,
				"Ein sehr starkes Injektionsmittel, das eine spontane Regeneration " + Environment.NewLine +
				"im Körper bewirkt."
			);
			AddEntry(
				LanguageEntries.SIMPLEMEDICINE_NAME,
				"Einfache Medizin"
			);
			AddEntry(
				LanguageEntries.SIMPLEMEDICINE_DESCRIPTION,
				"Ein nützliches Mittel bei Verdauungsproblemen oder leichten Schmerzen."
			);
			AddEntry(
				LanguageEntries.MEDICINE_NAME,
				"Medizin"
			);
			AddEntry(
				LanguageEntries.MEDICINE_DESCRIPTION,
				"Ein nützliches Mittel gegen Gifte und kleinere Verletzungen."
			);
            AddEntry(
                LanguageEntries.SIMPLEDETOXIFYING_NAME,
                "Einfache Entgiftung"
            );
            AddEntry(
                LanguageEntries.DETOXIFYING_NAME,
                "Entgiftend"
            );
            AddEntry(
                LanguageEntries.ADVANCEDDETOXIFYING_NAME,
                "Fortgeschrittene Entgiftung"
            );
            AddEntry(
                LanguageEntries.DETOXIFYING_DESCRIPTION,
                "Entgiftung ist ein vorbeugendes Medikament. Vor der Exposition gegenüber " + Environment.NewLine +
                "giftigen Umgebungen einnehmen."
            );
            AddEntry(
                LanguageEntries.SIMPLERADX_NAME,
                "Einfaches Rad-X"
            );
            AddEntry(
                LanguageEntries.RADX_NAME,
                "Rad-X"
            );
            AddEntry(
                LanguageEntries.ADVANCEDRADX_NAME,
                "Fortgeschrittene Rad-X"
            );
            AddEntry(
                LanguageEntries.RADX_DESCRIPTION,
                "Rad-X ist ein vorbeugendes Medikament. Nehmen Sie Rad-X ein, bevor Sie " + Environment.NewLine +
                "Strahlungsumgebungen ausgesetzt werden."
            );
            #endregion
            #region ORES
            AddEntry(
				LanguageEntries.BONES_NAME,
				"Knochen"
			);
			AddEntry(
				LanguageEntries.BONES_DESCRIPTION,
				"Ein Knochen ist ein starres Organ, das bei den meisten Wirbeltieren Teil " + Environment.NewLine +
				"des Skeletts ist."
			);
			AddEntry(
				LanguageEntries.FISH_BONES_NAME,
				"Gräten"
			);
			AddEntry(
				LanguageEntries.FISH_BONES_DESCRIPTION,
				"Ein Knochen ist ein starres Organ, das bei den meisten Wirbeltieren Teil " + Environment.NewLine +
				"des Skeletts ist."
			);
			AddEntry(
				LanguageEntries.POOP_NAME,
				"Kacke"
			);
			AddEntry(
				LanguageEntries.POOP_DESCRIPTION,
				"Die festen oder halbfesten Reste der Nahrung, die im Dünndarm nicht verdaut " + Environment.NewLine +
				"werden konnten."
			);
			AddEntry(
				LanguageEntries.WHEAT_NAME,
				"Weizen"
			);
			AddEntry(
				LanguageEntries.WHEAT_DESCRIPTION,
				"Weizenkorn ist ein Grundnahrungsmittel, aus dem Mehl und damit Brot hergestellt " + Environment.NewLine +
				"wird."
			);
			AddEntry(
				LanguageEntries.COFFEE_NAME,
				"Kaffee"
			);
			AddEntry(
				LanguageEntries.COFFEE_DESCRIPTION,
				"Kaffee ist ein Stimulans, da er Koffein enthält, kann er eine Alternative sein, " + Environment.NewLine +
				"um die Körperwärme an kalten Orten aufrechtzuerhalten."
			);
			AddEntry(
				LanguageEntries.THERMALFLUID_NAME,
				"Thermoflüssigkeit"
			);
			AddEntry(
				LanguageEntries.THERMALFLUID_DESCRIPTION,
				"Thermoflüssigkeit ist eine Chemikalie, die in einem Wärmekreislauf in" + Environment.NewLine +
				"Kühl- und Klimaanlagen verwendet wird."
			);
			#endregion
			#region QUIMICALS
			AddEntry(
				LanguageEntries.PROPOFOL_NAME,
				"Propofol"
			);
			AddEntry(
				LanguageEntries.PROPOFOL_DESCRIPTION,
				"Propofol ist ein kurz wirkendes Medikament, das zu einer Bewusstseinsminderung führt."
			);
			AddEntry(
				LanguageEntries.LIDOCAINE_NAME,
				"Lidocain"
			);
			AddEntry(
				LanguageEntries.LIDOCAINE_DESCRIPTION,
				"Lidocain ist ein langsam wirkendes Medikament, das zu einem verminderten " + Environment.NewLine +
				"Bewusstseinsgrad führt."
			);
			AddEntry(
				LanguageEntries.SMALLALOEVERAEXTRACT_NAME,
				"Kleiner Aloe Vera Extrakt"
			);
			AddEntry(
				LanguageEntries.SMALLALOEVERAEXTRACT_DESCRIPTION,
				"Aloe Vera Extrakt hat eine breite Anwendung in der Medizin."
			);
			AddEntry(
				LanguageEntries.ALOEVERAEXTRACT_NAME,
				"Aloe Vera Extrakt"
			);
			AddEntry(
				LanguageEntries.ALOEVERAEXTRACT_DESCRIPTION,
				"Aloe Vera Extrakt hat eine breite Anwendung in der Medizin."
			);
			AddEntry(
				LanguageEntries.ARNICAEXTRACT_NAME,
				"Arnika-Extrakt"
			);
			AddEntry(
				LanguageEntries.ARNICAEXTRACT_DESCRIPTION,
				"Arnika-Extrakt hat entzündungshemmende und antibiotische Anwendungen."
			);
			AddEntry(
				LanguageEntries.MINTEXTRACT_NAME,
				"Minze-Extrakt"
			);
			AddEntry(
				LanguageEntries.MINTEXTRACT_DESCRIPTION,
				"Minzextrakt hat eine erfrischende und verdauungsfördernde Wirkung."
			);
			AddEntry(
				LanguageEntries.CHAMOMILEEXTRACT_NAME,
				"Kamillenextrakt"
			);
			AddEntry(
				LanguageEntries.CHAMOMILEEXTRACT_DESCRIPTION,
				"Kamillenextrakt wirkt beruhigend und verdauungsfördernd."
			);
			AddEntry(
				LanguageEntries.AMATOXINA_NAME,
				"Amatoxina"
			);
			AddEntry(
				LanguageEntries.AMATOXINA_DESCRIPTION,
				"Amatoxina ist eine giftige Verbindung, die in giftigen Pilzen vorkommt."
			);
			#endregion
			#region RATIONS
			AddEntry(
				LanguageEntries.MEATRATION_NAME,
				"Fleischration"
			);
			AddEntry(
				LanguageEntries.MEATRATION_DESCRIPTION,
				"Ein fleischbasiertes Futter, perfekt für fleischfressende Tiere."
			);
			AddEntry(
				LanguageEntries.VEGETABLERATION_NAME,
				"Gemüseration"
			);
			AddEntry(
				LanguageEntries.VEGETABLERATION_DESCRIPTION,
				"Ein pflanzliches Futter, perfekt für pflanzenfressende Tiere."
			);
			AddEntry(
				LanguageEntries.GRAINSRATION_NAME,
				"Körnerration"
			);
			AddEntry(
				LanguageEntries.GRAINSRATION_DESCRIPTION,
				"Ein Futter auf Getreidebasis, perfekt für Vögel."
			);
			AddEntry(
				LanguageEntries.MEATRATION_CONSTRUCTION_NAME,
				"Fleischration"
			);
			AddEntry(
				LanguageEntries.ALIENMEATRATION_CONSTRUCTION_NAME,
				"Außerirdische Fleischration"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATRATION_CONSTRUCTION_NAME,
				"Edle Fleischration"
			);
			AddEntry(
				LanguageEntries.ALIENNOBLEMEATRATION_CONSTRUCTION_NAME,
				"Außerirdische Edle Fleischration"
			);
			AddEntry(
				LanguageEntries.FISHMEATRATION_CONSTRUCTION_NAME,
				"Fischfleischration"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATRATION_CONSTRUCTION_NAME,
				"Edle Fischfleischration"
			);
			AddEntry(
				LanguageEntries.BROCCOLIRATION_CONSTRUCTION_NAME,
				"Brokkoli-Ration"
			);
			AddEntry(
				LanguageEntries.BEETROOTRATION_CONSTRUCTION_NAME,
				"Rote-Bete-Ration"
			);
			AddEntry(
				LanguageEntries.CARROTRATION_CONSTRUCTION_NAME,
				"Karotten-Ration"
			);
			AddEntry(
				LanguageEntries.WHEATRATION_CONSTRUCTION_NAME,
				"Weizenration"
			);
			AddEntry(
				LanguageEntries.CEREALRATION_CONSTRUCTION_NAME,
				"Getreideration"
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.BOWL_NAME,
				"Schüssel"
			);
			AddEntry(
				LanguageEntries.BOWL_DESCRIPTION,
				"Schalen sind Behälter, die hauptsächlich zum Aufbewahren und Zubereiten " + Environment.NewLine +
				"von Speisen verwendet werden."
			);
			AddEntry(
				LanguageEntries.ALUMINUMCAN_NAME,
				"Aluminiumdosen"
			);
			AddEntry(
				LanguageEntries.ALUMINUMCAN_DESCRIPTION,
				"Aluminiumdosen werden verwendet, um Getränke sicher aufzubewahren, ohne " + Environment.NewLine +
				"Fäulnis zu riskieren."
			);
			AddEntry(
				LanguageEntries.BOWLOFWOOD_CONSTRUCTION_NAME,
				"Schale aus Holz"
			);
			AddEntry(
				LanguageEntries.BOWLOFGLASS_CONSTRUCTION_NAME,
				"Schüssel Glas"
			);
			AddEntry(
				 LanguageEntries.SMALLALUMINUMCANISTER_NAME,
				 "Kleiner Aluminiumkanister"
			 );
			AddEntry(
				LanguageEntries.SMALLALUMINUMCANISTER_DESCRIPTION,
				"Zur sicheren Aufbewahrung von Flüssigkeiten werden kleine" + Environment.NewLine +
				"Aluminiumkanister verwendet."
			);
			#endregion
			#region SEEDS
			AddEntry(
				LanguageEntries.ARNICA_SEEDS_NAME,
				"Arnika-Samen"
			);
			AddEntry(
				LanguageEntries.ARNICA_SEEDS_DESCRIPTION,
				"Arnikasamen können mit Dünger und Eis auf Farmen angebaut werden."
			);
			AddEntry(
				LanguageEntries.BEETROOT_SEEDS_NAME,
				"Rote-Bete-Samen"
			);
			AddEntry(
				LanguageEntries.BEETROOT_SEEDS_DESCRIPTION,
				"Rote-Bete-Samen können mit Dünger und Eis auf Farmen angebaut werden."
			);
			AddEntry(
				LanguageEntries.BROCCOLI_SEEDS_NAME,
				"Brokkoli-Samen"
			);
			AddEntry(
				LanguageEntries.BROCCOLI_SEEDS_DESCRIPTION,
				"Brokkolisamen können auf Farmen mit Dünger und Eis angebaut werden."
			);
			AddEntry(
				LanguageEntries.CARROT_SEEDS_NAME,
				"Karottensamen"
			);
			AddEntry(
				LanguageEntries.CARROT_SEEDS_DESCRIPTION,
				"Karottensamen können auf Farmen mit Dünger und Eis angebaut werden."
			);
			AddEntry(
				LanguageEntries.COFFEE_SEEDS_NAME,
				"Kaffeesamen"
			);
			AddEntry(
				LanguageEntries.COFFEE_SEEDS_DESCRIPTION,
				"Kaffeesamen können mit Dünger und Eis auf Farmen angebaut werden."
			);
			AddEntry(
				LanguageEntries.MINT_SEEDS_NAME,
				"Minzsamen"
			);
			AddEntry(
				LanguageEntries.MINT_SEEDS_DESCRIPTION,
				"Minzsamen können mit Dünger und Eis auf Farmen angebaut werden."
			);
			AddEntry(
				LanguageEntries.TOMATO_SEEDS_NAME,
				"Tomatensamen"
			);
			AddEntry(
				LanguageEntries.TOMATO_SEEDS_DESCRIPTION,
				"Tomatensamen können mit Dünger und Eis auf Farmen angebaut werden."
			);
			AddEntry(
				LanguageEntries.WHEAT_SEEDS_NAME,
				"Weizensamen"
			);
			AddEntry(
				LanguageEntries.WHEAT_SEEDS_DESCRIPTION,
				"Weizensamen können mit Dünger und Eis auf Farmen angebaut werden."
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_SEEDS_NAME,
				"Kamillensamen"
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_SEEDS_DESCRIPTION,
				"Kamillensamen können auf Farmen mit Dünger und Eis angebaut werden."
			);
			AddEntry(
				LanguageEntries.ALOEVERA_SEEDS_NAME,
				"Aloevera-Samen"
			);
			AddEntry(
				LanguageEntries.ALOEVERA_SEEDS_DESCRIPTION,
				"Aloevera-Samen können auf Farmen mit Dünger und Eis angebaut werden."
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_SEEDS_NAME,
				"Erythroxylum-Samen"
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_SEEDS_DESCRIPTION,
				"Erythroxylum-Samen können auf Farmen mit Dünger und Eis angebaut werden."
			);
            AddEntry(
                LanguageEntries.AMANITAMUSCARIA_SEEDS_NAME,
                "Amanita Muscaria-Samen"
            );
            AddEntry(
                LanguageEntries.AMANITAMUSCARIA_SEEDS_DESCRIPTION,
                "Amanita Muscaria-Samen können auf Bauernhöfen mit Dünger und Eis angebaut " + Environment.NewLine +
                "werden."
            );
            AddEntry(
                LanguageEntries.CHAMPIGNONS_SEEDS_NAME,
                "Champignonsamen"
            );
            AddEntry(
                LanguageEntries.CHAMPIGNONS_SEEDS_DESCRIPTION,
                "Champignonsamen können auf Bauernhöfen mit Dünger und Eis angebaut werden."
            );
            AddEntry(
                LanguageEntries.SHIITAKE_SEEDS_NAME,
                "Shiitake-Samen"
            );
            AddEntry(
                LanguageEntries.SHIITAKE_SEEDS_DESCRIPTION,
                "Shiitake-Samen können auf Bauernhöfen mit Dünger und Eis angebaut werden."
            );
            #region SeedDefinition
            AddEntry(
				LanguageEntries.SEEDDEFINITION_DESCRIPTION,
				"Sonnenlicht brauchen: {0}" + Environment.NewLine +
				"Lieblingsdünger: {1}"
			);
			#endregion
			#endregion
			#region FERTILIZERS
			AddEntry(
				LanguageEntries.FERTILIZER_NAME,
				"Organischer Dünger"
			);
			AddEntry(
				LanguageEntries.FERTILIZER_DESCRIPTION,
				"Dünger aus organischem Material."
			);
			AddEntry(
				LanguageEntries.MINERALFERTILIZER_NAME,
				"Mineraldünger"
			);
			AddEntry(
				LanguageEntries.MINERALFERTILIZER_DESCRIPTION,
				"Dünger aus mineralischen Stoffen."
			);
			AddEntry(
				LanguageEntries.SUPERFERTILIZER_NAME,
				"Super Dünger"
			);
			AddEntry(
				LanguageEntries.SUPERFERTILIZER_DESCRIPTION,
				"Mischung aus mineralischen und organischen Düngemitteln, " + Environment.NewLine +
				"kann mit allen Saaten effizient eingesetzt werden."
			);
			AddEntry(
				LanguageEntries.BONEFERTILIZER_CONSTRUCTION_NAME,
				"Organischer Dünger aus Knochenmehl"
			);
			AddEntry(
				LanguageEntries.POOPFERTILIZER_CONSTRUCTION_NAME,
				"Organischer Dünger von Poop"
			);
			AddEntry(
				LanguageEntries.SPOILEDMATERIALFERTILIZER_CONSTRUCTION_NAME,
				"Organischer Dünger aus organischem Material"
			);
			AddEntry(
				LanguageEntries.MAGNESIUMFERTILIZER_CONSTRUCTION_NAME,
				"Mineraldünger aus Magnesium"
			);
			AddEntry(
				LanguageEntries.POTASSIUMFERTILIZER_CONSTRUCTION_NAME,
				"Mineraldünger aus Kalium"
			);
			AddEntry(
				LanguageEntries.FERTILIZER_CONSTRUCTION_NAME,
				"Mineraldünger aus Schwefel"
			);
			#region FertilizerDefinition
			AddEntry(
				LanguageEntries.FERTILIZERDEFINITION_POWER_DESCRIPTION,
				"Bietet bei Verwendung einen Produktionsmultiplikator von {0}%." + Environment.NewLine +
				"Es ist mit allen Pflanzen kompatibel."
			);
			AddEntry(
				LanguageEntries.FERTILIZERDEFINITION_DESCRIPTION,
				"Bietet einen Produktionsmultiplikator von {0}%, wenn es " + Environment.NewLine +
				"mit kompatiblen Pflanzen verwendet wird." + Environment.NewLine +
				"Es ist kompatibel mit:"
			);
			#endregion
			#endregion
			#region TREES
			AddEntry(
				LanguageEntries.TREEDEAD_NAME,
				"Toter Baum"
			);
			AddEntry(
				LanguageEntries.TREEDEAD_DESCRIPTION,
				"Ein toter Baum kann in einer Mühle zu Holz verarbeitet werden."
			);
			AddEntry(
				LanguageEntries.APPLETREESEEDLING_NAME,
				"Apfelbaum-Sämling"
			);
			AddEntry(
				LanguageEntries.APPLETREESEEDLING_DESCRIPTION,
				"Kann zu einem Apfelbaum heranwachsen, wenn er mit Dünger und " + Environment.NewLine +
				"Eis in einer Baumfarm platziert wird."
			);
			AddEntry(
				LanguageEntries.APPLETREE_NAME,
				"Apfelbaum"
			);
			AddEntry(
				LanguageEntries.APPLETREE_DESCRIPTION,
				"Kann Äpfel und Setzlinge erzeugen, wenn sie mit Dünger und Eis " + Environment.NewLine +
				"in einer Baumfarm platziert werden, kann auch in einer Mühle zu " + Environment.NewLine +
				"Holz verarbeitet werden."
			);
			AddEntry(
				LanguageEntries.TREEDEAD_DESCONSTRUCTION_NAME,
				"Holzscheite vom toten Baum"
			);
			AddEntry(
				LanguageEntries.APPLETREE_DESCONSTRUCTION_NAME,
				"Holzscheite vom Apfelbaum"
			);
			#region TreeDefinition
			AddEntry(
				LanguageEntries.TREEDEFINITION_DESCRIPTION,
				"Sonnenlicht brauchen: {0}" + Environment.NewLine +
				"Lieblingsdünger: {1}"
			);
			#endregion
			#endregion
			#region WEAPONS
			AddEntry(
				LanguageEntries.PROPOFOLDART_NAME,
				"Propofol Pfeil"
			);
			AddEntry(
				LanguageEntries.PROPOFOLDART_DESCRIPTION,
				"Ein auf Propofol basierender Beruhigungspfeil."
			);
			AddEntry(
				LanguageEntries.LIDOCAINDART_NAME,
				"Lidocain Pfeil"
			);
			AddEntry(
				LanguageEntries.LIDOCAINDART_DESCRIPTION,
				"Ein auf Lidocain basierender Beruhigungspfeil."
			);
			AddEntry(
				LanguageEntries.BBBULLET_NAME,
				"BB-6mm Patrone"
			);
			AddEntry(
				LanguageEntries.BBBULLET_DESCRIPTION,
				"Eine 6-mm-Eisen-Pellet-Kugel."
			);
			AddEntry(
				LanguageEntries.PISTOL_PROPOFOL_MAGZINE_NAME,
				"Pistole DRT-Propofol Magazin"
			);
			AddEntry(
				LanguageEntries.PISTOL_PROPOFOL_MAGZINE_DESCRIPTION,
				"Ein Pistolenclip mit Propofol-Beruhigungspfeilen."
			);
			AddEntry(
				LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_NAME,
				"Pistole DRT-Lidocain Magazin"
			);
			AddEntry(
				LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_DESCRIPTION,
				"Ein Pistolenclip mit Lidocain-Beruhigungspfeilen."
			);
			AddEntry(
				LanguageEntries.PISTOL_BB_MAGZINE_NAME,
				"Pistole BB-6mm Magazin"
			);
			AddEntry(
				LanguageEntries.PISTOL_BB_MAGZINE_DESCRIPTION,
				"Ein Pistolenclip mit 6-mm-Eisen-Pelletgeschossen."
			);
			AddEntry(
				LanguageEntries.LIDOCAINPISTOLITEM_NAME,
				"Pistole DRT-Lidocain"
			);
			AddEntry(
				LanguageEntries.LIDOCAINPISTOLITEM_DESCRIPTION,
				"Eine Waffe für die Jagd auf Tiere mit Lidocain-Betäubungspfeilen."
			);
			AddEntry(
				LanguageEntries.PROPOFOLPISTOLITEM_NAME,
				"Pistole DRT-Propofol"
			);
			AddEntry(
				LanguageEntries.PROPOFOLPISTOLITEM_DESCRIPTION,
				"Eine Waffe für die Jagd auf Tiere mit Propofol-Betäubungspfeilen."
			);
			AddEntry(
				LanguageEntries.BBPISTOLITEM_NAME,
				"Pistole BB-6mm"
			);
			AddEntry(
				LanguageEntries.BBPISTOLITEM_DESCRIPTION,
				"Eine Waffe für die Jagd auf Tiere mit 6-mm-Eisen-Pelletgeschossen."
			);
			#endregion
			#region STATS
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_FLU_NAME,
				"Grippe"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_PNEUMONIA_NAME,
				"Lungenentzündung"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_DYSENTERY_NAME,
				"Ruhr"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_POISON_NAME,
				"Gift"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_INFECTED_NAME,
				"Infiziert"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPOTHERMIA_NAME,
				"Unterkühlung"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPERTHERMIA_NAME,
				"Hyperthermie"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_STARVATION_NAME,
				"Hungersnot"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVERESTARVATION_NAME,
				"Schwere Hungersnot"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_DEHYDRATION_NAME,
				"Austrocknung"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVEREDEHYDRATION_NAME,
				"Schwere Austrocknung"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_OBESITY_NAME,
				"Fettleibigkeit"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVEREOBESITY_NAME,
				"Schwere Fettleibigkeit"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_RICKETS_NAME,
				"Rachitis"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVERERICKETS_NAME,
				"Schwere Rachitis"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPOLIPIDEMIA_NAME,
				"Hypolipidämie"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_QUEASY_NAME,
				"Mulmig"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_POOPONCLOTHES_NAME,
				"Auf Kleidung kacken"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_PEEONCLOTHES_NAME,
				"Auf Kleidung pinkeln"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_OVERHEATING_NAME,
				"Überhitzung"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_ONFIRE_NAME,
				"In Brand geraten"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_COLD_NAME,
				"Kalt"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_FROSTY_NAME,
				"Eisig"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_WET_NAME,
				"Nass"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOCOLD_NAME,
				"Kalt ausgesetzt"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOFREEZE_NAME,
				"Frost ausgesetzt"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOHOT_NAME,
				"Hitze ausgesetzt"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOBOILING_NAME,
				"Sieden ausgesetzt"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RECOVERINGFROMEXPOSURE_NAME,
				"Erholung von der Exposition"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOCOLD_NAME,
				"Geringere Kältebeständigkeit"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOCOLD_NAME,
				"Kältebeständigkeit"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOCOLD_NAME,
				"Höhere Kältebeständigkeit"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOHOT_NAME,
				"Geringere Hitzebeständigkeit"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOHOT_NAME,
				"Hitzebeständigkeit"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOHOT_NAME,
				"Höhere Hitzebeständigkeit"
			);
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_INTOXICATED_NAME,
                "Berauscht"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_VERYINTOXICATED_NAME,
                "Sehr betrunken"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOTOXICITY_NAME,
                "Toxizität ausgesetzt"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOEXTREMETOXICITY_NAME,
                "Extremer Toxizität ausgesetzt"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_RADIATIONSICK_NAME,
                "Strahlenkrank"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_RADIATIONPOISONING_NAME,
                "Strahlenvergiftung"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTORADIOACTIVITY_NAME,
                "Radioaktivität ausgesetzt"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOEXTREMERADIOACTIVITY_NAME,
                "Extremer Radioaktivität ausgesetzt"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOTOXICITY_NAME,
                "Geringere Resistenz gegen Toxizität"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOTOXICITY_NAME,
                "Beständigkeit gegen Toxizität"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOTOXICITY_NAME,
                "Größere Resistenz gegen Toxizität"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETORADIOACTIVITY_NAME,
                "Geringere Beständigkeit gegen Radioaktivität"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETORADIOACTIVITY_NAME,
                "Beständigkeit gegen Radioaktivität"
            );
            AddEntry(
                LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETORADIOACTIVITY_NAME,
                "Höhere Beständigkeit gegen Radioaktivität"
            );
            AddEntry(
				LanguageEntries.DAMAGEEFFECTS_CONTUSION_NAME,
				"Prellung"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_WOUNDED_NAME,
				"Verwundet"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_DEEPWOUNDED_NAME,
				"Tief verwundet"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_BROKENBONES_NAME,
				"Gebrochene Knochen"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_HUNGRY_NAME,
				"Hungrig"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FAMISHED_NAME,
				"Ausgehungert"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_THIRSTY_NAME,
				"Durstig"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_DEHYDRATING_NAME,
				"Austrocknen"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_DISORIENTED_NAME,
				"Desorientiert"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_SUFFOCATION_NAME,
				"Erstickung"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLSTOMACH_NAME,
				"Voller Bauch"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_STOMACHBURSTING_NAME,
				"Magen platzt"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLGUT_NAME,
				"Voller Darm"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_GUTBURST_NAME,
				"Darm platzen"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLBLADDER_NAME,
				"Volle Blase"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_BLADDERBURST_NAME,
				"Blasenplatzen"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_TIRED_NAME,
				"Müde"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_EXTREMELYTIRED_NAME,
				"Extrem müde"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_STOMACHGROWLING_NAME,
				"Abschluss der Verdauung"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_EMPTYSTOMACH_NAME,
				"Leerer Magen"
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL0_NAME,
				"Ich fühle mich gut und gesund."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL1_NAME,
				"Mir geht es nicht sehr gut."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL2_NAME,
				"Mit mir stimmt etwas nicht."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL3_NAME,
				"Ich muss etwas tun, bevor es zu spät ist."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL4_NAME,
				"Ich brauche Hilfe, ich glaube, ich sterbe."
			);
			AddEntry(
				LanguageEntries.FEELING_INFO_NAME,
				"Bekannte Effekte:"
			);
			AddEntry(
				LanguageEntries.BOILING_NAME,
				"Sieden"
			);
			AddEntry(
				LanguageEntries.TOOHOT_NAME,
				"Zu heiß"
			);
			AddEntry(
				LanguageEntries.WARMINGUP_NAME,
				"Aufwärmen"
			);
			AddEntry(
				LanguageEntries.FREEZING_NAME,
				"Einfrieren"
			);
			AddEntry(
				LanguageEntries.VERYCOLD_NAME,
				"Sehr kalt"
			);
			AddEntry(
				LanguageEntries.COOLINGDOWN_NAME,
				"Abkühlung"
			);
			AddEntry(
				LanguageEntries.STABLE_NAME,
				"Stabil"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_WETLEVEL_NAME,
				"Nasses Niveau"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_UNTREATEDWOUND_NAME,
				"Unbehandelte Wunde"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_TOXICEXPOSURE_NAME,
				"Toxische Exposition"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_RADIOACTIVEEXPOSURE_NAME,
				"Radioaktive Exposition"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_COMPLETELYWET_NAME,
				"Völlig nass"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_COMPLETELYDRY_NAME,
				"Völlig trocken"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_INFECTED_NAME,
				"Infiziert"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_NOINJURIES_NAME,
				"Keine Verletzungen"
			);
			AddEntry(
				LanguageEntries.HUNGER_NAME,
				"Hunger"
			);
			AddEntry(
				LanguageEntries.THIRST_NAME,
				"Durst"
			);
			AddEntry(
				LanguageEntries.STAMINA_NAME,
				"Ausdauer"
			);
			AddEntry(
				LanguageEntries.FATIGUE_NAME,
				"Ermüdung"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_NAME,
				"Überlebenseffekte"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_NAME,
				"Schadenseffekte"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_NAME,
				"Temperatureffekte"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_NAME,
				"Krankheitseffekte"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_NAME,
				"Andere Effekte"
			);
			AddEntry(
				LanguageEntries.WOUNDEDTIME_NAME,
				"Verwundete Zeit"
			);
			AddEntry(
				LanguageEntries.TEMPERATURETIME_NAME,
				"Temperatur Zeit"
			);
			AddEntry(
				LanguageEntries.WETTIME_NAME,
				"Nasse Zeit"
			);
			AddEntry(
				LanguageEntries.BODYENERGY_NAME,
				"Energie"
			);
			AddEntry(
				LanguageEntries.BODYWATER_NAME,
				"Wasser"
			);
			AddEntry(
				LanguageEntries.BODYPERFORMANCE_NAME,
				"Effizienz"
			);
			AddEntry(
				LanguageEntries.BODYIMMUNE_NAME,
				"Immunität"
			);
			AddEntry(
				LanguageEntries.STOMACH_NAME,
				"Magen"
			);
			AddEntry(
				LanguageEntries.INTESTINE_NAME,
				"Darm"
			);
			AddEntry(
				LanguageEntries.BLADDER_NAME,
				"Blase"
			);
			AddEntry(
				LanguageEntries.BODYWEIGHT_NAME,
				"Gewicht"
			);
			AddEntry(
				LanguageEntries.BODYMUSCLES_NAME,
				"Muskeln"
			);
			AddEntry(
				LanguageEntries.BODYFAT_NAME,
				"Fett"
			);
			AddEntry(
				LanguageEntries.FOODDETECTOR_NAME,
				"Lebensmittel-Detektor"
			);
			AddEntry(
				LanguageEntries.MEDICALDETECTOR_NAME,
				"Medizinischer Detektor"
			);
			AddEntry(
				LanguageEntries.BODYCALORIES_NAME,
				"Kalorien"
			);
			AddEntry(
				LanguageEntries.TORPOR_NAME,
				"Erstarrung"
			);
			AddEntry(
				LanguageEntries.BODYPROTEIN_NAME,
				"Eiweiß"
			);
			AddEntry(
				LanguageEntries.BODYCARBOHYDRATE_NAME,
				"Kohlenhydrat"
			);
			AddEntry(
				LanguageEntries.BODYLIPIDS_NAME,
				"Lipide"
			);
			AddEntry(
				LanguageEntries.BODYMINERALS_NAME,
				"Mineralien"
			);
			AddEntry(
				LanguageEntries.BODYVITAMINS_NAME,
				"Vitamine"
			);
			AddEntry(
				LanguageEntries.INTOXICATIONTIME_NAME,
				"Rauschpegel"
			);
			AddEntry(
				LanguageEntries.RADIATIONTIME_NAME,
				"Radioaktivitätsniveau"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALFLUID_NAME,
				"Kalte Thermoflüssigkeit"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALFLUID_NAME,
				"Heiße Thermoflüssigkeit"
			);
			AddEntry(
				LanguageEntries.ENERGYSHIELD_NAME,
				"Energieschild"
			);
			AddEntry(
				LanguageEntries.BODYMUSCLESWEIGHT_NAME,
				"Muskelgewicht"
			);
			AddEntry(
				LanguageEntries.BODYFATWEIGHT_NAME,
				"Fettgewicht"
			);
            AddEntry(
                LanguageEntries.STAMINAAMOUNT_NAME,
                "Maximale Ausdauer"
            );
            AddEntry(
                LanguageEntries.HEALTHVALUEMODIFIER_REGENERATIONFACTOR_NAME,
                "Regenerationsfaktor"
            );
            AddEntry(
                LanguageEntries.HEALTHVALUEMODIFIER_MAXIMUMREGENERATIONHEALTH_NAME,
                "Maximale Regenerationsgesundheit"
            );
            AddEntry(
                LanguageEntries.HEALTHVALUEMODIFIER_MAXHEALTH_NAME,
                "Maximale Gesundheit"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_HIGHERSTAMINAEXPENDITURE_NAME,
                "Höhere Ausdauerausgaben"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_MAXIMUMSTAMINAREDUCTION_NAME,
                "Maximale Ausdauerreduzierung"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_LONGERSTAMINARECHARGETIME_NAME,
                "Längere Wiederaufladezeit der Ausdauer"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_STAMINAREGENERATION_NAME,
                "Ausdauerregeneration"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_MAXIMUMSTAMINABONUS_NAME,
                "Maximaler Ausdauerbonus"
            );
            AddEntry(
                LanguageEntries.METABOLISMVALUEMODIFIER_WATERCONSUMPTION_NAME,
                "Wasserverbrauch"
            );
            AddEntry(
                LanguageEntries.METABOLISMVALUEMODIFIER_ENERGYCONSUMPTION_NAME,
                "Energieverbrauch"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_INCREASEDFATIGUE_NAME,
                "Erhöhte Müdigkeit"
            );
            #endregion
            #region Food Effects
            AddEntry(
                LanguageEntries.FOODEFFECTS_FRESHFRUIT_NAME,
                "Frisches Obst"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_RAWVEGETABLE_NAME,
                "Rohes Gemüse"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_WILDMUSHROOM_NAME,
                "Wilder Pilz"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_POISONMUSHROOM_NAME,
                "Giftpilz"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_JUICYRED_NAME,
                "Saftiges Rot"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_STRAIGHTFROMTHECOW_NAME,
                "Direkt von der Kuh"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_RAWMEAT_NAME,
                "Rohes Fleisch"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_VISCOUSANDDELICIOUS_NAME,
                "Viskos und köstlich"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_GLUBGLUB_NAME,
                "Glub! Glub!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_REFRESHINGJUICE_NAME,
                "Erfrischender Saft"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_BUBBLY_NAME,
                "Sprudelnd!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_EYESOPEN_NAME,
                "Geöffnete Augen"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_MARIOSPARTY_NAME,
                "Marios Party"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_BREAKINGTHESHELL_NAME,
                "Die Schale brechen"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_BREAKFASTOFCHAMPIONS_NAME,
                "Frühstück der Champions"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_POPOPO_NAME,
                "Pó Pó Pó!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_SOOBIG_NAME,
                "Soo... Groß!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_BARBECUE_NAME,
                "Grill"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_TASTYLIKESAWDUST_NAME,
                "Lecker wie Sägemehl"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_BLESSED_NAME,
                "Gesegnet"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_SANCTIFIED_NAME,
                "Geheiligt"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_MAMAMIA_NAME,
                "Mama Mia!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_HOOMAMAMIA_NAME,
                "Hoo... Mama Mia!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_WOWMAMAMIA_NAME,
                "Wow... Mama Mia!"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_SAFEVEGAN_NAME,
                "Sicherer Veganer"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_WINTERPROTECTION_NAME,
                "Winterschutz"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_MOMSFOOD_NAME,
                "Mamas Essen"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_BALANCEDDIET_NAME,
                "Ausgewogene Ernährung"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_SUNDAYFOOD_NAME,
                "Sonntagsessen"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_WINTERISCOMING_NAME,
                "Der Winter kommt"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_GOOMBASEND_NAME,
                "Goombas Ende"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_GOOMBASPROTECTION_NAME,
                "Goombas Schutz"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_MOUSECHOICE_NAME,
                "Mauswahl"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_BESTFRIEND_NAME,
                "Bester Freund"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_SEACOCKROACH_NAME,
                "Meeresschabe"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_CAMPFEELING_NAME,
                "Camp-Feeling"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_EXPLOSIVEJUICINESS_NAME,
                "Explosive Saftigkeit"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_GOOMBASBREATH_NAME,
                "Goombas Atem"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_WINTERBREATH_NAME,
                "Winteratem"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_FINGERLICKING_NAME,
                "Finger lecken"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_MESMERIZINGSMELL_NAME,
                "Faszinierender Geruch"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_TASTYLIKEBUTTER_NAME,
                "Schmeckt wie Butter"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_TASTYLIKEBEEFJERKY_NAME,
                "Lecker wie Trockenfleisch vom Rind"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_IMPROVEDMETABOLISM_NAME,
                "Verbesserter Stoffwechsel"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_TASTYLIKEPOOP_NAME,
                "Lecker wie Kacke"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTSPART2_TASTYLIKECHARCOAL_NAME,
                "Lecker wie Holzkohle"
            );
            #endregion
            #region Weather
            AddEntry(
				LanguageEntries.WEATHEREFFECTSLEVEL_LIGHT_NAME,
				"Leichte"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTSLEVEL_HEAVY_NAME,
				"Starke"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTS_RAIN_NAME,
				"Regen"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTS_THUNDERSTORM_NAME,
				"Sturm"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_ATMOSPHERE_NAME,
				"Atmosphäre"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_SHIPORSTATION_NAME,
				"Druck"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_SPACE_NAME,
				"Raum"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_UNDERWATER_NAME,
				"Unterwasser"
			);
            AddEntry(
                LanguageEntries.ENVIRONMENTDETECTOR_NOTPRESSURIZEDROOM_NAME,
                "Nicht unter Druck stehender Raum"
            );
            AddEntry(
				LanguageEntries.UI_ENVIROMENT_DISPLAY,
				"Umfeld: "
			);
			AddEntry(
				LanguageEntries.UI_WEATHER_DISPLAY,
				"Wetter: "
			);
            AddEntry(
                LanguageEntries.UI_EXTERNALTEMP_DISPLAY,
                "Extern"
            );
            AddEntry(
                LanguageEntries.UI_SAFETEMPERATURE_DISPLAY,
                "Sicher"
            );
            AddEntry(
                LanguageEntries.UI_EXTERNALEXPOSE_DISPLAY,
                "Exposition: "
            );
            AddEntry(
                LanguageEntries.UI_TOXIC_DISPLAY,
                "[Toxizität: {0}]"
            );
            AddEntry(
                LanguageEntries.UI_RADIATION_DISPLAY,
                "[Strahlung: {0}]"
            );
            #endregion
            #region Armors
            AddEntry(
				LanguageEntries.SCAVENGERARMOR_NAME,
				"Plündererrüstung"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMOR_DESCRIPTION,
				"Ein sehr verbreitetes Rüstungsmodell für diejenigen, die" + Environment.NewLine +
				"nicht über viele Ressourcen verfügen und zusätzlichen Schutz" + Environment.NewLine +
				"benötigen."
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMORLIGHT_NAME,
				"Plündererrüstung [Leicht]"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMORHEAVY_NAME,
				"Plündererrüstung [Verstärkt]"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMOREXPANDED_NAME,
				"Plündererrüstung [Erweitert]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOR_NAME,
				"Jägerrüstung"
			);
            AddEntry(
                LanguageEntries.SCAVENGERHELMET_NAME,
                "Scavenger-Helm"
            );
            AddEntry(
                LanguageEntries.SCAVENGERHELMETLIGHT_NAME,
                "Scavenger-Helm [Leicht]"
            );
            AddEntry(
                LanguageEntries.SCAVENGERHELMETHEAVY_NAME,
                "Scavenger-Helm [Verstärkt]"
            );
            AddEntry(
                LanguageEntries.SCAVENGERHELMETEXPANDED_NAME,
                "Scavenger-Helm [Erweitert]"
            );
            AddEntry(
                LanguageEntries.SCAVENGERHELMET_DESCRIPTION,
                "Ein sehr verbreitetes Helmmodell für diejenigen, die nicht über viele" + Environment.NewLine +
                "Ressourcen verfügen und zusätzlichen Schutz benötigen."
            );
            AddEntry(
                LanguageEntries.HUNTERHELMET_NAME,
                "Jägerhelm"
            );
            AddEntry(
                LanguageEntries.HUNTERHELMETLIGHT_NAME,
                "Jägerhelm [Leicht]"
            );
            AddEntry(
                LanguageEntries.HUNTERHELMETHEAVY_NAME,
                "Jägerhelm [Verstärkt]"
            );
            AddEntry(
                LanguageEntries.HUNTERHELMETEXPANDED_NAME,
                "Jägerhelm [Erweitert]"
            );
            AddEntry(
                LanguageEntries.HUNTERHELMET_DESCRIPTION,
                "Ein sehr effektiver Helm für erfahrene Jäger."
            );
            AddEntry(
				LanguageEntries.HUNTERARMOR_DESCRIPTION,
				"Eine sehr effektive Rüstung für erfahrene Jäger."
			);
			AddEntry(
				LanguageEntries.HUNTERARMORLIGHT_NAME,
				"Jägerrüstung [Leicht]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMORHEAVY_NAME,
				"Jägerrüstung [Verstärkt]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOREXPANDED_NAME,
				"Jägerrüstung [Erweitert]"
			);
			AddEntry(
				LanguageEntries.ARMOR_DESCRIPTION,
				"Hinweis: Um Rüstungsboni zu erhalten, müssen Sie diese über " + Environment.NewLine +
				"die Ausrüstungsschnittstelle ausrüsten lassen."
			);
			AddEntry(
				LanguageEntries.ARMORLIGHT_DESCRIPTION,
				"Leichte Rüstungen haben weniger Verteidigungspunkte, dafür" + Environment.NewLine +
				"aber weniger Volumen und einen geringeren Ausdaueraufwand."
			);
			AddEntry(
				LanguageEntries.ARMORHEAVY_DESCRIPTION,
				"Verstärkte Rüstungen verfügen über mehr Verteidigungspunkte," + Environment.NewLine +
				"haben aber ein größeres Volumen und einen höheren " + Environment.NewLine +
				"Ausdaueraufwand."
			);
			AddEntry(
				LanguageEntries.ARMOREXPANDED_DESCRIPTION,
				"Erweiterte Panzerung verfügt über mehr Modulsteckplätze, hat" + Environment.NewLine +
				"aber ein höheres Volumen, eine geringere Verteidigung und einen" + Environment.NewLine +
				"höheren Ausdaueraufwand."
			);
			AddEntry(
				LanguageEntries.ARMORCATEGORY_WORK_NAME,
				"Arbeiten"
			);
			AddEntry(
				LanguageEntries.ARMORCATEGORY_COMBAT_NAME,
				"Kampf"
			);
			AddEntry(
				LanguageEntries.ARMORDESC_CATEGORY_ENTRY,
				"Kategorie:"
			);
			AddEntry(
				LanguageEntries.ARMORDESC_MODULES_ENTRY,
				"Gesamtzahl der Module: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_STAMINA_ENTRY,
				"Ausdauerkosten: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_RESISTENCE_ENTRY,
				"{0} {1} resistenz."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_EFFECT_ENTRY,
				"{0} bei {1}."
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_GATHERING_NAME,
				"Sammeln"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_CARGOLOAD_NAME,
				"Frachtladung"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_MOVEMENTSPEED_NAME,
				"Bewegungsgeschwindigkeit"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_CREATUREDAMAGE_NAME,
				"Schaden an Kreaturen"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_TORPORBONUS_NAME,
				"Erstarrungsbonus"
			);
            AddEntry(
                LanguageEntries.ARMOREFFECT_HANDWEAPONDAMAGE_NAME,
                "Handwaffenschaden"
            );
            AddEntry(
                LanguageEntries.ARMOREFFECT_SHOOTINGACCURACY_NAME,
                "Schussgenauigkeit"
            );
            AddEntry(
				LanguageEntries.ARMORDESC_UI_EQUIPED,
				"Rüstung ausgerüstet: {0} [{1} Leere Module]."
			);
            AddEntry(
                LanguageEntries.HELMETDESC_UI_EQUIPED,
                "Helm ausgerüstet: {0} [{1} Leere Module]."
            );
            AddEntry(
				LanguageEntries.ARMORDESC_UI_SHIELD_EQUIPED,
				"Schild ausgerüstet [{0} Max. Punkte]."
			);
            AddEntry(
                LanguageEntries.BODYTRACKER_UI_EQUIPED,
                "Bodytracker ausgestattet. [Stufe: {0}]"
            );
            AddEntry(
                LanguageEntries.BODYTRACKER_UI_NOEQUIPED,
                "Achtung: Body Tracker nicht ausgestattet! [Eingeschränkte Informationsanzeige]"
            );
            AddEntry(
                LanguageEntries.TOTAL_EFFECT_UID,
                "Angewendete Effekte:"
            );
            AddEntry(
                LanguageEntries.TOTAL_POSITIVE_EFFECT_UID,
                " [Positiv: {0}]"
            );
            AddEntry(
                LanguageEntries.TOTAL_NEGATIVE_EFFECT_UID,
                " [Negativ: {0}]"
            );
            AddEntry(
                LanguageEntries.TOTAL_NOTTRACKED_EFFECT_UID,
                " [Nicht verfolgt: {0}]"
            );
            AddEntry(
                LanguageEntries.NO_EFFECT_UID,
                "Keine Effekte angewendet!"
            );
            #endregion
            #region Armor Modules
            AddEntry(
				LanguageEntries.COLDTHERMALREGULATOR_NAME,
				"Kalter Thermoregler"
			);
			AddEntry(
				LanguageEntries.ENHANCEDCOLDTHERMALREGULATOR_NAME,
				"Verbesserter Kalter Thermoregler"
			);
			AddEntry(
				LanguageEntries.PROFICIENTCOLDTHERMALREGULATOR_NAME,
				"Kompetenter Kalter Thermoregler"
			);
			AddEntry(
				LanguageEntries.ELITECOLDTHERMALREGULATOR_NAME,
				"Elite Kalter Thermoregler"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION,
				"Wird verwendet, um die Temperatur des Anzugs in extrem kalten" + Environment.NewLine +
				"Umgebungen aufrechtzuerhalten und verbraucht dabei" + Environment.NewLine +
				"Thermoflüssigkeit."
			);
			AddEntry(
				LanguageEntries.HOTTHERMALREGULATOR_NAME,
				"Heißer Thermoregler"
			);
			AddEntry(
				LanguageEntries.ENHANCEDHOTTHERMALREGULATOR_NAME,
				"Verbesserter Heißer Thermoregler"
			);
			AddEntry(
				LanguageEntries.PROFICIENTHOTTHERMALREGULATOR_NAME,
				"Kompetenter Heißer Thermoregler"
			);
			AddEntry(
				LanguageEntries.ELITEHOTTHERMALREGULATOR_NAME,
				"Elite Heißer Thermoregler"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION,
				"Wird verwendet, um die Temperatur des Anzugs in extrem heißer" + Environment.NewLine +
				"Umgebungen aufrechtzuerhalten und verbraucht dabei" + Environment.NewLine +
				"Thermoflüssigkeit."
			);
			AddEntry(
				LanguageEntries.SHIELDGENERATOR_NAME,
				"Schildgenerator"
			);
			AddEntry(
				LanguageEntries.SHIELDGENERATOR_DESCRIPTION,
				"Die Verwendung zur Absorption von Stößen, Angriffen und" + Environment.NewLine +
				"Projektilen kann den Unterschied im Überleben ausmachen." + Environment.NewLine +
				"Eine Rüstung kann nur einen Schildgenerator haben, es gibt" + Environment.NewLine +
				"jedoch Schilderweiterungsmodule." + Environment.NewLine +
				"Es dauert eine Verzögerung von {0} Sekunden, bis der Schild" + Environment.NewLine +
				"wieder aufgeladen wird, ohne dass er Schaden erleidet."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDGENERATOR_NAME,
				"Verbesserter Schildgenerator"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDGENERATOR_NAME,
				"Kompetenter Schildgenerator"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDGENERATOR_NAME,
				"Elite-Schildgenerator"
			);
			AddEntry(
				LanguageEntries.SHIELDCAPACITOR_NAME,
				"Schirmkondensator"
			);
			AddEntry(
				LanguageEntries.SHIELDCAPACITOR_DESCRIPTION,
				"Wird verwendet, um die maximale Kapazität und" + Environment.NewLine +
				"Nachladegeschwindigkeit eines Schildes zu erhöhen, erhöht" + Environment.NewLine +
				"jedoch die Energiekosten."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDCAPACITOR_NAME,
				"Verbesserter Abschirmkondensator"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDCAPACITOR_NAME,
				"Kompetenter Abschirmkondensator"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDCAPACITOR_NAME,
				"Elite-Schildkondensator"
			);
			AddEntry(
				LanguageEntries.SHIELDTRANSISTOR_NAME,
				"Schirmtransistor"
			);
			AddEntry(
				LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION,
				"Wird verwendet, um die Energiekosten eines Schildes zu" + Environment.NewLine +
				"senken, aber die Gesamtabklingzeit zu erhöhen."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDTRANSISTOR_NAME,
				"Verbesserter Schirmtransistor"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDTRANSISTOR_NAME,
				"Kompetenter Schirmtransistor"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDTRANSISTOR_NAME,
				"Elite-Schirmtransistor"
			);
			AddEntry(
				LanguageEntries.SHIELDSPIKE_NAME,
				"Schildspitze"
			);
			AddEntry(
				LanguageEntries.SHIELDSPIKE_DESCRIPTION,
				"Wird verwendet, um einen Teil des erlittenen Nahkampfschadens" + Environment.NewLine +
				"an den Angreifer zurückzuerstatten."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDSPIKE_NAME,
				"Verbesserter Schildspitze"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDSPIKE_NAME,
				"Kompetenter Schildspitze"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDSPIKE_NAME,
				"Elite-Schildspitze"
			);
            AddEntry(
                LanguageEntries.TOXICITYFILTER_NAME,
                "Toxizitätsfilter"
            );
            AddEntry(
                LanguageEntries.ENHANCEDTOXICITYFILTER_NAME,
                "Verbesserter Toxizitätsfilter"
            );
            AddEntry(
                LanguageEntries.PROFICIENTTOXICITYFILTER_NAME,
                "Kompetenter Toxizitätsfilter"
            );
            AddEntry(
                LanguageEntries.ELITETOXICITYFILTER_NAME,
                "Elite-Toxizitätsfilter"
            );
            AddEntry(
                LanguageEntries.TOXICITYFILTER_DESCRIPTION,
                "Wird verwendet, um den Anzug in extrem giftigen Umgebungen frei von " + Environment.NewLine +
                "giftigem Material zu halten und dieses Material dabei in einer giftigen " + Environment.NewLine +
                "Filterflasche aufzubewahren."
            );
            AddEntry(
                LanguageEntries.RADIOACTIVITYFILTER_NAME,
                "Radioaktivitätsfilter"
            );
            AddEntry(
                LanguageEntries.ENHANCEDRADIOACTIVITYFILTER_NAME,
                "Verbesserter Radioaktivitätsfilter"
            );
            AddEntry(
                LanguageEntries.PROFICIENTRADIOACTIVITYFILTER_NAME,
                "Kompetenter Radioaktivitätsfilter"
            );
            AddEntry(
                LanguageEntries.ELITERADIOACTIVITYFILTER_NAME,
                "\r\nElite-Radioaktivitätsfilter"
            );
            AddEntry(
                LanguageEntries.RADIOACTIVITYFILTER_DESCRIPTION,
                "Wird verwendet, um den Anzug in extrem radioaktiven Umgebungen frei " + Environment.NewLine +
                "von radioaktivem Material zu halten und dieses Material dabei in einer " + Environment.NewLine +
                "Radioaktivitätsfilterflasche aufzubewahren."
            );
            AddEntry(
				LanguageEntries.ARMORMODULE_DESCRIPTION,
				"Hinweis: Um Boni vom Rüstungsmodul zu erhalten, muss es über die " + Environment.NewLine +
				"Ausrüstungsschnittstelle ausgerüstet werden."
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_EFFICIENCY_NAME,
				"Effizienz"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_CAPACITY_NAME,
				"Kapazität"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_RECHARGESPEED_NAME,
				"Aufladegeschwindigkeit"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTION_NAME,
				"Energieverbrauch"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_CAPACITYBONUS_NAME,
				"Kapazität Bonus"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_RECHARGESPEEDBONUS_NAME,
				"Aufladegeschwindigkeit Bonus"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTIONBONUS_NAME,
				"Energieverbrauch Bonus"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_SPIKEDAMAGE_NAME,
				"Spike-Schaden"
			);
            AddEntry(
                LanguageEntries.AIMASSISTANT_NAME,
                "Zielassistent"
            );
            AddEntry(
                LanguageEntries.ENHANCEDAIMASSISTANT_NAME,
                "Verbesserter Zielassistent"
            );
            AddEntry(
                LanguageEntries.PROFICIENTAIMASSISTANT_NAME,
                "Kompetenter Zielassistent"
            );
            AddEntry(
                LanguageEntries.ELITEAIMASSISTANT_NAME,
                "Elite-Zielassistent"
            );
            AddEntry(
                LanguageEntries.AIMASSISTANT_DESCRIPTION,
                "Der Zielassistent unterstützt Sie dabei, den Ablenkungswinkel des " + Environment.NewLine +
                "Geschosses zu verkleinern."
            );
            #endregion
            #region Damage Types
            AddEntry(
				LanguageEntries.DAMAGETYPE_CREATURE_NAME,
				"Kreatur"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_BULLET_NAME,
				"Kugeln"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_EXPLOSION_NAME,
				"Explosion"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_RADIOACTIVITY_NAME,
				"Radioaktivität"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_FIRE_NAME,
				"Feuer"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_TOXICITY_NAME,
				"Toxizität"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_FALL_NAME,
				"Fallen"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_TOOL_NAME,
				"Werkzeug"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_ENVIRONMENT_NAME,
				"Umwelt"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_OTHER_NAME,
				"Andere"
			);
			#endregion
			#region Equip Slot - System
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_BODYTRACKER_NAME,
				"Bodytracker"
			);
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_BODYARMOR_NAME,
				"Anzugrüstung"
			);
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_ARMORWORKMODULE_NAME,
				"Arbeitsmodul"
			);
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_ARMORCOMBATMODULE_NAME,
				"Kampfmodul"
			);
            AddEntry(
                LanguageEntries.EQUIPABLEITEMCATEGORY_HELMET_NAME,
                "Anzughelm"
            );
            AddEntry(
                LanguageEntries.EQUIPABLEITEMCATEGORY_HELMETWORKMODULE_NAME,
                "Arbeitsmodul"
            );
            AddEntry(
                LanguageEntries.EQUIPABLEITEMCATEGORY_HELMETCOMBATMODULE_NAME,
                "Kampfmodul"
            );
            #endregion


            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_USE_TO_CURE,
                "Ich sollte {0} verwenden, um {1} zu heilen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_STARVATION,
                "Ich sollte etwas essen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_DEHYDRATION,
                "Ich sollte etwas trinken."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_OBESITY,
                "Ich sollte ein paar Übungen machen und mich besser ernähren."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_RICKETS,
                "Ich sollte mich entspannen und kalorienreiche Lebensmittel essen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_HYPOLIPIDEMIA,
                "Ich sollte Sport treiben und mich proteinreich ernähren."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_PEEANDPOOPONCLOTHES,
                "Ich sollte in die Kryotherapie gehen, um mich zu reinigen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_EXPOSEDTOHOT,
                "Ich sollte meine Rüstung mit einem heißen Thermoregler ausstatten."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_EXPOSEDTOCOLD,
                "Ich sollte meine Rüstung mit einem Kälteregler ausstatten."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_WET,
                "Ich sollte eine unter Druck stehende Umgebung betreten."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_EXPOSEDTOTOXICITY,
                "Ich sollte meine Rüstung mit einem Toxizitätsfilter ausstatten."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_EXPOSEDTORADIOACTIVITY,
                "Ich sollte meine Rüstung mit einem Radioaktivitätsfilter ausstatten."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_SUFFOCATION,
                "Ich sollte nach einer Sauerstoffquelle suchen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_TIRED,
                "Ich sollte mich im Kryo oder im Bett etwas ausruhen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_FULLBLADDERORGUT,
                "Ich sollte mich im Kryo oder auf der Toilette erleichtern."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_FULLSTOMACH,
                "Ich sollte eine Weile mit dem Essen aufhören und auf die Verdauung warten."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_STOMACHBURSTING,
                "Ich sollte aufhören zu essen, damit ich mich nicht übergeben muss."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_STOMACHGROWLING,
                "Ich sollte meinen Magen nicht leer werden lassen."
            );
            AddEntry(
                LanguageEntries.FEELINGRESOLUTION_EMPTYSTOMACH,
                "Ich sollte nicht so lange ohne etwas im Magen auskommen."
            );


        }

    }

}
