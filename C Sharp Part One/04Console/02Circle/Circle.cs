//Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;

class Circle
{
    static void Main()
    {
        decimal r,pi=(decimal)Math.PI;

        r = decimal.Parse(Console.ReadLine());

        Console.WriteLine(2*pi*r);
        Console.WriteLine(pi*r*r);

    }
}

