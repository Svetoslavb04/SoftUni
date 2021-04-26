namespace StorageMaster.Models.Contracts
{
    using StorageMaster.Models.Products;
    using StorageMaster.Models.Storages;
    using StorageMaster.Models.Vehicles;
    using System.Collections.Generic;

    public interface IStorage
    {
        string Name { get; }

        int Capacity { get; }

        int GarageSlots { get; }

        bool IsFull { get; }

        IReadOnlyCollection<Vehicle> Garage { get; }

        IReadOnlyCollection<Product> Products { get; }

        Vehicle GetVehicle(int garageSlot);

        int SendVehicleTo(int garageSlot, Storage deliveryLocation);

        int UnloadVehicle(int garageSlot);
    }
}
