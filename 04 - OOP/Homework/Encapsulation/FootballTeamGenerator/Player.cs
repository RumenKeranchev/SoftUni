using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance { get => endurance; private set => endurance = ValidateStat(nameof(Endurance), value); }
        public int Sprint { get => sprint; private set => sprint = ValidateStat(nameof(Sprint), value); }
        public int Dribble { get => dribble; private set => dribble = ValidateStat(nameof(Dribble), value); }
        public int Passing { get => passing; private set => passing = ValidateStat(nameof(Passing), value); }
        public int Shooting { get => shooting; private set => shooting = ValidateStat(nameof(Shooting), value); }
                
        private int ValidateStat(string stat, int value)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }

            return value;
        }
    }
}
