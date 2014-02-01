//Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class Program
{
    static void Main(string[] args)
    {
        decimal val = 1;

        for (decimal i = 2; i < 10000000; i++)
        {
            val = val + 1 / i;
            i++;
            val = val - 1 / i;
            if ((1 / i) < 0.001M) break; 

        }
        Console.WriteLine("{0:F3}",val);
    }
}

