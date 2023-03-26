using System;
using System.Linq;
using VRage;
using VRage.Game.ModAPI;
using VRage.Utils;
using Sandbox.Game.Entities;
using VRage.Game.Entity;
using VRageMath;
using VRage.Game;
using Sandbox.ModAPI;
using Sandbox.Game.EntityComponents;
using Sandbox.Game;
using Sandbox.Game.Entities.Character.Components;
using Sandbox.Definitions;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Game.GameSystems;
using VRage.Collections;
using VRage.ObjectBuilders;
using Sandbox.Common.ObjectBuilders;

namespace ExtendedSurvival.Stats
{

    public class PlayerCharacterEntity : BaseCharacterEntity
    {

        public MyEntityStat GetStat(StatsConstants.ValidStats stat)
        {
            return GetStat(stat.ToString());
        }

        private const float MAX_HEALTH_REGEN_AT_SURVIVAL_KIT = 0.5f;

        public MyCharacterOxygenComponent OxygenComponent { get; private set; }

        public MyEntityStat FoodDetector { get { return GetStat(StatsConstants.ValidStats.FoodDetector); } }
        public MyEntityStat MedicalDetector { get { return GetStat(StatsConstants.ValidStats.MedicalDetector); } }

        public MyEntityStat Hunger { get { return GetStat(StatsConstants.ValidStats.Hunger); } }
        public MyEntityStat Thirst { get { return GetStat(StatsConstants.ValidStats.Thirst); } }
        public MyEntityStat Stamina { get { return GetStat(StatsConstants.ValidStats.Stamina); } }
        public MyEntityStat Fatigue { get { return GetStat(StatsConstants.ValidStats.Fatigue); } }

        public MyEntityStat SurvivalEffects { get { return GetStat(StatsConstants.ValidStats.SurvivalEffects); } }
        public MyEntityStat DamageEffects { get { return GetStat(StatsConstants.ValidStats.DamageEffects); } }
        public MyEntityStat TemperatureEffects { get { return GetStat(StatsConstants.ValidStats.TemperatureEffects); } }
        public MyEntityStat DiseaseEffects { get { return GetStat(StatsConstants.ValidStats.DiseaseEffects); } }
        public MyEntityStat OtherEffects { get { return GetStat(StatsConstants.ValidStats.OtherEffects); } }

        public MyEntityStat WoundedTime { get { return GetStat(StatsConstants.ValidStats.WoundedTime); } }
        public MyEntityStat TemperatureTime { get { return GetStat(StatsConstants.ValidStats.TemperatureTime); } }
        public MyEntityStat WetTime { get { return GetStat(StatsConstants.ValidStats.WetTime); } }

        public MyEntityStat BodyEnergy { get { return GetStat(StatsConstants.ValidStats.BodyEnergy); } }
        public MyEntityStat BodyWater { get { return GetStat(StatsConstants.ValidStats.BodyWater); } }
        public MyEntityStat BodyPerformance { get { return GetStat(StatsConstants.ValidStats.BodyPerformance); } }
        public MyEntityStat BodyImmune { get { return GetStat(StatsConstants.ValidStats.BodyImmune); } }
        public MyEntityStat BodyCalories { get { return GetStat(StatsConstants.ValidStats.BodyCalories); } }        

        public MyEntityStat Stomach { get { return GetStat(StatsConstants.ValidStats.Stomach); } }
        public MyEntityStat Intestine { get { return GetStat(StatsConstants.ValidStats.Intestine); } }
        public MyEntityStat Bladder { get { return GetStat(StatsConstants.ValidStats.Bladder); } }

        public MyEntityStat BodyWeight { get { return GetStat(StatsConstants.ValidStats.BodyWeight); } }
        public MyEntityStat BodyMuscles { get { return GetStat(StatsConstants.ValidStats.BodyMuscles); } }
        public MyEntityStat BodyFat { get { return GetStat(StatsConstants.ValidStats.BodyFat); } }
       
        public MyEntityStat BodyProtein { get { return GetStat(StatsConstants.ValidStats.BodyProtein); } }
        public MyEntityStat BodyCarbohydrate { get { return GetStat(StatsConstants.ValidStats.BodyCarbohydrate); } }
        public MyEntityStat BodyLipids { get { return GetStat(StatsConstants.ValidStats.BodyLipids); } }
        public MyEntityStat BodyMinerals { get { return GetStat(StatsConstants.ValidStats.BodyMinerals); } }
        public MyEntityStat BodyVitamins { get { return GetStat(StatsConstants.ValidStats.BodyVitamins); } }

        public MyEntityStat RadiationTime { get { return GetStat(StatsConstants.ValidStats.RadiationTime); } }
        public MyEntityStat IntoxicationTime { get { return GetStat(StatsConstants.ValidStats.IntoxicationTime); } }
        
        public float CurrentPerformance
        {
            get
            {
                var percent = BodyPerformance.Value / BodyPerformance.MaxValue;
                return (percent - 0.5f) * 0.5f;
            }
        }

