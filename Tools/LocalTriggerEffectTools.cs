using BO157Items.TriggerEffects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.Tools
{
    public static class LocalTriggerEffectTools
    {
        public static TriggerEffect Add(this TriggerEffect one, TriggerEffect two)
        {
            if(one is not PerformMultipleTriggerEffectsTriggerEffect multiple)
                return new PerformMultipleTriggerEffectsTriggerEffect([one, two]);

            multiple.effects.Add(two);
            return multiple;
        }
    }
}
