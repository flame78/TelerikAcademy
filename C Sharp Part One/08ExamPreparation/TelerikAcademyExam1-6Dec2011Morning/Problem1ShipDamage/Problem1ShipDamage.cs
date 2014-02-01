using System;

class Problem1ShipDamage
{
    static void Main(string[] args)
    {
        int tmp;
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());
        int ch1 = 0, ch2 = 0, ch3 = 0;
        int damage = 0;

        if (sx1 > sx2) { tmp = sx1; sx1 = sx2; sx2 = tmp; }
        if (sy1 < sy2) { tmp = sy1; sy1 = sy2; sy2 = tmp; }

        if (h > cy1) for (int i = cy1; i < h; i++) ch1++;
        else for (int i = h; i < cy1; i++) ch1--;


        if (h > cy2) for (int i = cy2; i < h; i++) ch2++;
        else for (int i = h; i < cy2; i++) ch2--;

        if (h > cy3) for (int i = cy3; i < h; i++) ch3++;
        else for (int i = h; i < cy3; i++) ch3--;




        if (cx1 == sx1 || cx1 == sx2)
        {
            if (sy1 == cy1 + 2 * ch1 || sy2 == cy1 + 2 * ch1) damage += 25;
            else if (cy1 + 2 * ch1 < sy1 && cy1 + 2 * ch1 > sy2) damage += 50;
        }
        else if (cx1 > sx1 && cx1 < sx2)
        {
            if (sy1 == cy1 + 2 * ch1 || sy2 == cy1 + 2 * ch1) damage += 50;
            else if (cy1 + 2 * ch1 < sy1 && cy1 + 2 * ch1 > sy2) damage += 100;
        }

        if (cx2 == sx1 || cx2 == sx2)
        {
            if (sy1 == cy2 + 2 * ch2 || sy2 == cy2 + 2 * ch2) damage += 25;
            else if (cy2 + 2 * ch2 < sy1 && cy2 + 2 * ch2 > sy2) damage += 50;
        }
        else if (cx2 > sx1 && cx2 < sx2)
        {
            if (sy1 == cy2 + 2 * ch2 || sy2 == cy2 + 2 * ch2) damage += 50;
            else if (cy2 + 2 * ch2 < sy1 && cy2 + 2 * ch2 > sy2) damage += 100;
        }

        if (cx3 == sx1 || cx3 == sx2)
        {
            if (sy1 == cy3 + 2 * ch3 || sy2 == cy3 + 2 * ch3) damage += 25;
            else if (cy3 + 2 * ch3 < sy1 && cy3 + 2 * ch3 > sy2) damage += 50;
        }
        else if (cx3 > sx1 && cx3 < sx2)
        {
            if (sy1 == cy3 + 2 * ch3 || sy2 == cy3 + 2 * ch3) damage += 50;
            else if (cy3 + 2 * ch3 < sy1 && cy3 + 2 * ch3 > sy2) damage += 100;
        }

        Console.WriteLine(damage + "%");


    }
}

