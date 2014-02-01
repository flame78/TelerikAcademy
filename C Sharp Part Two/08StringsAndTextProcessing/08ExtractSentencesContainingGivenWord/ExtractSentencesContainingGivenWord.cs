//Write a program that extracts from a given text all sentences containing given word.
//        Example: The word is "in". The text is:

//We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//        The expected result is:

//We are living in a yellow submarine.
//We will move out of it in 5 days.

//        Consider that the sentences are separated by "." and the words – by non-letter symbols.

using System;

class ExtractSentencesContainingGivenWord
{
    static void Main(string[] args)
    {
        Console.Write("Enter string : ");
        string input = Console.ReadLine();
        Console.Write("Enter word : ");
        string word = Console.ReadLine();

        string[] tokens = input.Split('.');

        foreach (var item in tokens)
        {
            int indexOfWord = 0;
            while (indexOfWord >= 0 && item.Length > word.Length)
            {
                indexOfWord = item.IndexOf(word, indexOfWord + 1);
                if (indexOfWord >= 0)
                    if (char.IsLetter(item[indexOfWord - 1]) == false)
                        if (char.IsLetter(item[indexOfWord + word.Length]) == false)
                        {
                            Console.WriteLine(item.Trim() + ".");
                            break;
                        }
            }
        }
    }
}

