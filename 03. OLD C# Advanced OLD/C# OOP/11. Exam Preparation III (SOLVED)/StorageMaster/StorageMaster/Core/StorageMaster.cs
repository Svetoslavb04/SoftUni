namespace StorageMaster.Core
{
    using global::StorageMaster.Core.Factories;
    using global::StorageMaster.Models.Products;
    using global::StorageMaster.Models.Storages;
    using global::StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private ProductFactory productFactory;
        private VehicleFactory vehicleFactory;
        private StorageFactory storageFactory;
        private readonly Dictionary<string, Storage> storageRegistry;
        private readonly Dictionary<string, Stack<Product>> productPool;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.vehicleFactory = new VehicleFactory();
            this.storageFactory = new StorageFactory();
            this.storageRegistry = new Dictionary<string, Storage>(); ;
            this.productPool = new Dictionary<string, Stack<Product>>();
        }

        public string AddProduct(string type, double price)
        {
            if (!this.productPool.ContainsKey(type))
            {
                this.productPool[type] = new Stack<Product>();
            }

            var product = this.productFactory.CreateProduct(type, price);

            this.productPool[type].Push(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.storageRegistry[storage.Name] = storage;

            return $"Registered {storage.Name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            return $"Selected {vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            foreach (var name in productNames)
            {
                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                if (!this.productPool.ContainsKey(name) || !this.productPool[name].Any())
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }

                var product = this.productPool[name].Pop();

                this.currentVehicle.LoadProduct(product);

                loadedProductsCount++;
            }

            var totalProductsCount = productNames.Count();
            return $"Loaded {loadedProductsCount}/{totalProductsCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            this.storageRegistry[sourceName].SendVehicleTo(sourceGarageSlot, this.storageRegistry[destinationName]);

            return $"Sent {this.currentVehicle.GetType()} to {destinationName} (slot {this.storageRegistry[sourceName].SendVehicleTo(sourceGarageSlot, this.storageRegistry[destinationName])})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];
            var vehicle = storage.GetVehicle(garageSlot);

            if (storage.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var productsInVehicle = vehicle.Trunk.Count;
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry[storageName];

            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();

            var productsCapacity = storage.Products.Sum(p => p.Weight);

            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]",
                productsCapacity,
                storage.Capacity,
                string.Join(", ", stockInfo));

            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();

            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();

            var sortedStorage = this.storageRegistry.Values
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToArray();

            foreach (var storage in sortedStorage)
            {
                sb.AppendLine($"{storage.Name}:");
                var totalMoney = storage.Products.Sum(p => p.Price);
                sb.AppendLine($"Storage worth: ${totalMoney:F2}");
            }

            return sb.ToString().TrimEnd('\r', '\n');
        }

    }
}
