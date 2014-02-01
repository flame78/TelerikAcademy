//Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.
//Use the method from the previous exercise.

using System;

class Program
{
    static void Main()
    {
        double[] array = ReadArray();
        Console.WriteLine("index of the first element in array that is bigger than its neighbors = "+FirstBiggerThanTwoNeighbors(array));
    }

    private static int FirstBiggerThanTwoNeighbors(double[] array)
    {

        for (int i = 1; i < array.Length-1; i++)
        {
            if (BiggerThanTwoNeighbors(array, i)) return i;
        }
        return -1;
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

