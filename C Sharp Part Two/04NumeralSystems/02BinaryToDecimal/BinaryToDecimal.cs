//Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    static void Main()
    {
        ulong decimalValue = 0;
        string binary = "10000";

        for (int i = 0; i < binary.Length; i++)
        {
            decimalValue <<= 1;                            
            decimalValue += (ulong)(1 & (48 - binary[i]));

        }

        Console.WriteLine(binary);
        Console.WriteLine(decimalValue);
       
    }
}



