using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AdditionalConsumption => 1.4;

        public override string DriveEmpty(double distance)
        {
            if (this.FuelQuantity >= distance)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }
    }
}
