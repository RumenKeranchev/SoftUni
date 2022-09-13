using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    /// <summary>
    /// 80/100
    /// https://judge.softuni.org/Contests/Practice/Index/3285#2
    /// </summary>
    public class Airfield
    {
        private string _name;
        private int _capacity;
        private double _landingStrip;

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name.Trim();
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public List<Drone> Drones { get; private set; } = new List<Drone>();
        public int Count => Drones.Count;
        public string Name { get => _name; set => _name = value; }
        public int Capacity { get => _capacity; set => _capacity = value; }
        public double LandingStrip { get => _landingStrip; set => _landingStrip = value; }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }

            if (Count == Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            var droneToRemove = Drones.FirstOrDefault(d => d.Name.ToLowerInvariant() == name.Trim().ToLowerInvariant());

            if (droneToRemove != null)
            {
                Drones.Remove(droneToRemove);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(d => d.Brand.ToLowerInvariant() == brand.Trim().ToLowerInvariant());
        }

        public Drone FlyDrone(string name)
        {
            var drone = Drones.FirstOrDefault(d => d.Name.ToLowerInvariant() == name.Trim().ToLowerInvariant());

            if (drone != null)
            {
                drone.Fly();
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            var dronesToFly = Drones.Where(d => d.Range >= range).ToList();

            dronesToFly.ForEach(drone => drone.Fly());

            return dronesToFly;
        }

        public string Report()
        {
            var notFlownDrones = Drones.Where(d => d.Available).ToList();

            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}");

            foreach (var drone in notFlownDrones)
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
