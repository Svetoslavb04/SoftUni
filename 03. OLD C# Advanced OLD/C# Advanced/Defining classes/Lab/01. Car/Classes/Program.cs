namespace Classes
{
    using System;

    public class Car
    {
        private string make;
        private string model;
        private int year;

        public string Make
        {
            get
            {
                return this.make;
            }
            
            set
            {
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                if (value < 1950 || value > 2019)
                {
                    throw new ArgumentException("Car year should be b");
                }

                this.year = value;
            }
        }
    }

    class CarManufacturer
    {
        public static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}");
        }
    }
}
