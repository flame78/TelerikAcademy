using System;



class Compare2FloatPointValues
{
    static void Main()
    {
        decimal firstValue = 0.000001M;
        decimal secondValue = 0.0000002M;
        bool equal = decimal.Round(firstValue, 6) == decimal.Round(secondValue, 6);
        Console.WriteLine(equal);
    }
}

