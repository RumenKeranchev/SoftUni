using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository _repository;
        private List<IGym> _gyms;

        public Controller()
        {
            _repository = new EquipmentRepository();
            _gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var validAthletes = new List<string> { nameof(Boxer), nameof(Weightlifter) };

            if (!validAthletes.Contains(athleteType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            var gym = _gyms.First(x => x.Name == gymName);

            if (athleteType == nameof(Boxer) && gym.GetType().Name != nameof(BoxingGym))
            {
                return OutputMessages.InappropriateGym;
            }
            else if (athleteType == nameof(Weightlifter) && gym.GetType().Name != nameof(WeightliftingGym))
            {
                return OutputMessages.InappropriateGym;
            }
            else
            {
                IAthlete athlete;

                if (athleteType == nameof(Boxer))
                {
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                }
                else
                {
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                }

                gym.AddAthlete(athlete);
                return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            _repository.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            var validGyms = new List<string> { nameof(BoxingGym), nameof(WeightliftingGym) };

            if (!validGyms.Contains(gymType))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            _gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = _gyms.First(g => g.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, $"{gym.EquipmentWeight:f2}");
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var equipment = _repository.FindByType(equipmentType);
            var equipmentRemoved = _repository.Remove(equipment);
            if (!equipmentRemoved)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            var gym = _gyms.First(g => g.Name == gymName);
            gym.AddEquipment(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in _gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            var gym = _gyms.First(g => g.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
