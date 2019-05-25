using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities
{
    public abstract class Character
    {
        private const double defaultRestHealMultiplier = 0.2;

        private bool isAlive;
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;

        public virtual double RestHealMultiplier => defaultRestHealMultiplier;
        public Faction Faction
        {
            get
            {
                return faction;
            }
            private set // TODO - What if input is not valid(CSharp or Java)?
            {
                faction = (Faction)(value);
            }
        }
        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }
        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            private set
            {
                abilityPoints = value;
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value <= 0)
                {
                    armor = 0;
                }
                else if (value >= BaseArmor)
                {
                    armor = BaseArmor;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }
        public double Health
        {
            get { return health; }
            set // TODO CHECK WHAT CONDITIONS ARE IN PLACE 
            {
                if (value<=0)
                {
                    this.IsAlive = false;
                    health = 0;
                }
                else if (value>BaseHealth)
                {
                    health = BaseHealth;
                }
                else
                {
                    health = value;
                }
            } 
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; } // perhaps no need for setter
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }


        public bool IsAlive
        {
            get { return isAlive; }
            private set { isAlive = value; }
        }

        public void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            double damageToTake = 0;

            if (Armor>=hitPoints)
            {
                Armor -= hitPoints;
            }
            else if (Armor<hitPoints)
            {
                damageToTake = hitPoints - Armor;
                Armor = 0;

                if (damageToTake>=Health)
                {
                    this.Health = 0;
                    this.IsAlive = false;
                }
                else
                {
                    Health -= damageToTake;
                }
            }
        }

        public void Rest()
        {
            if (!this.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            if (!this.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item,Character character)
        {
            if (!this.IsAlive || !character.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive || !character.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.ReceiveItem(item); // item is not taken from the giver, just given to the receiver
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive) // perhaps no error should be thrown
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            this.Bag.AddItem(item);
        }

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }
    }
}
