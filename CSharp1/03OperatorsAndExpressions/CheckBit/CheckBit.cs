using System;

//  Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1  false.

class CheckBit
{
    static void Main()
    {
        int v;
        byte p;
        bool isBitp1;

        Console.Write("Integer v=");
        while (!int.TryParse(Console.ReadLine(),out v));

        Console.Write("Bit position<32 p=");
        while (!byte.TryParse(Console.ReadLine(), out p) || p>=32);

        isBitp1 = ((v >> p) & 1) == 1;
        Console.WriteLine("isBitp1="+isBitp1);
        Console.WriteLine(Convert.ToString(v,2).PadLeft(32,'0'));
        
    }
}


