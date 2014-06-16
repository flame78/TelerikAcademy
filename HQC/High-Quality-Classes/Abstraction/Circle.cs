namespace Abstraction
{
    using System;

    public class Circle : IFigure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius of Circle must be positive");
                }

                this.radius = value;
            }
        }

        public double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.radius;

            return perimeter;
        }

        public double CalcSurface()
        {
            double surface = Math.PI * this.radius * this.radius;

            return surface;
        }
    }
}
