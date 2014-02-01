using System;
class Problem4BinaryDigitsCount
{
    static void Main()
    {
        uint b = uint.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        uint number;
        int bits;

        for (int i = 0; i < n; i++)
        {
            number = uint.Parse(Console.ReadLine());
            bits = 0;
            for (int i2 = 0; i2 < 32; i2++)
            {
                if ((number & 1) == b) bits++;


                number = (number >> 1);
                if (number == 0) break;
            }
            Console.WriteLine(bits);
        }

    }
}

