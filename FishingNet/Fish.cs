namespace FishingNet
{
    public class Fish
    {
        private readonly string fishType;
        private readonly double length;
        private readonly double weight;

        public Fish(string fishType, double length, double weight)
        {
            this.fishType = fishType;
            this.length = length;
            this.weight = weight;
        }

        public string FishType => fishType;
        public double Length => length;
        public double Weight => weight;

        public override string ToString()
        {
            return $"There is a {fishType}, {length} cm. long, and {weight} gr. in weight.";
        }
    }
}
