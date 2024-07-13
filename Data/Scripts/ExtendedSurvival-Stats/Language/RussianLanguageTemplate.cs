using System;
using VRage;

namespace ExtendedSurvival.Stats
{

    public class RussianLanguageTemplate : BaseLanguageTemplate
    {

        public RussianLanguageTemplate() 
            : base(MyLanguagesEnum.Russian)
        {
        }

        protected override void DoLoadEntries()
        {
			#region GENERALS
			AddEntry(
				LanguageEntries.TERMS_YES_NAME,
				"Да"
			);
			AddEntry(
				LanguageEntries.TERMS_NO_NAME,
				"Нет"
			);
			AddEntry(
				LanguageEntries.TERMS_FULL_NAME,
				"Полный"
			);
			AddEntry(
				LanguageEntries.TERMS_EMPTY_NAME,
				"Пусто"
			);
			#endregion
			#region CUBE_BLOCKS
			AddEntry(
				LanguageEntries.CUBEBLOCK_SMALL_CAGE,
				"Малая Клетка"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_LARGE_CAGE,
				"Большая Клетка"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_CAGE_DESCRIPTION,
				"Клетки используются для хранения пойманых животных. " +
				"Когда вы кормите животных, они будут есть, чтобы остаться в живых, и в некоторых " +
				"случаях производить продукты."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_COMPOSTER,
				"Компостер"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_COMPOSTER_DESCRIPTION,
				"Компостеры - это блоки которые увеличивают на {0} скорость " +
				"гниения предметов. Если в инвенторе блока имеются органические материалы, " +
				"то он будет создавать приманки для рыбы через определённый промежуток времени, этот промежуток может варьироваться от " +
				"{1}с до {2}с в зависимости от количества органических материалов." +
				"Потребление энергии варьируется в зависимости от объема инвенторя, " +
				"от {3}kW/h до {4}kW/h."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FARM,
				"Ферма"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FARM_DESCRIPTION,
				"Фермы - это блоки производящие овощи, грибы и травы " +
				"когда семена, лёд и удобрения находятся в инвентаре. " +
				"Стоимость ресурсов увеличивается на {0}% за каждый дополнительный тип семян и время " +
				"гниения уменьшается на {0}% при производстве."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_TREEFARM,
				"Фрма Дерева"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_TREEFARM_DESCRIPTION,
				"Фермы дерева - это блоки которые позволяют выращивать деревья и сохранять их живыми для производства " +
				"фруктов когда в инвентаре имеется лёд и удобрения. " +
				"Время гниения уменьшается на {0}% во время работы."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FISHTRAP,
				"Ловушка для рыбы"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FISHTRAP_DESCRIPTION,
				"Ловушки для рыбы - это блоки способные ловить рыбу потребляя наживку, они должны " +
				"быть погружены под воду и быть подключёнными к погруженным собирателям чтобы работать. " +
				"Периоды рыбалки составляют {0}с, потребление энергии варьируется от {1}kW/h до {2}kW/h."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FOODPROCESSOR,
				"Кухонный Комбайн"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FOODPROCESSOR_BASIC,

				"Базовый Кухонный Комбайн"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FOODPROCESSOR_INDUSTRIAL,
				"Промышленный Кухонный Комбайн"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_FOODPROCESSOR_DESCRIPTION,
				"Кухонные комбайны — это блоки, которые могут готовить пищу. " +
				"Под конец производства, если имеется подключённый холодильник, " +
				"пища автоматически попадёт в него."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE,
				"Скотобойня"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_BASIC,
				"Базовая Скотобойня"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_INDUSTRIAL,
				"Промышленная Скотобойня"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_SLAUGHTERHOUSE_DESCRIPTION,
				"Скотобойни - это блоки которые могут убивать выращеных " +
				"животных и добывать их мясо. Под конец производства, " +
				"если имеется подключённый холодильник, пища автоматически " +
				"попадёт в него."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_SMALL_REFRIGERATOR,
				"Малый Холодильник"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_LARGE_REFRIGERATOR,
				"Большой Холодильник"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_REFRIGERATOR_DESCRIPTION,
				"Холодильники - это блоки хранящие еду от гниения. " +
				"Потребление энергии варьируется в зависимости от объема инвенторя, " +
				"от {0}kW/h до {1}kW/h."
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR,
				"Генератор Термальной Жидкости"
			);
			AddEntry(
				LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR_DESCRIPTION,
				"Генераторы термальной жидкости - это блоки ответственные за пополнение " +
				"баллонов с термальным газом потребляя термальную жидкость."
			);
			#endregion
			#region EQUIPMENTS
			AddEntry(
				LanguageEntries.BODYTRACKER_NAME,
				"Анализатор состояния тела"
			);
			AddEntry(
				LanguageEntries.BODYTRACKER_DESCRIPTION,
				"Устройство,которое отслеживает состояния тела и" + Environment.NewLine +
				"выводит его на дисплей шлема скафандра." + Environment.NewLine +
				"Отслеживает:" + Environment.NewLine +
				"- Уровень влажности;" + Environment.NewLine +
				"- Температуру тела;" + Environment.NewLine +
				"- Базовые негативные эффекты;" + Environment.NewLine + Environment.NewLine +
				"Примечание. Чтобы получать дополнительные бонусы, вам необходимо " + Environment.NewLine +
				"экипировать их через интерфейс оборудования."
			);
			AddEntry(
				LanguageEntries.ENHANCEDBODYTRACKER_NAME,
				"Улучшенный анализатор состояния тела"
			);
			AddEntry(
				LanguageEntries.ENHANCEDBODYTRACKER_DESCRIPTION,
				"Устройство,которое отслеживает состояния тела и" + Environment.NewLine +
				"выводит его на дисплей шлема скафандра." + Environment.NewLine +
				"Отслеживает:" + Environment.NewLine +
				"- Уровень влажности;" + Environment.NewLine +
				"- Температуру тела;" + Environment.NewLine +
				"- Енергетический баланс пользователя;" + Environment.NewLine +
				"- Водный баланс пользователя;" + Environment.NewLine +
				"- Ранения;" + Environment.NewLine +
				"- Отрицательные эффекты среднего уровня и ниже;" + Environment.NewLine + Environment.NewLine +
				"Примечание. Чтобы получать дополнительные бонусы, вам необходимо " + Environment.NewLine +
				"экипировать их через интерфейс оборудования."
			);
			AddEntry(
				LanguageEntries.PROFICIENTBODYTRACKER_NAME,
				"Продвинутый Анализатор состояния тела"
			);
			AddEntry(
				LanguageEntries.PROFICIENTBODYTRACKER_DESCRIPTION,
				"Устройство,которое отслеживает состояния тела и" + Environment.NewLine +
				"выводит его на дисплей шлема скафандра." + Environment.NewLine +
				"Отслеживает:" + Environment.NewLine +
				"- Уровень влажности;" + Environment.NewLine +
				"- Температуру тела;" + Environment.NewLine +
				"- Енергетический баланс организма;" + Environment.NewLine +
				"- Водный баланс организма;" + Environment.NewLine +
				"- Вес тела;" + Environment.NewLine +
				"- Эффективность организма;" + Environment.NewLine +
				"- Выносливость;" + Environment.NewLine +
				"- Ранения;" + Environment.NewLine +
				"- Отрицательные эффекты высокого уровня и ниже;" + Environment.NewLine + Environment.NewLine +
				"Примечание. Чтобы получать дополнительные бонусы, вам необходимо " + Environment.NewLine +
				"экипировать их через интерфейс оборудования."
			);
			AddEntry(
				LanguageEntries.ELITEBODYTRACKER_NAME,
				"Элитный Анализатор состояния тела"
			);
			AddEntry(
				LanguageEntries.ELITEBODYTRACKER_DESCRIPTION,
				"Устройство,которое отслеживает состояния тела и" + Environment.NewLine +
				"выводит его на дисплей шлема скафандра." + Environment.NewLine +
				"Отслеживает:" + Environment.NewLine +
			   "- Уровень влажности;" + Environment.NewLine +
				"- Температуру тела;" + Environment.NewLine +
				"- Енергетический баланс организма;" + Environment.NewLine +
				"- Водный баланс организма;" + Environment.NewLine +
				"- Вес тела;" + Environment.NewLine +
				"- Эффективность организма;" + Environment.NewLine +
				"- Состояние иммунной системы;" + Environment.NewLine +
				"- Мышечную массу;" + Environment.NewLine +
				"- Баланс жиров;" + Environment.NewLine +
				"- Ранения;" + Environment.NewLine +
				"- Все негативные эффекты;" + Environment.NewLine + Environment.NewLine +
				"Примечание. Чтобы получать дополнительные бонусы, вам необходимо " + Environment.NewLine +
				"экипировать их через интерфейс оборудования."
			);
			AddEntry(
				LanguageEntries.COLDTHERMALBOTTLE_NAME,
				"Термальный сосуд с бензолом"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALBOTTLE_DESCRIPTION,
				"Используется нагревающим модулем для регулировки температуры тела" + Environment.NewLine +
				"в экстремально холодных условиях."
			);
			AddEntry(
				LanguageEntries.HOTTHERMALBOTTLE_NAME,
				"Термальный сосуд c азотом"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALBOTTLE_DESCRIPTION,
				"Используется охлаждающим модулем для регулировки температуры тела" + Environment.NewLine +
				"в экстремально горячих условиях."
			);
			#endregion
			#region FISHING
			AddEntry(
				LanguageEntries.FISH_NAME,
				"Рыба"
			);
			AddEntry(
				LanguageEntries.FISH_DESCRIPTION,
				"Рыба в изобилии водится в большинстве водоемов. Её можно найти" + Environment.NewLine +
				"практически во всех водных средах."
			);
			AddEntry(
				LanguageEntries.ALIENFISH_NAME,
				"Инопланетная рыба"
			);
			AddEntry(
				LanguageEntries.ALIENFISH_DESCRIPTION,
				"Рыба в изобилии водится в большинстве водоемов. Её можно найти" + Environment.NewLine +
				"практически во всех водных средах."
			);
			AddEntry(
				LanguageEntries.NOBLEFISH_NAME,
				"Благородная рыба"
			);
			AddEntry(
				LanguageEntries.NOBLEFISH_DESCRIPTION,
				"Благородную рыбу сложнее поймать. Её можно найти в" + Environment.NewLine +
				"более глубоких водах."
			);
			AddEntry(
				LanguageEntries.ALIENNOBLEFISH_NAME,
				"Инопланетная благородная рыба"
			);
			AddEntry(
				LanguageEntries.ALIENNOBLEFISH_DESCRIPTION,
				"Благородную рыбу сложнее поймать. Её можно найти в" + Environment.NewLine +
				"более глубоких водах."
			);
			AddEntry(
				LanguageEntries.SHRIMP_NAME,
				"Креветка"
			);
			AddEntry(
				LanguageEntries.SHRIMP_DESCRIPTION,
				"Креветки - это ракообразные с удлиненным телом и преимущественно" + Environment.NewLine +
				"плавательным способом передвижения."
			);
			AddEntry(
				LanguageEntries.FISH_BAIT_SMALL_NAME,
				"Приманка для рыбы"
			);
			AddEntry(
				LanguageEntries.FISH_BAIT_SMALL_DESCRIPTION,
				"Что-то вроде маленького червяка, некоторым рыбам он может показаться аппетитным."
			);
			AddEntry(
				LanguageEntries.FISH_NOBLE_BAIT_NAME,
				"Приманка для благородной рыбы"
			);
			AddEntry(
				LanguageEntries.FISH_NOBLE_BAIT_DESCRIPTION,
				"Что-то вроде маленького червяка, некоторым рыбам он может показаться аппетитным."
			);
			#region FishBaitDefinition
			AddEntry(
				LanguageEntries.FISHBAITDEFINITION_DESCRIPTION,
				"Может использоваться в ловушках для ловли рыбы." + Environment.NewLine +
				"Потребляет от {0} до {1} за цикл." + Environment.NewLine +
				"Может ловить до {2} рыб за цикл." + Environment.NewLine +
				"Допустимые цели:"
			);
			AddEntry(
				LanguageEntries.FISHBAITDEFINITION_FISH_DESCRIPTION,
				"-{1}%, чтобы получить {0} на минимальной глубине {2}м"
			);
			AddEntry(
				LanguageEntries.FISHBAITDEFINITION_DECOMPOSITION_DESCRIPTION,
				"Он может быть получен в компостерах." + Environment.NewLine +
				"{0}% шанс появления от {1} до {2} за цикл, потребляющий от " + Environment.NewLine +
				"{3} до {4} органических материалов."
			);
			#endregion
			#region FishDefinition
			AddEntry(
				LanguageEntries.FISHDEFINITION_DESCRIPTION,
				"Время вращения: {0}сек" + Environment.NewLine + Environment.NewLine +
				"Может быть пойман в ловушки:"
			);
			AddEntry(
				LanguageEntries.FISHDEFINITION_BAIT_DESCRIPTION,
				"- {1}% при использовании {0} на минимальной глубине {2}м"
			);
			AddEntry(
				LanguageEntries.FISHDEFINITION_NOTE_DESCRIPTION,
				"Примечание: Их мясо можно измельчать в кухонных комбайнах."
			);
			#endregion
			#endregion
			#region FOODS
			AddEntry(
				LanguageEntries.APPLE_NAME,
				"Яблоко"
			);
			AddEntry(
				LanguageEntries.APPLE_DESCRIPTION,
				"Яблоко - аппетитный красный фрукт," + Environment.NewLine +
				"имеет низкую калорийность."
			);
			AddEntry(
				LanguageEntries.BROCCOLI_NAME,
				"Брокколи"
			);
			AddEntry(
				LanguageEntries.BROCCOLI_DESCRIPTION,
				"Брокколи - съедобное зелёное растение семейства капустных," + Environment.NewLine +
				"они особенно богаты витаминами."
			);
			AddEntry(
				LanguageEntries.BEETROOT_NAME,
				"Свекла"
			);
			AddEntry(
				LanguageEntries.BEETROOT_DESCRIPTION,
				"Свекла — это корневая часть растения свеклы," + Environment.NewLine +
				"она особенно богата минеральными веществами."
			);
			AddEntry(
				LanguageEntries.CAROOT_NAME,
				"Морковь"
			);
			AddEntry(
				LanguageEntries.CAROOT_DESCRIPTION,
				"Морковь — корнеплод, особенно богатый" + Environment.NewLine +
				"минеральными веществами."
			);
			AddEntry(
				LanguageEntries.SHIITAKE_NAME,
				"Шиитаке"
			);
			AddEntry(
				LanguageEntries.SHIITAKE_DESCRIPTION,
				"Шиитаке — съедобный гриб, особенно богатый" + Environment.NewLine +
				"источник белка."
			);
			AddEntry(
				LanguageEntries.CHAMPIGNONS_NAME,
				"Champignon"
			);
			AddEntry(
				LanguageEntries.CHAMPIGNONS_DESCRIPTION,
				"Шампиньон — съедобный гриб, особенно богатый" + Environment.NewLine +
				"источник белка."
			);
			AddEntry(
				LanguageEntries.AMANITAMUSCARIA_NAME,
				"Красный Мухомор"
			);
			AddEntry(
				LanguageEntries.AMANITAMUSCARIA_DESCRIPTION,
				"Красный Мухомор - ядовитый гриб, не рекомендуется к употреблению," + Environment.NewLine +
				"но имеет широкое применение в химии и медицине"
			);
			AddEntry(
				LanguageEntries.TOMATO_NAME,
				"Помидор"
			);
			AddEntry(
				LanguageEntries.TOMATO_DESCRIPTION,
				"Помидор – съедобная ягода, имеет низкую калорийность."
			);//доделать
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
				"Мешок пшеницы"
			);
			AddEntry(
				LanguageEntries.WHEATSACK_DESCRIPTION,
				"Пшеничное зерно является основным продуктом, из которого делают муку, а вместе с ней и хлеб."
			);
			AddEntry(
				LanguageEntries.COFFEESACK_NAME,
				"Мешок кофе"
			);
			AddEntry(
				LanguageEntries.COFFEESACK_DESCRIPTION,
				"Кофе является стимулятором, так как в нем есть кофеин, так же" + Environment.NewLine +
				"он может использоваться для поддержания тепла в холодных местах."
			);
			AddEntry(
				LanguageEntries.MILK_NAME,
				"Молоко"
			);
			AddEntry(
				LanguageEntries.MILK_DESCRIPTION,
				"Молоко – это белая жидкая пища, вырабатываемая молочной " + Environment.NewLine +
				"железой млекопитающих."
			);
			AddEntry(
				LanguageEntries.MEAT_NAME,
				"Мясо"
			);
			AddEntry(
				LanguageEntries.MEAT_DESCRIPTION,
				"Мясо было одним из основных источников белка" + Environment.NewLine +
				"с доисторических времен."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_NAME,//доделать (тут было Alien meat, есть вариант обозначит его как "странное мясо", допустим или "Чужое мясо"(Гугл переводчик рекомендует этот вариант), "мясо Чужих")
				"Инопланетное мясо"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_DESCRIPTION,
				"Это странное мясо с резким запахом," + Environment.NewLine +
				"но на вкус - ничего."
			);
			AddEntry(
				LanguageEntries.CHICKENMEAT_NAME,
				"Курятина"
			);
			AddEntry(
				LanguageEntries.CHICKENMEAT_DESCRIPTION,
				"Курица – самый распространенный вид домашней птицы в мире."
			);
			AddEntry(
				LanguageEntries.BACON_NAME,
				"Бекон"
			);
			AddEntry(
				LanguageEntries.BACON_DESCRIPTION,
				"Бекон — это разновидность вяленой свинины, приготовленная из различных отрубов," + Environment.NewLine +
				"как правило, грудины или менее жирных частей спинки."
			);
			AddEntry(
				LanguageEntries.NOBLE_MEAT_NAME,
				"Изысканное мясо"
			);
			AddEntry(
				LanguageEntries.NOBLE_MEAT_DESCRIPTION,
				"Благородный отруб мяса, с высокой концентрацией белка."
			);
			AddEntry(//доделать в соответствии с Alien Meat
				LanguageEntries.ALIEN_NOBLE_MEAT_NAME,
				"Изысканное Инопланетное мясо"
			);
			AddEntry(
				LanguageEntries.ALIEN_NOBLE_MEAT_DESCRIPTION,
				"Это лучший срез Инопланетного мяса, у него" + Environment.NewLine +
				"более приемлемый запах и вкус."
			);
			AddEntry(
				LanguageEntries.EGG_NAME,
				"Яйцо"
			);
			AddEntry(
				LanguageEntries.EGG_DESCRIPTION,
				"Яйца являются очень богатым продуктом с точки зрения питания."
			);
			AddEntry(
				LanguageEntries.ALIEN_EGG_NAME, //доделать всё та же проблема Alien
				"Инопланетное Яйцо"
			);
			AddEntry(
				LanguageEntries.ALIEN_EGG_DESCRIPTION,
				"Это действительно довольно большое яйцо, но лучше не" + Environment.NewLine +
				"задумываться о том, откуда оно взялось."
			);
			AddEntry(
				LanguageEntries.SHRIMPMEAT_NAME,
				"Мясо креветок"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEAT_DESCRIPTION,
				"Креветки - один из самых потребляемых морепродуктов в мире, они" + Environment.NewLine +
				"богаты питательными веществами и очень полезны для здоровья."
			);
			AddEntry(
				LanguageEntries.FISHMEAT_NAME,
				"Мясо рыбы"
			);
			AddEntry(
				LanguageEntries.FISHMEAT_DESCRIPTION,
				"Рыба была важным диетическим источником белка и" + Environment.NewLine +
				"других питательных веществ на протяжении всей истории человечества."
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEAT_NAME,
				"Изысканное мясо рыбы"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEAT_DESCRIPTION,
				"Мясо рыбы высокого качества с высоким содержанием белка."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDFAT_NAME,
				"Жировой концентрат"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDFAT_DESCRIPTION,
				"Концентрированный жир, который можно использовать для изготовления других продуктов."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDPROTEIN_NAME,
				"Концентрат белка"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDPROTEIN_DESCRIPTION,
				"Концентрированный белок, который можно использовать для изготовления других продуктов."
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDVITAMIN_NAME,
				"Витаминный концентрат"
			);
			AddEntry(
				LanguageEntries.CONCENTRATEDVITAMIN_DESCRIPTION,
				"Концентрированные витамины, которые можно использовать для изготовления других продуктов."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_NAME,
				"Маленькая фляга воды"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_SMALL_DESCRIPTION,
				"Небольшая фляжка с водой."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_NAME,
				"Средняя фляга воды"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_MEDIUM_DESCRIPTION,
				"Средняя фляга с водой."
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_NAME,
				"Большая фляга воды"
			);
			AddEntry(
				LanguageEntries.WATER_FLASK_BIG_DESCRIPTION,
				"Большая фляга с водой."
			);
			AddEntry(
				LanguageEntries.APPLE_JUICE_NAME,
				"Яблочный сок"
			);
			AddEntry(
				LanguageEntries.APPLE_JUICE_DESCRIPTION,
				"Большая фляга свежевыжатого яблочного сока"
			);
			AddEntry(
				LanguageEntries.SODA_NAME,
				"Яблочная газировка"
			);
			AddEntry(
				LanguageEntries.SODA_DESCRIPTION,
				"Освежающая газировка на яблочной основе."
			);
			AddEntry(
				LanguageEntries.COFFEE_CAN_NAME,
				"Термос кофе"
			);
			AddEntry(
				LanguageEntries.COFFEE_CAN_DESCRIPTION,
				"Термос с горячим кофе"
			);
			AddEntry(
				LanguageEntries.DOUGH_NAME,
				"Тесто"
			);
			AddEntry(
				LanguageEntries.DOUGH_DESCRIPTION,
				"Тесто из молока и яиц."
			);
			AddEntry(
				LanguageEntries.ALIEN_DOUGH_NAME,
				"Инопланетное тесто"//доделать "Alien"
			);
			AddEntry(
				LanguageEntries.ALIEN_DOUGH_DESCRIPTION,
				"Тесто из молока и инопланетных яиц."
			);
			AddEntry(
				LanguageEntries.CAKEDOUGH_NAME,
				"Тесто для тортов"
			);
			AddEntry(
				LanguageEntries.CAKEDOUGH_DESCRIPTION,
				"Тесто для тортов из молока и яиц."
			);
			AddEntry(
				LanguageEntries.ALIEN_CAKEDOUGH_NAME,
				"Инопланетное тесто для тортов" //доделать "Alien"
			);
			AddEntry(
				LanguageEntries.ALIEN_CAKEDOUGH_DESCRIPTION,
				"Тесто для тортов из молока и инопланетных яиц."
			);
			AddEntry(
				LanguageEntries.RAW_BROCCOLI_BOWL_NAME,
				"Миска сырой брокколи"
			);
			AddEntry(
				LanguageEntries.RAW_BROCCOLI_BOWL_DESCRIPTION,
				"Миска измельчённой сырой брокколи"
			);
			AddEntry(
				LanguageEntries.RAW_CARROT_BOWL_NAME,
				"Миска сырой моркови"
			);
			AddEntry(
				LanguageEntries.RAW_CARROT_BOWL_DESCRIPTION,
				"Миска измельчённой сырой моркови"
			);
			AddEntry(
				LanguageEntries.RAW_BEETROOT_BOWL_NAME,
				"Миска сырой свеклы"
			);
			AddEntry(
				LanguageEntries.RAW_BEETROOT_BOWL_DESCRIPTION,
				"Миска измельчённой сырой свеклы."
			);
			AddEntry(
				LanguageEntries.RAW_MEAT_BOWL_NAME,
				"Миска сырого мяса"
			);
			AddEntry(
				LanguageEntries.RAW_MEAT_BOWL_DESCRIPTION,
				"Миска измельчённого сырого мяса."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_MEAT_BOWL_NAME, //доделать "Alien"
				"Миска сырого инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_MEAT_BOWL_DESCRIPTION,
				"Миска измельчённого сырого инопланетного мяса."
			);
			AddEntry(
				LanguageEntries.RAW_NOBLE_MEAT_BOWL_NAME,
				"Миска изысканного сырого мяса"
			);
			AddEntry(
				LanguageEntries.RAW_NOBLE_MEAT_BOWL_DESCRIPTION,
				"Миска измельчённого изысканного сырого мяса."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_NAME, //доделать "Alien"
				"Миска сырого изысканного инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_NOBLE_MEAT_BOWL_DESCRIPTION,
				"Миска измельчённого сырого изысканного инопланетного мяса."
			);
			AddEntry(
				LanguageEntries.RAWFISHMEATBOWL_NAME,
				"Миска сырого мяса рыбы"
			);
			AddEntry(
				LanguageEntries.RAWFISHMEATBOWL_DESCRIPTION,
				"Миска измельчённого сырого мяса рыбы."
			);
			AddEntry(
				LanguageEntries.RAWNOBLEFISHMEATBOWL_NAME,
				"Миска сырого изысканного мяса рыбы"
			);
			AddEntry(
				LanguageEntries.RAWNOBLEFISHMEATBOWL_DESCRIPTION,
				"Миска измельчённого сырого изысканного мяса рыбы."
			);
			AddEntry(
				LanguageEntries.RAW_SAUSAGE_NAME,
				"Сырая сосиска"
			);
			AddEntry(
				LanguageEntries.RAW_SAUSAGE_DESCRIPTION,
				"Сосиска, полная сырого мяса."
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_SAUSAGE_NAME, //доделать "Alien"
				"Сырая инопланетная сосиска"
			);
			AddEntry(
				LanguageEntries.RAW_ALIEN_SAUSAGE_DESCRIPTION,
				"Сосиска, полная сырого инопланетного мяса."
			);
			AddEntry(
				LanguageEntries.ROAST_CHAMPIGNON_NAME,
				"Жареные шампиньоны"
			);
			AddEntry(
				LanguageEntries.ROAST_CHAMPIGNON_DESCRIPTION,
				"Простой и вкусный способ есть грибы."
			);
			AddEntry(
				LanguageEntries.ROAST_SHIITAKE_NAME,
				"Жареные шиитаке"
			);
			AddEntry(
				LanguageEntries.ROAST_SHIITAKE_DESCRIPTION,
				"Простой и вкусный способ есть грибы."
			);
			AddEntry(
				LanguageEntries.FRIED_EGG_NAME,
				"Жаренное яйцо"
			);
			AddEntry(
				LanguageEntries.FRIED_EGG_DESCRIPTION,
				"Один из самых примитивных способов съесть яйцо."
			);
			AddEntry(
				LanguageEntries.FRIED_ALIEN_EGG_NAME, //доделать "Alien"
				"Жаренное инопланетное яйцо"
			);
			AddEntry(
				LanguageEntries.FRIED_ALIEN_EGG_DESCRIPTION,
				"Цвет странный, но это все равно яичница."
			);
			AddEntry(
				LanguageEntries.ROASTEDBACON_NAME,
				"Жареный бекон"
			);
			AddEntry(
				LanguageEntries.ROASTEDBACON_DESCRIPTION,
				"Бекон - это жизнь!"
			);
			AddEntry(
				LanguageEntries.ROASTEDCHICKEN_NAME,
				"Жареный цыпленок"
			);
			AddEntry(
				LanguageEntries.ROASTEDCHICKEN_DESCRIPTION,
				"Легкое нежирное мясо."
			);
			AddEntry(
				LanguageEntries.ROASTED_SAUSAGE_NAME,
				"Жареная сосиска"
			);
			AddEntry(
				LanguageEntries.ROASTED_SAUSAGE_DESCRIPTION,
				"Обработанное и хорошо приправленное мясо, его можно есть отдельно или с чем-то."
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_SAUSAGE_NAME, //доделать "Alien"
				"Жареная инопланетная сосиска"
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_SAUSAGE_DESCRIPTION,
				"После обработки и приправы, даже со странным цветом, вкус очень хороший."
			);
			AddEntry(
				LanguageEntries.ROASTED_MEAT_NAME,
				"Жареное мясо"
			);
			AddEntry(
				LanguageEntries.ROASTED_MEAT_DESCRIPTION,
				"С самого начала цивилизации жареное мясо было источником пищи для людей.."
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_MEAT_NAME, //доделать "Alien"
				"Жареное инопланетное мясо"
			);
			AddEntry(
				LanguageEntries.ROASTED_ALIEN_MEAT_DESCRIPTION,
				"Несмотря на то, что это странное мясо, барбекю есть барбекю."
			);
			AddEntry(
				LanguageEntries.CEREALBAR_NAME,//доделать (хотя, тут, несмотря, на "Cereal", мне кажется перевод вышел очень удачным)
				"Питательный батончик"
			);
			AddEntry(
				LanguageEntries.CEREALBAR_DESCRIPTION,
				"Батончик из злаков, простой и легкий в приготовлении."
			);
			AddEntry(
				LanguageEntries.WATERBREAD_NAME,
				"Пресная хлебная лепёшка"
			);
			AddEntry(
				LanguageEntries.WATERBREAD_DESCRIPTION,
				"Один из древнейших способов приготовления хлеба."
			);
			AddEntry(
				LanguageEntries.BREAD_NAME,
				"Хлеб"
			);
			AddEntry(
				LanguageEntries.BREAD_DESCRIPTION,
				"Молочный хлеб, мягкий и вкусный."
			);
			AddEntry(
				LanguageEntries.ALIEN_BREAD_NAME, //доделать "Alien"
				"Инопланетный хлеб"
			);
			AddEntry(
				LanguageEntries.ALIEN_BREAD_DESCRIPTION,
				"Молочный хлеб с использованием инопланетных яиц, даже странного цвета, получается мягким и вкусным."  //закончить тут
			);
			AddEntry(
				LanguageEntries.PASTA_NAME,
				"Макароны"
			);
			AddEntry(
				LanguageEntries.PASTA_DESCRIPTION,
				"Хорошие макароны из теста, которые можно приготовить с другими пиправами."
			);
			AddEntry(
				LanguageEntries.ALIEN_PASTA_NAME,
				"Инопланетная паста"
			);
			AddEntry(
				LanguageEntries.ALIEN_PASTA_DESCRIPTION,
				"Хорошие макароны из теста, с использованием инопланетных яиц, которые можно приготовить с другими пиправами."
			);
			AddEntry(
				LanguageEntries.VEGETABLEPASTA_NAME,
				"Овощные макароны"
			);
			AddEntry(
				LanguageEntries.VEGETABLEPASTA_DESCRIPTION,
				"Вкусные макароны с помидорами и брокколи."
			);
			AddEntry(
				LanguageEntries.VEGETABLEALIENPASTA_NAME,
				"Инопалнетные овощные макароны"
			);
			AddEntry(
				LanguageEntries.VEGETABLEALIENPASTA_DESCRIPTION,
				"Вкусные макароны приготовленные из инопланетных яиц, с помидорами и брокколи."
			);
			AddEntry(
				LanguageEntries.MEATPASTA_NAME,
				"Макароны с мясом"
			);
			AddEntry(
				LanguageEntries.MEATPASTA_DESCRIPTION,
				"Вкусные макароны с помидорами и мясом."
			);
			AddEntry(
				LanguageEntries.ALIENMEATPASTA_NAME,
				"Инопланетные макароны с мясом"
			);
			AddEntry(
				LanguageEntries.ALIENMEATPASTA_DESCRIPTION,
				"Вкусные макароны приготовленные из инопланетных яиц, с помидорами и инопланетным мясом."
			);
			AddEntry(
				LanguageEntries.CHEESE_NAME,
				"Сыр"
			);
			AddEntry(
				LanguageEntries.CHEESE_DESCRIPTION,
				"Сыр – это твердая пища, приготовленная из молока.."
			);
			AddEntry(
				LanguageEntries.SALAD_NAME,
				"Салат"
			);
			AddEntry(
				LanguageEntries.SALAD_DESCRIPTION,
				"Нарезанные и продезинфицированные овощи, легкая и свежая еда."
			);
			AddEntry(
				LanguageEntries.VEGETABLE_SOUP_BOWL_NAME,
				"Овощной суп"
			);
			AddEntry(
				LanguageEntries.VEGETABLE_SOUP_BOWL_DESCRIPTION,
				"Суп питателен и легко согревает тело."
			);
			AddEntry(
				LanguageEntries.STEW_NAME,
				"Тушенка"
			);
			AddEntry(
				LanguageEntries.STEW_DESCRIPTION,
				"Хорошая тушеная говядина."
			);
			AddEntry(
				LanguageEntries.ALIEN_STEW_NAME,
				"Инопланетная тушенка"
			);
			AddEntry(
				LanguageEntries.ALIEN_STEW_DESCRIPTION,
				"Хорошее тушеное инопланетное мясо."
			);
			AddEntry(
				LanguageEntries.MEAT_VEGETABLES_NAME,
				"Мясо с овощами"
			);
			AddEntry(
				LanguageEntries.MEAT_VEGETABLES_DESCRIPTION,
				"Вкусное мясо с хорошо приготовленными овощами."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_VEGETABLES_NAME,
				"Иноплнетное мясо с овощами"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_VEGETABLES_DESCRIPTION,
				"Вкусное инопланетное мясо с хорошо приготовленными овощами."
			);
			AddEntry(
				LanguageEntries.MEATLOAF_NAME,
				"Мясной рулет"
			);
			AddEntry(
				LanguageEntries.MEATLOAF_DESCRIPTION,
				"Вкусный мясной рулет."
			);
			AddEntry(
				LanguageEntries.ALIENMEATLOAF_NAME,
				"Инопланетный мясной рулет"
			);
			AddEntry(
				LanguageEntries.ALIENMEATLOAF_DESCRIPTION,
				"Вкусный инопланетный мясной рулет."
			);
			AddEntry(
				LanguageEntries.MEAT_SOUP_BOWL_NAME,
				"Мясной суп"
			);
			AddEntry(
				LanguageEntries.MEAT_SOUP_BOWL_DESCRIPTION,
				"Аромат мяса делает суп вкуснее."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_SOUP_BOWL_NAME,
				"Инопланетный мясной суп"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_SOUP_BOWL_DESCRIPTION,
				"Аромат инопланетного мяса делает суп вкуснее."
			);
			AddEntry(
				LanguageEntries.MUSHROOMPATE_BOWL_NAME,
				"Грибной паштет"
			);
			AddEntry(
				LanguageEntries.MUSHROOMPATE_BOWL_DESCRIPTION,
				"Паштет из грибов."
			);
			AddEntry(
				LanguageEntries.MEAT_MUSHROOMS_NAME,
				"Мясо с грибами"
			);
			AddEntry(
				LanguageEntries.MEAT_MUSHROOMS_DESCRIPTION,
				"Вкусное мясо с жареными грибами."
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_MUSHROOMS_NAME,
				"Инопланетное мясо с грибами"
			);
			AddEntry(
				LanguageEntries.ALIEN_MEAT_MUSHROOMS_DESCRIPTION,
				"Вкусное инопланетное мясо с тушеными грибами."
			);
			AddEntry(
				LanguageEntries.SANDWICH_NAME,
				"Сэндвич с колбасой"
			);
			AddEntry(
				LanguageEntries.SANDWICH_DESCRIPTION,
				"Сэндвич с нарезанной колбасой, сыром и помидорами."
			);
			AddEntry(
				LanguageEntries.ALIEN_SANDWICH_NAME,
				"Инопланетный сэндвич с колбасой"
			);
			AddEntry(
				LanguageEntries.ALIEN_SANDWICH_DESCRIPTION,
				"Сэндвич с нарезанной инопланетной колбасой, сыром и помидорами."
			);
			AddEntry(
				LanguageEntries.ROASTEDSHRIMP_NAME,
				"Жареные креветки"
			);
			AddEntry(
				LanguageEntries.ROASTEDSHRIMP_DESCRIPTION,
				"Жареные креветки очень вкусные."
			);
			AddEntry(
				LanguageEntries.ROASTEDFISH_NAME,
				"Жареная рыба"
			);
			AddEntry(
				LanguageEntries.ROASTEDFISH_DESCRIPTION,
				"Хорошо прожаренное мясо рыбы."
			);
			AddEntry(
				LanguageEntries.ROASTEDNOBLEFISH_NAME,
				"Жаренное изысканное мясо рыбы"
			);
			AddEntry(
				LanguageEntries.ROASTEDNOBLEFISH_DESCRIPTION,
				"Хорошо прожаренное изысканное мясо рыбы."
			);
			AddEntry(
				LanguageEntries.FISHMUSHROOM_NAME,
				"Рыба с грибами"
			);
			AddEntry(
				LanguageEntries.FISHMUSHROOM_DESCRIPTION,
				"Вкусная рыбка с жареными грибами."
			);
			AddEntry(
				LanguageEntries.FISHSOUPBOWL_NAME,
				"Уха"
			);
			AddEntry(
				LanguageEntries.FISHSOUPBOWL_DESCRIPTION,
				"Аромат изысканного рыбного мяса делает суп еще вкуснее."
			);
			AddEntry(
				LanguageEntries.SHRIMPSOUPBOWL_NAME,
				"Суп из креветок"
			);
			AddEntry(
				LanguageEntries.SHRIMPSOUPBOWL_DESCRIPTION,
				"Аромат креветок с мясом рыбы делает суп вкуснее."
			);
			AddEntry(
				LanguageEntries.APPLEPIE_NAME,
				"Яблочный пирог"
			);
			AddEntry(
				LanguageEntries.APPLEPIE_DESCRIPTION,
				"Пирог с яблоками."
			);
			AddEntry(
				LanguageEntries.ALIEN_APPLEPIE_NAME,
				"Инопланетный яблочный пирог"
			);
			AddEntry(
				LanguageEntries.ALIEN_APPLEPIE_DESCRIPTION,
				"Пирог из яблок и инопланетных яиц в тесте."
			);
			AddEntry(
				LanguageEntries.CHICKENPIE_NAME,
				"Куриный пирог"
			);
			AddEntry(
				LanguageEntries.CHICKENPIE_DESCRIPTION,
				"Пирог с курицей и беконом."
			);
			AddEntry(
				LanguageEntries.ALIEN_CHICKENPIE_NAME,
				"Инопланетный куриный пирог"
			);
			AddEntry(
				LanguageEntries.ALIEN_CHICKENPIE_DESCRIPTION,
				"Пирог с курицей, беконом и инопланетными яйцами в тесте.."
			);
			AddEntry(
				LanguageEntries.FATPORRIDGE_NAME,
				"Жирная каша"
			);
			AddEntry(
				LanguageEntries.FATPORRIDGE_DESCRIPTION,
				"Каша из концентрированного жира – отличный способ набрать вес."
			);
			AddEntry(
				LanguageEntries.PROTEINBAR_NAME,
				"Протеиновый батончик"
			);
			AddEntry(
				LanguageEntries.PROTEINBAR_DESCRIPTION,
				"Зерновой батончик, обогащенный большим количеством белка."
			);
			AddEntry(
				LanguageEntries.VITAMINPILLS_NAME,
				"Витаминные таблетки"
			);
			AddEntry(
				LanguageEntries.VITAMINPILLS_DESCRIPTION,
				"Таблетки-заменители витаминов."
			);
			AddEntry(
				LanguageEntries.TOFU_NAME,
				"Тофу"
			);
			AddEntry(
				LanguageEntries.TOFU_DESCRIPTION,
				"Куча органических веществ, очищенных и переработанных в своего рода сыр.."
			);
			AddEntry(
				LanguageEntries.MRE_NAME,
				"Сухпай - Неприкосновенный запас"
			);
			AddEntry(
				LanguageEntries.MRE_DESCRIPTION,
				"Источник пищи, который может спасти вам жизнь, но лишает достоинства."
			);
			AddEntry(
				LanguageEntries.TOMATOTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный витамин из помидоров"
			);
			AddEntry(
				LanguageEntries.APPLETOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный витамин из яблок"
			);
			AddEntry(
				LanguageEntries.ALIENEGGTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из инопланетных яиц"
			);
			AddEntry(
				LanguageEntries.EGGTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из яиц"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из мяса креветок"
			);
			AddEntry(
				LanguageEntries.SHRIMPMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из мяса креветок"
			);
			AddEntry(
				LanguageEntries.FISHMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из мяса рыбы"
			);
			AddEntry(
				LanguageEntries.FISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из мяса рыбы"
			);
			AddEntry(
				LanguageEntries.ALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.ALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.MEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из мяса"
			);
			AddEntry(
				LanguageEntries.MEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из мяса"
			);
			AddEntry(
				LanguageEntries.CHICKENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из курятины"
			);
			AddEntry(
				LanguageEntries.CHICKENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из курятины"
			);
			AddEntry(
				LanguageEntries.MILKTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из молока"
			);
			AddEntry(
				LanguageEntries.MILKTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из молока"
			);
			AddEntry(
				LanguageEntries.BACONTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из бекона"
			);
			AddEntry(
				LanguageEntries.BACONTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из бекона"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из изысканного мяса рыбы"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из изысканного мяса рыбы"
			);
			AddEntry(
				LanguageEntries.NOBLEALIENMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из изысканного инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.NOBLEALIENMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из изысканного инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATTOCONCENTRATED_CONSTRUCTION_NAME,
				"Концентрированный протеин из изысканного мяса"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATTOCONCENTRATEDFAT_CONSTRUCTION_NAME,
				"Концентрированный жир из изысканного мяса"
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
				LanguageEntries.FOODDEFINITION_REDUCEDISEASE_DESCRIPTION,
				"Можно уменьшить {0} на {1}"
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
				"Арника"
			);
			AddEntry(
				LanguageEntries.ARNICA_DESCRIPTION,
				"Арника - это редкий обычный цветок, у которого есть противовоспалительные и антибиотические свойства."
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_NAME,
				"Ромашка"
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_DESCRIPTION,
				"Ромашка - это очень распространенный цветок, у которого есть успокаивающее и желудочное действие."
			);
			AddEntry(
				LanguageEntries.ALOEVERA_NAME,
				"Алоэ вера"
			);
			AddEntry(
				LanguageEntries.ALOEVERA_DESCRIPTION,
				"Алоэ вера - это трава, которая имеет широкое применение в медицине."
			);
			AddEntry(
				LanguageEntries.MINT_NAME,
				"Мята"
			);
			AddEntry(
				LanguageEntries.MINT_DESCRIPTION,
				"Мята - это очень распространенная трава, которая имеет освежающее и желудочное действие."
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_NAME,
				"Эритроксилум"
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_DESCRIPTION,
				"Эритроксилум - это распространенная трава с обезболивающими свойствами."
			);
			#endregion
			#region ORES
			AddEntry(
				LanguageEntries.BONEMEAL_NAME,
				"Костная мука"
			);
			AddEntry(
				LanguageEntries.BONEMEAL_DESCRIPTION,
				"Костная мука - это смесь мелко и крупно измельченных костей животных " + Environment.NewLine +
				"и продуктов переработки на мясокомбинатах."
			);
			#endregion
			#region LIVESTOCK
			AddEntry(
				LanguageEntries.COWMALE_NAME,
				"Бык"
			);
			AddEntry(
				LanguageEntries.COWMALE_DESCRIPTION,
				"Это самец крупного рогатого скота и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.COWFEMALE_NAME,
				"Корова"
			);
			AddEntry(
				LanguageEntries.COWFEMALE_DESCRIPTION,
				"Это самка крупного рогатого скота и может использоваться для разведения, производства молока" + Environment.NewLine +
				"или убоя."
			);
			AddEntry(
				LanguageEntries.COWBABY_NAME,
				"Детеныш коровы"
			);
			AddEntry(
				LanguageEntries.COWBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.DEERMALE_NAME,
				"Самец оленя"
			);
			AddEntry(
				LanguageEntries.DEERMALE_DESCRIPTION,
				"Это самец оленя и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.DEERFEMALE_NAME,
				"Самка оленя"
			);
			AddEntry(
				LanguageEntries.DEERFEMALE_DESCRIPTION,
				"Это самка оленя и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.DEERBABY_NAME,
				"Детеныш оленя"
			);
			AddEntry(
				LanguageEntries.DEERBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.HORSEMALE_NAME,
				"Самец лошади"
			);
			AddEntry(
				LanguageEntries.HORSEMALE_DESCRIPTION,
				"Это самец лошади и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.HORSEFEMALE_NAME,
				"Самка лошади"
			);
			AddEntry(
				LanguageEntries.HORSEFEMALE_DESCRIPTION,
				"Это самка лошади и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.HORSEBABY_NAME,
				"Детеныш лошади"
			);
			AddEntry(
				LanguageEntries.HORSEBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.SHEEPMALE_NAME,
				"Самец овцы"
			);
			AddEntry(
				LanguageEntries.SHEEPMALE_DESCRIPTION,
				"Это самец овцы и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.SHEEPFEMALE_NAME,
				"Самка овцы"
			);
			AddEntry(
				LanguageEntries.SHEEPFEMALE_DESCRIPTION,
				"Это самка овцы и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.SHEEPBABY_NAME,
				"Детеныш овцы"
			);
			AddEntry(
				LanguageEntries.SHEEPBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.SPIDERMALE_NAME,
				"Самец паука"
			);
			AddEntry(
				LanguageEntries.SPIDERMALE_DESCRIPTION,
				"Это самец паука и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.SPIDERFEMALE_NAME,
				"Самка паука"
			);
			AddEntry(
				LanguageEntries.SPIDERFEMALE_DESCRIPTION,
				"Это самка паука и может использоваться для разведения, производства яиц" + Environment.NewLine +
				"или убоя."
			);
			AddEntry(
				LanguageEntries.SPIDERBABY_NAME,
				"Детеныш паука"
			);
			AddEntry(
				LanguageEntries.SPIDERBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.WOLFMALE_NAME,
				"Самец волка"
			);
			AddEntry(
				LanguageEntries.WOLFMALE_DESCRIPTION,
				"Это самец волка и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.WOLFFEMALE_NAME,
				"Самка волка"
			);
			AddEntry(
				LanguageEntries.WOLFFEMALE_DESCRIPTION,
				"Это самка волка и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.WOLFBABY_NAME,
				"Детеныш волка"
			);
			AddEntry(
				LanguageEntries.WOLFBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.COWDEAD_NAME,
				"Мертвая корова"
			);
			AddEntry(
				LanguageEntries.COWDEAD_DESCRIPTION,
				"Туша коровы."
			);
			AddEntry(
				LanguageEntries.DEERDEAD_NAME,
				"Мертвый олень"
			);
			AddEntry(
				LanguageEntries.DEERDEAD_DESCRIPTION,
				"Туша оленя."
			);
			AddEntry(
				LanguageEntries.HORSEDEAD_NAME,
				"Мертвая лошадь"
			);
			AddEntry(
				LanguageEntries.HORSEDEAD_DESCRIPTION,
				"Туша лошади."
			);
			AddEntry(
				LanguageEntries.SHEEPDEAD_NAME,
				"Мертвая овца"
			);
			AddEntry(
				LanguageEntries.SHEEPDEAD_DESCRIPTION,
				"Туша овцы."
			);
			AddEntry(
				LanguageEntries.SPIDERDEAD_NAME,
				"Мертвый паук"
			);
			AddEntry(
				LanguageEntries.SPIDERDEAD_DESCRIPTION,
				"Туша паука."
			);
			AddEntry(
				LanguageEntries.WOLFDEAD_NAME,
				"Мертвый волк"
			);
			AddEntry(
				LanguageEntries.WOLFDEAD_DESCRIPTION,
				"Туша волка."
			);
			AddEntry(
				LanguageEntries.COWBABYDEAD_NAME,
				"Мертвый теленок"
			);
			AddEntry(
				LanguageEntries.COWBABYDEAD_DESCRIPTION,
				"Туша теленка."
			);
			AddEntry(
				LanguageEntries.DEERBABYDEAD_NAME,
				"Мертвый детеныш оленя"
			);
			AddEntry(
				LanguageEntries.DEERBABYDEAD_DESCRIPTION,
				"Туша детеныша оленя."
			);
			AddEntry(
				LanguageEntries.HORSEBABYDEAD_NAME,
				"Мертвый детеныш лошади"
			);
			AddEntry(
				LanguageEntries.HORSEBABYDEAD_DESCRIPTION,
				"Туша детеныша лошади."
			);
			AddEntry(
				LanguageEntries.SHEEPBABYDEAD_NAME,
				"Мертвый детеныш овцы"
			);
			AddEntry(
				LanguageEntries.SHEEPBABYDEAD_DESCRIPTION,
				"Туша детеныша овцы."
			);
			AddEntry(
				LanguageEntries.SPIDERBABYDEAD_NAME,
				"Мертвый детеныш паука"
			);
			AddEntry(
				LanguageEntries.SPIDERBABYDEAD_DESCRIPTION,
				"Туша детеныша паука."
			);
			AddEntry(
				LanguageEntries.WOLFBABYDEAD_NAME,
				"Мертвый детеныш волка"
			);
			AddEntry(
				LanguageEntries.WOLFBABYDEAD_DESCRIPTION,
				"Туша детеныша волка."
			);
			AddEntry(
				LanguageEntries.PIGBABYDEAD_NAME,
				"Мертвый детеныш свиньи"
			);
			AddEntry(
				LanguageEntries.PIGBABYDEAD_DESCRIPTION,
				"Туша детеныша свиньи."
			);
			AddEntry(
				LanguageEntries.CHICKENBABYDEAD_NAME,
				"Мертвый детеныш курицы"
			);
			AddEntry(
				LanguageEntries.CHICKENBABYDEAD_DESCRIPTION,
				"Туша детеныша курицы."
			);
			AddEntry(
				LanguageEntries.PIGDEAD_NAME,
				"Мертвая свинья"
			);
			AddEntry(
				LanguageEntries.PIGDEAD_DESCRIPTION,
				"Туша свиньи."
			);
			AddEntry(
				LanguageEntries.CHICKENDEAD_NAME,
				"Мертвая курица"
			);
			AddEntry(
				LanguageEntries.CHICKENDEAD_DESCRIPTION,
				"Туша курицы."
			);
			AddEntry(
				LanguageEntries.PIGMALE_NAME,
				"Самец свиньи"
			);
			AddEntry(
				LanguageEntries.PIGMALE_DESCRIPTION,
				"Это самец свиньи и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.PIGFEMALE_NAME,
				"Самка свиньи"
			);
			AddEntry(
				LanguageEntries.PIGFEMALE_DESCRIPTION,
				"Это самка свиньи и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.PIGBABY_NAME,
				"Детеныш свиньи"
			);
			AddEntry(
				LanguageEntries.PIGBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			AddEntry(
				LanguageEntries.CHICKENMALE_NAME,
				"Самец курицы"
			);
			AddEntry(
				LanguageEntries.CHICKENMALE_DESCRIPTION,
				"Это самец курицы и может использоваться для разведения или убоя."
			);
			AddEntry(
				LanguageEntries.CHICKENFEMALE_NAME,
				"Самка курицы"
			);
			AddEntry(
				LanguageEntries.CHICKENFEMALE_DESCRIPTION,
				"Это самка курицы и может использоваться для разведения, производства яиц" + Environment.NewLine +
				"или убоя."
			);
			AddEntry(
				LanguageEntries.CHICKENBABY_NAME,
				"Детеныш курицы"
			);
			AddEntry(
				LanguageEntries.CHICKENBABY_DESCRIPTION,
				"Это детеныш, после кормления он вырастет во взрослое животное" + Environment.NewLine +
				"или может быть использован для убоя."
			);
			#region ОПИСАНИЕ СЕЛЬСКОГО ХОЗЯЙСТВА
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_HERBIVOROUS_DESCRIPTION,
				"Это травоядное животное и может питаться растительным кормом."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_CARNIVOROUS_DESCRIPTION,
				"Это хищное животное и может питаться мясным кормом."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_BIRD_DESCRIPTION,
				"Это птица и может питаться зерновым кормом."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_CARCASS_DESCRIPTION,
				"Примечание: Туша животного будет разлагаться со временем, чтобы не потерять" + Environment.NewLine +
				"мясо, его можно обработать в скотобойне." + Environment.NewLine +
				"Время разложения: {0} сек."
			);
			AddEntry(
				LanguageEntries.LIVESTOCKDEFINITION_DESCRIPTION,
				"Примечание: Животное нужно поместить в клетку и регулярно предоставлять" + Environment.NewLine +
				"корм в инвентарь блока в соответствии с его диетой."
			);
			AddEntry(
				LanguageEntries.LIVESTOCK_BUTCHERY_DESCRIPTION,
				"Убой {0}"
			);
			AddEntry(
				LanguageEntries.LIVESTOCK_SLAUGHTER_DESCRIPTION,
				"Обработка {0}"
			);
			#endregion
			#endregion
			#region MEDICAL
			AddEntry(
				LanguageEntries.BANDAGES_NAME,
				"Простые бинты"
			);
			AddEntry(
				LanguageEntries.BANDAGES_DESCRIPTION,
				"Простые бинты, которые можно использовать для первой помощи."
			);

