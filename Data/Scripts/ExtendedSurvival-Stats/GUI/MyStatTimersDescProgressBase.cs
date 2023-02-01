namespace ExtendedSurvival.Stats
{
    public abstract class MyStatTimersDescProgressBase : MyStatTimersProgressBase
    {

        protected override string GetDescription(int index)
        {
            switch (index)
            {
                case 0:
                    return "Wet Level";
                case 1:
                    return "Untreated Wound";
                case 2:
                    return "Intake Water";
                case 3:
                    return "Carbohydrates";
                case 4:
                    return "Protein";
                case 5:
                    return "Lipids";
                case 6:
                    return "Vitamins";
                case 7:
                    return "Minerals";
            }
            return "";
        }

    }

}