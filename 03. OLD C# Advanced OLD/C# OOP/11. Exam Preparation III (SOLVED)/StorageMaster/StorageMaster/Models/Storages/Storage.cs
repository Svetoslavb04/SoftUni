namespace StorageMaster.Models.Storages
{
    using StorageMaster.Models.Contracts;
    using StorageMaster.Models.Products;
    using StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage : IStorage
    {
        private bool isFull;
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();

            Array.Copy(vehicles.ToArray(), garage, vehicles.Count());
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull
        {
            get
            {
                if (products.Sum(p => p.Weight) >= this.Capacity)
                {
                    this.isFull = true;

                    return this.isFull;
                }

                return false;
            }
        }

        public IReadOnlyCollection<Vehicle> Garage { get => Array.AsReadOnly(this.garage); }

        public IReadOnlyCollection<Product> Products { get => this.products.AsReadOnly(); }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return this.garage[garageSlot];
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = GetVehicle(garageSlot);

            var deliveryGarageHasFreeSlot = deliveryLocation.Garage.Any(v => v == null);
            if (!deliveryGarageHasFreeSlot)
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            var addedSlot = deliveryLocation.AddVehicle(vehicle);
            return addedSlot;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.isFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            var vehicle = GetVehicle(garageSlot);
            int unloadedProducts = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();

                this.products.Add(product);
                unloadedProducts++;
            }

            return unloadedProducts;
        }

        private int AddVehicle(Vehicle vehicle)
        {
            var freeGarageSlotIndex = Array.IndexOf(this.garage, null);
            this.garage[freeGarageSlotIndex] = vehicle;

            return freeGarageSlotIndex;
        }
    }
}
