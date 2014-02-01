using System;

class AgeAfter10
{
    static void Main()
    {
        Console.WriteLine("How old are you?");
        Console.WriteLine("After 10 years, you will be " + (10 + Convert.ToDecimal(Console.ReadLine())) + ".");
    }
}

