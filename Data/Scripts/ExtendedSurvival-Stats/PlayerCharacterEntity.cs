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

namespace ExtendedSurvival
{

    public delegate void OnAtributeEvent(AtributeInformation atribute);
    public delegate void OnAtributeChangeEvent(AtributeInformation atribute, float oldValue, float finalValue);

    public class AtributeInformation
    {

        public BaseCharacterEntity Owner { get; set; }

        public bool freeze = false;
        public float baseValue = 0;
        public bool hasMinValue = false;
        public float minValue = 0;
        public bool hasMaxValue = false;
        public float maxValue = 0;

        public float currentValue;
        public float bonusValue;

        public OnAtributeEvent onMinValue;
        public OnAtributeEvent onMaxValue;
        public OnAtributeChangeEvent onValueChange;

        public virtual float GetCurrentValue()
        {
            return Math.Min(currentValue, GetFinalValue());
        }

        public virtual float GetFinalValue()
        {
            var final = baseValue + bonusValue;
            if (hasMinValue)
                final = Math.Max(final, minValue);
            if (hasMaxValue)
                final = Math.Min(final, maxValue);
            return final;
        }

        protected virtual void AfterChangeCurrentValue(bool hidden = false)
        {
            if (hasMinValue)
            {
                currentValue = Math.Max(minValue, currentValue);
                if (currentValue == minValue && onMinValue != null)
                {
                    onMinValue(this);
                }
            }
            if (hasMaxValue && currentValue == maxValue && onMaxValue != null)
            {
                onMaxValue(this);
            }
        }

        protected virtual void DoSetCurrentValue(float value, bool hidden = false)
        {
            if (freeze)
                return;
            var oldValue = value;
            currentValue = Math.Min(value, GetFinalValue());
            if (onValueChange != null)
                onValueChange(this, oldValue, currentValue);
            AfterChangeCurrentValue(hidden);
        }

        public virtual void SetCurrentValue(float value)
        {
            DoSetCurrentValue(value);
        }

        public virtual void DoChangeCurrentValue(float value, bool hidden = false)
        {
            if (freeze)
                return;
            var oldValue = value;
            currentValue = Math.Min(currentValue + value, GetFinalValue());
            if (onValueChange != null)
                onValueChange(this, oldValue, currentValue);
            AfterChangeCurrentValue(hidden);
        }

        public virtual void ChangeCurrentValue(float value)
        {
            DoChangeCurrentValue(value);
        }

        public virtual void InitializeValues()
        {
            currentValue = GetFinalValue();
        }

        public bool IsFull
        {
            get
            {
                return hasMaxValue && GetCurrentValue().Equals(GetFinalValue());
            }
        }

    }

    public delegate void OnStatEvent(StatInformation stat);
    public delegate void OnStatChangeEvent(StatInformation stat, float oldValue, float finalValue);

    [System.Serializable]
    public class StatInformation
    {

        public BaseCharacterEntity Owner { get; set; }

        public bool freeze = false;
        public float baseValue = 0;
        public bool hasMinValue = false;
        public float minValue = 0;
        public bool hasMaxValue = false;
        public float maxValue = 0;
        public bool regenerate = false;
        public float regenerateFactor = 0;
        public float ragenerateInterval = 0;
        public bool canBeInterrupted = true;
        public float interruptInterval = 0;

        public float currentValue;
        public float bonusValue;

        public OnStatEvent onMinValue;
        public OnStatEvent onMaxValue;
        public OnStatChangeEvent onValueChange;

        private float lastInterrupt;
        private float lastRegenerateEvent;

        public virtual float GetCurrentValue()
        {
            return Math.Min(currentValue, GetFinalValue());
        }

        public virtual float GetFinalValue()
        {
            var final = baseValue + bonusValue;
            if (hasMinValue)
                final = Math.Max(final, minValue);
            if (hasMaxValue)
                final = Math.Min(final, maxValue);
            return final;
        }

        protected virtual void AfterChangeCurrentValue(bool hidden = false)
        {
            if (hasMinValue)
            {
                currentValue = Math.Max(minValue, currentValue);
                if (currentValue == minValue && onMinValue != null)
                {
                    onMinValue(this);
                }
            }
            if (hasMaxValue && currentValue == maxValue && onMaxValue != null)
            {
                onMaxValue(this);
            }
            if (!hidden)
                lastInterrupt = DateTime.Now.Ticks;
        }

        protected virtual void DoSetCurrentValue(float value, bool hidden = false)
        {
            if (freeze)
                return;
            var oldValue = value;
            currentValue = Math.Min(value, GetFinalValue());
            if (onValueChange != null)
                onValueChange(this, oldValue, currentValue);
            AfterChangeCurrentValue(hidden);
        }

        public virtual void SetCurrentValue(float value)
        {
            DoSetCurrentValue(value);
        }

        public virtual void DoChangeCurrentValue(float value, bool hidden = false)
        {
            if (freeze)
                return;
            var oldValue = value;
            currentValue = Math.Min(currentValue + value, GetFinalValue());
            if (onValueChange != null)
                onValueChange(this, oldValue, currentValue);
            AfterChangeCurrentValue(hidden);
        }

        public virtual void ChangeCurrentValue(float value)
        {
            DoChangeCurrentValue(value);
        }

        public virtual void InitializeValues()
        {
            currentValue = GetFinalValue();
        }

        public bool IsFull
        {
            get
            {
                return GetCurrentValue().Equals(GetFinalValue());
            }
        }

        protected virtual void DoRegenerate()
        {
            if (regenerate && !IsFull)
            {
                if (canBeInterrupted && (DateTime.Now.Ticks - lastInterrupt) < interruptInterval)
                    return;
                if (DateTime.Now.Ticks - lastRegenerateEvent > ragenerateInterval)
                {
                    lastRegenerateEvent = DateTime.Now.Ticks;
                    DoChangeCurrentValue(regenerateFactor, true);
                }
            }
        }

        public virtual void DoUpdate()
        {
            DoRegenerate();
        }

    }

    public delegate void OnEffectEvent(EffectInformation effect);

    public class EffectInformation
    {

        public BaseCharacterEntity Owner { get; set; }

        public long createdTime = DateTime.Now.Ticks;
        public bool autoRemove = false;
        public long removeAt = 0;

        public OnEffectEvent onNeedRemove;

        protected long lifeTime;

        public virtual void DoUpdate()
        {
            lifeTime = DateTime.Now.Ticks - createdTime;
            if (autoRemove)
            {
                if (lifeTime > removeAt && onNeedRemove != null)
                    onNeedRemove(this);
            }
        }

    }



    public class PlayerCharacterEntity : BaseCharacterEntity
    {

        private const float MAX_HEALTH_REGEN_AT_SURVIVAL_KIT = 0.5f;

        public MyCharacterOxygenComponent OxygenComponent { get; private set; }

        public MyEntityStat Hunger { get; private set; }
        public MyEntityStat Thirst { get; private set; }
        public MyEntityStat Stamina { get; private set; }

