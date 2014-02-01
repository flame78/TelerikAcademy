using System;
using System.Numerics;


class Problem2Tribonacci
{
    static void Main()
    {
        BigInteger t1 = long.Parse(Console.ReadLine());
        BigInteger t2 = long.Parse(Console.ReadLine());
        BigInteger t3 = long.Parse(Console.ReadLine());
        BigInteger t = t1 + t2 + t3;

        int n = int.Parse(Console.ReadLine());

        if (n == 0) t = 0;
        if (n == 1) t = t1;
        if (n == 2) t = t2 ;
        if (n == 3) t = t3;




        for (int i = 4; i < n; i++)
        {
            t1 = t2;
            t2 = t3;
            t3 = t;
            t = t1 + t2 + t3;
        }

        Console.WriteLine(t);

    }
}

