using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        private int count;

        public Parking(int capacity)
        {
            this.Cars = new Dictionary<string, Car>();
            this.Capacity = capacity;
            this.count = 0;
        }

        public Dictionary<string, Car> Cars { get { return this.cars;  } set { this.cars = value; } }
        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }
        public int Count { get { return this.count; } set { this.count = value; } }

        public string AddCar(Car car)
        {
            if (this.Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.capacity == count)
            {
                return "Parking is full!";
            }
            else
            {
                this.Cars.Add(car.RegistrationNumber, car);
                count++;

                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string RegistrationNumber)
        {
            if (!cars.ContainsKey(RegistrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                cars.Remove(RegistrationNumber);
                this.count--;
                return $"Successfully removed {RegistrationNumber}";
            }
        }

        public Car GetCar(string RegistrationNumber)
        {
            return cars[RegistrationNumber];
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            for (int i = 0; i < RegistrationNumbers.Count; i++)
            {
                if (cars.ContainsKey(RegistrationNumbers[i]))
                {
                    cars.Remove(RegistrationNumbers[i]);
                    this.count--;
                }
            }
        }
    }
}
