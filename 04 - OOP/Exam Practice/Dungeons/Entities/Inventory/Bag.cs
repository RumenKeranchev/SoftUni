using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> _items;

        public Bag(int capacity)
        {
            _items = new List<Item>();
            Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => Items.Select(i => i.Weight).Sum();

        public IReadOnlyCollection<Item> Items => _items;

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            _items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!_items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var item = _items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            _items.Remove(item);
            return item;
        }
    }
}
