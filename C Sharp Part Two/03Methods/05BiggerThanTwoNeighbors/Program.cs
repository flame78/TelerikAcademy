//Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;

class Program
{
    static void Main()
    {
        double[] array = ReadArray();
        Console.Write("Position to check:");
        int pos = int.Parse(Console.ReadLine());
        Console.WriteLine(BiggerThanTwoNeighbors(array, pos));
    }

    private static bool BiggerThanTwoNeighbors(double[] array, int index)
    {
        if (array.Length == 0 || index < 1 || index >= array.Length - 1) return false;
        if (array[index] > array[index - 1] && array[index] > array[index + 1]) return true;
        return false;

    }

    private static double[] ReadArray()
    {
        string input;
        Console.Write("Enter Array(Example:3, 2, 3, 4, 2, 2, 4):");
        input = Console.ReadLine();
        string[] tokens = input.Split(',');
        double[] array1 = new double[tokens.Length];
        for (int i = 0; i < tokens.Length; i++)
        {
            array1[i] = double.Parse(tokens[i]);
        }
        return array1;
    }
}

