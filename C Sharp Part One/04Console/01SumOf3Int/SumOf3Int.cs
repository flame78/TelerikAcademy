//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class SumOf3Int
{
    static void Main()
    {
        int int1, int2, int3;
        
        int1 = int.Parse(Console.ReadLine());
        int2 = int.Parse(Console.ReadLine());
        int3 = int.Parse(Console.ReadLine());
        Console.WriteLine(int1+int2+int3);

    }
}

