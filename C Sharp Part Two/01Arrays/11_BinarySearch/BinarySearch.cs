//  Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).

using System;

class BinarySearch
{
    static void Main(string[] args)
    {
        int endPos, startPos = 0, pos=0;

        int[] array = ReadArray();

        Array.Sort(array);

        Console.WriteLine("Sorted array:"+string.Join(", ",array));

        Console.Write("Enter element to find:");
        int element = int.Parse(Console.ReadLine());

        if (element == array[pos])
        {
            Console.WriteLine("Element {0} is on {1} position.", element, pos);
            return;
        }

        endPos = array.Length;
        pos = (endPos - startPos) / 2;

        do
        {
            if (element == array[pos])
            {
                Console.WriteLine("Element {0} is on {1} position.", element, pos);
                return;
            }
            else if (element < array[pos])
            {
                endPos = pos;
                pos = startPos + (endPos - startPos) / 2;
            }
            else
            {
                startPos = pos;

                pos = startPos + (endPos - startPos) / 2; 
            }

            if (endPos - startPos<=1)
            {
                Console.WriteLine("Element {0} is not found.", element);
                return;
            }

        } while (true);
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

