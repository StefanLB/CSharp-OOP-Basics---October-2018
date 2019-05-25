using StorageMaster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Controller
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> products;
        private Dictionary<string, Storage> storages;
        Vehicle currentVehicle;

        public StorageMaster()
        {
            this.products = new Dictionary<string, Stack<Product>>();
            this.storages = new Dictionary<string, Storage>();
        }

        public string AddProduct(string type, double price)
        {
            Product product;

            switch (type)
            {
                case "Gpu":
                    product = new Gpu(price);
                    break;
                case "HardDrive":
                    product = new HardDrive(price);
                    break;
                case "Ram":
                    product = new Ram(price);
                    break;
                case "SolidStateDrive":
                    product = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException("Invalid product type!");
            }

            if (!products.ContainsKey(type))
            {
                products.Add(type, new Stack<Product>());
            }

            products[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage;

            switch (type)
            {
                case "AutomatedWarehouse":
                    storage = new AutomatedWarehouse(name);
                    break;
                case "DistributionCenter":
                    storage = new DistributionCenter(name);
                    break;
                case "Warehouse":
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            this.storages.Add(name, storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            currentVehicle = storages[storageName].GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int totalLoaded = 0;
            foreach (string product in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!products.ContainsKey(product) || products[product].Count == 0)
                {
                    throw new InvalidOperationException($"{product} is out of stock!");
                }
                currentVehicle.LoadProduct(products[product].Pop());
                totalLoaded++;
            }
            return $"Loaded {totalLoaded}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = storages[sourceName];
            Storage destinationStorage = storages[destinationName];
            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);


            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages[storageName];
            Vehicle vehicle = storage.GetVehicle(garageSlot);

            int productsInVehicle = vehicle.Trunk.Count;
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storages[storageName];

            Dictionary<string, int> productsAndCount = new Dictionary<string, int>();
            foreach (Product product in storage.Products)
            {
                string productTypeName = product.GetType().Name;

                if (!productsAndCount.ContainsKey(productTypeName))
                {
                    productsAndCount.Add(productTypeName, 1);
                }
                else
                {
                    productsAndCount[productTypeName]++;
                }
            }

            double productsSum = storage.Products.Sum(p => p.Weight);
            int storageCapacity = storage.Capacity;

            string[] productsAsStrings = productsAndCount
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .Select(kvp => $"{kvp.Key} ({kvp.Value})")
                .ToArray();

            string stockLine = $"Stock ({productsSum}/{storageCapacity}): [{string.Join(", ", productsAsStrings)}]";

            string[] storageStringRepresentation = storage
                .Garage
                .Select(g => g == null ? "empty" : g.GetType().Name)
                .ToArray();

            string garageLine = $"Garage: [{string.Join("|", storageStringRepresentation)}]";

            string result = stockLine +
                            Environment.NewLine +
                            garageLine;

            return result;
        }

        public string GetSummary()
        {
            storages = storages.OrderByDescending(x => x.Value.Products.Sum(y => y.Price)).ToDictionary(x=>x.Key,y=>y.Value);

            StringBuilder sb = new StringBuilder();

            foreach (var storage in storages)
            {
                string storageName = storage.Key;
                double totalMoney = storage.Value.Products.Sum(p => p.Price);

                sb.Append($"{storageName}:\n");
                sb.Append($"Storage worth: ${totalMoney:F2}\n");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }

    }
}
