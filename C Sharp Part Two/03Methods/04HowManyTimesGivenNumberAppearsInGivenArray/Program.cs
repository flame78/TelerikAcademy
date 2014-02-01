// Write a method that counts how many times given number appears in given array. Write a test program to check if the method is working correctly.

using System;
class Program04
{

    static void Main()
    {
        double[] array = ReadArray();
        Console.Write("Number to chek:");
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine("{0} repeats {1} times",number, RepeatInArray(array, number));
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

    private static int RepeatInArray(double[] array, double number)
    {
        if (array.Length == 0) return 0;
        int repeat = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number) repeat++;
        }
        return repeat;

    }



}

