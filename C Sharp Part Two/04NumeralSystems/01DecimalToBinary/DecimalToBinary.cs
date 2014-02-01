// Write a program to convert decimal numbers to their binary representation.

using System;

class DecimalToBinary
{
    static void Main()
    {
        ulong decimalValue = 31;
        string binary = "";

        ulong tmp = decimalValue;
        do
        {
            binary = (tmp & 1) + binary;    // =tmp%2+binary
            tmp >>= 1;                      // =tmp/2
        } while (tmp > 0);

        Console.WriteLine(decimalValue);
        Console.WriteLine(binary);
    }
}