			AddEntry(
				LanguageEntries.POWER_BANDAGES_NAME,
				"Усиленные бинты"
			);
			AddEntry(
				LanguageEntries.POWER_BANDAGES_DESCRIPTION,
				"Простые бинты, которые можно использовать для первой помощи."
			);

			AddEntry(
				LanguageEntries.HEALTH_BUSTER_NAME,
				"Лекарство 'Здоровье'"
			);
			AddEntry(
				LanguageEntries.HEALTH_BUSTER_DESCRIPTION,
				"Мощный инъекционный препарат, вызывающий спонтанную регенерацию" + Environment.NewLine +
				"в организме."
			);

			AddEntry(
				LanguageEntries.MEDKIT_NAME,
				"Медицинский набор"
			);
			AddEntry(
				LanguageEntries.MEDKIT_DESCRIPTION,
				"Инъекционный препарат, способный восстанавливать даже кости."
			);

			AddEntry(
				LanguageEntries.HEALTHINJECTION_NAME,
				"Инъекция 'Здоровье'"
			);
			AddEntry(
				LanguageEntries.HEALTHINJECTION_DESCRIPTION,
				"Мощная инъекция, способная лечить инфекции, болезни" + Environment.NewLine +
				"и снижать усталость."
			);

			AddEntry(
				LanguageEntries.HEALTHPOWERINJECTION_NAME,
				"Сильнодействующая инъекция 'Здоровье'"
			);
			AddEntry(
				LanguageEntries.HEALTHPOWERINJECTION_DESCRIPTION,
				"Очень мощная инъекция, вызывающая спонтанную регенерацию" + Environment.NewLine +
				"в организме."
			);

