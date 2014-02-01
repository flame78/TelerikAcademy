using System;

// Write an expression that calculates trapezoid's area by given sides a and b and height h.

class Program
{
    static void Main()
    {
        double a, b, h, area;
  
        Console.Write("Enter side a=");
        while (!double.TryParse(Console.ReadLine(), out a));

        Console.Write("Enter side b=");
        while (!double.TryParse(Console.ReadLine(), out b)) ;

        Console.Write("Enter height h=");
        while (!double.TryParse(Console.ReadLine(), out h)) ;

        area = ((a + b) * h) / 2;

        Console.WriteLine("Trapezoid area = " + area);



    }
}
