
//Write a program that finds the greatest of given 5 variables.

using System;


    class GreatestOf5
    {
        static void Main()
        {
            int[] a;
            string input;
            a = new int[6];

            a[0] = int.MinValue;

            for (int i = 1; i <= 5; i++)

            {
                do
                {
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out a[i]));

                if (a[i] > a[0])
                {
                    a[0] = a[i];
                }
            }

            Console.WriteLine(a[0]);

        }
    }

