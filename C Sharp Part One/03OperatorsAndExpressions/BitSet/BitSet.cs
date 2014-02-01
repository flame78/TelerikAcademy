using System;

//  We are given integer number n, value v (v=0 or 1) and a position p. 
//  Write a sequence of operators that modifies n to hold the value v
//  at the position p from the binary representation of n.
//	Example: n = 5 (00000101), p=3, v=1  13 (00001101)
//	n = 5 (00000101), p=2, v=0  1 (00000001)

class BitSet
{
    static void Main()
    {
        int n,mask;
        byte p,v;

        Console.Write("Integer n=");
        while (!int.TryParse(Console.ReadLine(), out n));

        Console.Write("Bit position<32 p=");
        while (!byte.TryParse(Console.ReadLine(), out p) || p >= 32);

        Console.Write("Bit value(0 or 1) v=");
        while (!byte.TryParse(Console.ReadLine(), out v) || v >1) ;


        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

        switch (v)
        {
            case 0:
                mask = ~(1 << p);
                n = n & mask;
                break;
            case 1:
                mask = 1 << p;
                n = n | mask;
                break;
        }

        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));

    }
}