//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;

class BinaryOfShort
{
    static void Main()
    {
        short val = -1;
        string binary = "";

        int tmp;

        if (val < 0) tmp = short.MaxValue - val;
        else tmp = val;
        do
        {
            binary = (tmp & 1) + binary;    // =tmp%2+binary
            tmp >>= 1;                      // =tmp/2
        } while (tmp > 0);

        Console.WriteLine(val);
        Console.WriteLine(binary);
    }
}

