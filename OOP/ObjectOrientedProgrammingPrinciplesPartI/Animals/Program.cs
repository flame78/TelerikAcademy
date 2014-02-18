using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            var arrayOfAnimals = new Animal[10];

            arrayOfAnimals[0] = new Dog("Dogi", 3, true);
            arrayOfAnimals[1] = new Frog("Frogi", 1, false);
            arrayOfAnimals[2] = new Dog("Pufi", 4, false);
            arrayOfAnimals[3] = new Cat("Pisanka", 5, false);
            arrayOfAnimals[4] = new Tomcat("Tom", 6);
            arrayOfAnimals[5] = new Cat("Dude", 2, true);
            arrayOfAnimals[6] = new Kitten("Duda", 1);
            arrayOfAnimals[7] = new Tomcat("Myro", 5);
            arrayOfAnimals[8] = new Frog("Kermit", 2, true);
            arrayOfAnimals[9] = new Kitten("Kiti", 1);

            
            foreach (var item in arrayOfAnimals)
            {
                Console.WriteLine(item);
                item.Sound();
            }

            Console.WriteLine("===========Cats==========");

            foreach (var item in arrayOfAnimals.Where(Animal => Animal is Cat))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Average Age = "+arrayOfAnimals.Where(Animal => Animal is Cat).
                Average(Animal => Animal.Age));

            Console.WriteLine("===========Dogs==========");
            foreach (var item in arrayOfAnimals.Where(Animal => Animal is Dog))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Average Age = " + arrayOfAnimals.Where(Animal => Animal is Dog).
                Average(Animal => Animal.Age));

            Console.WriteLine("===========Frogs==========");
            foreach (var item in arrayOfAnimals.Where(Animal => Animal is Frog))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Average Age = " + arrayOfAnimals.Where(Animal => Animal is Frog).
                Average(Animal => Animal.Age));

        }
    }
}
