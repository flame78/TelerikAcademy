//Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)


using System;

class PrintsMatrix
{
    static void Main()
    {
        Console.Write("n=");
        int n = int.Parse(Console.ReadLine());
        int number = 1;

        int[,] matrix = new int[n, n];

        Console.WriteLine("-----------------------------------------------");

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = number;
                number++;
            }
        }

        PrintMatrix(matrix);

        Console.WriteLine("-----------------------------------------------");

        number = 1;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            else
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = number;
                    number++;
                }

        }

        PrintMatrix(matrix);

        number = 1;

        Console.WriteLine("-----------------------------------------------");

        int depth = 0;
        int depth2 = 0;
        {
            int col = 0;
            int row = n - 1;

            do
            {

                if (row >= 0 && col >= 0 && row < n && col < n) matrix[row, col] = number;
                number++;
                col++; row++;
                if (row >= n && col < n)
                {
                    depth++;
                    col = 0;
                    row = n - 1 - depth;
                }
                else if (col >= n)
                {
                    depth2++;
                    col = 0 + depth2;
                    row = 0;



                    //10 13 15 16
                    // 6  9 12 14
                    // 3  5  8 11
                    // 1  2  4  7

                    //if (row >= 0 && col >= 0 && row < n && col < n) matrix[row, col] = number;
                    //number++;
                    //col--; row--;
                    //if (col < 0 && row >= 0)
                    //{
                    //    depth++;
                    //    col = depth;
                    //    row = n - 1;
                    //}
                    //else if (row < 0)
                    //{
                    //    depth2++;
                    //    col = n - 1;
                    //    row = n - 1 - depth2;


                }

            } while (number - 1 < n * n);
        }

        PrintMatrix(matrix);

        number = 1;

        Console.WriteLine("-----------------------------------------------");

        depth = 0;
        string direction = "Down";
        {
            int col = 0;
            int row = 0;

            do
            {


                if (row >= 0 && col >= 0 && row < n && col < n) matrix[row, col] = number;
                number++;

                if (direction == "Left")
                    if (col >= 0 + depth + 1)
                    {
                        col--;
                    }
                    else
                    {
                        direction = "Down";
                        row++;
                        matrix[row, col] = number;
                        number++;
                    }

                if (direction == "Up")
                    if (row >= 0 + depth + 1)
                    {
                        row--;
                    }
                    else
                    {
                        col = n - depth - 2;
                        direction = "Left";
                        depth++;
                    }

                if (direction == "Right")
                    if (col < n - depth - 1)
                    {
                        col++;
                    }
                    else
                    {
                        col = n - depth - 1;
                        direction = "Up";
                        row--;
                    }

                if (direction == "Down")
                    if (row < n - depth - 1)
                    {
                        row++;
                    }
                    else
                    {
                        row = n - depth - 1;
                        direction = "Right";
                        col++;
                    }

            } while (number - 1 < n * n);
        }

        PrintMatrix(matrix);


    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3}", matrix[row, col]);

            }
            Console.WriteLine();
        }
    }
}

