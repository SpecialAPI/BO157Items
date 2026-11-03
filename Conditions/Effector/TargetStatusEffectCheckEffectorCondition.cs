namespace BO157Items.Conditions.Effector
{
    public class TargetStatusEffectCheckEffectorCondition : EffectorConditionSO
    {
        public string statusID;
        public bool needsToHave;
        public int unitValueIndex;
        
        public override bool MeetCondition(IEffectorChecks effector, object args)
        {
            if (!ValueReferenceTools.TryGetUnitHolder(args, out var unitHolder) || unitHolder[unitValueIndex] is not IUnit u)
                return false;

            var hasStatus = u.ContainsStatusEffect(statusID);
            return hasStatus == needsToHave;
        }

        public static EffectorConditionSO Create(string statusID, bool needsToHave, int unitValueIndex = 0)
        {
            var ec = CreateScriptable<TargetStatusEffectCheckEffectorCondition>();
            ec.statusID = statusID;
            ec.needsToHave = needsToHave;
            ec.unitValueIndex = unitValueIndex;
            
            return ec;
        }
    }
}