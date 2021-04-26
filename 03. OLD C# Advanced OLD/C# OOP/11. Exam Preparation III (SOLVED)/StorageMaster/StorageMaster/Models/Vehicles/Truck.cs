namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int InitialCapacity = 5;

        public Truck()
            : base(InitialCapacity)
        {
        }
    }
}
