// Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;

class MinAndMax
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int number = int.Parse(Console.ReadLine());

            int min=number, max=number;

            for (int i = 2; i <= N; i++)
            {
                number = int.Parse(Console.ReadLine());
                if (number < min) min = number;
                else if (number > max) max = number;
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
        }
    }

