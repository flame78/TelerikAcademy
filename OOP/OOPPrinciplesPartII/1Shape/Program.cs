using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] arrayOfShapes = new Shape[4];

            arrayOfShapes[0] = new Triangle(2, 2);
            arrayOfShapes[1] = new Rectangle(2, 2);
            arrayOfShapes[2] = new Circle(2, 2);
            arrayOfShapes[3] = new Circle(2);
            

            foreach (var shape in arrayOfShapes)
            {
                Console.WriteLine(shape.CalculateSurface());
            }
        }
    }
}
