// Write a method GetMax() with two parameters that returns the bigger of two integers. Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

    class MethodGetMax
    {
        private static int GetMax(params int[] p1)  // Не отговаря точно на условиeто на задачата на върши по-добра работа :)
        {
            if (p1.Length == 0) return int.MinValue;
            int max=p1[0];
            for (int i = 1; i < p1.Length; i++)
            {
                if (max < p1[i]) max = p1[i];
            }
            return max;
        }
        
        static void Main()
        {
            int int1=int.Parse(Console.ReadLine());
            int int2 = int.Parse(Console.ReadLine());
            int int3 = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(int1,int2,int3));
        }

        
    }

