using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Person
{
    class Program
    {
        static void Main(string[] args)
        {

            var persons = new Person[]{new Person("Gosho"),new Person("Ivan", 22)};

            foreach (var person in persons)
            {
                Console.WriteLine( person);
            }
        }
    }
}
