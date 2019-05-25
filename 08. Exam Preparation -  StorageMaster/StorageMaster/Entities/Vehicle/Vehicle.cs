using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities
{
    public abstract class Vehicle
    {
        private int capacity;
        private List<Product> trunk;

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public IReadOnlyCollection<Product> Trunk
        {
            get { return trunk.AsReadOnly(); }
        }

        public bool IsFull
        {
            get
            {
                if (trunk.Sum(x => x.Weight) >= Capacity)
                {
                    return true;
                }
                return false;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (trunk.Count==0)
                {
                    return true;
                }
                return false;
            }
        }

        public Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (trunk.Count==0)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            Product product = trunk.LastOrDefault();
            trunk.RemoveAt(trunk.Count - 1);
            return product;
        }
    }
}
