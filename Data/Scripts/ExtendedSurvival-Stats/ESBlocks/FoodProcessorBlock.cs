using Sandbox.Common.ObjectBuilders;
using VRage.Game.Components;

namespace ExtendedSurvival
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Assembler), false, "BasicFoodProcessor", "FoodProcessor", "FoodProcessorIndustrial")]
    public class FoodProcessorBlock : BaseAssemblerBlock
    {

    }

}
