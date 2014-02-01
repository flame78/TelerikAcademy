using System;

class PrintMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            for (int i2 = i; i2 < i + n; i2++)
            {
                Console.Write("{0,-3}",i2);
            }

            Console.WriteLine();
        }
    }
}

