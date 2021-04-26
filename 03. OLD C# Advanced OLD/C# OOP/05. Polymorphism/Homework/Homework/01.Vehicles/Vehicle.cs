using System;

namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;

            if (fuelQuantity > this.TankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException($"Cannot fit {value} fuel in the tank");
                }
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        protected abstract double AdditionalConsumption { get; }



        public string Drive(double distance)
        {

            double requiredFuel = (FuelConsumption + AdditionalConsumption) * distance;

            if (requiredFuel <= FuelQuantity)
            {
                FuelQuantity -= requiredFuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double litters)
        {
            if (litters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (litters + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {litters} fuel in the tank");
            }

            FuelQuantity += litters;
        }

        public virtual string DriveEmpty(double distance)
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
