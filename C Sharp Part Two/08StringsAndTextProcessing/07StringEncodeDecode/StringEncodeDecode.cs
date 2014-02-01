//Write a program that encodes and decodes a string using given encryption key (cipher). The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, the second – with the second, etc. When the last key character is reached, the next is the first.

using System;
using System.Text;


  class StringEncodeDecode
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");
            StringBuilder input = new StringBuilder(Console.ReadLine());

            Console.Write("Enter encryption key (cipher) : ");
            string cipher = Console.ReadLine();

            int cipherIndex=0;
            for (int i = 0; i < input.Length; i++)
            {
                input[i]=(char)(input[i]^cipher[cipherIndex]);
                cipherIndex++;
                if (cipherIndex == cipher.Length) cipherIndex = 0;
            }

            Console.WriteLine(input);

        }
    }

