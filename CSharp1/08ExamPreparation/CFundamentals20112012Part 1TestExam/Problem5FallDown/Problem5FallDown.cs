using System;

class Problem5FallDown
{
    static void Main()
    {
        byte[] n = new byte[8];
        byte numb = 8;


        for (int i = 0; i < numb; i++)
        {
            n[i] = byte.Parse(Console.ReadLine());
        }

        for (int i = 0; i < numb; i++)
        {
            for (byte bit = 0; bit < 8; bit++)
            {
                if (((n[i] >> bit) & 1) == 1)
                    for (int i2 = 7; i2 > i; i2--)
                    {
                        if (((n[i2] >> bit) & 1) != 1)
                        {
                            n[i] = (byte)(n[i] & ~(1 << bit));
                            n[i2] = (byte)(n[i2] | (1 << bit));
                            break;
                        }
                    }
            }
        }

        for (int i = 0; i < numb; i++)
        {
            Console.WriteLine(n[i]);
        }
    }
}

