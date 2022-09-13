using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fishList = new List<Fish>();

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }

        public IReadOnlyCollection<Fish> Fish => fishList;
        public string Material { get; private set; }
        public int Capacity { get; private set; }

        public int Count => fishList.Count();

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length < 0 || fish.Weight < 0)
            {
                return "Invalid fish.";
            }

            if (Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }

            fishList.Add(fish);

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            return fishList.RemoveAll(f => f.Weight == weight) != 0;
        }

        public Fish GetFish(string fishType)
        {
            return fishList.FirstOrDefault(f => f.FishType.Equals(fishType));
        }

        public Fish GetBiggestFish()
        {
            return fishList.OrderByDescending(f => f.Length).FirstOrDefault();
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}");

            foreach (var fish in fishList.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
