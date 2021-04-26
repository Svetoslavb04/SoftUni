namespace _08._Raw_Data
{
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight { get; set; }
        public string Type { get; set; }
    }
}