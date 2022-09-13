using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private bool canRace;
        private int numberOfWins;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value;
            }
        }

        public IFormulaOneCar Car => car;

        public int NumberOfWins => numberOfWins;

        public bool CanRace => canRace;

        public void AddCar(IFormulaOneCar car)
        {
            this.car = car;
            canRace = true;
        }

        public void WinRace()
        {
            numberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot { FullName } has { NumberOfWins } wins.";
        }
    }
}
