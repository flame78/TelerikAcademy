using System;

// Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

class BooleanExpressionOfBit3
{
    static void Main()
    {
        int intValue = 24532;
        bool beBit3;

        beBit3 = ((intValue>>3) & 1) == 1;
        Console.WriteLine(Convert.ToString(intValue,2));
        Console.WriteLine(beBit3);
    }
}

