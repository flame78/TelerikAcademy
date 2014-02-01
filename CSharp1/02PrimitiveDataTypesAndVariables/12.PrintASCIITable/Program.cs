using System;

class PrintASCIITable
{
    static void Main()
    {
        for (int i = 0; i < 256; i++)
        {
            Console.Write(i + "=" + (char)i+" ");
        }
    }
}

