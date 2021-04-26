namespace StorageMaster.Models.Contracts
{
    using StorageMaster.Models.Products;
    using System.Collections.Generic;

    public interface IVehicle
    {
        int Capacity { get; }

        bool IsFull { get; }

        bool IsEmpty { get; }

        IReadOnlyCollection<Product> Trunk { get; }

        void LoadProduct(Product product);

        Product Unload();
    }
}
