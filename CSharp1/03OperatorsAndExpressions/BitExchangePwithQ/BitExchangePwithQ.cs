using System;

//  Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer

class BitExchangePwithQ
{
    static void Main()
    {
        uint n;
        int b1, b2, p, q, k;

        Console.Write("Unsigned Integer n=");
        while (!uint.TryParse(Console.ReadLine(), out n)) ;

        Console.Write("Bit number p=");
        while (!int.TryParse(Console.ReadLine(), out p)) ;

        Console.Write("Bit number q=");
        while (!int.TryParse(Console.ReadLine(), out q)) ;

        Console.Write("Number of bits k=");
        while (!int.TryParse(Console.ReadLine(), out k)) ;

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

        for (int i = 0; i < k; i++)
        {
            b1 = BitExtract(n, p + i);
            b2 = BitExtract(n, q + i);

            n = BitSet(n, p + i, b2);
            n = BitSet(n, q + i, b1);

        }

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

