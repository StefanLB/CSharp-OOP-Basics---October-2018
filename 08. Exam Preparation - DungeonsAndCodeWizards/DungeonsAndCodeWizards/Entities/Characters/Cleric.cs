using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double ClericRestHealMultiplier = 0.5;
        private const double ClericBaseHealth = 50;
        private const double ClericBaseArmor = 25;
        private const double ClericAbilityPoints = 40;

        public override double RestHealMultiplier => ClericRestHealMultiplier;

        public Cleric(string name, Faction faction)
            : base(name, ClericBaseHealth, ClericBaseArmor, ClericAbilityPoints, new Backpack(), faction)
        {
        }

        public void Heal(Character character)
        {
            if (!this.IsAlive || !character.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}
