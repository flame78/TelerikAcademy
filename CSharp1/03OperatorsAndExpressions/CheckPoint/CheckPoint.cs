using System;

// Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).

class Program
{
    static void Main()
    {
        decimal x, y;

        Console.Write("Enter point (x,y) x=");
        while (!decimal.TryParse(Console.ReadLine(), out x));
        
        Console.Write("y=");
        while (!decimal.TryParse(Console.ReadLine(), out y));
        
        x--; y--; // Decrease x,y with 1 because center of circle is on 1,1 

        if ((x * x) + (y * y) < 3 * 3) // check within circle
        {
            x++; y++; //  Return original value of x,y
            if (x >= -1 && x <= (-1 + 6) && y >= (1 - 2) && y <= 1)  // check within rectangle
            {
                Console.WriteLine("Given point ({0}, {1}) is not within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2)", x, y);
            }
            else Console.WriteLine("Given point ({0}, {1}) is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2)", x, y);

        }
        else
        {
            x++; y++;   //  Return original value of x,y
            Console.WriteLine("Ggiven point ({0}, {1}) is not within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2)", x, y);
        }


    }
}
