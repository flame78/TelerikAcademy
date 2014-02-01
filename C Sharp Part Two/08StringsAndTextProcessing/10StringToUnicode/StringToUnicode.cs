////Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:

//Hi!

//        Expected output:

//\u0048\u0069\u0021

using System;
using System.Text;

    class StringToUnicode
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string : ");
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                result.Append("\\u"+string.Format("{0:X}",(int)input[i]).PadLeft(4,'0'));
            }

            Console.WriteLine(result);
        }
    }

