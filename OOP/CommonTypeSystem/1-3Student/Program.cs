using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_3Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student firstStudent = new Student("Gosho","Georgiev","Georgiev",123123123,"Sofia 1000","+3598888888","Abv@abv.bg",3,Specialties.ComputerScience,Universities.Tu,Faculties.ComputerSystemsAndControl);
            Student secondStudent = new Student("Gosho", "Georgiev", "Georgiev", 123123124, "Sofia 1000", "+3598888888", "Abv@abv.bg", 3, Specialties.ComputerScience, Universities.Tu, Faculties.ComputerSystemsAndControl);


            Console.WriteLine(firstStudent);

            Console.WriteLine("firstStudent HashCode : {0}",firstStudent.GetHashCode());
            Console.WriteLine("secondStudent HashCode : {0}", secondStudent.GetHashCode());
            Console.WriteLine( firstStudent.Equals(secondStudent) );
            Console.WriteLine( firstStudent==secondStudent);
            Console.WriteLine(firstStudent!=secondStudent);

            Console.WriteLine(firstStudent.CompareTo(secondStudent));

            var thirdStudent = firstStudent.Clone();

            firstStudent.FirstName = "Ivan";
            firstStudent.Course = 2;
            firstStudent.SSN = 345345;

            Console.WriteLine( thirdStudent);
            Console.WriteLine(firstStudent);

            
        }
    }
}
