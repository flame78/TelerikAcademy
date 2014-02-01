using System;



class Problem5Pillars
{

    static void Main()
    {
        int[] n = new int[8];
        byte dotsLeft = 0, dotsRight = 0;

        for (int i = 0; i < 8; i++)
        {
            n[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < 8; i++)
        {
            dotsLeft = 0; dotsRight = 0;
            for (int i2 = 0; i2 < i; i2++)
            {
                for (int i3 = 0; i3 < 8; i3++)
                {
                    if (((n[i3] << i2) & (1 << 7)) == (1 << 7)) dotsLeft++;
                }

            }
            for (int i2 = 6 - i; i2 >= 0; i2--)
            {
                for (int i3 = 0; i3 < 8; i3++)
                {
                    if (((n[i3] >> i2) & 1) == 1) dotsRight++;
                }

            }
            if (dotsLeft == dotsRight)
            {
                Console.WriteLine(7 - i); Console.WriteLine(dotsLeft); break;
            }
            else if (i == 7) Console.WriteLine("No");

        }

    }
}