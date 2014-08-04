namespace Abstraction
{
    using System;

    public class Rectangle : IFigure
    {
        private double height;

        private double width;

        public Rectangle(double width, double height)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height of Rectangle must be positive");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width of Rectangle must be positive");
                }

                this.width = value;
            }
        }

        public double CalcPerimeter()
        {
            var perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public double CalcSurface()
        {
            var surface = this.Width * this.Height;
            return surface;
        }
    }
}