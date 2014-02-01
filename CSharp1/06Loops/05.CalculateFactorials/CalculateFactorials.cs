//Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;
using System.Numerics;

class CalculateFactorials
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int kMinusN = k - n;
        BigInteger kFactorial = 1, nFactorial = 1, kMinusNFactorial=1;

        for (int i = 1; i <= k; i++)
        {
            kFactorial *= i;
            if (i == n) nFactorial = kFactorial;
            if (i == kMinusN) kMinusNFactorial = kFactorial;
        }

        Console.WriteLine(nFactorial * kFactorial / kMinusNFactorial);
    }
}
