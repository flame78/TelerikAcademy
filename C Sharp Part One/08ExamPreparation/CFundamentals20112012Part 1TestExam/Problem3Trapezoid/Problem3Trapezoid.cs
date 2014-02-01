using System;

    class Problem3Trapezoid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int y = 0; y < n + 1; y++)
            {


                for (int x = 0; x < n * 2; x++)
                {
                    if (y == 0)
                        if (x < n) Console.Write(".");
                        else Console.Write("*");
                    else if (y == n) Console.Write("*");
                    else if (x == n - y) Console.Write("*");
                    else if (x == n * 2 - 1) Console.Write("*");
                    else Console.Write(".");

                }
                Console.WriteLine();
            }

        }
    }

