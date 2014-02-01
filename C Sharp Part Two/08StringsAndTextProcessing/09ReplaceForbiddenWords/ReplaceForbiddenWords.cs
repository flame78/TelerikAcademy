//We are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces the forbidden words with asterisks. Example:

//    Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.

//        Words: "PHP, CLR, Microsoft"
//        The expected result:

//********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

using System;

class ReplaceForbiddenWords
{
    static void Main(string[] args)
    {
        Console.Write("Enter forbidden words separated by ',' : ");
        string[] words = Console.ReadLine().Split(',');
        Console.Write("Enter string : ");
        string text = Console.ReadLine();

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Trim();
            text = text.Replace(words[i], new string('*', words[i].Length));
        }

        Console.WriteLine(text);
    }
}

