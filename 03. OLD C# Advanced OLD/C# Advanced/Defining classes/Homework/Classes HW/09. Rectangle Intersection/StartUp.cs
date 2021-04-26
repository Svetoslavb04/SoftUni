namespace _08._Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var cars = new List<Car>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age>

                string model = input[0];
                int speed = int.Parse(input[1]);
                int power = int.Parse(input[2]);
                int weight = int.Parse(input[3]);
                string type = input[4];
                double pressure1 = double.Parse(input[5]);
                int age1 = int.Parse(input[6]);
                double pressure2 = double.Parse(input[7]);
                int age2 = int.Parse(input[8]);
                double pressure3 = double.Parse(input[9]);
                int age3 = int.Parse(input[10]);
                double pressure4 = double.Parse(input[11]);
                int age4 = int.Parse(input[12]);

                Engine engine = new Engine(speed, power);
                Cargo cargo = new Cargo(weight, type);
                List<Tire> tires = new List<Tire>();
                tires.Add(new Tire(pressure1, age1));
                tires.Add(new Tire(pressure2, age2));
                tires.Add(new Tire(pressure3, age3));
                tires.Add(new Tire(pressure4, age4));

                cars.Add(new Car(model, engine, cargo, tires));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }
    }
}