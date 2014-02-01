//Write a program that calculates N!/K! for given N and K (1<K<N).

using System;
using System.Numerics;

class CalculatesNfactorialDivKfactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger kFactorial = 1, nFactorial = 1;

        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
            if (i == k) kFactorial = nFactorial;
        }

        Console.WriteLine(nFactorial / kFactorial);
    }
}
