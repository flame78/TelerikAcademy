using System;

    class Problem1MathExpression
    {
        static void Main()
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal m = decimal.Parse(Console.ReadLine());
            decimal p = decimal.Parse(Console.ReadLine());

            decimal a, b;
            double d,c;
         
            d = (int)m % 180;

            a= n*n +1/(m*p)+1337;
            b = n - 128.523123123M * p;
            c = Math.Sin(d);

            Console.WriteLine("{0:F6}",a/b+(decimal)c);

        }
    }

