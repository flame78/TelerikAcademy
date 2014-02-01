using System;

    class Problem3ForestRoad
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int i=0;

            while (i<n) 
            {
                for (int i2 = 0; i2 < n; i2++)
                {
                    if (i2 == i) Console.Write("*");
                    else Console.Write(".");

                }
                Console.WriteLine();
                i++;
            }
          
            i=n-2;
            while (i>=0) 
            {
                for (int i2 = 0; i2 < n; i2++)
                {
                    if (i2 == i) Console.Write("*");
                    else Console.Write(".");

                }
                Console.WriteLine();
                i--;
            }

        }
    }

