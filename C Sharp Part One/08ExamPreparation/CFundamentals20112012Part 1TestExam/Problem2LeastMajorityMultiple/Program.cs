using System;

class Problem2LeastMajorityMultiple
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());
        int nd;


        for (int i = 1; i < int.MaxValue; i++)
        {
            nd = 0;
            if (i % a == 0) nd++;
            if (i % b == 0) nd++;
            if (i % c == 0) nd++;
            if (i % d == 0) nd++;
            if (i % e == 0) nd++;

            if (nd >= 3) { Console.WriteLine(i); break; }

        }

    }
}
