// Write a program that prints all the numbers from 1 to N.


using System;

class NumbersFrom1toN
{
    static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());

        if (numberN > 0)
        {
            for (int i = 1; i <= numberN; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            for (int i = 1; i >= numberN; i--)
            {
                Console.WriteLine(i);
            }

        }

    }
}

