using System.Text;

namespace Drones
{
    public class Drone
    {
        private readonly string _name;
        private readonly string _brand;
        private readonly int _range;
        private bool _available = true;

        public Drone(string name, string brand, int range)
        {
            _name = name.Trim();
            _brand = brand.Trim();
            _range = range;
        }

        public string Name => _name;
        public string Brand => _brand;
        public int Range => _range;
        public bool Available => _available;

        public void Fly()
        {
            _available = false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drone: {_name}");
            sb.AppendLine($"Manufactured by: {_brand}");
            sb.AppendLine($"Range: {_range} kilometers");

            return sb.ToString().Trim();
        }
    }
}
