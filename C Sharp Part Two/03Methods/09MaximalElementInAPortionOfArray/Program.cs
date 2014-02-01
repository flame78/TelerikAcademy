//Write a method that return the maximal element in a portion of array of integers starting at given index. Using it write another method that sorts an array in ascending / descending order.

using System;

class Program
{
    static int ascending = 1;
    static int descending = -1;

    static void Main(string[] args)
    {
        double[] arr = ReadArray();
        sort(arr, ascending);
        Console.WriteLine(string.Join(", ", arr));
        sort(arr, descending);
        Console.WriteLine(string.Join(", ", arr));

    }

    private static void sort(double[] arr, int p)
    {
        int maxIndex = 0;
        double tmp = 0;
        if (p == descending)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                maxIndex = SubArrayMaximalElementIndex(arr, i - 1, arr.Length - 1);
                tmp = arr[i - 1];
                arr[i - 1] = arr[maxIndex];
                arr[maxIndex] = tmp;

            }
        }
        if (p == ascending)
        {
            for (int i = arr.Length - 2; i >= 0; i--)
            {
                maxIndex = SubArrayMaximalElementIndex(arr, 0, i + 1);
                tmp = arr[i + 1];
                arr[i + 1] = arr[maxIndex];
                arr[maxIndex] = tmp;

            }
        }
    }

    private static int SubArrayMaximalElementIndex(double[] ar, int start = 0, int end = -1)
    {
        double max = ar[start];
        int index = start;

        if (end == -1) end = ar.Length - 1;
        for (int i = start + 1; i <= end; i++)
        {
            if (max < ar[i]) { max = ar[i]; index = i; }
        }
        return index;
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

