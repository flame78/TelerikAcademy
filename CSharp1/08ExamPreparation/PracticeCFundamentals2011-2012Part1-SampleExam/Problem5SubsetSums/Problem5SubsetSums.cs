using System;

class Problem5SubsetSums
{
    static void Main()
    {
        long s = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        //int subsets = 0;
        // int maxComb=(int)Math.Pow(2, n);
        long[] array = new long[n + 1];
        byte[,] arrayCombination = new byte[2, n];

        array[n] = 0;

        for (int i = 0; i < n; i++)
        {
            while (!long.TryParse(Console.ReadLine(), out array[i])) ;
        }

        GenerateCombinations(0, arrayCombination, n, array, s);

        //for (int i = 2; i < maxComb; i++)
        //{
        //    for (int i2 = 0; i2 < n; i2++)
        //    {
        //        Console.Write(arrayCombination[i, i2]+" ");
        //    }
        Console.WriteLine(array[n]);
        //}


    }

    static void GenerateCombinations(int index, byte[,] aC, int n, long[] ar, long s)
    {

        if (index >= n)
        {
            long sum = 0; bool zv = true;

            for (int i = 0; i < n; i++)
            {
                if (aC[1, i] != 0) { sum += ar[i]; zv = false; }
            }

            if (sum == s && zv == false)
            {
                ar[n]++;
                //for (int i = 0; i < n; i++)
                //{
                //    if (aC[1, i] != 0) Console.Write(ar[i] + " ");
                //}
                //Console.WriteLine();
            }
        }
        else
        {
            for (int i = 0; i <= 1; i++)
            {
                aC[1, index] = (byte)i;

                GenerateCombinations(index + 1, aC, n, ar, s);
            }
        }



    }
}

