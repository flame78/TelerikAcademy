//Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.


using System;

class Greater
{
    static void Main(string[] args)
    {
        decimal firstNum = decimal.Parse(Console.ReadLine()), secNum = decimal.Parse(Console.ReadLine());

        Console.WriteLine(Math.Max(firstNum,secNum));
    }
}

