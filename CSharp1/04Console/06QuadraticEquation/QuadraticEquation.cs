//Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class QuadraticEquation
{
    static void Main()
    {
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal c = decimal.Parse(Console.ReadLine());
        decimal x1, x2, current, previous, x;

        if ((b * b - 4 * a * c) < 0 || a == 0) Console.WriteLine("NaN");
        else
        {

            x = (b * b - 4 * a * c);

            current = (decimal)Math.Sqrt((double)x);

            do                                                  // increase precision of Math.Sqrt to Decimal
            {
                previous = current;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > 0);

            x1 = (-b + current) / (2 * a);
            x2 = (-b - current) / (2 * a);
            Console.WriteLine(x1);
            Console.WriteLine(x2);

            // check precision

            Console.WriteLine(a * x1 * x1 + b * x1 + c);
            Console.WriteLine(a * x2 * x2 + b * x2 + c);

        }

    }
}

