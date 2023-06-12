using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using VRage;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;

namespace ExtendedSurvival.Stats
{

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Drill), false)]
    public class ShipDrillBlock : SimpleInventoryLogicComponent<IMyShipDrill>
    {

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

        protected override void OnInit(MyObjectBuilder_EntityBase objectBuilder)
        {
            OnAfterCreateNewObserver += ShipDrillBlock_OnAfterCreateNewObserver;
            base.OnInit(objectBuilder);
            NeedsUpdate |= MyEntityUpdateEnum.EACH_100TH_FRAME;
        }

        private PlayerArmorController.PlayerArmorInfo? armorInfo;
        protected override void OnUpdateAfterSimulation100()
        {
            base.OnUpdateAfterSimulation100();
            this.armorInfo = null;
            if (CurrentEntity.IsFunctional && CurrentEntity.IsActivated)
            {
                var blocks = new List<IMySlimBlock>();
                CurrentEntity.CubeGrid.GetBlocks(blocks, x => x.BlockDefinition.Id.TypeId == typeof(MyObjectBuilder_Cockpit));
                var query = blocks.Where(x => (x.FatBlock as IMyCockpit)?.IsOccupied ?? false);
                if (query.Any())
                {
                    var lista = query.Select(x => x.FatBlock as IMyCockpit).ToArray();
                    foreach (var cockpit in lista)
                    {
                        var playerId = cockpit.ControllerInfo.ControllingIdentityId;
                        var armorInfo = PlayerArmorController.GetEquipedArmor(playerId, useCache: true);
                        if (armorInfo.HasValue)
                        {
                            this.armorInfo = armorInfo;
                            break;
                        }
                    }
                }
            }
        }

        private void ShipDrillBlock_OnAfterCreateNewObserver(int index, Guid observerId)
        {
            ExtendedSurvivalCoreAPI.RegisterInventoryObserverAfterContentsAddedCallback(observerId, (id, inventory, item, amount) =>
            {
                if (CurrentEntity.IsFunctional && CurrentEntity.IsActivated)
                {
                    if (item.Content.TypeId == typeof(MyObjectBuilder_Ore))
                    {
                        if (armorInfo.HasValue && armorInfo.Value.Definition.Effects.ContainsKey(ArmorSystemConstants.ArmorEffect.Gathering))
                        {
                            var getBonus = armorInfo.Value.Definition.Effects[ArmorSystemConstants.ArmorEffect.Gathering];
                            var finalamount = (MyFixedPoint)(amount * getBonus);
                            item.Amount += finalamount;
                        }
                    }
                }
            });
        }

    }

}
