//Write a program that reads two numbers N and K and generates all the combinations of K distinct elements from the set [1..N]. Example:
//	N = 5, K = 2  {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
using System;

class CombinationsOfKDistinctElements
{
    static void Main()
    {
        Console.Write("Enter N:");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter K:");
        int K = int.Parse(Console.ReadLine());
        int[] variations = new int[K];
        Combinations(variations, 0, 1, N);

    }

    static void Combinations(int[] array, int index, int currentNumber, int N)
    {
       
        if (index == array.Length)
        {
              for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = currentNumber; i <= N; i++)
            {
                array[index] = i;
                Combinations(array, index + 1, i+1,N);
            }
        }
   

        
    }
}

