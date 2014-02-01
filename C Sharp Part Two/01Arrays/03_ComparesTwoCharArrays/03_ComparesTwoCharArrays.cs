// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class Program
{

    static void Main()
    {
        bool isArray1BeforeArray2 = true;
        int length,shortestArray;
        string input;

        Console.Write("Enter First Char Array:=");
        input = Console.ReadLine();

        char[] array1 = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            array1[i] = input[i];
        }

        Console.Write("Enter Second Char Array:=");
        input = Console.ReadLine();

        char[] array2 = input.ToCharArray();

        if (array1.Length < array2.Length)
        {
            length = array1.Length;
            shortestArray = 1;
        }
        else
        {
            length = array2.Length;
            shortestArray = 2;
        }

        for (int i = 0; i < length; i++)
        {

            if (array1[i] < array2[i])
                break;
            else if (array1[i] > array2[i])
            {
                isArray1BeforeArray2 = false;
                break;
            }

            if (i==length-1 && shortestArray==2)
                isArray1BeforeArray2 = false;
            
        }

        Console.WriteLine("First Array lexicographically is {0} second Array."
            , isArray1BeforeArray2 ? "Before" : "After");
    }
}