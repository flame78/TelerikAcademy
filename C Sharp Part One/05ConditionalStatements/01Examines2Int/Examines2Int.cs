// Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.




using System;


class Examines2Int
{
    static void Main()
    {
        int firstInt = 7, secondInt = 6, tmp;

        if (firstInt > secondInt)
        {
            tmp = firstInt;
            firstInt = secondInt;
            secondInt = tmp;
        }
    }
}

