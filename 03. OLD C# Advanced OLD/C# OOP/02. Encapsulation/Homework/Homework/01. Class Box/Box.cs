namespace _01._Class_Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }

        public string SurfaceArea()
        {
            double surfaceArea = 2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);
            return $"Surface Area – {surfaceArea:F2}";
        }

        public string LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * (this.length * this.height) + 2 * (this.width * this.height);
            return $"Lateral Surface Area – {lateralSurfaceArea:F2}";
        }

        public string Volume()
        {
            double volume = this.length * this.width * this.height;
            return $"Volume – {volume:F2}";
        }
    }
}