			AddEntry(
				LanguageEntries.SIMPLEMEDICINE_NAME,
				"Простое лекарство"
			);
			AddEntry(
				LanguageEntries.SIMPLEMEDICINE_DESCRIPTION,
				"Полезное средство от проблем с пищеварением или легкой боли."
			);

			AddEntry(
				LanguageEntries.MEDICINE_NAME,
				"Лекарство"
			);
			AddEntry(
				LanguageEntries.MEDICINE_DESCRIPTION,
				"Полезное средство от ядов и незначительных травм."
			);
			#endregion
			#region ORES
			AddEntry(
				LanguageEntries.BONES_NAME,
				"Кости"
			);
			AddEntry(
				LanguageEntries.BONES_DESCRIPTION,
				"Кость - жесткий орган, составляющий часть скелета у большинства" + Environment.NewLine +
				"позвоночных животных."
			);

			AddEntry(
				LanguageEntries.FISH_BONES_NAME,
				"Рыбные кости"
			);
			AddEntry(
				LanguageEntries.FISH_BONES_DESCRIPTION,
				"Кость - жесткий орган, составляющий часть скелета у большинства" + Environment.NewLine +
				"позвоночных животных."
			);

			AddEntry(
				LanguageEntries.POOP_NAME,
				"Фекалии"
			);
			AddEntry(
				LanguageEntries.POOP_DESCRIPTION,
				"Твердые или полутвердые остатки пищи, которые не могут быть переварены" + Environment.NewLine +
				"в тонкой кишке."
			);

