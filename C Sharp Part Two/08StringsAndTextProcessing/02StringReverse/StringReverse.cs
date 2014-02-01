//Write a program that reads a string, reverses it and prints the result at the console.
//Example: "sample"  "elpmas".

using System;
using System.Text;


    class StringReverse
    {
        static void Main()
        {
            Console.Write("Enter string : ");
            StringBuilder input = new StringBuilder(Console.ReadLine());

            for (int i = 0; i < input.Length/2; i++) // Count to middle 
            {
                char tmp;
                tmp = input[i];
                input[i] = input[input.Length - 1 - i]; // switch first half fromt start
                input[input.Length - 1 - i] = tmp;      // to seceond half from end
            }

            Console.WriteLine("Reversed string : " + input);
        }
    }

