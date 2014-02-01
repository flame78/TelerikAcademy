//Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class TwoIntDivision5
{
    static void Main()
    {
        uint firstInt = uint.Parse(Console.ReadLine()), secInt = uint.Parse(Console.ReadLine());
        int p = 0;

        for (uint i = firstInt; i <= secInt; i++)
        {
            if (i % 5 == 0) p++;
        }

        Console.WriteLine(p);


    }
}
