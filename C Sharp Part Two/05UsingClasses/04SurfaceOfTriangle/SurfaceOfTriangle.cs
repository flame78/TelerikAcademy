// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class SurfaceOfTriangle
{
    static void Main(string[] args)
    {
        decimal a, b, c, h, angle,tmp2;
        double tmp;
        Console.Write("Enter side b = ");
        decimal.TryParse(Console.ReadLine(), out b);
        Console.Write("Enter altitude to b  h = ");
        decimal.TryParse(Console.ReadLine(), out h);

        Console.WriteLine("Surface of triangle = {0}", (b * h / 2));
        Console.WriteLine();

        Console.Write("Enter side a = ");
        decimal.TryParse(Console.ReadLine(), out a);
        Console.Write("Enter side b = ");
        decimal.TryParse(Console.ReadLine(), out b);
        Console.Write("Enter angle between a and b  = ");
        decimal.TryParse(Console.ReadLine(), out angle);

        tmp= Math.Sin((double)angle);
        tmp2 = (1m / 2m * a * b * (decimal)tmp);
        Console.WriteLine("Surface of triangle = {0}", tmp2);
        Console.WriteLine();

        Console.Write("Enter side a = ");
        decimal.TryParse(Console.ReadLine(), out a);
        Console.Write("Enter side b = ");
        decimal.TryParse(Console.ReadLine(), out b);
        Console.Write("Enter side c  = ");
        decimal.TryParse(Console.ReadLine(), out c);
        Console.WriteLine("Surface of triangle = {0}",( 1d / 4d * Math.Sqrt((double)((a + b - c) * (a - b + c) * (-a + b + c) * (a + b + c)))));
    }
}

