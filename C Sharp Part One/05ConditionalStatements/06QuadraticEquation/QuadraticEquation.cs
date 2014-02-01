//Write a program that enters the coefficients a, b and c of a quadratic equation
//        a*x2 + b*x + c = 0
//        and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.


using System;

class QuadraticEquation
{
    static void Main()
    {
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal c = decimal.Parse(Console.ReadLine());
        decimal x1, x2, current, previous, x;

        if ((b * b - 4 * a * c) < 0 || a == 0)
        {
            Console.WriteLine("0 real roots");
        }
        else if ((b * b - 4 * a * c) == 0)
        {
            x1 = ((-b) / (2 * a));
            Console.WriteLine("1 real root = " + x1);
        }
        else
        {

            x = (b * b - 4 * a * c);

            current = (decimal)Math.Sqrt((double)x);

            do             //increase accuracy of Math.Sqrt to Decimal
            {
                previous = current;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > 0);

            x1 = (-b + current) / (2 * a);
            x2 = (-b - current) / (2 * a);
            Console.WriteLine("1 real root = " + x1);
            Console.WriteLine("2 real root = " + x2);

            // check accuracy

            //Console.WriteLine(a * x1 * x1 + b * x1 + c);
            //Console.WriteLine( a * x2 * x2 + b * x2 + c);

        }

    }
}

