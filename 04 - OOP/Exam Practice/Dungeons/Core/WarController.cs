using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Core.IO;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private List<string> characterTypes = new List<string>() { nameof(Warrior), nameof(Priest) };
        private List<string> itemTypes = new List<string>() { nameof(HealthPotion), nameof(FirePotion) };
        private List<Character> party;
        private List<Item> itemPool;
        public WarController()
        {
            party = new List<Character>();
            itemPool = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            var type = typeof(Character).Assembly.GetTypes().FirstOrDefault(t => t.Name == args[0]);
            var name = args[1];

            if (type == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, args[0]));
            }

            var character = (Character)Activator.CreateInstance(type, name);
            party.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            var name = args[0];
            var type = typeof(Item).Assembly.GetTypes().FirstOrDefault(t => t.Name == name);

            if (type == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
            }

            var item = (Item)Activator.CreateInstance(type);
            itemPool.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, name);
        }

        public string PickUpItem(string[] args)
        {
            var character = party.FirstOrDefault(c => c.Name == args[0]);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            if (!itemPool.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            var item = itemPool.Last();
            itemPool.Remove(item);

            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, character.Name, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            var character = party.FirstOrDefault(c => c.Name == args[0]);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            var item = character.Bag.GetItem(args[1]);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, character.Name, item.GetType().Name);
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            foreach (var character in party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                sb.AppendLine(character.ToString());
            }

            return sb.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            var attacker = party.FirstOrDefault(c => c.Name == args[0]);
            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            var receiver = party.FirstOrDefault(c => c.Name == args[1]);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
            }

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attacker.Name));
            }

            var attackerCast = attacker as IAttacker;
            attackerCast.Attack(receiver);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Name,
                receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiver.Name));
            }

            return sb.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            var healer = party.FirstOrDefault(c => c.Name == args[0]);
            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[0]));
            }

            var receiver = party.FirstOrDefault(c => c.Name == args[1]);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, args[1]));
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healer.Name));
            }

            var healerCast = healer as IHealer;
            healerCast.Heal(receiver);

            var sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health));

            return sb.ToString().Trim();
        }
    }
}
