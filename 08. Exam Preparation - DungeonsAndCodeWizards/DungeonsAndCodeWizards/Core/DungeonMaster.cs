using DungeonsAndCodeWizards.Entities;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> items;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
            this.lastSurvivorRounds = 0;
        }
        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            if (characterType!="Warrior" && characterType !="Cleric")
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            Character character;

            if (characterType=="Warrior")
            {
                character = new Warrior(name, factionResult);
            }
            else
            {
                character = new Cleric(name, factionResult);
            }

            characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            switch (itemName)
            {
                case "HealthPotion":
                    items.Add(new HealthPotion());
                    break;
                case "PoisonPotion":
                    items.Add(new PoisonPotion());
                    break;
                case "ArmorRepairKit":
                    items.Add(new ArmorRepairKit());
                    break;
                default:
                    throw new ArgumentException($"Invalid item \"{ itemName }\"!");
            }

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (!characters.Any(x=>x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (items.Count==0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = items.Last();
            items.RemoveAt(items.Count - 1);

            characters.FirstOrDefault(x => x.Name == characterName).Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            if (!characters.Any(x=>x.Name == characterName))
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Character character = characters.FirstOrDefault(x => x.Name == characterName);
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            if (!characters.Any(x => x.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!characters.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Character giver = characters.FirstOrDefault(x => x.Name == giverName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            if (!characters.Any(x => x.Name == giverName))
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (!characters.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Character giver = characters.FirstOrDefault(x => x.Name == giverName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);
            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            List<Character> orderedCharacters = characters
                .OrderByDescending(x => x.IsAlive)
                .ThenByDescending(y => y.Health)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var character in orderedCharacters)
            {
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (!characters.Any(x => x.Name == attackerName))
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (!characters.Any(x => x.Name == receiverName))
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Character attacker = characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            StringBuilder sb = new StringBuilder();

            ((Warrior)attacker).Attack(receiver);

            sb.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if(!receiver.IsAlive)
            {
                sb.Append($"\n{receiver.Name} is dead!");
            }

            return sb.ToString();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (!characters.Any(x => x.Name == healerName))
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (!characters.Any(x => x.Name == healingReceiverName))
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            Character healer = characters.FirstOrDefault(x => x.Name == healerName);
            Character receiver = characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            StringBuilder sb = new StringBuilder();

            ((Cleric)healer).Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.Where(x=>x.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (characters.Where(x=>x.IsAlive).Count()<=1)
            {
                lastSurvivorRounds++;
            }

            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds>1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
