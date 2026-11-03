using BO157Items.Conditions.Effector;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.Items
{
    public static class DoomsdayClock
    {
        public static readonly string ID = "DoomsdayClock_TW".Prefix();

        public static void Init()
        {
            var name = "Doomsday Clock";
            var flav = "\"We're all gonna die!\"";
            var desc = "At the start of the third turn, apply 1 Fury to this party member.";

            var item = NewItem<MultiCustomTriggerEffectWearable>(ID)
                .SetBasicInformation(name, flav, desc, "DoomsdayClock")
                .SetPrice(1)
                .AddToTreasure();

            item.SetTriggerEffects(new()
            {
                new()
                {
                    trigger = TriggerCalls.OnTurnStart.ToString(),
                    immediate = false,
                    doesPopup = true,
                    
                    effect = new PerformEffectTriggerEffect(new()
                    {
                        Effects.GenerateEffect(CommonEffects.ApplyStatus(GrimoireStatusField.Fury), 1, Targeting.Slot_SelfSlot)
                    }),
                    conditions = new()
                    {
                        IsTurnEffectorCondition.Create(3)
                    }
                }
            });
        }
    }
}
