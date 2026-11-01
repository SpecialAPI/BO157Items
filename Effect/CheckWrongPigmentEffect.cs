using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.Effect
{
    public class CheckWrongPigmentEffect : EffectSO
    {
        public override bool PerformEffect(CombatStats stats, IUnit caster, TargetSlotInfo[] targets, bool areTargetSlots, int entryVariable, out int exitAmount)
        {
            return (exitAmount = caster.LastCalculatedWrongMana) > entryVariable;
        }

        public static EffectSO Create() => CreateScriptable<CheckWrongPigmentEffect>();
    }
}
