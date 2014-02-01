// Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        ulong decimalValue = 81985529216486895;
        string hexadecimal = "";

        ulong tmp = decimalValue;
        do
        {
            if ((tmp & 15)<10)
                hexadecimal = (char)((tmp & 15)+48) + hexadecimal;    // =tmp%16+hexadecimal
            else
                hexadecimal = (char)((tmp & 15) + 65 - 10 ) + hexadecimal; 
            tmp >>= 4;                      // =tmp/16
        } while (tmp > 0);

        Console.WriteLine(decimalValue);
        Console.WriteLine(hexadecimal);
    }
}

