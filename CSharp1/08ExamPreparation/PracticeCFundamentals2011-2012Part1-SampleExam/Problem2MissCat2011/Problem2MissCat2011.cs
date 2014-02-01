using System;


class Problem2MissCat2011
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int max = 0, maxVote = 0;
        byte vote;
        int[] cat = new int[10];
        for (int i = 0; i < n; i++)
        {
            vote = byte.Parse(Console.ReadLine());
            cat[vote - 1]++;

            if (cat[vote - 1] > max)
            {
                max = cat[vote - 1];
                maxVote = vote;
            }
            else if (cat[vote - 1] == max)
                if (vote < maxVote) maxVote = vote;

        }

        Console.WriteLine(maxVote);
    }
}

