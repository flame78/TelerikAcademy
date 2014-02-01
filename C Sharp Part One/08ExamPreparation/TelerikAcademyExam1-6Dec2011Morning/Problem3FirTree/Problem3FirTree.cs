using System;

class Problem3FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int i2 = 0; i2 < n * 2 - 3; i2++)
            {
                if (i == n - 1)
                {
                    if ( i2==i-1 ) Console.Write("*");
                    else Console.Write(".");
                } else if (i2 > n - i-3 && i2<n+i-1) Console.Write("*");
                else Console.Write(".");
            }
            Console.WriteLine();


        }

    }
}

