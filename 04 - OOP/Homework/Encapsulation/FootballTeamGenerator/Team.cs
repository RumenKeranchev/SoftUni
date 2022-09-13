using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public double Rating
        {
            get
            {
                var average = (players.Sum(p => p.Dribble) +
                players.Sum(p => p.Endurance) +
                players.Sum(p => p.Passing) +
                players.Sum(p => p.Shooting) +
                players.Sum(p => p.Sprint)) / 5.0;

                return Math.Round(average);
            }
        }
        public void AddPlayer(Player player) => players.Add(player);

        public void RemovePlayer(string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new NullReferenceException($"Player {playerName} is not in {Name} team.");
            }

            players.Remove(player);
        }

        public override string ToString()
        {
            return $"{Name} - {Rating:f0}";
        }
    }
}