			AddEntry(
				LanguageEntries.WHEAT_NAME,
				"Пшеница"
			);
			AddEntry(
				LanguageEntries.WHEAT_DESCRIPTION,
				"Зерно пшеницы - основной продукт, используемый для производства муки и," + Environment.NewLine +
				"с ее помощью, хлеба."
			);

			AddEntry(
				LanguageEntries.COFFEE_NAME,
				"Кофе"
			);
			AddEntry(
				LanguageEntries.COFFEE_DESCRIPTION,
				"Кофе - стимулятор, благодаря содержанию кофеина, он может служить" + Environment.NewLine +
				"альтернативой для поддержания телесной температуры в холодных местах."
			);

			AddEntry(
				LanguageEntries.THERMALFLUID_NAME,
				"Теплоноситель"
			);
			AddEntry(
				LanguageEntries.THERMALFLUID_DESCRIPTION,
				"Теплоноситель - химическое вещество, используемое в тепловом цикле в" + Environment.NewLine +
				"системах холодильника и кондиционирования воздуха."
			);
			#endregion
			#region QUIMICALS
			AddEntry(
				LanguageEntries.PROPOFOL_NAME,
				"Пропофол"
			);
			AddEntry(
				LanguageEntries.PROPOFOL_DESCRIPTION,
				"Пропофол - короткодействующее лекарство, приводящее к снижению уровня сознания."
			);

