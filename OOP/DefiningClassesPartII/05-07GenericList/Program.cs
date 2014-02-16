using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_07GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
  
            GenericList<int> a= new GenericList<int>(2);

            a.Add(1);
            a.Add(2);
            Console.WriteLine(a);
            a.Add(3);

            Console.WriteLine( a.ToString());
            Console.WriteLine(a.Min());
            Console.WriteLine(a.Max());

            a.RemoveAt(2);

            Console.WriteLine(a.ToString());

            a.InsertAt(3, 1);

            Console.WriteLine(a.ToString());
        }
    }
}
