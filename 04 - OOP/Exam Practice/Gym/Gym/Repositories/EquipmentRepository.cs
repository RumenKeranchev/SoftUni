using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> _equipment;

        public EquipmentRepository()
        {
            _equipment = new List<IEquipment>();
        }

        public IReadOnlyCollection<IEquipment> Models => _equipment;

        public void Add(IEquipment model)
        {
            _equipment.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return _equipment.FirstOrDefault(e => e.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return _equipment.Remove(model);
        }
    }
}
