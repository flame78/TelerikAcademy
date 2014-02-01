//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class PrintListOfWordsInAlphabeticalOrder
{
    static void Main()
    {
        Console.Write("Enter list of words separated by spaces : ");
        string str = Console.ReadLine();

        var words = new List<string>();

        foreach (Match word in Regex.Matches(str, @"\w+"))
            words.Add(word.Value);

        words.Sort();

        foreach (string word in words)
            Console.WriteLine(word);
    }
}

