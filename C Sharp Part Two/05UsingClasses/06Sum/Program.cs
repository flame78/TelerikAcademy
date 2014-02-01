//You are given a sequence of positive integer values written into a string, separated by spaces. Write a function that reads these values from given string and calculates their sum. Example:
//		string = "43 68 9 23 318"  result = 461

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter positive integer values separated by spaces = ");
        string str = Console.ReadLine();
        string[] str2 = str.Split(' ');
        decimal sum = 0;

        for (int i = 0; i < str2.Length; i++)
        {
            sum += int.Parse(str2[i]);
        }

        Console.WriteLine(sum);
    }
}

