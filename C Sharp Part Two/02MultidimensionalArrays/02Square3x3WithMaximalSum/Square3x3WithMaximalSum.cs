//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;
  class Square3x3WithMaximalSum
    {
        static void Main()
        {
            Console.Write("N=");
            int N = int.Parse(Console.ReadLine());

            Console.Write("M=");
            int M = int.Parse(Console.ReadLine());

            int[,] matrix = new int[N, M];

            ReadMatrix(matrix);

            PrintMatrix(matrix);

            int sum,rowMS=0,colMS=0, maxSum = int.MinValue;


            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    sum += matrix[row+1, col] + matrix[row+1, col + 1] + matrix[row+1, col + 2];
                    sum += matrix[row+2, col] + matrix[row+2, col + 1] + matrix[row+2, col + 2];
                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        rowMS = row;
                        colMS = col;
                    }

                }
                
            }

            Console.WriteLine("----------------------------------------------");

            for (int row = rowMS; row < rowMS+3; row++)
            {
                for (int col = colMS; col < colMS+3; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();

            }

        }

        private static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("Element [{0},{1}]=",row,col);
                    matrix[row, col] = int.Parse(Console.ReadLine());
                }

            }

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

