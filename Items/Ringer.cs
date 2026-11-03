using BO157Items.Conditions.Effector;
using BO157Items.CustomTrigger;

namespace BO157Items.Items
{
    public static class Ringer
    {
        public static readonly string ID = "Ringer_TW".Prefix();
        public static readonly string PopupSVID = "RingerPopup".Prefix();

        public static void Init()
        {
            var damageUp = 50;
            
            var name = "Ringer";
            var flav = "\"Ring Ring...\"";
            var desc = $"This party member deals {damageUp}% more damage to Focused targets. Upon dealing damage, apply Focused to the target.";

            var item = NewItem<MultiCustomTriggerEffectWearable>(ID)
                .SetBasicInformation(name, flav, desc, "Ringer")
                .SetPrice(8)
                .AddToTreasure();

            NewStoredValue<UnitStoreData_BasicSO>(PopupSVID);
            item.SetTriggerEffects(new()
            {
                new()
                {
                    trigger = TriggerCalls.OnWillApplyDamage.ToString(),
                    immediate = true,
                    doesPopup = true,

                    effect = new PercentageModifierSetterTriggerEffect(damageUp, true)
                        .Add(new TargetStoredValueChangeTriggerEffect(PopupSVID, 1, IntOperation.Set, unitValueIndex: 0)),

                    conditions = new()
                    {
                        TargetStatusEffectCheckEffectorCondition.Create(StatusField_GameIDs.Focused_ID.ToString(), true, unitValueIndex: 0)
                    }
                },
                new()
                {
                    trigger = LocalCustomTriggers.OnTargetDamaged,
                    immediate = false,
                    doesPopup = true,

                    effect = null, // do popup if didnt apply damageup

                    conditions = new()
                    {
                        TargetStoredValueComparisonEffectorCondition.Create(PopupSVID, 0, IntComparison.LessThanOrEqual, unitValueIndex: 1)
                    }
                },
                new()
                {
                    trigger = LocalCustomTriggers.OnTargetDamaged,
                    immediate = false,
                    doesPopup = false,

                    effect = new TargetApplyStatusTriggerEffect(StatusField.Focused, 0, unitValueIndex: 1)
                        .Add(new TargetStoredValueChangeTriggerEffect(PopupSVID, 0, IntOperation.Set, unitValueIndex: 1)),
                }
            });
        }
    }
}