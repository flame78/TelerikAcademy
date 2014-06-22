namespace Task3
{
    using System;

    public static class WalkInMatrica
    {
        private static readonly int[] DirectionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] DirectionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static void Main(string[] args)
        {
            int n = GetMatrixSize();
            int[,] matrix = new int[n, n];

            GenerateMatrix(matrix);

            PrintMatrix(matrix);
        }

        private static void GenerateMatrix(int[,] matrix)
        {
            int currentNumber = 1,
                col = 0,
                row = 0,
                currentDirectionX = 1,
                currentDirectionY = 1,
                n = matrix.GetLength(0);

            while (true)
            {
                matrix[col, row] = currentNumber;

                if (!HaveEmptyНeighborCell(matrix, col, row))
                {
                    if (!FindFirstEmptyCell(matrix, ref col, ref row))
                    {
                        // No more empty cells and finish
                        break;
                    }
                }

                // get direction for next empty cell
                while (col + currentDirectionX < 0 || n <= col + currentDirectionX
                    || row + currentDirectionY < 0 || n <= row + currentDirectionY
                    || matrix[col + currentDirectionX, row + currentDirectionY] != 0)
                {
                    NextDirection(ref currentDirectionX, ref currentDirectionY);
                }

                col += currentDirectionX;
                row += currentDirectionY;
                currentNumber++;
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static bool FindFirstEmptyCell(int[,] matrix, ref int inputCol, ref int inputRow)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        inputCol = col;
                        inputRow = row;
                        return true;
                    }
                }
            }

            return false;
        }

        private static int GetMatrixSize()
        {
            Console.WriteLine("enter a positive number ");

            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }

        private static void NextDirection(ref int dx, ref int dy)
        {
            for (int count = 0; count < 8; count++)
            {
                // find current direction
                if (DirectionsX[count] == dx && DirectionsY[count] == dy)
                {
                    // current direction is last
                    if (count == 7)
                    {
                        dx = DirectionsX[0];
                        dy = DirectionsY[0];
                        return;
                    }
                    else
                    {
                        dx = DirectionsX[count + 1];
                        dy = DirectionsY[count + 1];
                        return;
                    }
                }
            }
        }

        private static bool HaveEmptyНeighborCell(int[,] arr, int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                if (x + DirectionsX[i] >= arr.GetLength(0) || x + DirectionsX[i] < 0)
                {
                    continue;
                }

                if (y + DirectionsY[i] >= arr.GetLength(1) || y + DirectionsY[i] < 0)
                {
                    continue;
                }

                if (arr[x + DirectionsX[i], y + DirectionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
