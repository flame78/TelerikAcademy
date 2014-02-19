using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Shape
{
    class Circle : Shape
    {

        public Circle(double diameter)
            : base(diameter, diameter) { }
        public Circle(double height, double width) :  base(height, width)
        {
            if (height != width) throw new ArgumentException("Height and Width must be same for Circle");
        }
        public override double CalculateSurface()
        {
            return Math.PI * (this.Width / 2) * (this.Width / 2);
        }
    }
}
