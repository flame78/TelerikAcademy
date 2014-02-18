using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Human
{
    class Program
    {
        static void Main()
        {


            List<Worker> workers = new List<Worker>();
            List<Student> students = new List<Student>();
            List<Human> humans = new List<Human>();


            students.Add(new Student("Ivan", "Ivanov", 2));
            students.Add(new Student("Georgi", "Georgiev", 1));
            students.Add(new Student("Plamen", "Plamenov", 4));
            students.Add(new Student("Vasil", "Vasilev", 1));
            students.Add(new Student("Cviatko", "Cvetkov", 2));
            students.Add(new Student("Aleksandyr", "Aleksandrov", 3));
            students.Add(new Student("Vladimir", "Vladimirov", 1));
            students.Add(new Student("Kancho", "Kanchev", 1));
            students.Add(new Student("Nikolai", "Nikolov", 1));
            students.Add(new Student("Jivko", "Jivkov", 3));

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------");

             students = students.OrderBy(Student => Student.Grade ).ToList<Student>();

             foreach (var item in students)
             {
                 Console.WriteLine(item);
             }

             workers.Add(new Worker("Georgi", "Ivanov",300,8));
             workers.Add(new Worker("Plamen", "Georgiev", 150, 4));
             workers.Add(new Worker("Vladimir", "Plamenov", 200,8));
             workers.Add(new Worker("Cviatko", "Vasilev", 180,6));
             workers.Add(new Worker("Jivko", "Cvetkov", 220,4));
             workers.Add(new Worker("Aleksandyr", "Aleksandrov", 250,8));
             workers.Add(new Worker("Aleksandyr", "Vladimirov", 100,4));
             workers.Add(new Worker("Kancho", "Kanchev", 200,6));
             workers.Add(new Worker("Ivan", "Nikolov", 150,6));
             workers.Add(new Worker("Nikolai", "Jivkov", 280,8));

             Console.WriteLine("============================");

             foreach (var item in workers)
             {
                 Console.WriteLine(item);
             }

             workers = workers.OrderByDescending(Worker => Worker.MoneyPerHour()).ToList<Worker>();

             Console.WriteLine("============================");

             foreach (var item in workers)
             {
                 Console.WriteLine(item);
             }

             humans = students.Union<Human>(workers).ToList<Human>();

             Console.WriteLine("============================");

             foreach (var item in humans)
             {
                 Console.WriteLine(item);
             }

             humans = humans.
                 OrderBy(Human => Human.FirstName).
                 ThenBy(Human => Human.LastName).
                 ToList<Human>();

             Console.WriteLine("============================");

             foreach (var item in humans)
             {
                 Console.WriteLine(item);
             }
        }
    }
}
