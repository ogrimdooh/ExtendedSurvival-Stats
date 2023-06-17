using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.Game.Components;

namespace ExtendedSurvival.Stats
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false, "ThermalFluidGenerator", "ThermalFluidGeneratorSmall")]
    public class ThermalFluidGeneratorBlock : SimpleInventoryLogicComponent<IMyGasGenerator>
    {

        public static string BLOCK_NAME
        {
            get
            {
                return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR);
            }
        }

        public static string GetFullDescription()
        {
            return LanguageProvider.GetEntry(LanguageEntries.CUBEBLOCK_THERMALFLUIDGENERATOR_DESCRIPTION);
        }

        public MyInventory Inventory
        {
            get
            {
                return GetMyInventory(0);
            }
        }

        private MyInventory _inventory;
        protected override MyInventory GetMyInventory(int index)
        {
            if (_inventory == null)
                _inventory = CurrentEntity.GetInventory() as MyInventory;
            return _inventory;
        }

        protected override int GetInventoryCount()
        {
            return 1;
        }

    }

}
