//Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;
   class Fibonacci
    {
        static void Main()
        {
            decimal f=0, s=1,t=0;
            Console.WriteLine("1="+f);
            Console.WriteLine("2="+s);
            for (int i = 3; i <=100; i++)
            {
                t = f + s;
                f = s; s = t;
                Console.WriteLine("{0}={1}",i,t);
            }
            Console.WriteLine();
            //Console.WriteLine(decimal.MaxValue);
        }
    }
