// Write a program that finds in given array of integers a sequence of given sum S (if present). Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5}	

using System;

class SequenceOfGivenSumS
    {
        static void Main()
        {
            int sum;
            int[] array = ReadArray();


            Console.Write("Enter Sum S:");
            int S = int.Parse(Console.ReadLine());

            for (int b = 0; b < array.Length; b++)
            {
                sum = 0;
                for (int i = b; i < array.Length; i++)
                {
                    sum += array[i];
                    if (sum==S)
                    {
                        for (int r = b; r <= i; r++)
                        {
                            Console.Write(array[r]);
                            if (r != i) Console.Write(", ");
                        }
                        Console.WriteLine();
                        return;
                    }
                }
            }

        }

       

        private static int[] ReadArray()
        {
            string input;
            int length;

            Console.Write("Enter Array(Example:3, 2, 3, 4, 2, 2, 4):");

            input = Console.ReadLine();

            string[] tokens = input.Split(',');

            length = tokens.Length;

            int[] array = new int[length];


            for (int i = 0; i < tokens.Length; i++)
            {
                array[i] = int.Parse(tokens[i]);
            }

            return array;
        }
    }

