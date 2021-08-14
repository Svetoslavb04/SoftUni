using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public interface IVehicle
    {
        double fuelQuantity { get; }
        double fuelConsumption { get; }

        void Refuel(double liters);
        void Drive(double distance);
    }
}