        public float CurrentBaseCargoMass
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier * 1000f;
            }
        }

        public float CurrentCargoMass
        {
            get
            {
                return CurrentBaseCargoMass;
            }
        }

        public float CurrentBaseCargoVolume
        {
            get
            {
                return MyAPIGateway.Session.SessionSettings.InventorySizeMultiplier * 0.4f;
            }
        }

        public float CurrentCargoVolume
        {
            get
            {
                return CurrentBaseCargoVolume;
            }
        }

        public float CurrentBodyFatMultiplier
        {
            get
            {
                if (BodyFat != null)
                {
                    var percent = BodyFat.Value / BodyFat.MaxValue;
                    return (percent - 0.5f) * 0.5f;
                }
                return 0;
            }
        }

        public float CurrentBodyMusclesMultiplier
        {
            get
            {
                if (BodyMuscles != null)
                {
                    var percent = BodyMuscles.Value / BodyMuscles.MaxValue;
                    return (percent - 0.5f) * 0.5f;
                }
                return 0;
            }
        }

        public StatsConstants.SurvivalEffects CurrentSurvivalEffects
        {
            get
            {
                return SurvivalEffects != null ? (StatsConstants.SurvivalEffects)((int)SurvivalEffects.Value) : StatsConstants.SurvivalEffects.None;
            }
            set
            {
                SurvivalEffects.Value = (int)value;
            }
        }

        public StatsConstants.DamageEffects CurrentDamageEffects
        {
            get
            {
                return DamageEffects != null ? (StatsConstants.DamageEffects)((int)DamageEffects.Value) : StatsConstants.DamageEffects.None;
            }
            set
            {
                DamageEffects.Value = (int)value;
            }
        }

        public StatsConstants.TemperatureEffects CurrentTemperatureEffects
        {
            get
            {
                return TemperatureEffects != null ? (StatsConstants.TemperatureEffects)((int)TemperatureEffects.Value) : StatsConstants.TemperatureEffects.None;
            }
            set
            {
                TemperatureEffects.Value = (int)value;
            }
        }

        public StatsConstants.DiseaseEffects CurrentDiseaseEffects
        {
            get
            {
                return DiseaseEffects != null ? (StatsConstants.DiseaseEffects)((int)DiseaseEffects.Value) : StatsConstants.DiseaseEffects.None;
            }
            set
            {
                DiseaseEffects.Value = (int)value;
            }
        }

        public StatsConstants.OtherEffects CurrentOtherEffects
        {
            get
            {
                return OtherEffects != null ? (StatsConstants.OtherEffects)((int)OtherEffects.Value) : StatsConstants.OtherEffects.None;
            }
            set
            {
                OtherEffects.Value = (int)value;
            }
        }

        public bool HasFoodThirstEffects
        {
            get
            {
                return IsValid && FoodDetector.HasAnyEffect();
            }
        }

        public bool HasHealthEffects
        {
            get
            {
                return IsValid && MedicalDetector.HasAnyEffect();
            }
        }

        public float FoodThirstEffectsTimeLeft
        {
            get
            {
                return FoodDetector.HasAnyEffect() ? FoodDetector.GetEffects().Max(x => x.Value.Duration * 1000) : 0;
            }
        }

        public float HealthEffectsTimeLeft
        {
            get
            {
                return MedicalDetector.HasAnyEffect() ? MedicalDetector.GetEffects().Max(x => x.Value.Duration * 1000) : 0;
            }
        }

        private DateTime lastFraskCreated;
        private DateTime lastRegenEffect;
        private PlayerData storeData = null;

        private PlayerBodyController controller;

        public PlayerCharacterEntity(IMyCharacter entity)
            : base(entity)
        {
            controller = new PlayerBodyController();
            controller.BodyEvent += Controller_BodyEvent;
            controller.BodyGetDisease += Controller_BodyGetDisease;
            controller.BodyCureDisease += Controller_BodyCureDisease;
            controller.InstantFoodEffect += Controller_InstantFoodEffect;
            controller.OverTimeFoodEffect += Controller_OverTimeFoodEffect;
            controller.BodyCureDamage += Controller_BodyCureDamage;
        }

        private void Controller_BodyCureDamage(PlayerBodyController sender, StatsConstants.DamageEffects damage)
        {
            if (StatsConstants.IsFlagSet(CurrentDamageEffects, damage))
                CurrentDamageEffects &= ~damage;
        }

        private void Controller_BodyCureDisease(PlayerBodyController sender, StatsConstants.DiseaseEffects disease)
        {
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, disease))
                CurrentDiseaseEffects &= ~disease;
        }

        private void DoFoodEffect(FoodEffectTarget target, float ammount)
        {
            if (ammount != 0)
            {
                MyEntityStat stat = null;
                switch (target)
                {
                    case FoodEffectTarget.Health:
                        stat = Health;
                        break;
                    case FoodEffectTarget.Stamina:
                        stat = Stamina;
                        break;
                    case FoodEffectTarget.Fatigue:
                        stat = Fatigue;
                        ammount *= -1;
                        break;
                    case FoodEffectTarget.Temperature:
                        stat = TemperatureTime;
                        break;
                }
                if (stat != null)
                {
                    if (ammount > 0)
                        stat.Increase(ammount, Player?.IdentityId);
                    else
                        stat.Decrease(ammount * -1, Player?.IdentityId);
                }
            }
        }

        private void Controller_OverTimeFoodEffect(PlayerBodyController sender, FoodEffectTarget target, float ammount)
        {
            DoFoodEffect(target, ammount);
        }

        private void Controller_InstantFoodEffect(PlayerBodyController sender, FoodEffectTarget target, float ammount)
        {
            DoFoodEffect(target, ammount);
        }

        private void Controller_BodyGetDisease(PlayerBodyController sender, StatsConstants.DiseaseEffects disease)
        {
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, disease))
                CurrentDiseaseEffects |= disease;
        }

        private void Controller_BodyEvent(PlayerBodyController sender, PlayerBodyController.BodyEventType eventType)
        {
            switch (eventType)
            {
                case PlayerBodyController.BodyEventType.FullIntestine:
                    DoShitYourself();
                    break;
                case PlayerBodyController.BodyEventType.FullBladder:
                    DoTakeAPiss();
                    break;
                case PlayerBodyController.BodyEventType.FullStomach:
                    DoVomit();
                    break;
            }
        }

        private void DoCleanYourself()
        {
            if (StatsConstants.IsFlagSet(CurrentOtherEffects, StatsConstants.OtherEffects.PoopOnClothes))
            {
                CurrentOtherEffects &= ~StatsConstants.OtherEffects.PoopOnClothes;
            }
            if (StatsConstants.IsFlagSet(CurrentOtherEffects, StatsConstants.OtherEffects.PeeOnClothes))
            {
                CurrentOtherEffects &= ~StatsConstants.OtherEffects.PeeOnClothes;
            }
        }

        private void DoBodyNeeds()
        {
            if (controller.CurrentBladderAmmount >= 0.075f)
                controller.DoEmptyBladder();
            if (controller.CurrentIntestineAmmount >= 0.5f)
                controller.DoEmptyIntestine();
        }

        private void DoShitYourself()
        {
            if (!StatsConstants.IsFlagSet(CurrentOtherEffects, StatsConstants.OtherEffects.PoopOnClothes))
            {
                CurrentOtherEffects |= StatsConstants.OtherEffects.PoopOnClothes;
            }
            controller.DoEmptyIntestine();
        }

        private void DoTakeAPiss()
        {
            if (!StatsConstants.IsFlagSet(CurrentOtherEffects, StatsConstants.OtherEffects.PeeOnClothes))
            {
                CurrentOtherEffects |= StatsConstants.OtherEffects.PeeOnClothes;
            }
            controller.DoEmptyBladder();
        }

        private void DoVomit()
        {
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Queasy))
            {
                CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Queasy;
            }
            controller.DoEmptyStomach();
        }

        private bool IsOnCryoChamber()
        {
            var block = GetControlledEntity();
            if (block != null)
            {
                var cryoBlock = block as IMyCryoChamber;
                if (cryoBlock != null)
                {
                    return cryoBlock.IsWorking;
                }
            }
            return false;
        }

        private static readonly string[] ValidBathroom = new string[] {
            "LargeBlockBathroomOpen",
            "LargeBlockBathroom",
            "LargeBlockToilet",
            "LargeBlockCryoChamber",
            "SmallBlockCryoChamber"
        };

        private bool IsOnValidBathroom()
        {
            var block = GetControlledEntity();
            if (block != null)
            {
                return ValidBathroom.Contains(block.BlockDefinition.SubtypeId);
            }
            return false;
        }

        private static readonly MyObjectBuilderType[] ValidRestBlock = new MyObjectBuilderType[] {
            typeof(MyObjectBuilder_CryoChamber),
            typeof(MyObjectBuilder_Cockpit)
        };

        private bool IsOnValidRestBlock()
        {
            var block = GetControlledEntity();
            if (block != null)
            {
                return ValidRestBlock.Contains(block.BlockDefinition.TypeId);
            }
            return false;
        }

        private static readonly string[] GoodRestBlock = new string[] {
            "LargeBlockCryoChamber",
            "SmallBlockCryoChamber",
            "LargeBlockBed"
        };

        private bool IsOnGoodRestBlock()
        {
            var block = GetControlledEntity();
            if (block != null)
            {
                return GoodRestBlock.Contains(block.BlockDefinition.SubtypeId);
            }
            return false;
        }

        private bool IsOnTreadmill()
        {
            var block = GetControlledEntity();
            if (block != null)
            {
                var cockpit = block as IMyCockpit;
                if (cockpit != null)
                {
                    return cockpit.BlockDefinition.SubtypeName.Contains("Treadmill");
                }
            }
            return false;
        }

        public void RemoveDiedRoutine()
        {
            hasDied = false;
        }

        protected override void OnBeginConfigureCharacter()
        {
            base.OnBeginConfigureCharacter();
            OxygenComponent = Entity.Components.Get<MyCharacterOxygenComponent>();
            if (StatComponent != null)
            {
                foreach (StatsConstants.ValidStats stat in Enum.GetValues(typeof(StatsConstants.ValidStats)).Cast<StatsConstants.ValidStats>())
                {
                    LoadPlayerStat(stat.ToString());
                }
                if (hasDied && storeData != null)
                {
                    SurvivalEffects.Value = storeData.GetStatValue(nameof(CurrentSurvivalEffects));
                    DamageEffects.Value = storeData.GetStatValue(nameof(CurrentDamageEffects));
                    TemperatureEffects.Value = storeData.GetStatValue(nameof(CurrentTemperatureEffects));
                    DiseaseEffects.Value = storeData.GetStatValue(nameof(CurrentDiseaseEffects));
                    OtherEffects.Value = storeData.GetStatValue(nameof(CurrentOtherEffects));
                    WoundedTime.Value = storeData.GetStatValue(nameof(WoundedTime));
                    TemperatureTime.Value = storeData.GetStatValue(nameof(TemperatureTime));
                    WetTime.Value = storeData.GetStatValue(nameof(WetTime));
                    Stamina.Value = storeData.GetStatValue(nameof(Stamina));
                    Fatigue.Value = storeData.GetStatValue(nameof(Fatigue));
                    if (ExtendedSurvivalSettings.Instance.HardModeEnabled)
                    {
                        if (!StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.ON_DEATH_NO_CHANGE_IF))
                        {
                            CurrentDamageEffects &= ~StatsConstants.ON_DEATH_REMOVE_DAMAGE;
                            CurrentDamageEffects |= StatsConstants.ON_DEATH_APPLY_DAMAGE;
                        }
                        if (CurrentDamageEffects != StatsConstants.DamageEffects.None)
                        {
                            Health.Value = Health.MaxValue * StatsConstants.DAMAGE_HEALTH_START_VALUE[(StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects)];
                        }
                    }
                    else
                    {
                        CurrentDamageEffects = StatsConstants.DamageEffects.None;
                    }
                    controller.CheckMinimalToLive();
                    hasDied = false;
                    storeData = null;
                }
            }
        }

        protected override void OnEndConfigureCharacter()
        {
            base.OnEndConfigureCharacter();

        }

        protected override void OnBeginResetConfiguration()
        {

            base.OnBeginResetConfiguration();
        }

        protected override void OnEndResetConfiguration()
        {
            base.OnEndResetConfiguration();
            OxygenComponent = null;
        }

        protected override void OnCharacterDied()
        {
            base.OnCharacterDied();
            enterUnderWater = false;
            hasDied = true;
            storeData = GetStoreData();
        }

        protected override void OnHealthChanged(float newValue, float oldValue, object statChangeData)
        {
            base.OnHealthChanged(newValue, oldValue, statChangeData);
            if (newValue < oldValue)
            {
                CheckHealthDamage(oldValue - newValue);
            }
            else
            {
                CheckHealthValue();
            }
        }

        private void CheckHealthValue()
        {
            var percentValue = Health.Value / Health.MaxValue;
            if (percentValue == 1)
            {
                if (StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.Contusion))
                {
                    CurrentDamageEffects &= ~StatsConstants.DamageEffects.Contusion;
                }
            }
        }

        private void CheckHealthDamage(float damage)
        {
            var percentValue = Health.Value / Health.MaxValue;
            var percentDamage = damage / Health.MaxValue;
            if (percentDamage >= 0.6f)
            {
                CurrentDamageEffects |= StatsConstants.DamageEffects.BrokenBones;
                CurrentDamageEffects &= ~StatsConstants.DamageEffects.DeepWounded;
                CurrentDamageEffects &= ~StatsConstants.DamageEffects.Wounded;
                CurrentDamageEffects &= ~StatsConstants.DamageEffects.Contusion;
            }
            else if (percentDamage >= 0.4f || percentValue <= 0.2f)
            {
                if (!StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                {
                    CurrentDamageEffects |= StatsConstants.DamageEffects.DeepWounded;
                    CurrentDamageEffects &= ~StatsConstants.DamageEffects.Wounded;
                    CurrentDamageEffects &= ~StatsConstants.DamageEffects.Contusion;
                }
            }
            else if (percentDamage >= 0.2f || percentValue <= 0.4f)
            {
                if (!StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones) &&
                    !StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                {
                    CurrentDamageEffects |= StatsConstants.DamageEffects.Wounded;
                    CurrentDamageEffects &= ~StatsConstants.DamageEffects.Contusion;
                }
            }
            else if (percentDamage >= 0.1f)
            {
                if (!StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones) &&
                    !StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) &&
                    !StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                {
                    CurrentDamageEffects |= StatsConstants.DamageEffects.Contusion;
                }
            }
        }

        private void CheckOxygenValue()
        {
            float percentValue;
            bool usingSuit = Entity.EnabledHelmet;
            if (IsUnderwater)
            {
                percentValue = usingSuit ?
                    enterUnderWaterO2Level :
                    0f;
            }
            else
            {
                percentValue = usingSuit ?
                    Entity.GetSuitGasFillLevel(ItensConstants.OXYGEN_ID.DefinitionId) :
                    Entity.OxygenLevel;
            }
            var checkValue = usingSuit ?
                new Vector2(0.05f, 0.2f) :
                new Vector2(0.1f, 0.8f);
            if (percentValue <= checkValue.X)
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Disoriented;
                CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Suffocation;
            }
            else if (percentValue <= checkValue.Y)
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Suffocation;
                CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Disoriented;
            }
            else
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Suffocation;
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Disoriented;
            }
        }

        private void CheckHungerValues()
        {
            var percentValue = Hunger.Value / Hunger.MaxValue;
            if (percentValue <= 0.05f)
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Hungry;
                CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Famished;
            }
            else if (percentValue <= 0.2f)
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Famished;
                CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Hungry;
            }
            else
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Famished;
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Hungry;
            }
        }

        private void CheckThirstValues()
        {
            var percentValue = Thirst.Value / Thirst.MaxValue;
            if (percentValue <= 0.05f)
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Thirsty;
                CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Dehydrating;
            }
            else if (percentValue <= 0.2f)
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Dehydrating;
                CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Thirsty;
            }
            else
            {
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Dehydrating;
                CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Thirsty;
            }
        }

        private void CheckConsumableHasSpecialAction()
        {
            if (lastRemovedIten != null)
            {
                var removedId = new MyDefinitionId(lastRemovedIten.Value.Key.Content.TypeId, lastRemovedIten.Value.Key.Content.SubtypeId);
                var removedUniqueId = new UniqueEntityId(removedId);
                if (removedId.TypeId.ToString().Contains("Consumable"))
                {
                    if (HasFoodThirstEffects && DateTime.Now > lastFraskCreated)
                    {
                        lastFraskCreated = DateTime.Now.AddMilliseconds(FoodThirstEffectsTimeLeft);
                        if (FoodConstants.FOOD_DEFINITIONS.ContainsKey(removedUniqueId))
                        {
                            controller.DoConsumeItem(FoodConstants.FOOD_DEFINITIONS[removedUniqueId]);
                            RefeshInterfaceStats();
                        }
                    }
                    if (HasHealthEffects && DateTime.Now > lastRegenEffect)
                    {
                        lastRegenEffect = DateTime.Now.AddMilliseconds(HealthEffectsTimeLeft);
                        if (MedicalConstants.MEDICAL_DEFINITIONS.ContainsKey(removedUniqueId))
                        {
                            controller.DoConsumeItem(MedicalConstants.MEDICAL_DEFINITIONS[removedUniqueId]);
                            RefeshInterfaceStats();
                        }
                    }
                    lastRemovedIten = null;
                }
            }
        }

        protected override void OnInventoryContentsRemoved(MyPhysicalInventoryItem item, MyFixedPoint ammount)
        {
            base.OnInventoryContentsRemoved(item, ammount);
            CheckConsumableHasSpecialAction();
        }

        public void CheckStatusValues()
        {
            if (IsValid)
            {
                foreach (var key in Stats.Keys)
                {
                    if (Stats[key].Value < Stats[key].MinValue)
                        Stats[key].Value = Stats[key].MinValue;
                }
                CheckOxygenValue();
            }
        }

        public void SetCharacterStatValue(string name, float value)
        {
            StatsConstants.ValidStats stat;
            if (Enum.TryParse(name, true, out stat))
            {
                switch (stat)
                {
                    case StatsConstants.ValidStats.Stamina:
                        Stamina.Value = value;
                        break;
                    case StatsConstants.ValidStats.Fatigue:
                        Fatigue.Value = value;
                        break;
                    case StatsConstants.ValidStats.WoundedTime:
                        WoundedTime.Value = value;
                        break;
                    case StatsConstants.ValidStats.TemperatureTime:
                        TemperatureTime.Value = value;
                        break;
                    case StatsConstants.ValidStats.WetTime:
                        WetTime.Value = value;
                        break;
                    case StatsConstants.ValidStats.BodyWater:
                        controller.WaterAmmount = value;
                        break;
                    case StatsConstants.ValidStats.BodyPerformance:
                        controller.CurrentPerformance = value;
                        break;
                    case StatsConstants.ValidStats.BodyImmune:
                        controller.CurrentImunity = value;
                        break;
                    case StatsConstants.ValidStats.Stomach:
                        if (value == 0)
                            controller.DoEmptyStomach();
                        break;
                    case StatsConstants.ValidStats.Intestine:
                        controller.IntestineVolume = value;
                        break;
                    case StatsConstants.ValidStats.Bladder:
                        controller.BladderVolume = value;
                        break;
                    case StatsConstants.ValidStats.BodyWeight:
                        controller.CurrentWeight = value;
                        break;
                    case StatsConstants.ValidStats.BodyMuscles:
                        controller.CurrentMuscle = value;
                        break;
                    case StatsConstants.ValidStats.BodyFat:
                        controller.CurrentFat = value;
                        break;
                    case StatsConstants.ValidStats.BodyCalories:
                        controller.CaloriesAmmount = value;
                        break;
                    case StatsConstants.ValidStats.BodyProtein:
                        controller.ProteinAmmount = value;
                        break;
                    case StatsConstants.ValidStats.BodyCarbohydrate:
                        controller.CarbohydrateAmmount = value;
                        break;
                    case StatsConstants.ValidStats.BodyLipids:
                        controller.LipidsAmmount = value;
                        break;
                    case StatsConstants.ValidStats.BodyVitamins:
                        controller.VitaminsAmmount = value;
                        break;
                    case StatsConstants.ValidStats.BodyMinerals:
                        controller.MineralsAmmount = value;
                        break;
                }
            }
        }

        public void ResetCharacterStats()
        {
            controller.ResetCharacterStats();
            SurvivalEffects.Value = SurvivalEffects.DefaultValue;
            DamageEffects.Value = DamageEffects.DefaultValue;
            TemperatureEffects.Value = TemperatureEffects.DefaultValue;
            DiseaseEffects.Value = DiseaseEffects.DefaultValue;
            OtherEffects.Value = OtherEffects.DefaultValue;
            WoundedTime.Value = WoundedTime.DefaultValue;
            TemperatureTime.Value = TemperatureTime.DefaultValue;
            WetTime.Value = WetTime.DefaultValue;
            Stamina.Value = Stamina.DefaultValue;
            Fatigue.Value = Fatigue.DefaultValue;
            Health.Value = Health.DefaultValue;
            RefeshInterfaceStats();
        }

        public void CheckValuesToDoDamage()
        {
            if (IsValid || CanTakeDamage)
            {
                try
                {
                    if (BodyWater.Value == 0)
                    {
                        Entity.Kill();
                    }
                }
                catch (Exception ex)
                {
                    ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
                }
            }
        }

        private TimeSpan lastTimeProcess = TimeSpan.Zero;

        public float GetSpendedStamina()
        {
            return _spendedStamina;
        }

        public void ClearSpendedStamina()
        {
            _spendedStamina = 0;
        }

        private float _spendedStamina = 0;
        public void AddSpendedStamina(float value)
        {
            _spendedStamina += value;
        }

        private void RefeshInterfaceStats()
        {
            Hunger.Value = Hunger.MaxValue * controller.CurrentHungerAmmount;
            Thirst.Value = Thirst.MaxValue * controller.CurrentThirstAmmount;
            Intestine.Value = Intestine.MaxValue * controller.CurrentIntestineAmmount;
            Stomach.Value = Stomach.MaxValue * controller.CurrentStomachAmmount;
            Bladder.Value = Bladder.MaxValue * controller.CurrentBladderAmmount;
            BodyWater.Value = BodyWater.MaxValue * controller.CurrentBodyWater;
            BodyEnergy.Value = BodyEnergy.MaxValue * controller.CurrentBodyEnergy;
            BodyWeight.Value = controller.CurrentWeight;
            BodyFat.Value = BodyFat.MaxValue * controller.FatFactor;
            BodyMuscles.Value = BodyMuscles.MaxValue * controller.MuscleFactor;
            BodyPerformance.Value = BodyPerformance.MaxValue * controller.CurrentPerformance;
            BodyImmune.Value = BodyImmune.MaxValue * controller.CurrentImunity;
            BodyCalories.Value = controller.CaloriesAmmount;
            BodyProtein.Value = controller.ProteinAmmount;
            BodyCarbohydrate.Value = controller.CarbohydrateAmmount;
            BodyLipids.Value = controller.LipidsAmmount;
            BodyMinerals.Value = controller.MineralsAmmount;
            BodyVitamins.Value = controller.VitaminsAmmount;
        }

        public void ProcessStatsCycle(int runCount)
        {
            if (!MyAPIGateway.Session.CreativeMode && IsValid)
            {
                if (!IsOnCryoChamber())
                {
                    if (controller.DoCicle(GetSpendedStamina()))
                    {
                        ClearSpendedStamina();
                        ProcessHealth();
                    }
                }
                else
                {
                    controller.DoRefreshDeltaTime();
                }
                if (IsOnValidBathroom())
                {
                    DoCleanYourself();
                    DoBodyNeeds();
                }
                RefeshInterfaceStats();
                if (runCount >= 300)
                {
                    ProcessEffectsTimers();
                    if (IsOnValidRestBlock() && !IsOnTreadmill())
                    {
                        ProcessRest(IsOnGoodRestBlock());
                    }
                    else
                    {
                        ProcessFatigue();
                    }
                    ProcessCargoMax();
                    CheckHungerValues();
                    CheckThirstValues();
                    CheckOxygenValue();
                    CheckHealthValue();
                    CheckValuesToDoDamage();
                }
            }
        }

        private void ProcessRest(bool goodRest)
        {
            if (Fatigue.Value > Fatigue.MinValue)
            {
                var valueToDecrease = StatsConstants.BASE_FATIGUE_DECREASE_FACTOR;
                if (goodRest)
                    valueToDecrease *= StatsConstants.BASE_FATIGUE_DECREASE_MULTIPLIER;
                Fatigue.Decrease(valueToDecrease, Player?.IdentityId);
            }
        }

        private float enterUnderWaterO2Level = 0;
        private float enterUnderWaterO2Consumption = 0;
        protected bool enterUnderWater = false;

        private float GasRefillRation
        {
            get
            {
                return MyCharacterOxygenComponent.GAS_REFILL_RATION * 1.25f; 
            }
        }

        public void ProcessUnderwater(int runcount)
        {
            if (IsUnderwater && !Entity.IsDead)
            {
                if (!enterUnderWater)
                {
                    enterUnderWater = true;
                    enterUnderWaterO2Level = OxygenComponent.GetGasFillLevel(MyCharacterOxygenComponent.OxygenId);
                    enterUnderWaterO2Consumption = (Entity.Definition as MyCharacterDefinition).OxygenConsumption / OxygenComponent.OxygenCapacity;
                }
                if (MyAPIGateway.Session.SessionSettings.EnableOxygen)
                {
                    if (Entity.EnabledHelmet)
                    {
                        if (enterUnderWaterO2Level > 0 && runcount % 60 == 0)
                            enterUnderWaterO2Level -= enterUnderWaterO2Consumption;
                    }
                    else if (runcount % 60 == 0 && CanTakeDamage)
                    {
                        Entity.DoDamage(NoO2DamageAmount, MyDamageType.Asphyxia, true);
                    }
                    if (enterUnderWaterO2Level < 0)
                        enterUnderWaterO2Level = 0;

                    if (OxygenComponent.SuitOxygenLevel < GasRefillRation)
                    {
                        if (InventoryObserver != Guid.Empty && ExtendedSurvivalCoreAPI.Registered)
                        {
                            var bottles = ExtendedSurvivalCoreAPI.GetItemInfoByGasId(InventoryObserver, ItensConstants.OXYGEN_ID.DefinitionId);
                            if (bottles != null && bottles.Length > 0)
                            {
                                foreach (var bottle in bottles)
                                {
                                    var item = Inventory.GetItemByID(bottle.ItemId);
                                    if (item != null)
                                    {
                                        var gasContainer = item.Value.Content as MyObjectBuilder_GasContainerObject;
                                        if (gasContainer != null)
                                        {
                                            var physicalItem = MyDefinitionManager.Static.GetPhysicalItemDefinition(gasContainer) as MyOxygenContainerDefinition;
                                            if (physicalItem.StoredGasId != ItensConstants.OXYGEN_ID.DefinitionId)
                                                continue;
                                            float gasAmount = gasContainer.GasLevel * physicalItem.Capacity;
                                            float transferredAmount = Math.Min(gasAmount, (1f - enterUnderWaterO2Level) * OxygenComponent.OxygenCapacity);
                                            gasContainer.GasLevel = Math.Max((gasAmount - transferredAmount) / physicalItem.Capacity, 0f);
                                            float trasnferredFillLevel = transferredAmount / OxygenComponent.OxygenCapacity;
                                            enterUnderWaterO2Level += trasnferredFillLevel;
                                            if (enterUnderWaterO2Level == 1f)
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    OxygenComponent.SuitOxygenLevel = enterUnderWaterO2Level;

                    if (enterUnderWaterO2Level <= 0 && CanTakeDamage)
                    {
                        if (runcount % 60 == 0)
                            Entity.DoDamage(NoO2DamageAmount, MyDamageType.Asphyxia, true);
                    }
                }
            }
            else
            {
                enterUnderWater = false;
            }
        }

        public float NoO2DamageAmount
        {
            get
            {
                return (Entity.Definition as MyCharacterDefinition).DamageAmountAtZeroPressure;
            }
        }

        public void ProcessActivityCycle()
        {
            if (!MyAPIGateway.Session.CreativeMode && IsValid)
            {
                RefreshWeatherInfo();
                ProcessStamina();
            }
        }

        private void ProcessFatigue()
        {
            if (Fatigue.Value < Fatigue.MaxValue)
            {
                var value = StatsConstants.BASE_FATIGUE_INCREASE_FACTOR;
                Fatigue.Increase(value, Player?.IdentityId);
            }
        }

        private void ProcessCargoMax()
        {
            if (Inventory != null)
            {
                if ((float)Inventory.MaxVolume != CurrentCargoVolume)
                {
                    var definition = new MyInventoryComponentDefinition
                    {
                        RemoveEntityOnEmpty = false,
                        MultiplierEnabled = false,
                        MaxItemCount = int.MaxValue,
                        Mass = CurrentCargoMass,
                        Volume = CurrentCargoVolume,
                        InputConstraint = new MyInventoryConstraint("PlayerInventory", null, false)
                    };
                    Inventory.Init(definition);
                }
            }
        }

        private void ProcessEffectsTimers()
        {
            var timePassed = lastTimeProcess != TimeSpan.Zero ? MyAPIGateway.Session.ElapsedPlayTime - lastTimeProcess : TimeSpan.Zero;
            lastTimeProcess = MyAPIGateway.Session.ElapsedPlayTime;
            if (Entity.Parent == null && currentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
            {
                switch (weatherEffect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        IncriseWetTimer(weatherEffect, weatherLevel, weatherIntensity);
                        break;
                    default:
                        DecresaseWetTimer();
                        break;
                }
            }
            else if (Entity.Parent == null && currentEnvironmentType == WeatherConstants.EnvironmentDetector.Underwater)
                IncriseUnderwaterWetTimer();
            else
                DecresaseWetTimer();
            CheckWetEffect();
            if (timePassed > TimeSpan.Zero)
            {
                IncDecWoundedTimer(timePassed);
                CheckWoundedEffect();
                IncDevTemperatureTimer(timePassed);
                CheckTemperatureEffect();
            }
            CheckIfGetDiseases();
        }

        private void CheckIfGetDiseases()
        {
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Pneumonia))
            {
                if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                {
                    var isWet = StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet);
                    var chance = StatsConstants.CHANCE_TO_GET_PNEUMONIA;
                    if (isWet)
                        chance += StatsConstants.PNEUMONIA_CHANCE_INCRISE;
                    float temperatureMultiplier = 1f - (TemperatureTime.CurrentRatio * 2);
                    if (temperatureMultiplier > 0 && CheckChance(chance * temperatureMultiplier))
                    {
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Pneumonia;
                    }
                }
            }
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
            {
                if (TemperatureTime.Value <= TemperatureTime.MinValue)
                {
                    CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Hypothermia;
                }
            }
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
            {
                if (TemperatureTime.Value >= TemperatureTime.MaxValue)
                {
                    CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Hyperthermia;
                }
            }
            CheckStomach();
            CheckIntestine();
            CheckBladder();
            CheckStarvation();
            CheckDehydration();
            CheckFatigue();
            CheckWeight();
        }

        private void CheckStomach()
        {
            var percent = Stomach.Value / Stomach.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.StomachBursting))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.FullStomach;
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.StomachBursting;
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.StomachBursting;
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullStomach))
                {
                    if (percent >= 0.75f)
                    {
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.FullStomach;
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.FullStomach;
                    }
                }
            }
        }

        private void CheckIntestine()
        {
            var percent = Intestine.Value / Intestine.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.GutBurst))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.FullGut;
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.GutBurst;
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.GutBurst;
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullGut))
                {
                    if (percent >= 0.75f)
                    {
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.FullGut;
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.FullGut;
                    }
                }
            }
        }

        private void CheckBladder()
        {
            var percent = Bladder.Value / Bladder.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.BladderBurst))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.9f)
                    {
                        needToCheckStarvation = false;
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.FullBladder;
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.BladderBurst;
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.9f)
                {
                    CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.BladderBurst;
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.FullBladder))
                {
                    if (percent >= 0.75f)
                    {
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.FullBladder;
                    }
                }
                else
                {
                    if (percent < 0.75f)
                    {
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.FullBladder;
                    }
                }
            }
        }

        private void CheckFatigue()
        {
            var percent = Fatigue.Value / Fatigue.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.ExtremelyTired))
            {
                if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.8f)
                    {
                        needToCheckStarvation = false;
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Tired;
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.ExtremelyTired;
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent < 0.8f)
                {
                    CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.ExtremelyTired;
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Tired))
                {
                    if (percent >= 0.6f)
                    {
                        CurrentSurvivalEffects |= StatsConstants.SurvivalEffects.Tired;
                    }
                }
                else
                {
                    if (percent < 0.6f)
                    {
                        CurrentSurvivalEffects &= ~StatsConstants.SurvivalEffects.Tired;
                    }
                }
            }
        }

        private void SetWeightStatus(StatsConstants.DiseaseEffects effect)
        {
            ClearWeightStatus();
            CurrentDiseaseEffects |= effect;
        }

        private void ClearWeightStatus()
        {
            CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Obesity;
            CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.SevereObesity;
            CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Rickets;
            CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.SevereRickets;
        }

        private void CheckWeight()
        {
            var height = 1.8f;
            var bmi = BodyWeight.Value / (height * height);
            if (bmi >= 40)
            {
                SetWeightStatus(StatsConstants.DiseaseEffects.SevereObesity);
            }
            else if (bmi >= 30)
            {
                SetWeightStatus(StatsConstants.DiseaseEffects.Obesity);
            }
            else if (bmi <= 17)
            {
                SetWeightStatus(StatsConstants.DiseaseEffects.Rickets);
            }
            else if (bmi <= 14)
            {
                SetWeightStatus(StatsConstants.DiseaseEffects.SevereRickets);
            }
            else
            {
                ClearWeightStatus();
            }
        }

        private void CheckDehydration()
        {
            var percent = BodyWater.Value / BodyWater.MaxValue;
            var needToCheckDehydration = true;
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
            {
                if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckDehydration = false;
                        CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Dehydration;
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.SevereDehydration;
                    }
                }
            }
            else
            {
                needToCheckDehydration = false;
                if (percent > 0.05f)
                {
                    CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.SevereDehydration;
                    needToCheckDehydration = true;
                }
            }
            if (needToCheckDehydration)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                {
                    if (percent <= 0.25f)
                    {
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Dehydration;
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Dehydration;
                    }
                }
            }
        }

        private void CheckStarvation()
        {
            var percent = BodyEnergy.Value / BodyEnergy.MaxValue;
            var needToCheckStarvation = true;
            if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
            {
                if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.05f)
                    {
                        needToCheckStarvation = false;
                        CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Starvation;
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.SevereStarvation;
                    }
                }
            }
            else
            {
                needToCheckStarvation = false;
                if (percent > 0.05f)
                {
                    CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.SevereStarvation;
                    needToCheckStarvation = true;
                }
            }
            if (needToCheckStarvation)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                {
                    if (percent <= 0.25f)
                    {
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Starvation;
                    }
                }
                else
                {
                    if (percent > 0.25f)
                    {
                        CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Starvation;
                    }
                }
            }
        }

        private void CheckTemperatureEffect()
        {
            if (TemperatureTime.Value >= StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
            {
                CurrentTemperatureEffects |= StatsConstants.TemperatureEffects.OnFire;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Overheating;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Cold;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Frosty;
            }
            else if (TemperatureTime.Value >= StatsConstants.MIN_TO_GET_EFFECT_OVERHITING)
            {
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.OnFire;
                CurrentTemperatureEffects |= StatsConstants.TemperatureEffects.Overheating;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Cold;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Frosty;
            }
            else if (TemperatureTime.Value <= StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
            {
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.OnFire;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Overheating;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Cold;
                CurrentTemperatureEffects |= StatsConstants.TemperatureEffects.Frosty;
            }
            else if (TemperatureTime.Value <= StatsConstants.MIN_TO_GET_EFFECT_COLD)
            {
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.OnFire;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Overheating;
                CurrentTemperatureEffects |= StatsConstants.TemperatureEffects.Cold;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Frosty;
            }
            else
            {
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.OnFire;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Overheating;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Cold;
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Frosty;
            }
        }

        private void IncDevTemperatureTimer(TimeSpan timePassed)
        {
            var temperature = currentTemperature.Y;
            var finalValue = (float)timePassed.TotalMilliseconds;
            if (temperature > HungerConstants.THIRST_TEMPERATURE_RANGE ||
                temperature < HungerConstants.HUNGER_TEMPERATURE_RANGE)
            {
                if (temperature > HungerConstants.THIRST_HARD_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_THIRST_FACTOR.Y;
                else if (temperature > HungerConstants.THIRST_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_THIRST_FACTOR.X;
                else if (temperature < HungerConstants.HUNGER_HARD_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_HUNGER_FACTOR.Y;
                else if (temperature < HungerConstants.HUNGER_TEMPERATURE_RANGE)
                    finalValue *= HungerConstants.TEMPERATURE_HUNGER_FACTOR.X;
                if (temperature > HungerConstants.THIRST_TEMPERATURE_RANGE)
                {
                    finalValue *= TemperatureTime.Value < 0 ? StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER : 1;
                    bool isHardTemperature = temperature > HungerConstants.THIRST_HARD_TEMPERATURE_RANGE;
                    if (isHardTemperature || TemperatureTime.Value < StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
                        TemperatureTime.Increase(finalValue, null);
                }
                else
                {
                    finalValue *= TemperatureTime.Value > 0 ? StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER : 1;
                    bool isHardTemperature = temperature < HungerConstants.HUNGER_HARD_TEMPERATURE_RANGE;
                    if (isHardTemperature || TemperatureTime.Value > StatsConstants.MIN_TO_GET_EFFECT_FROSTY)
                        TemperatureTime.Decrease(finalValue, null);
                }
            }
            else
            {
                if (TemperatureTime.Value < 0)
                {
                    if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
                        finalValue *= StatsConstants.HYPOTHERMIA_CHANGE_MULTIPLIER;
                    finalValue *= StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER;
                    TemperatureTime.Increase(finalValue, null);
                    if (TemperatureTime.Value > 0)
                        TemperatureTime.Value = 0;
                }
                else if (TemperatureTime.Value > 0)
                {
                    if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                        finalValue *= StatsConstants.HYPERTHERMIA_CHANGE_MULTIPLIER;
                    finalValue *= StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER;
                    TemperatureTime.Decrease(finalValue, null);
                    if (TemperatureTime.Value < 0)
                        TemperatureTime.Value = 0;
                }
            }
            if (TemperatureTime.Value <= 0)
            {
                if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                    CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Hyperthermia;
            }
            if (TemperatureTime.Value >= 0)
            {
                if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
                    CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Hypothermia;
            }
        }

        private void IncDecWoundedTimer(TimeSpan timePassed)
        {
            if (StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.Wounded) ||
                StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded) ||
                StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
            {
                if (WoundedTime.Value < WoundedTime.MaxValue)
                {
                    var maxDamageEffect = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects);
                    var finalTimer = (float)timePassed.TotalMilliseconds;
                    WoundedTime.Increase(finalTimer * StatsConstants.TIME_MULTIPLIER_FACTOR[maxDamageEffect], null);
                }
            }
            else
            {
                WoundedTime.Value = 0;
            }
        }


        private void CheckWoundedEffect()
        {
            if (WoundedTime.Value >= WoundedTime.MaxValue &&
                !StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
            {
                CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Infected;
            }
        }

        private void CheckWetEffect()
        {
            if (WetTime.Value >= StatsConstants.MIN_TO_GET_EFFECT_WET)
                CurrentTemperatureEffects |= StatsConstants.TemperatureEffects.Wet;
            else
                CurrentTemperatureEffects &= ~StatsConstants.TemperatureEffects.Wet;
        }

        private void DecresaseWetTimer()
        {

            if (WetTime.Value > 0)
            {
                var decValue = StatsConstants.BASE_REMOVE_WET_FACTOR;
                if (Entity.EnvironmentOxygenLevel == 0)
                    decValue += StatsConstants.BASE_REMOVE_WET_FACTOR_NOO2_BONUS;
                if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
                    decValue *= StatsConstants.BASE_REMOVE_WET_FACTOR_IN_ATM;
                else if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.ShipOrStation)
                    decValue *= StatsConstants.BASE_REMOVE_WET_FACTOR_IN_SHIP;
                else if (currentEnvironmentType == WeatherConstants.EnvironmentDetector.Space)
                    decValue *= StatsConstants.BASE_REMOVE_WET_FACTOR_IN_VOID;
                WetTime.Decrease(decValue, null);
            }
        }

        private void IncriseUnderwaterWetTimer()
        {
            if (WetTime.Value < WetTime.MaxValue)
            {
                float finalValue = StatsConstants.BASE_WET_FACTOR_UNDERWATER;
                WetTime.Increase(finalValue, null);                
            }
        }

        private void IncriseWetTimer(WeatherConstants.WeatherEffects effect, WeatherConstants.WeatherEffectsLevel level, float intensity)
        {
            if (WetTime.Value < WetTime.MaxValue)
            {
                float finalValue = 0;
                switch (effect)
                {
                    case WeatherConstants.WeatherEffects.Rain:
                        finalValue += StatsConstants.BASE_WET_FACTOR_RAIN * (1 + intensity);
                        finalValue *= level == WeatherConstants.WeatherEffectsLevel.Light ? StatsConstants.RAIN_WET_FACTOR.X : StatsConstants.RAIN_WET_FACTOR.Y;
                        break;
                    case WeatherConstants.WeatherEffects.Thunderstorm:
                        finalValue += StatsConstants.BASE_WET_FACTOR_THUNDER * (1 + intensity);
                        finalValue *= level == WeatherConstants.WeatherEffectsLevel.Light ? StatsConstants.THUNDER_WET_FACTOR.X : StatsConstants.THUNDER_WET_FACTOR.Y;
                        break;
                }
                WetTime.Increase(finalValue, null);
            }
        }

        private void ProcessHealth()
        {
            var maxDamage = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects);
            var finalRegen = StatsConstants.BASE_HEALTH_REGEN_FACTOR;
            var maxRegen = 1f;
            if (maxDamage != StatsConstants.DamageEffects.None)
            {
                var regenAffect = StatsConstants.DAMAGE_HEALTH_REGEN_FACTOR[maxDamage];
                finalRegen *= regenAffect.X;
                maxRegen = regenAffect.Y;
            }
            var currentStatusValue = Health.Value / Health.MaxValue;
            if (currentStatusValue < maxRegen)
            {
                Health.Increase(finalRegen, null);
            }
        }

        private int GetTotalDiseaseMultiplier()
        {
            int totalMultiplier = 0;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dysentery))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Infected))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Pneumonia))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Poison))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Dehydration))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereDehydration))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Starvation))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereStarvation))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypolipidemia))
                totalMultiplier++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                totalMultiplier += 2;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                totalMultiplier +=  2;
            if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Disoriented))
                totalMultiplier ++;
            if (StatsConstants.IsFlagSet(CurrentSurvivalEffects, StatsConstants.SurvivalEffects.Suffocation))
                totalMultiplier +=  2;
            return totalMultiplier;
        }

        private float GetMaxStamina()
        {
            var maxStamina = Stamina.MaxValue;
            float totalStaminaToRemove = StatsConstants.BASE_TOTAL_STAMINA_REMOVE_PER_STACK * GetTotalDiseaseMultiplier();
            if (totalStaminaToRemove > 0)
                maxStamina *= 1 - (Math.Min(totalStaminaToRemove, StatsConstants.MAX_STAMINA_REMOVE_WHEN_STACK));
            return maxStamina;
        }

        private void ProcessStamina()
        {
            var value = GetStaminaToDecrese();
            var maxStamina = GetMaxStamina();
            if (IsCharacterMoving() || IsCharacterUsingTool() || IsOnTreadmill())
            {
                AddSpendedStamina(value);
                if (Stamina.Value > 0)
                {
                    Stamina.Decrease(value, Player?.IdentityId);
                }
                else
                {
                    var staminaDamage = StatsConstants.BASE_STAMINA_DAMAGE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DamageMultiplier;
                    if (staminaDamage > 0 && CanTakeDamage)
                        Entity.DoDamage(staminaDamage, MyDamageType.Environment, true);
                }
                if (Fatigue.Value < Fatigue.MaxValue)
                {
                    if (IsOnTreadmill())
                        value *= StatsConstants.BASE_FATIGUE_INCREASE_MULTIPLIER;
                    Fatigue.Increase(value, Player?.IdentityId);
                }
            }
            else
            {
                if (Stamina.Value < maxStamina)
                {
                    Stamina.Increase(GetStaminaToIncrease(), Player?.IdentityId);
                }
            }
            if (Stamina.Value > maxStamina)
                Stamina.Value = maxStamina;
        }

        private float GetStaminaRuningMultiplier()
        {
            return Math.Min(1, StatsConstants.BASE_RUNING_MULTIPLIER * ExtendedSurvivalSettings.Instance.StaminaSettings.RuningDrainMultiplier);
        }

        private float GetStaminaTreadmillMultiplier()
        {
            return Math.Min(1, StatsConstants.BASE_TREADMILL_MULTIPLIER * ExtendedSurvivalSettings.Instance.StaminaSettings.TreadmillDrainMultiplier);
        }

        private float GetBaseStaminaToDecrease()
        {
            if (IsCharacterUsingTool() && !IsCharacterMoving())
            {
                return StatsConstants.BASE_TOOL_STAMINA_DECREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.ToolsDrainMultiplier;
            }
            else
            {
                return StatsConstants.BASE_STAMINA_DECREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DrainMultiplier;
            }
        }

        private float GetStaminaToDecrese()
        {
            var finalValue = GetBaseStaminaToDecrease();
            if (ExtendedSurvivalSettings.Instance.StaminaSettings.IncriseStaminaDrainWithTemperature)
            {
                var maxTemperatureEffect = CurrentTemperatureEffects;
                maxTemperatureEffect &= ~StatsConstants.TemperatureEffects.Wet;
                if (StatsConstants.TEMPERATURE_STAMINA_CONSUME_FACTOR.ContainsKey(maxTemperatureEffect))
                    finalValue *= StatsConstants.TEMPERATURE_STAMINA_CONSUME_FACTOR[maxTemperatureEffect];
            }
            if (ExtendedSurvivalSettings.Instance.StaminaSettings.IncriseStaminaDrainWithBodyFat && CurrentBodyFatMultiplier > 0)
            {

            }
            if (IsCharacterSprinting())
            {
                finalValue *= GetStaminaRuningMultiplier();
            }
            if (IsOnTreadmill())
            {
                finalValue *= GetStaminaTreadmillMultiplier();
            }
            return finalValue;
        }

        private float GetStaminaToIncrease()
        {
            var finalValue = StatsConstants.BASE_STAMINA_INCREASE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.GainMultiplier;
            if (ExtendedSurvivalSettings.Instance.StaminaSettings.DecreaseStaminaGainWithDamage)
            {
                var maxDamageEffect = (StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects);
                if (StatsConstants.DAMAGE_STAMINA_REGEN_FACTOR.ContainsKey(maxDamageEffect))
                    finalValue *= StatsConstants.DAMAGE_STAMINA_REGEN_FACTOR[maxDamageEffect];
            }
            var activeSurvivalEffects = CurrentSurvivalEffects.GetFlags();
            if (activeSurvivalEffects.Any())
            {
                var effectWeight = activeSurvivalEffects.Sum(x => StatsConstants.GetSurvivalEffectFeelingLevel(x));
                finalValue *= Math.Max(1 - (0.1f * effectWeight), 0.3f);
            }
            return finalValue;
        }

        public void PlayerHealthRecharging()
        {
            var maxLife = MAX_HEALTH_REGEN_AT_SURVIVAL_KIT * Health.MaxValue;
            if (lastHealthChanged.X > maxLife)
            {
                if (lastHealthChanged.Y > maxLife)
                    Health.Value = lastHealthChanged.Y;
                else
                    Health.Value = maxLife;
            }
        }

        public void LoadStoreData(PlayerData storeData)
        {
            try
            {
                if (!IsValid)
                    ConfigureCharacter(Entity);
                if (IsValid)
                {
                    if (storeData != null)
                    {
                        controller.LoadPlayerData(storeData);
                        SurvivalEffects.Value = storeData.GetStatValue(nameof(CurrentSurvivalEffects));
                        DamageEffects.Value = storeData.GetStatValue(nameof(CurrentDamageEffects));
                        TemperatureEffects.Value = storeData.GetStatValue(nameof(CurrentTemperatureEffects));
                        DiseaseEffects.Value = storeData.GetStatValue(nameof(CurrentDiseaseEffects));
                        OtherEffects.Value = storeData.GetStatValue(nameof(CurrentOtherEffects));
                        WoundedTime.Value = storeData.GetStatValue(nameof(WoundedTime));
                        TemperatureTime.Value = storeData.GetStatValue(nameof(TemperatureTime));
                        WetTime.Value = storeData.GetStatValue(nameof(WetTime));
                        Stamina.Value = storeData.GetStatValue(nameof(Stamina));
                        Fatigue.Value = storeData.GetStatValue(nameof(Fatigue));
                        Health.Value = storeData.GetStatValue(nameof(Health));
                        controller.CheckMinimalToLive();
                    }
                    else
                    {
                        ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), "storeData null");
                    }
                }
                else
                {
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), "LoadStoreData Not Valid Player");
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
            }
        }

        public PlayerData GetStoreData()
        {
            try
            {
                if (!IsValid)
                    ConfigureCharacter(Entity);
                if (IsValid)
                {
                    var data = new PlayerData
                    {
                        PlayerId = PlayerId,
                        SteamPlayerId = Player?.SteamUserId ?? 0
                    };
                    controller.SavePlayerData(data);
                    data.SetStatValue(nameof(CurrentSurvivalEffects), (int)CurrentSurvivalEffects);
                    data.SetStatValue(nameof(CurrentDamageEffects), (int)CurrentDamageEffects);
                    data.SetStatValue(nameof(CurrentTemperatureEffects), (int)CurrentTemperatureEffects);
                    data.SetStatValue(nameof(CurrentDiseaseEffects), (int)CurrentDiseaseEffects);
                    data.SetStatValue(nameof(CurrentOtherEffects), (int)CurrentOtherEffects);
                    data.SetStatValue(nameof(WoundedTime), WoundedTime.Value);
                    data.SetStatValue(nameof(TemperatureTime), TemperatureTime.Value);
                    data.SetStatValue(nameof(WetTime), WetTime.Value);
                    data.SetStatValue(nameof(Stamina), Stamina.Value);
                    data.SetStatValue(nameof(Fatigue), Fatigue.Value);
                    data.SetStatValue(nameof(Health), Health.Value);
                    return data;
                }
                else
                {
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), "GetStoreData Not Valid Player");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
                return null;
            }
        }

        public PlayerSendData GetData()
        {
            try
            {
                if (!IsValid)
                    ConfigureCharacter(Entity);
                if (IsValid)
                {
                    return new PlayerSendData()
                    {
                        EntityId = Entity.EntityId,
                        PlayerId = PlayerId,
                        SteamPlayerId = Player?.SteamUserId ?? 0,
                        HasDied = Entity.IsDead,
                        LastTimeDied = lastTimeDead,
                        Temperature = currentTemperature,
                        NeedToUpdateLocal = MyAPIGateway.Utilities.IsDedicated || !MyAPIGateway.Session.IsServer,
                        O2Level = OxygenComponent.SuitOxygenLevel,
                        CurrentCargoMass = CurrentCargoMass,
                        CurrentCargoVolume = CurrentCargoVolume
                    };
                }
                else
                {
                    ExtendedSurvivalStatsLogging.Instance.LogWarning(GetType(), "GetData Not Valid Player");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalStatsLogging.Instance.LogError(GetType(), ex);
                return null;
            }
        }

    }

}