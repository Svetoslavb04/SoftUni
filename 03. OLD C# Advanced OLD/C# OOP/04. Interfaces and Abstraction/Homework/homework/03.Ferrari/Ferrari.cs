namespace _03.Ferrari
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Ferrari : IDrivable
    {
        private const string model = "488-Spider";

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Model => model;
        public string Driver { get; protected set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }
    }
}
