// * Write a program that finds the largest area of equal neighbor elements in a rectangular matrix and prints its size.

using System;

class LargestAreaOfEqualNeighborElements
{
    static int tempCount = 1;
    static bool[,] visited;

    static void Main()
    {
        int[,] matrix = {
                                {1, 3, 2, 2, 2, 4},
                                {3, 3, 3, 2, 2, 4},
                                {4, 3, 1, 2, 3, 3},
                                {4, 3, 1, 3, 3, 1},
                                {4, 3, 3, 3, 1, 1}
                            };
        visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        int bestCount = 0;
        int bestNumber = 0;


        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                tempCount = 1;
                CountLength(matrix, visited, i, j);
                if (tempCount > bestCount)
                {
                    bestCount = tempCount;
                    bestNumber = matrix[i, j];
                }

            }
        }
        Console.WriteLine("The longest sequence is: {0}, the number is: {1}", bestCount, bestNumber);

    }

    static void CountLength(int[,] matrix, bool[,] visited, int startRow, int startCol)
    {
        int number = matrix[startRow, startCol];
        visited[startRow, startCol] = true;
        int i = startRow;
        int j = startCol;

        if (matrix[startRow, startCol] != number)
        {
            return;
        }

        if (CellIsValid(matrix, visited, number, i - 1, j))     //=== check UP
        {
            tempCount++;
            CountLength(matrix, visited, i - 1, j);
        }
        if (CellIsValid(matrix, visited, number, i, j + 1))     //=== check RIGHT
        {
            tempCount++;
            CountLength(matrix, visited, i, j + 1);
        }
        if (CellIsValid(matrix, visited, number, i + 1, j))     //=== check DOWN
        {
            tempCount++;
            CountLength(matrix, visited, i + 1, j);
        }
        if (CellIsValid(matrix, visited, number, i, j - 1))     //=== check LEFT
        {
            tempCount++;
            CountLength(matrix, visited, i, j - 1);
        }
    }

    private static bool CellIsValid(int[,] matrix, bool[,] visited, int number, int row, int col)
    {
        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))       //check if position is inside the matrix
        {
            if (visited[row, col] == false && matrix[row, col] == number)            //check if the cell has been visited or if the number is different
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
