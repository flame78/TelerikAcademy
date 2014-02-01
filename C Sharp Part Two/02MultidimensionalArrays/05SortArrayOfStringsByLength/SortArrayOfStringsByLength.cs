// You are given an array of strings. Write a method that sorts the array by the 
// length of its elements (the number of characters composing them).
// Can use code as Input
using System;
using System.Collections.Generic;
class SortArrayOfStringsByLength
{
    static void Main(string[] args)
    {
        Console.WindowWidth = 100;
        string[] array = ReadStringArray();
        Console.WriteLine(new string('-', 80));
        SortByLength(array);
        PrintArray(array);
    }
    private static void SortByLength(string[] array)
    {
        Array.Sort(array, (x, y) => x.Length.CompareTo(y.Length));
    }
    private static void PrintArray(string[] array)
    {
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
    private static string[] ReadStringArray()
    {
        Console.WriteLine("Enter String Array(use empty string(only pres Enter) to finish)");
        List<string> matrix = new List<string>();
        do
        {
            string input = Console.ReadLine();
            if (input == "") break;
            matrix.Add(input);
        } while (true);
        return matrix.ToArray();
    }
}
