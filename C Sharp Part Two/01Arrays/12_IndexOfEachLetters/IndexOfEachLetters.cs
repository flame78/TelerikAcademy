//Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Collections.Generic;


    class IndexOfEachLetters
    {
        static void Main()
        {
            List<char> alphabet = new List<char>();

            for (int i = 0; i <= (int)'Z'- (int)'A'; i++)
            {
               alphabet.Add((char)((int)'A'+i)); 
            }

            string input = Console.ReadLine();

            for (int s = 0; s < input.Length; s++)
            {
                Console.Write(alphabet.IndexOf(input[s]));
                if (s != input.Length - 1) Console.Write(", ");
            }

            Console.WriteLine();


        }
    }

