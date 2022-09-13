using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string _name;
        private int _capacity;
        private List<IEquipment> _equipment;
        private List<IAthlete> _athletes;

        public Gym(string name, int capacity)
        {
            Name = name;
            _capacity = capacity;
            _equipment = new List<IEquipment>();
            _athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                _name = value;
            }
        }

        public int Capacity => _capacity;

        public double EquipmentWeight => Equipment.Select(e => e.Weight).Sum();

        public ICollection<IEquipment> Equipment => _equipment;

        public ICollection<IAthlete> Athletes => _athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (Capacity == Athletes.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            else
            {
                _athletes.Add(athlete);
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            _equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in _athletes)
            {
                athlete.Exercise();
            }
        }

        public abstract string GymInfo();

        public bool RemoveAthlete(IAthlete athlete)
        {
            return _athletes.Remove(athlete);
        }
    }
}
