using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int defaultCapacity = 20;

        public WeightliftingGym(string name) : base(name, defaultCapacity)
        {
        }

        public override string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:");

            var athletesString = string.Join(", ", Athletes.Select(a => a.FullName));
            sb.AppendLine("Athletes: " + (!string.IsNullOrWhiteSpace(athletesString) ? athletesString : "No athletes"));
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().Trim();
        }
    }
}
