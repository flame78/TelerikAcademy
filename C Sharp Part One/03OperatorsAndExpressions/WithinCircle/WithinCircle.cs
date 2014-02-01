using System;

// Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

class WithinCircle
{
    static void Main()
    {
        string strX="0";
        string strY="0";
        double radius=5;
        double x=0;
        double y=0;
        bool inCircle = false;
        bool cond = false;


        while (!cond)
        {
            Console.Write("Enter x=");
            strX = Console.ReadLine();
            cond = double.TryParse(strX, out x);
        }

        
        cond = false;

        while (!cond)
        {
            Console.Write("Enter y=");
            strY = Console.ReadLine();
            cond = double.TryParse(strY, out y);
        }

        inCircle = (((x * x) + (y * y)) < (radius * radius));

        Console.WriteLine("point (x={0}, y={1}) is {2}within the circle K(O, 5).",x,y,inCircle?"":"not ");
    }
}

