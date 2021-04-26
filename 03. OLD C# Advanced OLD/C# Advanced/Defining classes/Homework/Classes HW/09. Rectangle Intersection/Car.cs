namespace _08._Raw_Data
{
    using System.Collections.Generic;

    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public string Model{ get; set;}
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tire> Tires { get; set; } = new List<Tire>();

    }
}
