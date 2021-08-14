using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : IVehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption + 1.6;
        }

        public double fuelQuantity { get; private set; }

        public double fuelConsumption { get; private set; }

        public void Drive(double distance)
        {
            if (distance * fuelConsumption > fuelQuantity)
            {
                Console.WriteLine("Truck needs refueling");
            }
            else
            {
                Console.WriteLine($"Truck travelled {distance} km");
                this.fuelQuantity -= distance * this.fuelConsumption;
            }
        }

        public void Refuel(double liters)
        {
            this.fuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {Math.Round(this.fuelQuantity, 2):F2}";
        }
    }
}
