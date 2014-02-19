using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Shape
{
    abstract class Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public abstract double CalculateSurface();

        public Shape(double height, double width)
        {
            if (height<=0 || width<=0) throw new ArgumentException("Height and Width must be positive value");
            this.Height = height;
            this.Width = width;
        }
    }
}
