using StorageMaster.Models.Vehicles;
using System;

namespace StorageMaster.Core.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Type vehicleType = Type.GetType($"StorageMaster.Models.Vehicles{type}");

            var vehicle = Activator.CreateInstance(vehicleType, null);

            return (Vehicle)vehicle;
        }
    }
}
