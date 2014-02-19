//Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable constructor so that at initialization height must be kept equal to width and implement the Calculate Surface() method. Write a program that tests the behavior of  the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.

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
