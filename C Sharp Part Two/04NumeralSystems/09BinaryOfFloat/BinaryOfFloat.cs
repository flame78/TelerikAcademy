//* Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format (the C# type float). Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

using System;

class BinaryOfFloat
{

    static void Main()
    {
        float val = -6.0000005F;
        byte[] binary = BitConverter.GetBytes(val);

        int sign = (binary[3] & 128) >> 7;
        int exponent = ((binary[3] & 127) << 1) + ((binary[2] & 128) >> 7);
        int mantissa = binary[0] + (binary[1] << 8) + ((binary[2] & 127)<<16);

        Console.WriteLine("Sign = "+sign);
        Console.WriteLine("Exponent = "+Convert.ToString(exponent, 2).PadLeft(8, '0'));
        Console.WriteLine("Mantissa = "+Convert.ToString(mantissa, 2).PadRight(23, '0'));
    }
}


