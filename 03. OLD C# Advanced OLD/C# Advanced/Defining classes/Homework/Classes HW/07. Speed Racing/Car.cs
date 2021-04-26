namespace _07._Speed_Racing
{
    public class Car
    {
        public Car (string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.DistanceTravelled = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; private set; }
        public double DistanceTravelled { get; set; }

        public bool CanDrive(double amountKm)
        {
            bool canDrive = true;

            if (amountKm * FuelConsumption > FuelAmount)
            {
                canDrive = false;
            }

            return canDrive;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {DistanceTravelled}";
        }
    }
}
