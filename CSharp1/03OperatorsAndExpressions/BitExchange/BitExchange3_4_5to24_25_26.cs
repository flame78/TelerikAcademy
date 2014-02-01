using System;

//  Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer

class BitExchange3_4_5to24_25_26
{
    static void Main()
    {
        uint n;
        int b1, b2;

        Console.Write("Unsigned Integer n=");
        while (!uint.TryParse(Console.ReadLine(), out n)) ;

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

        b1 = BitExtract(n, 3);
        b2 = BitExtract(n, 24);

        n = BitSet(n, 3, b2);
        n = BitSet(n, 24, b1);

        b1 = BitExtract(n, 4);
        b2 = BitExtract(n, 25);

        n = BitSet(n, 4, b2);
        n = BitSet(n, 25, b1);

        b1 = BitExtract(n, 5);
        b2 = BitExtract(n, 26);

        n = BitSet(n, 5, b2);
        n = BitSet(n, 26, b1);

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
    }

    static int BitExtract(uint i, int b)
    {
        return (int)((i >> b) & 1);
    }

    static uint BitSet(uint i, int b, int v)
    {
        uint mask;

        switch (v)
        {
            case 0:
                mask = ~(1U << b);
                i = i & mask;
                break;
            case 1:
                mask = 1U << b;
                i = i | mask;
                break;
        }
        return i;
    }
}

