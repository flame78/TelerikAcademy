// Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 


using System;
    class ArrayBinSearch
    {
        static void Main()
        {
            int[] matrix=ReadMatrix();            
            Console.Write("K=");
            int K = int.Parse(Console.ReadLine());

            Array.Sort(matrix);
            
            Console.WriteLine("\n\nSorted Array\n");
            

            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.WriteLine("Element [{0}]={1}", col,matrix[col]);
                
            }

            Console.WriteLine();

            int index = Array.BinarySearch(matrix, K);


            if (index==-1)
            {
                Console.WriteLine("Not Found");
                return;
            }
            else if (index>0)
            {

                Console.WriteLine("Element [{0}]={1} = K={2}", index, matrix[index],K);
            }
            else
            {

                Console.WriteLine("Element [{0}]={1} < K={2}", ~index-1, matrix[~index-1],K);
            }


            

            //if (index < 0)
            //    if (K < matrix[0])
            //    {
            //        Console.WriteLine("Not Found");
            //        return;
            //    }
            //    else
            //        for (int i = 1; i <matrix.Length; i++)
            //        {
            //            if (matrix[i]>K)
            //            {
            //                Console.WriteLine("Largest number in the array which is < K");
            //                Console.WriteLine("Element [{0}]={1}", i-1, matrix[i-1]);
            //                return;
            //            }
            //        }
            //else
            //{
            //    Console.WriteLine("Largest number in the array which is = K");
            //    Console.WriteLine("Element [{0}]={1}", index, matrix[index]);
            //}

        }

        private static int[] ReadMatrix()
        {
            Console.Write("N=");
            int N = int.Parse(Console.ReadLine());

            
            int[] matrix = new int[N];

            for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    Console.Write("Element [{0}]=", col);
                    matrix[col] = int.Parse(Console.ReadLine());
                }

            return matrix;

        }
    }