			AddEntry(
				LanguageEntries.LIDOCAINE_NAME,
				"Лидокаин"
			);
			AddEntry(
				LanguageEntries.LIDOCAINE_DESCRIPTION,
				"Лидокаин - медленно действующее лекарство, приводящее к снижению уровня сознания."
			);

			AddEntry(
				LanguageEntries.SMALLALOEVERAEXTRACT_NAME,
				"Малый экстракт алоэ вера"
			);
			AddEntry(
				LanguageEntries.SMALLALOEVERAEXTRACT_DESCRIPTION,
				"Экстракт алоэ вера имеет широкое применение в медицине."
			);

			AddEntry(
				LanguageEntries.ALOEVERAEXTRACT_NAME,
				"Экстракт алоэ вера"
			);
			AddEntry(
				LanguageEntries.ALOEVERAEXTRACT_DESCRIPTION,
				"Экстракт алоэ вера имеет широкое применение в медицине."
			);

			AddEntry(
				LanguageEntries.ARNICAEXTRACT_NAME,
				"Экстракт арники"
			);
			AddEntry(
				LanguageEntries.ARNICAEXTRACT_DESCRIPTION,
				"Экстракт арники имеет противовоспалительные и антибиотические свойства."
			);

			AddEntry(
				LanguageEntries.MINTEXTRACT_NAME,
				"Экстракт мяты"
			);
			AddEntry(
				LanguageEntries.MINTEXTRACT_DESCRIPTION,
				"Экстракт мяты обладает освежающим и пищеварительным действием."
			);

