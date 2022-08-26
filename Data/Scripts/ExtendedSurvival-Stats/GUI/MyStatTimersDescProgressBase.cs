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
                    return "Intake Food";
                case 3:
                    return "Intake Water";
                case 4:
                    return "Carbohydrates";
                case 5:
                    return "Protein";
                case 6:
                    return "Lipids";
                case 7:
                    return "Vitamins";
                case 8:
                    return "Minerals";
            }
            return "";
        }

    }

}