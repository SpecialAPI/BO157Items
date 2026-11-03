using BO157Items.CustomTrigger.Args;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO157Items.TriggerEffects
{
    public class OverridePigmentWithSourceHealthColorTriggerEffect : TriggerEffect
    {
        public override void DoEffect(IUnit sender, object args, TriggerEffectInfo triggerInfo, TriggerEffectActivationExtraInfo extraInfo)
        {
            if (args is not ModifyCanProducePigmentFromDamageReference { sourceUnit: { } sourceUnit, damagedUnit: { } damagedUnit } canProduceRef)
                return;

            canProduceRef.canProducePigmentFromDamage = false;
            CombatManager.Instance.ProcessImmediateAction(new AddManaToManaBarAction(sourceUnit.HealthColor, damagedUnit.NumPigmentOnDamage(), damagedUnit.IsUnitCharacter, damagedUnit.ID));
        }
    }
}
