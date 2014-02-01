//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. Format the output aligned right in 15 symbols.

using System;
using System.Globalization;
using System.Threading;

    class PrintNumberIn4Formats
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("");
            Console.Write("Enter number : ");
            decimal number=decimal.Parse ( Console.ReadLine());
            Console.WriteLine("{0,15}",number);
            Console.WriteLine("{0,15:X}",(long)number);
            Console.WriteLine("{0,15:P}", number);
            Console.WriteLine("{0,15:E}", number);
        }
    }

