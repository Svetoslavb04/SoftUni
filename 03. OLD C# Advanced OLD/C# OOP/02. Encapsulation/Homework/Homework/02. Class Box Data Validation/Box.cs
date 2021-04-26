using System;

namespace _02._Class_Box_Data_Validation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }

        private double Width
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                else
                {
                    this.width = value;
                }
            }
        }

        private double Height
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                else
                {
                    this.height = value;
                }
            }
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
