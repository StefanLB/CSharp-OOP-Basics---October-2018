﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class PoisonPotion : Item
    {
        private const int PoisonPotionWeight = 5;
        private const int PoisonPotionDamage = 20;
        public PoisonPotion()
            : base(PoisonPotionWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
            character.Health -= PoisonPotionDamage;
        }
    }
}
