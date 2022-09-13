using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string _name;
        private double _baseHealth;
        private double _health;
        private double _baseArmor;
        private double _armor;
        private double _abilityPoints;
        private Bag _bag;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            _baseHealth = health;
            _health = health;
            _baseArmor = armor;
            _armor = armor;
            _abilityPoints = abilityPoints;
            _bag = bag;
        }

        public bool IsAlive { get; set; } = true;
        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                _name = value;
            }
        }
        public double Health { get => _health; set => _health = value; }
        public double BaseHealth => _baseHealth;
        public double Armor { get => _armor; set => _armor = value; }
        public double BaseArmor => _baseArmor;
        public double AbilityPoints => _abilityPoints;
        public Bag Bag => _bag;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            if (hitPoints > Armor)
            {
                hitPoints -= Armor;
                Armor = 0;
                Health -= hitPoints;
            }
            else
            {
                Armor -= hitPoints;
            }

            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void UseItem(Item item)
        {
            EnsureAlive();

            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            return $"{Name} - HP: {Health}/{_baseHealth}, AP: {Armor}/{_baseArmor}, Status: {(IsAlive ? "Alive" : "Dead")}";
        }
    }
}