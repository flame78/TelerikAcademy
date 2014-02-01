using System;

class Problem4WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int numb,tmp,numb2=0,numb3=0;

        for (int i = 0; i < n; i++)
        {

            numb = int.Parse(Console.ReadLine());
            for (int f1 = 0; f1 < 32; f1++)
            {
                tmp = numb << f1;
                if ((tmp | (1 << 31)) == tmp)
                {
                    numb2 = numb;
                    for (int i2 = 0; i2 < 32 - f1; i2++)
                    {
                        if (((numb2 >> i2) & 1) == 1) numb2 = (~(1 << i2)) & numb2;
                        else numb2 = (1 << i2) | numb2;

                    }
                    numb3 = 0;
                    for (int i2 = 0; i2 < 32 - f1; i2++)
                    {
                        if (((numb >> i2) & 1) == 1) numb3 = 1 | numb3;
                        if (i2!=32 - f1-1) numb3=numb3 << 1;

                    }
                    Console.WriteLine((numb ^ numb2) & numb3);
                    break;
                }
            }
            
            
        }
    }
}

