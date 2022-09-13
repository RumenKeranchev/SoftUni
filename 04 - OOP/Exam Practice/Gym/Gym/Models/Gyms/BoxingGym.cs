using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int defaultCapacity = 15;

        public BoxingGym(string name) : base(name, defaultCapacity)
        {
        }

        public override string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:");

            var athletesString = string.Join(", ", Athletes.Select(a => a.FullName));
            sb.AppendLine(!string.IsNullOrWhiteSpace(athletesString) ? athletesString : "No athletes");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
    }
}
