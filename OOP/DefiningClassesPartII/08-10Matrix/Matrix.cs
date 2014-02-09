

using System;
using System.Text;
namespace _08_10Matrix
{
    
    //8.Define a class Matrix<T> to hold a matrix of numbers (e.g. integers, floats, decimals). 

    class Matrix<T>
        where T : new()
    {
        private T[,] matrix;

        public Matrix(int row, int col)
        {
            matrix = new T[row, col];
        }

        //9.Implement an indexer this[row, col] to access the inner matrix cells.

        public T this[int row, int col]
        {
            get { return this.matrix[row,col];}
            set { this.matrix[row, col] = value; }
        }

        public int Rows
        { get { return this.matrix.GetLength(0); } }

        public int Cols
        { get { return this.matrix.GetLength(1); } }


        //10.Implement the operators + and - (addition and subtraction of matrices of the same size) and * for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the true operator (check for non-zero elements).

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            CheckSize(a, b);
            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
            dynamic p1, p2;

            for (int roww = 0; roww < a.Rows; roww++)
            {
                for (int coll = 0; coll < a.Cols; coll++)
                {
                    p1 = a[roww, coll]; p2 = b[roww, coll];
                    result[roww, coll] =p1 + p2;
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            CheckSize(a, b);
            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
            dynamic p1, p2;

            for (int roww = 0; roww < a.Rows; roww++)
            {
                for (int coll = 0; coll < a.Cols; coll++)
                {
                    p1 = a[roww, coll]; p2 = b[roww, coll];
                    result[roww, coll] = p1 - p2;
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != a.Cols) throw new Exception("Cannot multiply matrix with diferent number of rows and cols");
            CheckSize(a, b);
            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);
            dynamic p1, p2;

            for (int roww = 0; roww < a.Rows; roww++)
            {
                for (int coll = 0; coll < a.Cols; coll++)
                {
                    p1 = a[roww, coll]; p2 = b[coll, roww];
                    result[roww, coll] = p1 * p2;
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> a)
        {
            T zero = new T();
            for (int roww = 0; roww < a.Rows; roww++)
            {
                for (int coll = 0; coll < a.Cols; coll++)
                {
                    if (a[roww, coll].Equals(zero)) return false;
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> a)
        {
            return true;
        }

        private static void CheckSize(Matrix<T> a, Matrix<T> b)
        {
            if (a.Rows != b.Rows || a.Cols != b.Cols) throw new Exception("Diferent size matrix");
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int roww = 0; roww < this.Rows; roww++)
            {
                for (int coll = 0; coll < this.Cols; coll++)
                {
                    result.Append(this.matrix[roww,coll]);
                    result.Append(", ");
                }
                 result.Append("\n");
            }
           

            return result.ToString();
        }
    }
}
