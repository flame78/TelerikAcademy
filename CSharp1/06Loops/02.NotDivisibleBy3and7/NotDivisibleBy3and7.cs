// Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;

class NotDivisibleBy3and7
{
    static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());

        if (numberN > 0)
        {
            for (int i = 1; i <= numberN; i++)
            {
                if (i % 3 == 0 &&  i% 7 == 0) continue;
                Console.WriteLine(i);
            }
        }
        else                // for negative N
        {
            for (int i = 1; i >= numberN; i--)
            {
                if (i % 3 != 0 || i % 7 != 0) Console.WriteLine(i);
            }

        }
    }
}

