//Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.

using System;
class Program
{
    static string name;
    static void AskName()
    {
        Console.Write("What is you name?");
        name = Console.ReadLine();
    }
    static void PrintHelloName()
    {
        AskName();
        Console.WriteLine("Hello, "+name);
    }
    static void Main()
    {
        PrintHelloName();
    }
}
