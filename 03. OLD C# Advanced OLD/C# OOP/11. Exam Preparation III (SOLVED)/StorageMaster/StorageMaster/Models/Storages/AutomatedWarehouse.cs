namespace StorageMaster.Models.Storages
{
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;

    public class AutomatedWarehouse : Storage
    {
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };

        public AutomatedWarehouse(string name)
            : base(name, capacity: 1, garageSlots: 2, vehicles: DefaultVehicles)
        {
        }
    }
}
