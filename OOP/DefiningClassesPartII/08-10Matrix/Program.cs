//8.Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 
//9.Implement an indexer this[row, col] to access the inner matrix cells.
//10.Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).
//11.Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format major.minor (e.g. 2.11). Apply the version attribute to a sample class and display its version at runtime.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_10Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matrix1 = new Matrix<int>(2, 2);
            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            Matrix<int> result = new Matrix<int>(2, 2);
            Matrix<int> emptyMatrix = new Matrix<int>(4, 4);

            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[1, 0] = 3;
            matrix1[1, 1] = 4;

            matrix2[0, 0] = 1;
            matrix2[0, 1] = 2;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 4;

            result = matrix1 * matrix2;

            Console.WriteLine();
            Console.Write("{0} * \n{1}\n", matrix1,matrix2);
            Console.Write(" = \n{0}", result);

            if (emptyMatrix)
            {
                Console.WriteLine("The matrix is not empty");
            }
            else
            {
                Console.WriteLine("The matrix is empty");
            }

        }
    }
}
