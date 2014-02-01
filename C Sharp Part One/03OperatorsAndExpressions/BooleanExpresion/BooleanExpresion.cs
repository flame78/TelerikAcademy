using System;

// Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

class BooleanExpresion
{
    static void Main()
    {
        int firstValue = 35;
        bool boolExp = (firstValue % 5 == 0) && (firstValue % 7 == 0 );
        Console.WriteLine(boolExp);

    }
}

