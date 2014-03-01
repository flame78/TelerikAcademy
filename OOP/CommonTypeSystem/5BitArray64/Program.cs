using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {

            var ba = new BitArray64(0);
            ba[63] = 1;
            Console.WriteLine(ba);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(ba);
            var ba2 = new BitArray64(ulong.MaxValue);

            Console.WriteLine(ba);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(ba2);

            Console.WriteLine(new string('-', 40));

            Console.WriteLine(ba.Equals(1));

            Console.WriteLine(new string('-',40));

            foreach (var bit in ba)
            {
                Console.Write(bit+", ");
            }
        }
    }
}
