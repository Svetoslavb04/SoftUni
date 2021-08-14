using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : IVehicle
    {
        public Car(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption + 0.9;
        }

        public double fuelQuantity { get; private set; }

        public double fuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            if (distance * fuelConsumption > fuelQuantity)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.fuelQuantity -= distance * this.fuelConsumption;
            }
        }

        public void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"Car: {Math.Round(this.fuelQuantity, 2):F2}";
        }
    }
}
