using BO157Items.Conditions.Effector;
using BO157Items.CustomTrigger;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.Items
{
    public static class AlmightyBranch
    {
        public static readonly string ID = "AlmightyBranch_TW".Prefix();

        public static void Init()
        {
            var name = "Almighty Branch";
            var flav = "\"Divine Blood.\"";
            var desc = "This party member's health color is now red. All direct damage produces pigment of the attacker's health color instead of the target's.\nUpon this party member receiving any damage, randomize all party members' health colors.";

            var item = NewItem<MultiCustomTriggerEffectWearable>(ID)
                .SetBasicInformation(name, flav, desc, "AlmightyBranch")
                .SetPrice(3)
                .AddToTreasure();

            item.SetStaticModifiers(HealthColorModifier(Pigments.Red));
            item.SetConnectionEffects(new()
            {
                new()
                {
                    doesPopup = true,
                    immediate = false,
                    
                    effect = null
                }
            });
            item.SetTriggerEffects(new()
            {
                new()
                {
                    trigger = LocalCustomTriggers.ModifyCanProducePigmentFromDamage_Anyone,
                    doesPopup = false,
                    immediate = true,

                    effect = new OverridePigmentWithSourceHealthColorTriggerEffect()
                },
                new()
                {
                    trigger = TriggerCalls.OnDamaged.ToString(),
                    doesPopup = true,
                    immediate = false,
                    
                    effect = new PerformEffectTriggerEffect(new()
                    {
                        Effects.GenerateEffect(CommonEffects.RandomizeHealthColor, 0, Targeting.Unit_AllAllies)
                    })
                }
            });
        }
    }
}
