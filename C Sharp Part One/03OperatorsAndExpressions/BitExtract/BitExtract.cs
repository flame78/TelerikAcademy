using System;

//  Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2  value=1.

class BitExtract
{
    static void Main()
    {
        int i, bitValue;
        byte b;

        Console.Write("Integer i=");
        while (!int.TryParse(Console.ReadLine(), out i)) ;

        Console.Write("Bit number<32 b=");
        while (!byte.TryParse(Console.ReadLine(), out b) || b >= 32) ;

        bitValue = (i >> b)&1 ;
        Console.WriteLine("bitValue=" + bitValue);
        Console.WriteLine(Convert.ToString(i, 2).PadLeft(32, '0'));

    }
}

