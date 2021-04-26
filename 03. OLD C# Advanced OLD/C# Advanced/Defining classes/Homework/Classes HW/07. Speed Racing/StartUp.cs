namespace _07._Speed_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsuption = double.Parse(input[2]);

                var car = new Car(model, fuelAmount, fuelConsuption);

                cars.Add(model, car);
            }

            while (true)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                if (input[0] == "Drive")
                {
                    string model = input[1];
                    double kilometersToDrive = double.Parse(input[2]);

                    if (!cars[model].CanDrive(kilometersToDrive))
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                        continue;
                    }

                    cars[model].FuelAmount -= cars[model].FuelConsumption * kilometersToDrive;
                    cars[model].DistanceTravelled += kilometersToDrive;
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.DistanceTravelled}");
            }
        }
    }
}
