using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int PotionWeight = 5;
        private const int HealthRestored = 20;

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            character.Health += HealthRestored;
        }

        public HealthPotion()
            :base(PotionWeight)
        {

        }
    }
}
