using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private const int defaultCapacity = 100;

        private int capacity;
        private List<Item> items;
        public int Load => this.items.Sum(x => x.Weight);

        public int Capacity
        {
            get { return capacity; }
            private set { this.capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return items.AsReadOnly(); }
        }

        public void AddItem(Item item)
        {
            if (Load+item.Weight>Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!items.Any(x=>x.GetType().Name==name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            items.Remove(item);

            return item;
        }

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        protected Bag()
        {
            this.Capacity = defaultCapacity;
            this.items = new List<Item>();
        }
    }
}
