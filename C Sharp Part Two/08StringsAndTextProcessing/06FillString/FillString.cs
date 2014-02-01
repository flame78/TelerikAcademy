//Write a program that reads from the console a string of maximum 20 characters. If the length of the string is less than 20, the rest of the characters should be filled with '*'. Print the result string into the console.

using System;
using System.Text;


class FillString
{
    static void Main(string[] args)
    {
        Console.Write("Enter string : ");
        StringBuilder input = new StringBuilder();
        do
        {
            input.Append(Console.ReadKey().KeyChar);
            if (input[input.Length - 1] == '\r')
            {
                input.Remove(input.Length - 1, 1);
                break;
            }
        } while (input.Length < 20);

        Console.WriteLine();
        
        if (input.Length < 20)
        {
            while (input.Length < 20)
            {
                input.Append('*');
            }
            Console.WriteLine(input);
        }
        else Console.WriteLine(input);
    }
}

