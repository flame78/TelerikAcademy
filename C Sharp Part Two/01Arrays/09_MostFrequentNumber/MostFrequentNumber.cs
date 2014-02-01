//  Write a program that finds the most frequent number in an array. Example:
//	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)

using System;
class MostFrequentNumber
{
    static void Main()
    {
        string input;
        int length, maxSequence = 0, maxElement = 0;

        Console.Write("Enter Array(Example:3, 2, 3, 4, 2, 2, 4):");

        input = Console.ReadLine();

        string[] tokens = input.Split(',');

        length = tokens.Length;

        int[] array = new int[length];


        for (int i = 0; i < tokens.Length; i++)
        {
            array[i] = int.Parse(tokens[i]);
        }

        Array.Sort(array);

        for (int i = 1; i < length; i++)
        {
            if (array[i] == array[i - 1])
            {
                if (i == length - 1)
                {
                    if (maxSequence == null) { maxSequence = 2; maxElement = array[i - 1]; }
                    else if (maxSequence < 2) { maxSequence = 2; maxElement = array[i - 1]; }
                    break;
                }
                for (int i2 = i + 1; i2 < length; i2++)
                {
                    if (array[i2] != array[i2 - 1])
                    {
                        if (maxSequence == null) { maxSequence = i2 - i + 1; maxElement = array[i2 - 1]; }
                        else if (maxSequence < (i2 - (i - 1))) { maxSequence = i2 - i + 1; maxElement = array[i2 - 1]; }
                        i = i2 - 1;
                        break;
                    }
                    else if (i2 == length - 1)
                    {
                        if (maxSequence == null) { maxSequence = i2 - i + 2; maxElement = array[i2 - 1]; }
                        else if (maxSequence < (i2 - (i - 2))) { maxSequence = i2 - i + 2; maxElement = array[i2 - 1]; }
                        i = i2;
                        break;
                    }
                }
            }
        }

        Console.WriteLine(maxElement + " ({0} times)", maxSequence);
    }
}

