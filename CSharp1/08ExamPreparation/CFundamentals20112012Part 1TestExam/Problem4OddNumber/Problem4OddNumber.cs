using System;

class Problem4OddNumber
{
    static void Main()
    {
        int uniqNumb=0, maxNumb = 0, max = 0, n = int.Parse(Console.ReadLine());
        long[] val = new long[n];
        int[] odd = new int[n];

        for (int numb = 0; numb < n; numb++)
        {
           
            val[uniqNumb] = long.Parse(Console.ReadLine());
            odd[uniqNumb]++;
           
            
            for (int i = 0; i < uniqNumb; i++)
            {
                if (val[uniqNumb ] == val[i])
                {
                    odd[i]++;
                    uniqNumb--;
                    break;
                }
            }
            uniqNumb++;
        }


        for (int numb = 0; numb < uniqNumb; numb++)
        {
           
            if ((odd[numb] % 2) != 0 && max < odd[numb])
            {
                maxNumb = numb;
                max = odd[numb];
            }
        }

   
        Console.WriteLine(val[maxNumb]);
    }
}