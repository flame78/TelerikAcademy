//Write a program that reads two integer numbers N and K and an array of N elements from the console. Find in the array those K elements that have maximal sum.

using System;
using System.Collections.Generic;

class MaximalSum
{
    static void Main()
    {
        int N, K;

        Console.WriteLine("Enter N");
        N = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter K");
        K = int.Parse(Console.ReadLine());

        List<int> array = new List<int>();

        for (int i = 0; i < N; i++)
        {
            Console.Write("Element {0} (Int):",i);
            array.Add(int.Parse(Console.ReadLine()));
        }

        array.Sort();

        for (int i = N-1; i > N-1-K; i--)
        {
            Console.Write(array[i]);
            if (i!=N-K) Console.Write(", ");
        }
        Console.WriteLine();
        

    }
}