        public MyEntityStat IntakeBodyFood { get; private set; }
        public MyEntityStat IntakeBodyWater { get; private set; }
        public MyEntityStat BodyEnergy { get; private set; }
        public MyEntityStat BodyWater { get; private set; }

        public MyEntityStat IntakeCarbohydrates { get; private set; }
        public MyEntityStat IntakeProtein { get; private set; }
        public MyEntityStat IntakeLipids { get; private set; }
        public MyEntityStat IntakeVitamins { get; private set; }
        public MyEntityStat IntakeMinerals { get; private set; }
        public MyEntityStat BodyMuscles { get; private set; }
        public MyEntityStat BodyFat { get; private set; }
        public MyEntityStat BodyPerformance { get; private set; }

        public MyEntityStat SurvivalEffects { get; private set; }
        public MyEntityStat DamageEffects { get; private set; }
        public MyEntityStat TemperatureEffects { get; private set; }
        public MyEntityStat DiseaseEffects { get; private set; }
        public MyEntityStat OtherEffects { get; private set; }

        public MyEntityStat WoundedTime { get; private set; }
        public MyEntityStat TemperatureTime { get; private set; }
        public MyEntityStat WetTime { get; private set; }

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
                return GetValueWithBodyMuscleMultiplier(CurrentBaseCargoMass);
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
                return GetValueWithBodyMuscleMultiplier(CurrentBaseCargoVolume);
            }
        }

        public float CurrentBodyFatMultiplier
        {
            get
            {
                var percent = BodyFat.Value / BodyFat.MaxValue;
                return (percent - 0.5f) * 0.5f;
            }
        }

        public float CurrentBodyMusclesMultiplier
        {
            get
            {
                var percent = BodyMuscles.Value / BodyMuscles.MaxValue;
                return (percent - 0.5f) * 0.5f;
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

        protected override bool GetIsValid()
        {
            return Thirst != null &&
                Hunger != null &&
                Stamina != null &&
                Health != null &&
                SurvivalEffects != null &&
                DamageEffects != null &&
                TemperatureEffects != null &&
                DiseaseEffects != null &&
                OtherEffects != null &&
                WoundedTime != null &&
                TemperatureTime != null &&
                WetTime != null &&
                IntakeBodyFood != null &&
                IntakeBodyWater != null &&
                BodyEnergy != null &&
                BodyWater != null &&
                IntakeCarbohydrates != null &&
                IntakeProtein != null &&
                IntakeLipids != null &&
                IntakeVitamins != null &&
                IntakeMinerals != null &&
                BodyMuscles != null &&
                BodyFat != null &&
                BodyPerformance != null;
        }

        public bool HasFoodThirstEffects
        {
            get
            {
                return IsValid && (Hunger.HasAnyEffect() || Thirst.HasAnyEffect());
            }
        }

        public float FoodThirstEffectsTimeLeft
        {
            get
            {
                return Math.Max(
                    Hunger.HasAnyEffect() ? Hunger.GetEffects().Max(x => x.Value.Duration * 1000) : 0,
                    Thirst.HasAnyEffect() ? Thirst.GetEffects().Max(x => x.Value.Duration * 1000) : 0
                );
            }
        }

        private DateTime lastFraskCreated;
        private DateTime lastRegenEffect;
        private PlayerData storeData = null;

        public PlayerCharacterEntity(IMyCharacter entity)
            : base(entity)
        {

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
                Hunger = GetPlayerStat("Hunger");
                Thirst = GetPlayerStat("Thirst");
                Stamina = GetPlayerStat("Stamina");
                SurvivalEffects = GetPlayerStat("SurvivalEffects");
                DamageEffects = GetPlayerStat("DamageEffects");
                TemperatureEffects = GetPlayerStat("TemperatureEffects");
                DiseaseEffects = GetPlayerStat("DiseaseEffects");
                OtherEffects = GetPlayerStat("OtherEffects");
                WoundedTime = GetPlayerStat("WoundedTime");
                TemperatureTime = GetPlayerStat("TemperatureTime");
                WetTime = GetPlayerStat("WetTime");
                IntakeBodyFood = GetPlayerStat("IntakeBodyFood");
                IntakeBodyWater = GetPlayerStat("IntakeBodyWater");
                BodyEnergy = GetPlayerStat("BodyEnergy");
                BodyWater = GetPlayerStat("BodyWater");
                IntakeCarbohydrates = GetPlayerStat("IntakeCarbohydrates");
                IntakeProtein = GetPlayerStat("IntakeProtein");
                IntakeLipids = GetPlayerStat("IntakeLipids");
                IntakeVitamins = GetPlayerStat("IntakeVitamins");
                IntakeMinerals = GetPlayerStat("IntakeMinerals");
                BodyMuscles = GetPlayerStat("BodyMuscles");
                BodyFat = GetPlayerStat("BodyFat");
                BodyPerformance = GetPlayerStat("BodyPerformance");
                if (hasDied && storeData != null && ExtendedSurvivalSettings.Instance.HardModeEnabled)
                {
                    RestoreStatValue(Hunger, storeData.Hunger, HungerConstants.MIN_HUNGER_AT_START);
                    RestoreStatValue(Thirst, storeData.Thirst, HungerConstants.MIN_THIRST_AT_START);
                    if (ExtendedSurvivalSettings.Instance.UseMetabolism)
                    {
                        RestoreStatValue(BodyEnergy, storeData.BodyEnergy, HungerConstants.MIN_BODYENERGY_AT_START);
                        RestoreStatValue(BodyWater, storeData.BodyWater, HungerConstants.MIN_BODYWATER_AT_START);
                        IntakeBodyFood.Value = storeData.IntakeBodyFood.Z;
                        IntakeBodyWater.Value = storeData.IntakeBodyWater.Z;
                        if (ExtendedSurvivalSettings.Instance.UseNutrition)
                        {
                            IntakeCarbohydrates.Value = storeData.IntakeCarbohydrates.Z;
                            IntakeProtein.Value = storeData.IntakeProtein.Z;
                            IntakeLipids.Value = storeData.IntakeLipids.Z;
                            IntakeVitamins.Value = storeData.IntakeVitamins.Z;
                            IntakeMinerals.Value = storeData.IntakeMinerals.Z;
                            BodyMuscles.Value = storeData.BodyMuscles.Z;
                            BodyFat.Value = storeData.BodyFat.Z;
                            BodyPerformance.Value = storeData.BodyPerformance.Z;
                        }
                    }
                    RestoreStatValue(Stamina, storeData.Stamina, HungerConstants.MIN_STAMINA_AT_START);
                    CurrentDamageEffects = storeData.CurrentDamageEffects;
                    if (!StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.ON_DEATH_NO_CHANGE_IF))
                    {
                        CurrentDamageEffects &= ~StatsConstants.ON_DEATH_REMOVE_DAMAGE;
                        CurrentDamageEffects |= StatsConstants.ON_DEATH_APPLY_DAMAGE;
                    }
                    if (CurrentDamageEffects != StatsConstants.DamageEffects.None)
                    {
                        Health.Value = Health.MaxValue * StatsConstants.DAMAGE_HEALTH_START_VALUE[(StatsConstants.DamageEffects)StatsConstants.GetMaxSetFlagValue(CurrentDamageEffects)];
                    }
                    CurrentDiseaseEffects = storeData.CurrentDiseaseEffects;
                    WetTime.Value = storeData.WetTime.Z;
                    TemperatureTime.Value = storeData.TemperatureTime.Z;
                    WoundedTime.Value = storeData.WoundedTime.Z;
                }
                CheckHungerValues();
                CheckThirstValues();
                CheckOxygenValue();
                CheckHealthValue();
            }
        }

        protected override void OnEndConfigureCharacter()
        {
            if (StatComponent != null)
            {
                Hunger.OnStatChanged += Hunger_OnStatChanged;
                Thirst.OnStatChanged += Thirst_OnStatChanged;
                Stamina.OnStatChanged += Stamina_OnStatChanged;
            }
            base.OnEndConfigureCharacter();
        }

        protected override void OnBeginResetConfiguration()
        {
            base.OnBeginResetConfiguration();
            if (Hunger != null)
                Hunger.OnStatChanged -= Hunger_OnStatChanged;
            if (Thirst != null)
                Thirst.OnStatChanged -= Thirst_OnStatChanged;
            if (Stamina != null)
                Stamina.OnStatChanged -= Stamina_OnStatChanged;
        }

        protected override void OnEndResetConfiguration()
        {
            base.OnEndResetConfiguration();
            OxygenComponent = null;
            Thirst = null;
            Hunger = null;
            Stamina = null;
            SurvivalEffects = null;
            DamageEffects = null;
            TemperatureEffects = null;
            DiseaseEffects = null;
            OtherEffects = null;
            WoundedTime = null;
            TemperatureTime = null;
            WetTime = null;
        }

        protected override void OnCharacterDied()
        {
            base.OnCharacterDied();
            Hunger.OnStatChanged -= Hunger_OnStatChanged;
            Thirst.OnStatChanged -= Thirst_OnStatChanged;
            Stamina.OnStatChanged -= Stamina_OnStatChanged;
            enterUnderWater = false;
            storeData = GetData();
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

        private void Stamina_OnStatChanged(float newValue, float oldValue, object statChangeData)
        {

        }

        private void Thirst_OnStatChanged(float newValue, float oldValue, object statChangeData)
        {
            CheckThirstValues();
        }

        private void Hunger_OnStatChanged(float newValue, float oldValue, object statChangeData)
        {
            CheckHungerValues();
        }

        private void CheckHealthValue()
        {
            if (ExtendedSurvivalSettings.Instance.DamageEffectsEnabled)
            {
                var percentValue = Health.Value / Health.MaxValue;
                if (percentValue == 1)
                {
                    CurrentDamageEffects &= ~StatsConstants.DamageEffects.Contusion;
                }
            }
        }

        private void CheckHealthDamage(float damage)
        {
            if (ExtendedSurvivalSettings.Instance.DamageEffectsEnabled)
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
        }

        private void CheckOxygenValue()
        {
            if (ExtendedSurvivalSettings.Instance.StaminaEnabled)
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
        }

        private void CheckHungerValues()
        {
            if (ExtendedSurvivalSettings.Instance.HungerEnabled)
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
        }

        private void CheckThirstValues()
        {
            if (ExtendedSurvivalSettings.Instance.ThirstEnabled)
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
        }

        private void CheckConsumableHasSpecialAction()
        {
            if (lastRemovedIten != null)
            {
                var removedId = new MyDefinitionId(lastRemovedIten.Value.Key.Content.TypeId, lastRemovedIten.Value.Key.Content.SubtypeId);
                var removedUniqueId = new UniqueEntityId(removedId);
                if (removedId.TypeId.ToString().Contains("Consumable"))
                {
                    bool needToCheckDisease = false;
                    if (HasFoodThirstEffects && DateTime.Now > lastFraskCreated)
                    {
                        lastFraskCreated = DateTime.Now.AddMilliseconds(FoodThirstEffectsTimeLeft);
                        if (NutritionConstants.FOOD_RECIPIENTS.ContainsKey(removedUniqueId))
                        {
                            Inventory.AddMaxItems(1f, ItensConstants.GetPhysicalObjectBuilder(NutritionConstants.FOOD_RECIPIENTS[removedUniqueId]));
                        }
                    }
                    if (HasHealthEffects && DateTime.Now > lastRegenEffect)
                    {
                        lastRegenEffect = DateTime.Now.AddMilliseconds(FoodThirstEffectsTimeLeft);
                        if (ItensConstants.REMOVE_DAMAGE_EFFECTS.Keys.Contains(removedUniqueId))
                        {
                            CurrentDamageEffects &= ~ItensConstants.REMOVE_DAMAGE_EFFECTS[removedUniqueId];
                            if (StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.BrokenBones))
                            {
                                CurrentDamageEffects &= ~StatsConstants.DamageEffects.BrokenBones;
                                CurrentDamageEffects |= StatsConstants.DamageEffects.DeepWounded;
                            }
                            else if (StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.DeepWounded))
                            {
                                CurrentDamageEffects &= ~StatsConstants.DamageEffects.DeepWounded;
                                CurrentDamageEffects |= StatsConstants.DamageEffects.Wounded;
                            }
                            else if (StatsConstants.IsFlagSet(CurrentDamageEffects, StatsConstants.DamageEffects.Wounded))
                            {
                                CurrentDamageEffects &= ~StatsConstants.DamageEffects.Wounded;
                                CurrentDamageEffects |= StatsConstants.DamageEffects.Contusion;
                            }
                        }
                        if (ItensConstants.REMOVE_DISEASE_EFFECTS.Keys.Contains(removedUniqueId))
                        {
                            CurrentDiseaseEffects &= ~ItensConstants.REMOVE_DISEASE_EFFECTS[removedUniqueId];
                        }
                    }
                    if (needToCheckDisease)
                        CheckHasDiseaseToGive(removedUniqueId);
                    lastRemovedIten = null;
                }
            }
        }

        private bool CheckCanAdd(StatsConstants.DiseaseEffects effect)
        {
            switch (effect)
            {
                case StatsConstants.DiseaseEffects.Pneumonia:
                    return ExtendedSurvivalSettings.Instance.PneumoniaEnabled;
                case StatsConstants.DiseaseEffects.Dysentery:
                    return ExtendedSurvivalSettings.Instance.DysenteryEnabled;
                case StatsConstants.DiseaseEffects.Poison:
                    return ExtendedSurvivalSettings.Instance.PoisonEnabled;
                case StatsConstants.DiseaseEffects.Infected:
                    return ExtendedSurvivalSettings.Instance.InfectedEnabled;
                case StatsConstants.DiseaseEffects.Hypothermia:
                    return ExtendedSurvivalSettings.Instance.HypothermiaEnabled;
                case StatsConstants.DiseaseEffects.Hyperthermia:
                    return ExtendedSurvivalSettings.Instance.HyperthermiaEnabled;
                case StatsConstants.DiseaseEffects.Starvation:
                    return ExtendedSurvivalSettings.Instance.StarvationEnabled;
                case StatsConstants.DiseaseEffects.SevereStarvation:
                    return ExtendedSurvivalSettings.Instance.SevereStarvationEnabled;
                case StatsConstants.DiseaseEffects.Dehydration:
                    return ExtendedSurvivalSettings.Instance.DehydrationEnabled;
                case StatsConstants.DiseaseEffects.SevereDehydration:
                    return ExtendedSurvivalSettings.Instance.SevereDehydrationEnabled;
                case StatsConstants.DiseaseEffects.Obesity:
                    return ExtendedSurvivalSettings.Instance.ObesityEnabled;
                case StatsConstants.DiseaseEffects.SevereObesity:
                    return ExtendedSurvivalSettings.Instance.SevereObesityEnabled;
                case StatsConstants.DiseaseEffects.Rickets:
                    return ExtendedSurvivalSettings.Instance.RicketsEnabled;
                case StatsConstants.DiseaseEffects.SevereRickets:
                    return ExtendedSurvivalSettings.Instance.SevereRicketsEnabled;
                case StatsConstants.DiseaseEffects.Hypolipidemia:
                    return ExtendedSurvivalSettings.Instance.HypolipidemiaEnabled;
                default:
                    return false;
            }
        }

        private void CheckHasDiseaseToGive(UniqueEntityId id)
        {
            if (ItensConstants.GIVE_DISEASE_EFFECTS.Keys.Contains(id))
            {
                foreach (var item in ItensConstants.GIVE_DISEASE_EFFECTS[id])
                {
                    if (CheckCanAdd(item.Key))
                    {
                        var chance = item.Value;
                        if (ExtendedSurvivalSettings.Instance.UseNutrition && chance < 100)
                        {
                            chance = GetValueWithPerformance(chance, true);
                        }
                        if (chance >= 100 || CheckChance(chance))
                        {
                            CurrentDiseaseEffects |= item.Key;
                        }
                    }
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
            if (Hunger.Value < 0)
                Hunger.Value = 0;
            if (Thirst.Value < 0)
                Thirst.Value = 0;
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                if (IntakeBodyWater.Value < 0)
                    IntakeBodyWater.Value = 0;
                if (IntakeBodyFood.Value < 0)
                    IntakeBodyFood.Value = 0;
                if (BodyEnergy.Value < 0)
                    BodyEnergy.Value = 0;
                if (BodyWater.Value < 0)
                    BodyWater.Value = 0;
                if (ExtendedSurvivalSettings.Instance.UseNutrition)
                {
                    if (IntakeProtein.Value < 0)
                        IntakeProtein.Value = 0;
                    if (IntakeCarbohydrates.Value < 0)
                        IntakeCarbohydrates.Value = 0;
                    if (IntakeLipids.Value < 0)
                        IntakeLipids.Value = 0;
                    if (IntakeMinerals.Value < 0)
                        IntakeMinerals.Value = 0;
                    if (IntakeVitamins.Value < 0)
                        IntakeVitamins.Value = 0;
                    if (BodyMuscles.Value < 0)
                        BodyMuscles.Value = 0;
                    if (BodyFat.Value < 0)
                        BodyFat.Value = 0;
                    if (BodyPerformance.Value < 0)
                        BodyPerformance.Value = 0;
                }
            }
            CheckOxygenValue();
        }

        private float GetValueWithPerformance(float value, bool inv = false)
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
                return value + (value * CurrentPerformance * (inv ? -1 : 1));
            return value;
        }

        private float GetValueWithBodyFatMultiplier(float value, bool inv = false)
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
                return value + (value * CurrentBodyFatMultiplier * (inv ? -1 : 1));
            return value;
        }

        private float GetValueWithBodyMuscleMultiplier(float value, bool inv = false)
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
                return value + (value * CurrentBodyMusclesMultiplier * (inv ? -1 : 1));
            return value;
        }

        public void CheckValuesToDoDamage()
        {
            try
            {
                if (ExtendedSurvivalSettings.Instance.ThirstEnabled || ExtendedSurvivalSettings.Instance.HungerEnabled)
                {
                    if (!MyAPIGateway.Session.CreativeMode && !MyAPIGateway.Session.IsUserInvulnerable(Player?.SteamUserId ?? 0) && Health.Value > 0)
                    {
                        if (ExtendedSurvivalSettings.Instance.UseMetabolism)
                        {
                            if (BodyEnergy.Value == 0 || BodyWater.Value == 0)
                            {
                                Entity.Kill();
                            }
                        }
                        else
                        {
                            float damageMultiplier = 0;
                            if (Hunger.Value == 0)
                                damageMultiplier += HungerConstants.BASE_HUNGER_DAMAGE_FACTOR;
                            if (Thirst.Value == 0)
                                damageMultiplier += HungerConstants.BASE_THIRST_DAMAGE_FACTOR;
                            if (damageMultiplier > 0)
                                Entity.DoDamage(HungerConstants.BASE_DAMAGE_FACTOR * damageMultiplier, MyDamageType.Environment, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
            }
        }

        private void ProcessHunger()
        {
            if (ExtendedSurvivalSettings.Instance.HungerEnabled)
            {
                if (Hunger.Value > 0)
                    Hunger.Decrease(GetValueWithPerformance(GetHungerToDecrease(), true), PlayerId);
            }
        }

        private void ProcessThirst()
        {
            if (ExtendedSurvivalSettings.Instance.ThirstEnabled)
            {
                var thirstNegative = true;
                var thirstValue = GetThirstToDecrease();

                if (Entity.Parent == null && currentEnvironmentType == WeatherConstants.EnvironmentDetector.Atmosphere)
                {
                    if (weatherEffect != WeatherConstants.WeatherEffects.None && !Entity.EnabledHelmet)
                    {
                        thirstNegative = false;
                        thirstValue = GetThirstToIncrise(weatherEffect, weatherLevel, weatherIntensity);
                    }
                }

                if (Thirst.Value > 0 && thirstNegative)
                    Thirst.Decrease(GetValueWithPerformance(thirstValue, true), PlayerId);

                if (!thirstNegative)
                {
                    thirstValue = GetValueWithPerformance(thirstValue);
                    if (Thirst.Value < Thirst.MaxValue)
                    {
                        Thirst.Increase(thirstValue, PlayerId);
                    }
                    if (ExtendedSurvivalSettings.Instance.UseMetabolism)
                    {
                        IntakeBodyWater.Increase(thirstValue, PlayerId);
                    }
                }
            }
        }

        private TimeSpan lastTimeProcess = TimeSpan.Zero;

        public void ProcessStatsCycle()
        {
            if (!MyAPIGateway.Session.CreativeMode)
            {
                ProcessEffectsTimers();
                if (!IsOnCryoChamber())
                {
                    ProcessHunger();
                    ProcessThirst();
                    ProcessHealth();
                    ProcessCargoMax();
                }
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
            if (!MyAPIGateway.Session.CreativeMode)
            {
                RefreshWeatherInfo();
                ProcessStamina();
                if (!IsOnCryoChamber())
                {
                    ProcessIntakeBodyFood();
                    ProcessIntakeBodyWater();
                    ProcessBodyEnergy();
                    ProcessBodyWater();
                    ProcessBodyPerformance();
                    ProcessBodyMuscle();
                    ProcessBodyFat();
                }
                else
                {
                    lastBodyFoodGainValue = 0;
                    lastBodyWaterConsumeValue = 0;
                    incriseBodyPerformanceValue = 0;
                    consumeBodyPerformanceValue = 0;
                    incriseBodyMuscleValue = 0;
                    consumeBodyMuscleValue = 0;
                    incriseBodyFatValue = 0;
                    consumeBodyFatValue = 0;
                }
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

        private float incriseBodyPerformanceValue = 0;
        private float consumeBodyPerformanceValue = 0;
        private void ProcessBodyPerformance()
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
            {
                incriseBodyPerformanceValue = 0;
                consumeBodyPerformanceValue = 0;
                if (IntakeVitamins.Value > 0)
                {
                    var incriseValue = StatsConstants.BODY_PERFORMANCE_V_GAIN;
                    var consumeValue = StatsConstants.BODY_PERFORMANCE_V_DRAIN;
                    incriseValue = GetValueWithPerformance(incriseValue);
                    BodyPerformance.Increase(incriseValue, PlayerId);
                    IntakeVitamins.Decrease(consumeValue, PlayerId);
                    incriseBodyPerformanceValue += incriseValue;
                }
                if (IntakeMinerals.Value > 0)
                {
                    var incriseValue = StatsConstants.BODY_PERFORMANCE_M_GAIN;
                    var consumeValue = StatsConstants.BODY_PERFORMANCE_M_DRAIN;
                    incriseValue = GetValueWithPerformance(incriseValue);
                    BodyPerformance.Increase(incriseValue, PlayerId);
                    IntakeMinerals.Decrease(consumeValue, PlayerId);
                    incriseBodyPerformanceValue += incriseValue;
                }
                if (incriseBodyPerformanceValue > 0)
                {
                    incriseBodyPerformanceValue = (float)Math.Round(incriseBodyPerformanceValue, 3);
                }
                if (BodyPerformance.Value > 0)
                {
                    consumeBodyPerformanceValue = StatsConstants.BODY_PERFORMANCE_CYCLE_DRAIN;
                    consumeBodyPerformanceValue += StatsConstants.BODY_PERFORMANCE_CYCLE_DRAIN_INC * GetTotalDiseaseMultiplier();
                    consumeBodyPerformanceValue = Math.Min(consumeBodyPerformanceValue, StatsConstants.BODY_PERFORMANCE_CYCLE_MAXDRAIN);
                    consumeBodyPerformanceValue = GetValueWithPerformance(consumeBodyPerformanceValue, true);
                    BodyPerformance.Decrease(consumeBodyPerformanceValue, PlayerId);
                    consumeBodyPerformanceValue = (float)Math.Round(consumeBodyPerformanceValue * -1, 3);
                }
            }
        }

        private float GetBaseMuscleGain()
        {
            if (IsOnTreadmill())
                return StatsConstants.BODY_MUSCLE_MOVE_GAIN.Z;
            if (IsCharacterSprinting())
                return StatsConstants.BODY_MUSCLE_MOVE_GAIN.Y;
            return StatsConstants.BODY_MUSCLE_MOVE_GAIN.X;
        }

        private float incriseBodyMuscleValue = 0;
        private float consumeBodyMuscleValue = 0;
        private void ProcessBodyMuscle()
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
            {
                incriseBodyMuscleValue = 0;
                consumeBodyMuscleValue = 0;
                if (IsCharacterMoving() || IsCharacterUsingTool() || IsOnTreadmill())
                {
                    if (IntakeProtein.Value > 0)
                    {
                        incriseBodyMuscleValue = GetBaseMuscleGain();
                        incriseBodyMuscleValue = GetValueWithPerformance(incriseBodyMuscleValue);
                        var consumeValue = StatsConstants.BODY_MUSCLE_PROTEIN_DRAIN;
                        BodyMuscles.Increase(incriseBodyMuscleValue, PlayerId);
                        IntakeProtein.Decrease(consumeValue, PlayerId);
                        incriseBodyMuscleValue = (float)Math.Round(incriseBodyMuscleValue, 3);
                    }
                }
                else
                {
                    consumeBodyMuscleValue = StatsConstants.BODY_MUSCLE_NOMOVE_DRAIN;
                    consumeBodyMuscleValue = GetValueWithPerformance(consumeBodyMuscleValue, true);
                    BodyMuscles.Decrease(consumeBodyMuscleValue, PlayerId);
                    consumeBodyMuscleValue = (float)Math.Round(consumeBodyMuscleValue * -1, 3);
                }
            }
        }

        private float incriseBodyFatValue = 0;
        private float consumeBodyFatValue = 0;
        private void ProcessBodyFat()
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
            {
                incriseBodyFatValue = 0;
                consumeBodyFatValue = 0;
                if (IntakeLipids.Value > 0 || IntakeCarbohydrates.Value > 0)
                {
                    incriseBodyFatValue = IntakeLipids.Value > 0 ? StatsConstants.BODY_FAT_NOMOVE_LC_GAIN.X : StatsConstants.BODY_FAT_NOMOVE_LC_GAIN.Y;
                    incriseBodyFatValue = GetValueWithPerformance(incriseBodyFatValue, true);
                    BodyFat.Increase(incriseBodyFatValue, PlayerId);
                    if (IntakeLipids.Value > 0)
                    {
                        IntakeLipids.Decrease(StatsConstants.BODY_FAT_LC_DRAIN.X, PlayerId);
                    }
                    else
                    {
                        IntakeCarbohydrates.Decrease(StatsConstants.BODY_FAT_LC_DRAIN.Y, PlayerId);
                    }
                    incriseBodyFatValue = (float)Math.Round(incriseBodyFatValue, 3);
                }
                if (IsCharacterMoving() || IsCharacterUsingTool() || IsOnTreadmill())
                {
                    consumeBodyFatValue = GetBaseFatDrain();
                    consumeBodyFatValue = GetValueWithPerformance(consumeBodyFatValue);
                    BodyFat.Decrease(consumeBodyFatValue, PlayerId);
                    consumeBodyFatValue = (float)Math.Round(consumeBodyFatValue * -1, 3);
                }
            }
        }

        private float GetBaseFatDrain()
        {
            if (IsOnTreadmill())
                return StatsConstants.BODY_FAT_MOVE_DRAIN.Z;
            if (IsCharacterSprinting())
                return StatsConstants.BODY_FAT_MOVE_DRAIN.Y;
            return StatsConstants.BODY_FAT_MOVE_DRAIN.X;
        }

        private float lastBodyEnergyConsumeValue = 0;
        private void ProcessBodyEnergy()
        {
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                lastBodyEnergyConsumeValue = 0;
                if (BodyEnergy.Value > 0)
                {
                    var consumeValue = StatsConstants.BASE_USE_ENERGY_FACTOR * (1 - Hunger.CurrentRatio);
                    if (IsCharacterMoving() || IsCharacterUsingTool() || IsOnTreadmill())
                    {
                        if (IsCharacterSprinting() || IsOnTreadmill())
                            consumeValue *= StatsConstants.BASE_USE_ENERGY_MOVE_MULTIPLIER.Y;
                        else
                            consumeValue *= StatsConstants.BASE_USE_ENERGY_MOVE_MULTIPLIER.X;
                    }
                    if (ExtendedSurvivalSettings.Instance.BodyTemperatureEnabled)
                    {
                        if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.Frosty))
                            consumeValue *= StatsConstants.BASE_USE_ENERGY_TEMPERATURE_MULTIPLIER.X;
                        else if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.Cold))
                            consumeValue *= StatsConstants.BASE_USE_ENERGY_TEMPERATURE_MULTIPLIER.Y;
                        else if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.Overheating))
                            consumeValue *= StatsConstants.BASE_USE_ENERGY_TEMPERATURE_MULTIPLIER.Z;
                        else if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.OnFire))
                            consumeValue *= StatsConstants.BASE_USE_ENERGY_TEMPERATURE_MULTIPLIER.W;
                    }
                    if (CurrentSurvivalEffects.IsFlagSet(StatsConstants.SurvivalEffects.Hungry))
                        consumeValue *= StatsConstants.BASE_USE_ENERGY_HUNGER_MULTIPLIER.X;
                    else if (CurrentSurvivalEffects.IsFlagSet(StatsConstants.SurvivalEffects.Famished))
                        consumeValue *= StatsConstants.BASE_USE_ENERGY_HUNGER_MULTIPLIER.Y;
                    consumeValue = GetValueWithPerformance(consumeValue, true);
                    BodyEnergy.Decrease(consumeValue, PlayerId);
                    lastBodyEnergyConsumeValue = (float)Math.Round(consumeValue * -1, 3);
                }
            }
        }

        private float lastBodyWaterConsumeValue = 0;
        private void ProcessBodyWater()
        {
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                lastBodyWaterConsumeValue = 0;
                if (BodyWater.Value > 0)
                {
                    var consumeValue = StatsConstants.BASE_USE_WATER_FACTOR * (1 - Thirst.CurrentRatio);
                    if (IsCharacterMoving() || IsCharacterUsingTool() || IsOnTreadmill())
                    {
                        if (IsCharacterSprinting() || IsOnTreadmill())
                            consumeValue *= StatsConstants.BASE_USE_WATER_MOVE_MULTIPLIER.Y;
                        else
                            consumeValue *= StatsConstants.BASE_USE_WATER_MOVE_MULTIPLIER.X;
                    }
                    if (ExtendedSurvivalSettings.Instance.BodyTemperatureEnabled)
                    {
                        if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.Frosty))
                            consumeValue *= StatsConstants.BASE_USE_WATER_TEMPERATURE_MULTIPLIER.X;
                        else if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.Cold))
                            consumeValue *= StatsConstants.BASE_USE_WATER_TEMPERATURE_MULTIPLIER.Y;
                        else if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.Overheating))
                            consumeValue *= StatsConstants.BASE_USE_WATER_TEMPERATURE_MULTIPLIER.Z;
                        else if (CurrentTemperatureEffects.IsFlagSet(StatsConstants.TemperatureEffects.OnFire))
                            consumeValue *= StatsConstants.BASE_USE_WATER_TEMPERATURE_MULTIPLIER.W;
                    }
                    if (CurrentSurvivalEffects.IsFlagSet(StatsConstants.SurvivalEffects.Thirsty))
                        consumeValue *= StatsConstants.BASE_USE_WATER_THIRST_MULTIPLIER.X;
                    else if (CurrentSurvivalEffects.IsFlagSet(StatsConstants.SurvivalEffects.Dehydrating))
                        consumeValue *= StatsConstants.BASE_USE_WATER_THIRST_MULTIPLIER.Y;
                    consumeValue = GetValueWithPerformance(consumeValue, true);
                    BodyWater.Decrease(consumeValue, PlayerId);
                    lastBodyWaterConsumeValue = (float)Math.Round(consumeValue * -1, 3);
                }
            }
        }

        private float lastBodyFoodGainValue = 0;
        private void ProcessIntakeBodyFood()
        {
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                lastBodyFoodGainValue = 0;
                if (IntakeBodyFood.Value > 0)
                {
                    var transferValue = StatsConstants.BASE_FOOD_METABOLISM;
                    IntakeBodyFood.Decrease(transferValue, PlayerId);
                    var consumeValue = GetValueWithPerformance(transferValue);
                    BodyEnergy.Increase(consumeValue, PlayerId);
                    lastBodyFoodGainValue = (float)Math.Round(consumeValue, 3);
                }
            }
        }

        private float lastBodyWaterGainValue = 0;
        private void ProcessIntakeBodyWater()
        {
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                lastBodyWaterGainValue = 0;
                if (IntakeBodyWater.Value > 0)
                {
                    var transferValue = StatsConstants.BASE_WATER_METABOLISM;
                    IntakeBodyWater.Decrease(transferValue, PlayerId);
                    var consumeValue = GetValueWithPerformance(transferValue);
                    BodyWater.Increase(consumeValue, PlayerId);
                    lastBodyWaterGainValue = (float)Math.Round(consumeValue, 3);
                }
            }
        }

        private void ProcessEffectsTimers()
        {
            var timePassed = lastTimeProcess != TimeSpan.Zero ? MyAPIGateway.Session.ElapsedPlayTime - lastTimeProcess : TimeSpan.Zero;
            lastTimeProcess = MyAPIGateway.Session.ElapsedPlayTime;
            if (ExtendedSurvivalSettings.Instance.WetEnabled)
            {
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
            }
            if (timePassed > TimeSpan.Zero)
            {
                if (ExtendedSurvivalSettings.Instance.InfectedEnabled)
                {
                    IncDecWoundedTimer(timePassed);
                    CheckWoundedEffect();
                }
                if (ExtendedSurvivalSettings.Instance.BodyTemperatureEnabled)
                {
                    IncDevTemperatureTimer(timePassed);
                    CheckTemperatureEffect();
                }
            }
            CheckIfGetDiseases();
        }

        private void CheckIfGetDiseases()
        {
            if (ExtendedSurvivalSettings.Instance.PneumoniaEnabled)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Pneumonia))
                {
                    if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    {
                        var isWet = StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Wet);
                        var chance = StatsConstants.CHANCE_TO_GET_PNEUMONIA;
                        if (isWet)
                            chance += StatsConstants.PNEUMONIA_CHANCE_INCRISE;
                        if (ExtendedSurvivalSettings.Instance.UseNutrition)
                        {
                            chance = GetValueWithPerformance(chance, true);
                        }
                        float temperatureMultiplier = 1f - (TemperatureTime.CurrentRatio * 2);
                        if (temperatureMultiplier > 0 && CheckChance(chance * temperatureMultiplier))
                        {
                            CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Pneumonia;
                        }
                    }
                }
            }
            if (ExtendedSurvivalSettings.Instance.HypothermiaEnabled)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypothermia))
                {
                    if (TemperatureTime.Value <= TemperatureTime.MinValue)
                    {
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Hypothermia;
                    }
                }
            }
            if (ExtendedSurvivalSettings.Instance.HyperthermiaEnabled)
            {
                if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                {
                    if (TemperatureTime.Value >= TemperatureTime.MaxValue)
                    {
                        CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Hyperthermia;
                    }
                }
            }
            CheckStarvation();
            CheckDehydration();
            CheckObesityAndHypolipidemia();
            CheckRickets();
        }

        private void CheckRickets()
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
            {
                if (ExtendedSurvivalSettings.Instance.RicketsEnabled)
                {
                    var percent = BodyMuscles.Value / BodyMuscles.MaxValue;
                    var needToCheckRickets = true;
                    if (ExtendedSurvivalSettings.Instance.SevereRicketsEnabled)
                    {
                        if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereRickets))
                        {
                            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                            {
                                if (percent <= 0.05f)
                                {
                                    needToCheckRickets = false;
                                    CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Rickets;
                                    CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.SevereRickets;
                                }
                            }
                        }
                        else
                        {
                            needToCheckRickets = false;
                            if (percent > 0.05f)
                            {
                                CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.SevereRickets;
                                needToCheckRickets = true;
                            }
                        }
                    }
                    if (needToCheckRickets)
                    {
                        if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Rickets))
                        {
                            if (percent <= 0.25f)
                            {
                                CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Rickets;
                            }
                        }
                        else
                        {
                            if (percent > 0.25f)
                            {
                                CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Rickets;
                            }
                        }
                    }
                }
            }
        }

        private void CheckObesityAndHypolipidemia()
        {
            if (ExtendedSurvivalSettings.Instance.UseNutrition)
            {
                var percent = BodyFat.Value / BodyFat.MaxValue;
                if (ExtendedSurvivalSettings.Instance.ObesityEnabled)
                {
                    var needToCheckObesity = true;
                    if (ExtendedSurvivalSettings.Instance.SevereObesityEnabled)
                    {
                        if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.SevereObesity))
                        {
                            if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                            {
                                if (percent >= 0.95f)
                                {
                                    needToCheckObesity = false;
                                    CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Obesity;
                                    CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.SevereObesity;
                                }
                            }
                        }
                        else
                        {
                            needToCheckObesity = false;
                            if (percent < 0.95f)
                            {
                                CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.SevereObesity;
                                needToCheckObesity = true;
                            }
                        }
                    }
                    if (needToCheckObesity)
                    {
                        if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Obesity))
                        {
                            if (percent >= 0.75f)
                            {
                                CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Obesity;
                            }
                        }
                        else
                        {
                            if (percent < 0.75f)
                            {
                                CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Obesity;
                            }
                        }
                    }
                }
                if (ExtendedSurvivalSettings.Instance.HypolipidemiaEnabled)
                {
                    if (!StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hypolipidemia))
                    {
                        if (percent <= 0.1f)
                        {
                            CurrentDiseaseEffects |= StatsConstants.DiseaseEffects.Hypolipidemia;
                        }
                    }
                    else
                    {
                        if (percent > 0.1f)
                        {
                            CurrentDiseaseEffects &= ~StatsConstants.DiseaseEffects.Hypolipidemia;
                        }
                    }
                }
            }
        }

        private void CheckDehydration()
        {
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                if (ExtendedSurvivalSettings.Instance.DehydrationEnabled)
                {
                    var percent = BodyWater.Value / BodyWater.MaxValue;
                    var needToCheckDehydration = true;
                    if (ExtendedSurvivalSettings.Instance.SevereDehydrationEnabled)
                    {
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
            }
        }

        private void CheckStarvation()
        {
            if (ExtendedSurvivalSettings.Instance.UseMetabolism)
            {
                if (ExtendedSurvivalSettings.Instance.StarvationEnabled)
                {
                    var percent = BodyEnergy.Value / BodyEnergy.MaxValue;
                    var needToCheckStarvation = true;
                    if (ExtendedSurvivalSettings.Instance.SevereStarvationEnabled)
                    {
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
                    if (ExtendedSurvivalSettings.Instance.UseNutrition)
                    {
                        finalValue = GetValueWithBodyFatMultiplier(finalValue);
                    }
                    bool isHardTemperature = temperature > HungerConstants.THIRST_HARD_TEMPERATURE_RANGE;
                    if (isHardTemperature || TemperatureTime.Value < StatsConstants.MIN_TO_GET_EFFECT_ONFIRE)
                        TemperatureTime.Increase(finalValue, null);
                }
                else
                {
                    finalValue *= TemperatureTime.Value > 0 ? StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER : 1;
                    if (ExtendedSurvivalSettings.Instance.UseNutrition)
                    {
                        finalValue = GetValueWithBodyFatMultiplier(finalValue, true);
                    }
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
                    if (ExtendedSurvivalSettings.Instance.UseNutrition)
                    {
                        finalValue = GetValueWithBodyFatMultiplier(finalValue);
                    }
                    TemperatureTime.Increase(finalValue, null);
                    if (TemperatureTime.Value > 0)
                        TemperatureTime.Value = 0;
                }
                else if (TemperatureTime.Value > 0)
                {
                    if (StatsConstants.IsFlagSet(CurrentDiseaseEffects, StatsConstants.DiseaseEffects.Hyperthermia))
                        finalValue *= StatsConstants.HYPERTHERMIA_CHANGE_MULTIPLIER;
                    finalValue *= StatsConstants.TEMPERATURE_CHANGE_MULTIPLIER;
                    if (ExtendedSurvivalSettings.Instance.UseNutrition)
                    {
                        finalValue = GetValueWithBodyFatMultiplier(finalValue, true);
                    }
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
                Health.Increase(GetValueWithPerformance(finalRegen), null);
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
            if (ExtendedSurvivalSettings.Instance.StaminaEnabled)
            {
                var maxStamina = GetMaxStamina();
                if (IsCharacterMoving() || IsCharacterUsingTool() || IsOnTreadmill())
                {
                    if (Stamina.Value > 0)
                    {
                        var value = GetStaminaToDecrese();
                        Stamina.Decrease(GetValueWithPerformance(value, true), Player?.IdentityId);
                    }
                    else
                    {
                        var staminaDamage = StatsConstants.BASE_STAMINA_DAMAGE_FACTOR * ExtendedSurvivalSettings.Instance.StaminaSettings.DamageMultiplier;
                        if (staminaDamage > 0 && CanTakeDamage)
                            Entity.DoDamage(staminaDamage, MyDamageType.Environment, true);
                    }
                }
                else
                {
                    if (Stamina.Value < maxStamina)
                    {
                        Stamina.Increase(GetValueWithPerformance(GetStaminaToIncrease()), Player?.IdentityId);
                    }
                }
                if (Stamina.Value > maxStamina)
                    Stamina.Value = maxStamina;
            }
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
                finalValue = GetValueWithBodyFatMultiplier(finalValue);
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
            return finalValue;
        }

        private float GetHungerToDecrease()
        {
            var finalValue = HungerConstants.BASE_HUNGER_FACTOR * ExtendedSurvivalSettings.Instance.HungerSettings.DrainMultiplier;
            if (IsCharacterMoving())
                finalValue += GetSpeed() * HungerConstants.MOVE_INC_HUNGER_FACTOR * ExtendedSurvivalSettings.Instance.HungerSettings.MovingDrainMultiplier;
            if (IsOnTreadmill())
                finalValue += 5 * HungerConstants.MOVE_INC_HUNGER_FACTOR * ExtendedSurvivalSettings.Instance.HungerSettings.TreadmillDrainMultiplier;
            if (ExtendedSurvivalSettings.Instance.HungerSettings.IncriseHungerDrainWithTemperature)
            {
                if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Frosty))
                    finalValue *= HungerConstants.TEMPERATURE_HUNGER_FACTOR.Y;
                else if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Cold))
                    finalValue *= HungerConstants.TEMPERATURE_HUNGER_FACTOR.X;
            }
            return finalValue;
        }

        private float GetThirstToDecrease()
        {
            var finalValue = HungerConstants.BASE_THIRST_FACTOR * ExtendedSurvivalSettings.Instance.ThirstSettings.DrainMultiplier;
            if (IsCharacterMoving())
                finalValue += GetSpeed() * HungerConstants.MIVE_INC_THIRST_FACTOR * ExtendedSurvivalSettings.Instance.ThirstSettings.MovingDrainMultiplier;
            if (IsOnTreadmill())
                finalValue += 5 * HungerConstants.MOVE_INC_HUNGER_FACTOR * ExtendedSurvivalSettings.Instance.ThirstSettings.TreadmillDrainMultiplier;
            if (ExtendedSurvivalSettings.Instance.ThirstSettings.IncriseThirstDrainWithTemperature)
            {
                if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.OnFire))
                    finalValue *= HungerConstants.TEMPERATURE_THIRST_FACTOR.Y;
                else if (StatsConstants.IsFlagSet(CurrentTemperatureEffects, StatsConstants.TemperatureEffects.Overheating))
                    finalValue *= HungerConstants.TEMPERATURE_THIRST_FACTOR.X;
            }
            return finalValue;
        }

        private static float GetThirstToIncrise(WeatherConstants.WeatherEffects effect, WeatherConstants.WeatherEffectsLevel level, float intensity)
        {
            var finalValue = HungerConstants.BASE_THIRST_FACTOR;
            switch (effect)
            {
                case WeatherConstants.WeatherEffects.Rain:
                    finalValue += HungerConstants.RAIN_INC_THIRST_FACTOR * (1 + intensity);
                    finalValue *= level == WeatherConstants.WeatherEffectsLevel.Light ? HungerConstants.RAIN_THIRST_FACTOR.X : HungerConstants.RAIN_THIRST_FACTOR.Y;
                    break;
                case WeatherConstants.WeatherEffects.Thunderstorm:
                    finalValue += HungerConstants.THUNDER_INC_THIRST_FACTOR * (1 + intensity);
                    finalValue *= level == WeatherConstants.WeatherEffectsLevel.Light ? HungerConstants.THUNDER_THIRST_FACTOR.X : HungerConstants.THUNDER_THIRST_FACTOR.Y;
                    break;
            }
            return finalValue * ExtendedSurvivalSettings.Instance.ThirstSettings.GainMultiplier;
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

        public PlayerData GetData()
        {
            try
            {
                if (!IsValid)
                    ConfigureCharacter(Entity);
                if (IsValid)
                {
                    var planet = PlanetAtRange;
                    return new PlayerData()
                    {
                        EntityId = Entity.EntityId,
                        PlayerId = PlayerId,
                        SteamPlayerId = Player?.SteamUserId ?? 0,
                        HasDied = Entity.IsDead,
                        LastTimeDied = lastTimeDead,
                        Temperature = currentTemperature,
                        Health = Health.GetValues(),
                        Stamina = Stamina.GetValues(GetMaxStamina() - Stamina.MaxValue),
                        Hunger = Hunger.GetValues(),
                        Thirst = Thirst.GetValues(),
                        WetTime = WetTime.GetValues(),
                        TemperatureTime = TemperatureTime.GetValues(),
                        WoundedTime = WoundedTime.GetValues(),
                        IntakeBodyFood = IntakeBodyFood.GetValues(),
                        IntakeBodyWater = IntakeBodyWater.GetValues(),
                        BodyEnergy = BodyEnergy.GetValues(lastBodyEnergyConsumeValue + lastBodyFoodGainValue),
                        BodyWater = BodyWater.GetValues(lastBodyWaterConsumeValue + lastBodyWaterGainValue),
                        IntakeCarbohydrates = IntakeCarbohydrates.GetValues(),
                        IntakeProtein = IntakeProtein.GetValues(),
                        IntakeLipids = IntakeLipids.GetValues(),
                        IntakeVitamins = IntakeVitamins.GetValues(),
                        IntakeMinerals = IntakeMinerals.GetValues(),
                        BodyMuscles = BodyMuscles.GetValues(consumeBodyMuscleValue + incriseBodyMuscleValue),
                        BodyFat = BodyFat.GetValues(consumeBodyFatValue + incriseBodyFatValue),
                        BodyPerformance = BodyPerformance.GetValues(consumeBodyPerformanceValue + incriseBodyPerformanceValue),
                        CurrentDamageEffects = CurrentDamageEffects,
                        CurrentDiseaseEffects = CurrentDiseaseEffects,
                        CurrentOtherEffects = CurrentOtherEffects,
                        CurrentSurvivalEffects = CurrentSurvivalEffects,
                        CurrentTemperatureEffects = CurrentTemperatureEffects,
                        CurrentEnvironmentType = currentEnvironmentType,
                        HungerEnabled = ExtendedSurvivalSettings.Instance.HungerEnabled,
                        StaminaEnabled = ExtendedSurvivalSettings.Instance.StaminaEnabled,
                        ThirstEnabled = ExtendedSurvivalSettings.Instance.ThirstEnabled,
                        BodyTemperatureEnabled = ExtendedSurvivalSettings.Instance.BodyTemperatureEnabled,
                        UseMetabolism = ExtendedSurvivalSettings.Instance.UseMetabolism,
                        UseNutrition = ExtendedSurvivalSettings.Instance.UseNutrition,
                        Depth = Depth,
                        PlanetAtRange = planet?.SettingId,
                        PlanetHasWater = planet?.HasWater,
                        NeedToUpdateLocal = MyAPIGateway.Utilities.IsDedicated || !MyAPIGateway.Session.IsServer,
                        O2Level = OxygenComponent.SuitOxygenLevel,
                        CurrentCargoMass = CurrentCargoMass,
                        CurrentCargoVolume = CurrentCargoVolume
                    };
                }
                else
                {
                    ExtendedSurvivalLogging.Instance.LogWarning(GetType(), "GetData Not Valid Player");
                    return null;
                }
            }
            catch (Exception ex)
            {
                ExtendedSurvivalLogging.Instance.LogError(GetType(), ex);
                return null;
            }
        }

    }

}