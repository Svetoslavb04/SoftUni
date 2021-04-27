using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> specialCars = new List<Car>();

            while (true)
            {
                var input = Console.ReadLine().Split().ToList();

                if (input[0] == "No" && input[1] == "more" && input[2] == "tires")
                {
                    break;
                }

                int tyreYear1 = int.Parse(input[0]);
                double tyrePressure1 = double.Parse(input[1]);
                int tyreYear2 = int.Parse(input[2]);
                double tyrePressure2 = double.Parse(input[3]);
                int tyreYear3 = int.Parse(input[4]);
                double tyrePressure3 = double.Parse(input[5]);
                int tyreYear4 = int.Parse(input[6]);
                double tyrePressure4 = double.Parse(input[7]);

                tires.Add(new Tire[4] { new Tire(tyreYear1, tyrePressure1), new Tire(tyreYear2, tyrePressure2), new Tire(tyreYear3, tyrePressure3), new Tire(tyreYear4, tyrePressure4)});
            }

            while (true)
            {
                var input = Console.ReadLine().Split().ToList();

                if (input[0] == "Engines" && input[1] == "done")
                {
                    break;
                }

                int horsepower = int.Parse(input[0]);
                double cubicCapacity = double.Parse(input[1]);

                engines.Add(new Engine(horsepower, cubicCapacity));
            }

            while (true)
            {
                var input = Console.ReadLine().Split().ToList();

                if (input[0] == "Show" && input[1] == "special")
                {
                    break;
                }

                string make = input[0];
                string model = input[1];
                int year = int.Parse(input[2]);
                double fuelQuantity = double.Parse(input[3]);
                double fuelConsumption = double.Parse(input[4]);
                int engineIndex = int.Parse(input[5]);
                int tiresIndex = int.Parse(input[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                
                if (car.Year >= 2017 && car.Engine.HorsePower > 330 && car.Tires.Sum(x => x.Pressure) > 9 && car.Tires.Sum(x => x.Pressure) < 10)
                {
                    car.Drive(20);
                    specialCars.Add(car);
                }
            }

            foreach (Car specialCar in specialCars)
            {
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}
