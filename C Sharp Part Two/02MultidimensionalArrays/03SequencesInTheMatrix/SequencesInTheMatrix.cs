//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix. Example:

/* input N=3 M=4
ha
fi
ho
xx
fo
ha
hi
xx
x
ho
aa
xx
*/
/* input N=3 M=4
1
2
3
4
1
3
4
2
0
4
0
0
 */
/* input N=3 M=4
1
2
3
4
4
4
4
4
0
4
0
0
 */


using System;

class SequencesInTheMatrix
{
    static void Main()
    {
        string[,] matrix = ReadMatrix();

        int maxLength = 0;

        string[,] matrixResult = new string[matrix.GetLength(0), matrix.GetLength(1)];



        //PrintMatrix(matrix);
        //Console.ReadLine();

        // Right Down
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int tmpRow = row;
                int tmpCol = col;
                int length = 1;
                do
                {
                    tmpRow++;
                    tmpCol++;

                    if (tmpRow >= matrix.GetLength(0) || tmpCol >= matrix.GetLength(1))
                    {
                        break;
                    }
                    if (matrix[tmpRow, tmpCol] == matrix[row, col])
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                if (length > maxLength)
                {
                    matrixResult = new string[matrix.GetLength(0), matrix.GetLength(1)];
                    maxLength = length;
                    tmpRow = row;
                    tmpCol = col;
                    do
                    {
                        matrixResult[tmpRow, tmpCol] = "1";
                        length--;
                        tmpRow++;
                        tmpCol++;
                    } while (length != 0);
                }

                // Left Down
                tmpRow = row;
                tmpCol = col;
                length = 1;
                do
                {
                    tmpRow++;
                    tmpCol--;

                    if (tmpRow >= matrix.GetLength(0) || tmpCol < 0)
                    {
                        break;
                    }
                    if (matrix[tmpRow, tmpCol] == matrix[row, col])
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                if (length > maxLength)
                {
                    matrixResult = new string[matrix.GetLength(0), matrix.GetLength(1)];
                    maxLength = length;
                    tmpRow = row;
                    tmpCol = col;
                    do
                    {
                        matrixResult[tmpRow, tmpCol] = "1";
                        length--;
                        tmpRow++;
                        tmpCol--;
                    } while (length != 0);


                }

                // Right
                tmpRow = row;
                tmpCol = col;
                length = 1;
                do
                {
                    tmpCol++;

                    if (tmpCol >= matrix.GetLength(1))
                    {
                        break;
                    }
                    if (matrix[tmpRow, tmpCol] == matrix[row, col])
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                if (length > maxLength)
                {
                    matrixResult = new string[matrix.GetLength(0), matrix.GetLength(1)];
                    maxLength = length;
                    tmpRow = row;
                    tmpCol = col;
                    do
                    {
                        matrixResult[tmpRow, tmpCol] = "1";
                        length--;
                        tmpCol++;
                    } while (length != 0);


                }

                // Down
                tmpRow = row;
                tmpCol = col;
                length = 1;
                do
                {
                    tmpRow++;

                    if (tmpRow >= matrix.GetLength(0))
                    {
                        break;
                    }
                    if (matrix[tmpRow, tmpCol] == matrix[row, col])
                    {
                        length++;
                    }
                    else
                    {
                        break;
                    }

                } while (true);

                if (length > maxLength)
                {
                    matrixResult = new string[matrix.GetLength(0), matrix.GetLength(1)];
                    maxLength = length;
                    tmpRow = row;
                    tmpCol = col;
                    do
                    {
                        matrixResult[tmpRow, tmpCol] = "1";
                        length--;
                        tmpRow++;
                    } while (length != 0);


                }
            }


        
        }
        //PrintMatrix(matrixResult);

        string result="";

        Console.WriteLine();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrixResult[row, col] == "1")
                {
                    Console.BackgroundColor = (ConsoleColor)3;
                    result += matrix[row, col] + ", ";
                }
                else Console.BackgroundColor = (ConsoleColor)0;
                Console.Write("{0,3}", matrix[row, col]);

            }
            Console.BackgroundColor = (ConsoleColor)0;
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine(result.Substring(0,result.Length-2));

    }


    private static string[,] ReadMatrix()
    {
        Console.Write("N=");
        int N = int.Parse(Console.ReadLine());

        Console.Write("M=");
        int M = int.Parse(Console.ReadLine());

        string[,] matrix = new string[N, M];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("Element [{0},{1}]=", row, col);
                matrix[row, col] = Console.ReadLine();
            }

        }

        return matrix;

    }

    private static void PrintMatrix(string[,] matrix)
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

