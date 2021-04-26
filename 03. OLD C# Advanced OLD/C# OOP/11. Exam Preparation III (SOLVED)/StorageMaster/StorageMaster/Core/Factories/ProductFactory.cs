using StorageMaster.Models.Products;
using System;

namespace StorageMaster.Core.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Type productType = Type.GetType($"StorageMaster.Models.Products{type}");

            var product = Activator.CreateInstance(productType, price);

            return (Product)product;
        }
    }
}
