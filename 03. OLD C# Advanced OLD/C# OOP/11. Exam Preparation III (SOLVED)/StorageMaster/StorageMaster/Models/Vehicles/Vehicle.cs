namespace StorageMaster.Models.Vehicles
{
    using StorageMaster.Models.Contracts;
    using StorageMaster.Models.Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle : IVehicle
    {
        private List<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;

            this.trunk = new List<Product>();
        }

        public IReadOnlyCollection<Product> Trunk { get => this.trunk.AsReadOnly(); }

        public int Capacity { get; private set; }

        public bool IsFull
        {
            get
            {
                if (trunk.Sum(p => p.Weight) >= this.Capacity)
                {
                    this.isFull = true;

                    return this.isFull;
                }

                return false;
            }
        }

        public bool IsEmpty
        {
            get
            {
                if (trunk.Count == 0)
                {
                    this.isEmpty = true;

                    return this.isEmpty;
                }

                return false;
            }
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
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            Product product = this.trunk.Last();

            this.trunk.Remove(product);

            return product;
        }
    }
}