			AddEntry(
				LanguageEntries.CHAMOMILEEXTRACT_NAME,
				"Экстракт ромашки"
			);
			AddEntry(
				LanguageEntries.CHAMOMILEEXTRACT_DESCRIPTION,
				"Экстракт ромашки обладает успокаивающим и пищеварительным действием."
			);

			AddEntry(
				LanguageEntries.AMATOXINA_NAME,
				"Аматоксина"
			);
			AddEntry(
				LanguageEntries.AMATOXINA_DESCRIPTION,
				"Аматоксина - токсичные соединения, обнаруживаемые в ядовитых грибах."
			);
			#endregion
			#region RATIONS
			AddEntry(
				LanguageEntries.MEATRATION_NAME,
				"Мясной корм"
			);
			AddEntry(
				LanguageEntries.MEATRATION_DESCRIPTION,
				"Рацион на основе мяса, отлично подходит для хищных животных."
			);

			AddEntry(
				LanguageEntries.VEGETABLERATION_NAME,
				"Рацион из овощей"
			);
			AddEntry(
				LanguageEntries.VEGETABLERATION_DESCRIPTION,
				"Рацион на основе овощей, отлично подходит для травоядных животных."
			);

			AddEntry(
				LanguageEntries.GRAINSRATION_NAME,
				"Рацион из зерна"
			);
			AddEntry(
				LanguageEntries.GRAINSRATION_DESCRIPTION,
				"Рацион на основе зерна, идеально подходит для птиц."
			);

