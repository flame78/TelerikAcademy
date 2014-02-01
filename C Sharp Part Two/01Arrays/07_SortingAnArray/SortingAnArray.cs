//Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

using System;

class Program
    {
        static void Main()
        {
            string input;
            int length,se,sv;
            
            Console.Write("Enter Array(Example:3, 2, 3, 4, 2, 2, 4):");

            input = Console.ReadLine();

            string[] tokens = input.Split(',');

            length = tokens.Length;

            int[] array = new int[length];

            for (int i = 0; i < tokens.Length; i++)
            {
                array[i] = int.Parse(tokens[i]);
            }

            for (int pos = 0; pos < length; pos++)
            {

                sv = array[pos];
                se = pos;

                for (int i = pos; i < length; i++)
                {
                    if (array[i] < sv)
                    {
                        sv = array[i];
                        se = i;
                    }
                }

                array[se] = array[pos];
                array[pos] = sv;
            }

            Console.WriteLine(String.Join(", ",array));
        
        }
    }
