﻿namespace _08._Raw_Data
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }

        public double Pressure { get; set; }
        public int Age { get; set; }
    }
}