			AddEntry(
				LanguageEntries.MEATRATION_CONSTRUCTION_NAME,
				"Мясной рацион"
			);
			AddEntry(
				LanguageEntries.ALIENMEATRATION_CONSTRUCTION_NAME,
				"Рацион из инопланетного мяса"
			);
			AddEntry(
				LanguageEntries.NOBLEMEATRATION_CONSTRUCTION_NAME,
				"Рацион из благородного мяса"
			);
			AddEntry(
				LanguageEntries.ALIENNOBLEMEATRATION_CONSTRUCTION_NAME,
				"Рацион из инопланетного благородного мяса"
			);
			AddEntry(
				LanguageEntries.FISHMEATRATION_CONSTRUCTION_NAME,
				"Рацион из рыбы"
			);
			AddEntry(
				LanguageEntries.NOBLEFISHMEATRATION_CONSTRUCTION_NAME,
				"Рацион из благородной рыбы"
			);
			AddEntry(
				LanguageEntries.BROCCOLIRATION_CONSTRUCTION_NAME,
				"Рацион из брокколи"
			);
			AddEntry(
				LanguageEntries.BEETROOTRATION_CONSTRUCTION_NAME,
				"Рацион из свеклы"
			);
			AddEntry(
				LanguageEntries.CARROTRATION_CONSTRUCTION_NAME,
				"Рацион из моркови"
			);
			AddEntry(
				LanguageEntries.WHEATRATION_CONSTRUCTION_NAME,
				"Рацион из пшеницы"
			);
			AddEntry(
				LanguageEntries.CEREALRATION_CONSTRUCTION_NAME,
				"Рацион из круп"
			);
			#endregion
			#region RECIPIENTS
			AddEntry(
				LanguageEntries.BOWL_NAME,
				"Миска"
			);
			AddEntry(
				LanguageEntries.BOWL_DESCRIPTION,
				"Миски в основном используются для хранения и приготовления пищи."
			);
			AddEntry(
				LanguageEntries.ALUMINUMCAN_NAME,
				"Алюминиевая банка"
			);
			AddEntry(
				LanguageEntries.ALUMINUMCAN_DESCRIPTION,
				"Алюминиевые банки используются для безопасного хранения напитков без риска порчи."
			);
			AddEntry(
				LanguageEntries.BOWLOFWOOD_CONSTRUCTION_NAME,
				"Деревянная миска"
			);
			AddEntry(
				LanguageEntries.BOWLOFGLASS_CONSTRUCTION_NAME,
				"Стеклянная миска"
			);
			AddEntry(
				 LanguageEntries.SMALLALUMINUMCANISTER_NAME,
				 "Маленькая алюминиевая банка"
			);
			AddEntry(
				LanguageEntries.SMALLALUMINUMCANISTER_DESCRIPTION,
				"Маленькие алюминиевые банки используются для безопасного хранения жидкостей."
			);
			#endregion
			#region SEEDS
			AddEntry(
				LanguageEntries.ARNICA_SEEDS_NAME,
				"Семена арники"
			);
			AddEntry(
				LanguageEntries.ARNICA_SEEDS_DESCRIPTION,
				"Семена арники могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.BEETROOT_SEEDS_NAME,
				"Семена свеклы"
			);
			AddEntry(
				LanguageEntries.BEETROOT_SEEDS_DESCRIPTION,
				"Семена свеклы могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.BROCCOLI_SEEDS_NAME,
				"Семена брокколи"
			);
			AddEntry(
				LanguageEntries.BROCCOLI_SEEDS_DESCRIPTION,
				"Семена брокколи могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.CARROT_SEEDS_NAME,
				"Семена моркови"
			);
			AddEntry(
				LanguageEntries.CARROT_SEEDS_DESCRIPTION,
				"Семена моркови могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.COFFEE_SEEDS_NAME,
				"Семена кофе"
			);
			AddEntry(
				LanguageEntries.COFFEE_SEEDS_DESCRIPTION,
				"Семена кофе могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.MINT_SEEDS_NAME,
				"Семена мяты"
			);
			AddEntry(
				LanguageEntries.MINT_SEEDS_DESCRIPTION,
				"Семена мяты могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.TOMATO_SEEDS_NAME,
				"Семена помидоров"
			);
			AddEntry(
				LanguageEntries.TOMATO_SEEDS_DESCRIPTION,
				"Семена помидоров могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.WHEAT_SEEDS_NAME,
				"Семена пшеницы"
			);
			AddEntry(
				LanguageEntries.WHEAT_SEEDS_DESCRIPTION,
				"Семена пшеницы могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_SEEDS_NAME,
				"Семена ромашки"
			);
			AddEntry(
				LanguageEntries.CHAMOMILE_SEEDS_DESCRIPTION,
				"Семена ромашки могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.ALOEVERA_SEEDS_NAME,
				"Семена алоэ вера"
			);
			AddEntry(
				LanguageEntries.ALOEVERA_SEEDS_DESCRIPTION,
				"Семена алоэ вера могут быть выращены с использованием удобрений и льда на фермах."
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_SEEDS_NAME,
				"Семена эритроксилума"
			);
			AddEntry(
				LanguageEntries.ERYTHROXYLUM_SEEDS_DESCRIPTION,
				"Семена эритроксилума могут быть выращены с использованием удобрений и льда на фермах."
			);
			#region Определение семян
			AddEntry(
				LanguageEntries.SEEDDEFINITION_DESCRIPTION,
				"Требуется солнечный свет: {0}" + Environment.NewLine +
				"Любимые удобрения: {1}"
			);
			#endregion
			#endregion
			#region FERTILIZERS
			AddEntry(
				LanguageEntries.FERTILIZER_NAME,
				"Органическое удобрение"
			);
			AddEntry(
				LanguageEntries.FERTILIZER_DESCRIPTION,
				"Удобрение, изготовленное из органических материалов."
			);
			AddEntry(
				LanguageEntries.MINERALFERTILIZER_NAME,
				"Минеральное удобрение"
			);
			AddEntry(
				LanguageEntries.MINERALFERTILIZER_DESCRIPTION,
				"Удобрение, изготовленное из минеральных материалов."
			);
			AddEntry(
				LanguageEntries.SUPERFERTILIZER_NAME,
				"Супер удобрение"
			);
			AddEntry(
				LanguageEntries.SUPERFERTILIZER_DESCRIPTION,
				"Смесь минеральных и органических удобрений," + Environment.NewLine +
				"эффективно используется с любыми семенами."
			);
			AddEntry(
				LanguageEntries.BONEFERTILIZER_CONSTRUCTION_NAME,
				"Органическое удобрение из костной муки"
			);
			AddEntry(
				LanguageEntries.POOPFERTILIZER_CONSTRUCTION_NAME,
				"Органическое удобрение из навоза"
			);
			AddEntry(
				LanguageEntries.SPOILEDMATERIALFERTILIZER_CONSTRUCTION_NAME,
				"Органическое удобрение из органического материала"
			);
			AddEntry(
				LanguageEntries.MAGNESIUMFERTILIZER_CONSTRUCTION_NAME,
				"Минеральное удобрение из магния"
			);
			AddEntry(
				LanguageEntries.POTASSIUMFERTILIZER_CONSTRUCTION_NAME,
				"Минеральное удобрение из калия"
			);
			AddEntry(
				LanguageEntries.FERTILIZER_CONSTRUCTION_NAME,
				"Минеральное удобрение из серы"
			);
			#region Определение удобрений
			AddEntry(
				LanguageEntries.FERTILIZERDEFINITION_POWER_DESCRIPTION,
				"Предоставляет {0}% увеличение производства при использовании." + Environment.NewLine +
				"Совместимо со всеми растениями."
			);
			AddEntry(
				LanguageEntries.FERTILIZERDEFINITION_DESCRIPTION,
				"Предоставляет {0}% увеличение производства при использовании" + Environment.NewLine +
				"с совместимыми растениями." + Environment.NewLine +
				"Совместимо с:"
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
				"Пропофоловый дротик"
			);
			AddEntry(
				LanguageEntries.PROPOFOLDART_DESCRIPTION,
				"Дротик с пропофольным транквилизатором."
			);
			AddEntry(
				LanguageEntries.LIDOCAINDART_NAME,
				"Дротик с лидокаином"
			);
			AddEntry(
				LanguageEntries.LIDOCAINDART_DESCRIPTION,
				"Дротик с лидокаиновым транквилизатором."
			);
			AddEntry(
				LanguageEntries.BBBULLET_NAME,
				"Пуля BB-6mm."
			);
			AddEntry(
				LanguageEntries.BBBULLET_DESCRIPTION,
				"6-миллиметровая железная дробь."
			);
			AddEntry(
				LanguageEntries.PISTOL_PROPOFOL_MAGZINE_NAME,
				"DRT-Магазин с пропофолом для пистолета."
			);
			AddEntry(
				LanguageEntries.PISTOL_PROPOFOL_MAGZINE_DESCRIPTION,
				"обойма дротиков с пропофольным транквилизатором для пистолета."
			);
			AddEntry(
				LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_NAME,
				"DRT-магазин с лидокаином для пистолета."
			);
			AddEntry(
				LanguageEntries.PISTOL_LIDOCAIN_MAGZINE_DESCRIPTION,
				"Обойма дротиков с лидокаиновым транквилизатором для пистолета."
			);
			AddEntry(
				LanguageEntries.PISTOL_BB_MAGZINE_NAME,
				"магазин BB-6mm муль для пистолета"
			);
			AddEntry(
				LanguageEntries.PISTOL_BB_MAGZINE_DESCRIPTION,
				"Пистолетная обойма с 6-миллиметровой дробью."
			);
			AddEntry(
				LanguageEntries.LIDOCAINPISTOLITEM_NAME,
				"Пистолетный DRT-лидокаин."
			);
			AddEntry(
				LanguageEntries.LIDOCAINPISTOLITEM_DESCRIPTION,
				"Дротиковое ружье для охоты на животных с лидокаиновым транквилизатором."
			);
			AddEntry(
				LanguageEntries.PROPOFOLPISTOLITEM_NAME,
				"Пистолетный DRT-Пропофол"
			);
			AddEntry(
				LanguageEntries.PROPOFOLPISTOLITEM_DESCRIPTION,
				"Дротиковое ружье для охоты на животных с пропофольным транквилизатором."
			);
			AddEntry(
				LanguageEntries.BBPISTOLITEM_NAME,
				"Пистолет BB-6mm"
			);
			AddEntry(
				LanguageEntries.BBPISTOLITEM_DESCRIPTION,
				"дробовик под 6mm калибр."
			);
			#endregion
			#region STATS
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_FLU_NAME,
				"Грипп"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_PNEUMONIA_NAME,
				"Пневмония"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_DYSENTERY_NAME,
				"Дизентерия"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_POISON_NAME,
				"Отравление"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_INFECTED_NAME,
				"Заражение"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPOTHERMIA_NAME,
				"Гипотермия"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPERTHERMIA_NAME,
				"Гипертермия"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_STARVATION_NAME,
				"Голод"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVERESTARVATION_NAME,
				"Сильный голод"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_DEHYDRATION_NAME,
				"Обезвоживание"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVEREDEHYDRATION_NAME,
				"Сильное обезвоживание"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_OBESITY_NAME,
				"Ожирение"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVEREOBESITY_NAME,
				"Сильное ожирение"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_RICKETS_NAME,
				"Рахит"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_SEVERERICKETS_NAME,
				"Сильный рахит"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_HYPOLIPIDEMIA_NAME,
				"Гиполипидемия"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_QUEASY_NAME,
				"Извращение"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_POOPONCLOTHES_NAME,
				"Грязь на одежде"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_PEEONCLOTHES_NAME,
				"Моча на одежде"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_OVERHEATING_NAME,
				"Перегрев"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_ONFIRE_NAME,
				"Пожар"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_COLD_NAME,
				"Холод"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_FROSTY_NAME,
				"Мороз"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_WET_NAME,
				"Мокрость"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOCOLD_NAME,
				"Вынужденное охлаждение"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOFREEZE_NAME,
				"Вынужденное замораживание"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOHOT_NAME,
				"Вынужденное нагревание"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_EXPOSEDTOBOILING_NAME,
				"Вынужденное кипячение"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RECOVERINGFROMEXPOSURE_NAME,
				"Восстановление от воздействия"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOCOLD_NAME,
				"Слабая устойчивость к холоду"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOCOLD_NAME,
				"Устойчивость к холоду"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOCOLD_NAME,
				"Сильная устойчивость к холоду"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_LESSERRESISTENCETOHOT_NAME,
				"Слабая устойчивость к жаре"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_RESISTENCETOHOT_NAME,
				"Устойчивость к жаре"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_GREATERRESISTENCETOHOT_NAME,
				"Сильная устойчивость к жаре"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_CONTUSION_NAME,
				"Контузия"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_WOUNDED_NAME,
				"Ранение"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_DEEPWOUNDED_NAME,
				"Глубокое ранение"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_BROKENBONES_NAME,
				"Переломы"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_HUNGRY_NAME,
				"Голодный"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FAMISHED_NAME,
				"Голоден до смерти"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_THIRSTY_NAME,
				"Жаждет"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_DEHYDRATING_NAME,
				"Обезвоживается"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_DISORIENTED_NAME,
				"Дезориентирован"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_SUFFOCATION_NAME,
				"Удушье"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLSTOMACH_NAME,
				"Полный желудок"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_STOMACHBURSTING_NAME,
				"Желудок сорвало"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLGUT_NAME,
				"Полные кишки"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_GUTBURST_NAME,
				"Кишки сорвало"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_FULLBLADDER_NAME,
				"Полный мочевой пузырь"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_BLADDERBURST_NAME,
				"Мочевой пузырь сорвало"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_TIRED_NAME,
				"Усталый"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_EXTREMELYTIRED_NAME,
				"Чрезмерно усталый"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_STOMACHGROWLING_NAME,
				"завершение пищеварения"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_EMPTYSTOMACH_NAME,
				"Пустой желудок"
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL0_NAME,
				"Я чувствую себя хорошо и здорово."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL1_NAME,
				"Мне не очень хорошо."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL2_NAME,
				"Со мной что-то не так."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL3_NAME,
				"Мне нужно что-то сделать, пока не поздно."
			);
			AddEntry(
				LanguageEntries.FEELING_LEVEL4_NAME,
				"Мне нужна помощь, я думаю, я умираю."
			);
			AddEntry(
				LanguageEntries.FEELING_INFO_NAME,
				"Известные эффекты:"
			);
			AddEntry(
				LanguageEntries.BOILING_NAME,
				"Кипячение"
			);
			AddEntry(
				LanguageEntries.TOOHOT_NAME,
				"Слишком жарко"
			);
			AddEntry(
				LanguageEntries.WARMINGUP_NAME,
				"Прогрев"
			);
			AddEntry(
				LanguageEntries.FREEZING_NAME,
				"Замерзание"
			);
			AddEntry(
				LanguageEntries.VERYCOLD_NAME,
				"Очень холодно"
			);
			AddEntry(
				LanguageEntries.COOLINGDOWN_NAME,
				"Охлаждение"
			);
			AddEntry(
				LanguageEntries.STABLE_NAME,
				"Стабильное"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_WETLEVEL_NAME,
				"Уровень влажности"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_UNTREATEDWOUND_NAME,
				"Нетронутая рана"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_TOXICEXPOSURE_NAME,
				"Токсическое воздействие"
			);
			AddEntry(
				LanguageEntries.STATTIMERS_RADIOACTIVEEXPOSURE_NAME,
				"Радиационное воздействие"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_COMPLETELYWET_NAME,
				"Полностью мокрый"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_COMPLETELYDRY_NAME,
				"Полностью сухой"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_INFECTED_NAME,
				"Заражение"
			);
			AddEntry(
				LanguageEntries.STATTIMERSPROGRESS_NOINJURIES_NAME,
				"Нет травм"
			);
			AddEntry(
				LanguageEntries.HUNGER_NAME,
				"Голод"
			);
			AddEntry(
				LanguageEntries.THIRST_NAME,
				"Жажда"
			);
			AddEntry(
				LanguageEntries.STAMINA_NAME,
				"Выносливость"
			);
			AddEntry(
				LanguageEntries.FATIGUE_NAME,
				"Усталость"
			);
			AddEntry(
				LanguageEntries.SURVIVALEFFECTS_NAME,
				"Эффекты выживания"
			);
			AddEntry(
				LanguageEntries.DAMAGEEFFECTS_NAME,
				"Эффекты повреждений"
			);
			AddEntry(
				LanguageEntries.TEMPERATUREEFFECTS_NAME,
				"Температурные эффекты"
			);
			AddEntry(
				LanguageEntries.DISEASEEFFECTS_NAME,
				"Эффекты заболеваний"
			);
			AddEntry(
				LanguageEntries.OTHEREFFECTS_NAME,
				"Другие эффекты"
			);
			AddEntry(
				LanguageEntries.WOUNDEDTIME_NAME,
				"Время ранения"
			);
			AddEntry(
				LanguageEntries.TEMPERATURETIME_NAME,
				"Время воздействия температуры"
			);
			AddEntry(
				LanguageEntries.WETTIME_NAME,
				"Время мокрости"
			);
			AddEntry(
				LanguageEntries.BODYENERGY_NAME,
				"Энергия"
			);
			AddEntry(
				LanguageEntries.BODYWATER_NAME,
				"Вода"
			);
			AddEntry(
				LanguageEntries.BODYPERFORMANCE_NAME,
				"Эффективность"
			);
			AddEntry(
				LanguageEntries.BODYIMMUNE_NAME,
				"Иммунитет"
			);
			AddEntry(
				LanguageEntries.STOMACH_NAME,
				"Желудок"
			);
			AddEntry(
				LanguageEntries.INTESTINE_NAME,
				"Кишечник"
			);
			AddEntry(
				LanguageEntries.BLADDER_NAME,
				"Мочевой пузырь"
			);
			AddEntry(
				LanguageEntries.BODYWEIGHT_NAME,
				"Вес"
			);
			AddEntry(
				LanguageEntries.BODYMUSCLES_NAME,
				"Мышцы"
			);
			AddEntry(
				LanguageEntries.BODYFAT_NAME,
				"Жир"
			);
			AddEntry(
				LanguageEntries.FOODDETECTOR_NAME,
				"Детектор пищи"
			);
			AddEntry(
				LanguageEntries.MEDICALDETECTOR_NAME,
				"Детектор медицины"
			);
			AddEntry(
				LanguageEntries.BODYCALORIES_NAME,
				"Калории"
			);
			AddEntry(
				LanguageEntries.TORPOR_NAME,
				"Торпор"
			);
			AddEntry(
				LanguageEntries.BODYPROTEIN_NAME,
				"Белки"
			);
			AddEntry(
				LanguageEntries.BODYCARBOHYDRATE_NAME,
				"Углеводы"
			);
			AddEntry(
				LanguageEntries.BODYLIPIDS_NAME,
				"Липиды"
			);
			AddEntry(
				LanguageEntries.BODYMINERALS_NAME,
				"Минералы"
			);
			AddEntry(
				LanguageEntries.BODYVITAMINS_NAME,
				"Витамины"
			);
			AddEntry(
				LanguageEntries.INTOXICATIONTIME_NAME,
				"Уровень отравления"
			);
			AddEntry(
				LanguageEntries.RADIATIONTIME_NAME,
				"Уровень радиации"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALFLUID_NAME,
				"Холодная термальная жидкость"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALFLUID_NAME,
				"Горячая термальная жидкость"
			);
			AddEntry(
				LanguageEntries.ENERGYSHIELD_NAME,
				"Энергетический щит"
			);
			AddEntry(
				LanguageEntries.BODYMUSCLESWEIGHT_NAME,
				"Мышечный вес"
			);
			AddEntry(
				LanguageEntries.BODYFATWEIGHT_NAME,
				"Жирный вес"
			);
            AddEntry(
                LanguageEntries.STAMINAAMOUNT_NAME,
                "Макс. выносливость"
            );
            AddEntry(
                LanguageEntries.HEALTHVALUEMODIFIER_REGENERATIONFACTOR_NAME,
                "Фактор регенерации"
            );
            AddEntry(
                LanguageEntries.HEALTHVALUEMODIFIER_MAXIMUMREGENERATIONHEALTH_NAME,
                "Максимальное восстановление здоровья"
            );
            AddEntry(
                LanguageEntries.HEALTHVALUEMODIFIER_MAXHEALTH_NAME,
                "Максимальное здоровье"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_HIGHERSTAMINAEXPENDITURE_NAME,
                "Более высокие затраты на выносливость"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_MAXIMUMSTAMINAREDUCTION_NAME,
                "Максимальное снижение выносливости"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_LONGERSTAMINARECHARGETIME_NAME,
                "Увеличенное время перезарядки выносливости"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_STAMINAREGENERATION_NAME,
                "Регенерация выносливости"
            );
            AddEntry(
                LanguageEntries.STAMINAVALUEMODIFIER_MAXIMUMSTAMINABONUS_NAME,
                "Максимальный бонус выносливости"
            );
            AddEntry(
                LanguageEntries.METABOLISMVALUEMODIFIER_WATERCONSUMPTION_NAME,
                "Потребление воды"
            );
            AddEntry(
                LanguageEntries.METABOLISMVALUEMODIFIER_ENERGYCONSUMPTION_NAME,
                "Потребление энергии"
            );
            #endregion
            #region Food Effects
            AddEntry(
                LanguageEntries.FOODEFFECTS_FRESHFRUIT_NAME,
                "Свежие фрукты"
            );
            AddEntry(
                LanguageEntries.FOODEFFECTS_RAWVEGETABLE_NAME,
                "Сырой овощ"
            );
            #endregion
            #region Weather
            AddEntry(
				LanguageEntries.WEATHEREFFECTSLEVEL_LIGHT_NAME,
				"Легкий"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTSLEVEL_HEAVY_NAME,
				"Сильный"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTS_RAIN_NAME,
				"Дождь"
			);
			AddEntry(
				LanguageEntries.WEATHEREFFECTS_THUNDERSTORM_NAME,
				"Гроза"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_ATMOSPHERE_NAME,
				"Атмосфера"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_SHIPORSTATION_NAME,
				"Под давлением"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_SPACE_NAME,
				"Космос"
			);
			AddEntry(
				LanguageEntries.ENVIRONMENTDETECTOR_UNDERWATER_NAME,
				"Под водой"
			);
			AddEntry(
				LanguageEntries.UI_ENVIROMENT_DISPLAY,
				"Окружающая среда: "
			);
			AddEntry(
				LanguageEntries.UI_WEATHER_DISPLAY,
				"Погода: "
			);
			#endregion
			#region Armors
			AddEntry(
				LanguageEntries.SCAVENGERARMOR_NAME,
				"Доспехи мусорщика"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMOR_DESCRIPTION,
				"Очень распространенная модель брони для тех, у кого нет много" + Environment.NewLine +
				"ресурсов и им нужна дополнительная защита."
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMORLIGHT_NAME,
				"Доспехи мусорщика [Легкие]"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMORHEAVY_NAME,
				"Доспехи мусорщика [Укрепленные]"
			);
			AddEntry(
				LanguageEntries.SCAVENGERARMOREXPANDED_NAME,
				"Доспехи мусорщика [Увеличенные]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOR_NAME,
				"Охотничьи доспехи"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOR_DESCRIPTION,
				"Очень эффективная броня для опытных охотников."
			);
			AddEntry(
				LanguageEntries.HUNTERARMORLIGHT_NAME,
				"Охотничьи доспехи [Легкие]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMORHEAVY_NAME,
				"Охотничьи доспехи [Укрепленные]"
			);
			AddEntry(
				LanguageEntries.HUNTERARMOREXPANDED_NAME,
				"Охотничьи доспехи [Увеличенные]"
			);
			AddEntry(
				LanguageEntries.ARMOR_DESCRIPTION,
				"Примечание. Чтобы получать бонусы к броне, вам необходимо экипировать " + Environment.NewLine +
				"ее через интерфейс оборудования."
			);
			AddEntry(
				LanguageEntries.ARMORLIGHT_DESCRIPTION,
				"Легкая броня имеет меньше защитных очков, но занимает меньше места" + Environment.NewLine +
				"и требует меньше выносливости."
			);
			AddEntry(
				LanguageEntries.ARMORHEAVY_DESCRIPTION,
				"Укрепленная броня имеет больше защитных очков, но занимает больше места" + Environment.NewLine +
				"и требует больше выносливости."
			);
			AddEntry(
				LanguageEntries.ARMOREXPANDED_DESCRIPTION,
				"Увеличенная броня имеет больше модульных слотов, но занимает больше места," + Environment.NewLine +
				"имеет меньше защиту и требует больше выносливости."
			);
			AddEntry(
				LanguageEntries.ARMORCATEGORY_WORK_NAME,
				"Рабочая"
			);
			AddEntry(
				LanguageEntries.ARMORCATEGORY_COMBAT_NAME,
				"Боевая"
			);
			AddEntry(
				LanguageEntries.ARMORDESC_CATEGORY_ENTRY,
				"Категория: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_MODULES_ENTRY,
				"Всего модулей: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_STAMINA_ENTRY,
				"Стоимость выносливости: {0}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_RESISTENCE_ENTRY,
				"{0} сопротивление {1}."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_EFFECT_ENTRY,
				"{0} {1}."
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_GATHERING_NAME,
				"Собирательство"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_CARGOLOAD_NAME,
				"Грузоподъемность"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_MOVEMENTSPEED_NAME,
				"Скорость передвижения"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_CREATUREDAMAGE_NAME,
				"Урон по существам"
			);
			AddEntry(
				LanguageEntries.ARMOREFFECT_TORPORBONUS_NAME,
				"Бонус к торпору"
			);
			AddEntry(
				LanguageEntries.ARMORDESC_UI_EQUIPED,
				"Одетые доспехи: {0} [{1} пустых модулей]."
			);
			AddEntry(
				LanguageEntries.ARMORDESC_UI_SHIELD_EQUIPED,
				"Одет щит [{0} максимальных очков]."
			);
			#endregion
			# region Armor Modules
			AddEntry(
				LanguageEntries.COLDTHERMALREGULATOR_NAME,
				"Холодный тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.ENHANCEDCOLDTHERMALREGULATOR_NAME,
				"Улучшенный холодный тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.PROFICIENTCOLDTHERMALREGULATOR_NAME,
				"Профессиональный  холодный тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.ELITECOLDTHERMALREGULATOR_NAME,
				"Элитный холодный тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.COLDTHERMALREGULATOR_DESCRIPTION,
				"Используется для поддержания температуры скафандра в экстремально холодных" + Environment.NewLine +
				"средах и потребляет тепловую жидкость в процессе."
			);
			AddEntry(
				LanguageEntries.HOTTHERMALREGULATOR_NAME,
				"Горячий тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.ENHANCEDHOTTHERMALREGULATOR_NAME,
				"Улучшенный горячий тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.PROFICIENTHOTTHERMALREGULATOR_NAME,
				"Профессиональный горячий тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.ELITEHOTTHERMALREGULATOR_NAME,
				"Элитный горячий тепловой регулятор"
			);
			AddEntry(
				LanguageEntries.HOTTHERMALREGULATOR_DESCRIPTION,
				"Используется для поддержания температуры скафандра в экстремально жарких" + Environment.NewLine +
				"средах и потребляет тепловую жидкость в процессе."
			);
			AddEntry(
				LanguageEntries.SHIELDGENERATOR_NAME,
				"Генератор щита"
			);
			AddEntry(
				LanguageEntries.SHIELDGENERATOR_DESCRIPTION,
				"Используется для поглощения ударов, атак и снарядов, это может быть" + Environment.NewLine +
				"решающим моментом для выживания. В броне может быть только один генератор" + Environment.NewLine +
				"щита, но есть модули расширения щита." + Environment.NewLine +
				"Для начала перезарядки щита требуется {0} секунд без получения урона."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDGENERATOR_NAME,
				"Улучшенный генератор щита"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDGENERATOR_NAME,
				"Профессиональный генератор щита"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDGENERATOR_NAME,
				"Элитный генератор щита"
			);
			AddEntry(
				LanguageEntries.SHIELDCAPACITOR_NAME,
				"Конденсатор щита"
			);
			AddEntry(
				LanguageEntries.SHIELDCAPACITOR_DESCRIPTION,
				"Используется для увеличения максимальной емкости щита и скорости его перезарядки," + Environment.NewLine +
				"но увеличивает энергопотребление."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDCAPACITOR_NAME,
				"Улучшенный конденсатор щита"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDCAPACITOR_NAME,
				"Профессиональный конденсатор щита"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDCAPACITOR_NAME,
				"Элитный конденсатор щита"
			);
			AddEntry(
				LanguageEntries.SHIELDTRANSISTOR_NAME,
				"Транзистор щита"
			);
			AddEntry(
				LanguageEntries.SHIELDTRANSISTOR_DESCRIPTION,
				"Используется для снижения энергопотребления щита, но увеличивает" + Environment.NewLine +
				"общее время перезарядки."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDTRANSISTOR_NAME,
				"Улучшенный транзистор щита"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDTRANSISTOR_NAME,
				"Опытный транзистор щита"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDTRANSISTOR_NAME,
				"Элитный транзистор щита"
			);
			AddEntry(
				LanguageEntries.SHIELDSPIKE_NAME,
				"Реверсионная броня"
			);
			AddEntry(
				LanguageEntries.SHIELDSPIKE_DESCRIPTION,
				"Используется для возврата части получаемого урона в ближнем бою" + Environment.NewLine +
				"нападающему."
			);
			AddEntry(
				LanguageEntries.ENHANCEDSHIELDSPIKE_NAME,
				"Улучшенная Реверсионная броня"
			);
			AddEntry(
				LanguageEntries.PROFICIENTSHIELDSPIKE_NAME,
				"Профессиональная Реверсионная броня"
			);
			AddEntry(
				LanguageEntries.ELITESHIELDSPIKE_NAME,
				"Элитная Реверсионная броня"
			);
			AddEntry(
				LanguageEntries.ARMORMODULE_DESCRIPTION,
				"Примечание. Для получения бонусов от модуля брони его необходимо " + Environment.NewLine +
				"экипировать через интерфейс оборудования."
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_EFFICIENCY_NAME,
				"Эффективность"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_CAPACITY_NAME,
				"Емкость"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_RECHARGESPEED_NAME,
				"Скорость перезарядки"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTION_NAME,
				"Потребление энергии"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_CAPACITYBONUS_NAME,
				"Бонус к емкости"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_RECHARGESPEEDBONUS_NAME,
				"Бонус к скорости перезарядки"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_ENERGYCONSUMPTIONBONUS_NAME,
				"Бонус к потреблению энергии"
			);
			AddEntry(
				LanguageEntries.MODULEATTRIBUTE_SPIKEDAMAGE_NAME,
				"Урон шипом"
			);
			#endregion
			#region Damage Types
			AddEntry(
				LanguageEntries.DAMAGETYPE_CREATURE_NAME,
				"Существо"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_BULLET_NAME,
				"Пуля"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_EXPLOSION_NAME,
				"Взрыв"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_RADIOACTIVITY_NAME,
				"Радиоактивность"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_FIRE_NAME,
				"Огонь"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_TOXICITY_NAME,
				"Токсичность"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_FALL_NAME,
				"Падение"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_TOOL_NAME,
				"Инструмент"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_ENVIRONMENT_NAME,
				"Окружающая среда"
			);
			AddEntry(
				LanguageEntries.DAMAGETYPE_OTHER_NAME,
				"Прочее"
			);
			#endregion
			#region Equip Slot - System
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_BODYTRACKER_NAME,
				"Трекер тела"
			);
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_BODYARMOR_NAME,
				"Костюм Броня"
			);
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_ARMORWORKMODULE_NAME,
				"Рабочий модуль"
			);
			AddEntry(
				LanguageEntries.EQUIPABLEITEMCATEGORY_ARMORCOMBATMODULE_NAME,
				"Боевой модуль"
			);
			#endregion
		}

	}

}
