using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities
{
    public abstract class Storage
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        private int garageSlots;

        public int GarageSlots
        {
            get { return garageSlots; }
            private set { garageSlots = value; }
        }

        public bool IsFull
        {
            get
            {
                if (Products.Sum(x=>x.Weight)>=Capacity)
                {
                    return true;
                }
                return false;
            }
        }

        private Vehicle[] garage;

        public IEnumerable<Vehicle> Garage
        {
            get { return garage; }
        }

        private List<Product> products;

        public IReadOnlyCollection<Product> Products
        {
            get { return products.AsReadOnly(); }
        }

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = vehicles.ToArray();
            this.products = new List<Product>();
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot>=GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            if (garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            return garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot,Storage deliveryLocation)
        {
            if (!deliveryLocation.garage.Any(x=>x==null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            Vehicle currentVehicle = GetVehicle(garageSlot);
            int result = Array.IndexOf(deliveryLocation.garage,null);
            deliveryLocation.garage[result] = currentVehicle;
            this.garage[garageSlot] = null;
            return result;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle currentVehicle = GetVehicle(garageSlot);
            int result = 0;

            while (!this.IsFull && !currentVehicle.IsEmpty)
            {
                products.Add(currentVehicle.Unload());
                result++;
            }

            return result;
        }
    }
}
