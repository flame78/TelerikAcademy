using System;

class EvenOrOdd     // Write an expression that checks if given integer is odd or even.
{
    static void Main()
    {
        int firstValue = 1114;
        bool isOdd = 1 == (firstValue & 1); // if right bit=1 its Odd
        Console.WriteLine(isOdd ? "Value is Odd" : "Value is Even");
    }
}

