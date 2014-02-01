//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.


using System;
class SumOfSubset
{
    static void Main()
    {
        int[] a;
        string input;
        int sum;
        a = new int[6];

        a[0] = 0;

        for (int i = 1; i <= 5; i++)
        {
            do
            {
                input = Console.ReadLine();
            } while (!int.TryParse(input, out a[i]));
        }

        Console.WriteLine(new string('-',40));
        for (int mask = 1; mask < 1 << 5; mask++)   // Count to 2^4 in binary 11111
        {                                           // use bits to get all combinations
            sum = 0;

            for (int i2 = 0; i2 < 5; i2++)
            {
                if ((int)((1 << i2) | mask) == mask)    // if bit i2 is 1 
                {
                    sum += a[i2 + 1];                   // add integer number i2+1 to sum
                }
            }

            if (sum == 0)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    if ((int)((1 << i2) | mask) == mask)
                    {
                        Console.Write(a[i2 + 1] + "\t");
                    }
                    else Console.Write("\t");
                }
                Console.WriteLine();

            }


        }
    }
}

