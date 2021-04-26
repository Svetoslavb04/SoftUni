using StorageMaster.Models.Storages;
using System;

namespace StorageMaster.Core.Factories
{
    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Type storageType = Type.GetType($"StorageMaster.Models.Storages{type}");

            var storage = Activator.CreateInstance(storageType, name);

            return (Storage)storage;
        }
    }
}
