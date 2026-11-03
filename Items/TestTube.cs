namespace BO157Items.Items
{
    public static class TestTube
    {
        public static readonly string ID = "TestTube_SW".Prefix();
        public static readonly string AbilityID = "Mutate_A".Prefix();
        
        public static void Init()
        {
            var numPigment = 4;
            var abName = "Mutate";
            var abDesc = $"Produce {numPigment} random pigment not used to perform this ability.";
            
            var name = "Test Tube";
            var flav = "\"Lab-grown organism.\"";
            var desc = $"Adds \"{abName}\" as an additional ability, a reliable pigment rerolling ability.";

            var item = NewItem<BasicWearable>(ID)
                .SetBasicInformation(name, flav, desc, "TestTube")
                .SetPrice(6)
                .AddToShop();

            var ab = NewAbility(AbilityID)
                .SetBasicInformation(abName, abDesc)
                .SetEffects(new()
                {
                    Effects.GenerateEffect(ProducePigmentNotUsedForAbilityEffect.Create(CommonEffects.BasicPigmentColors), numPigment)
                })
                .AddIntent(Targeting.Slot_SelfSlot, IntentType_GameIDs.Mana_Generate.ToString())
                .CharacterAbility(new ManaColorSO[numPigment].Populate(Pigments.Grey));

            item.SetStaticModifiers(ExtraAbilityModifier(ab));
        }
    }
}