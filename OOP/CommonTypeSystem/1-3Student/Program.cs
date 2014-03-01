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
            Student secondStudent = new Student("Gosho", "Georgiev", "Georgiev", 123123123, "Sofia 1000", "+3598888888", "Abv@abv.bg", 3, Specialties.ComputerScience, Universities.Tu, Faculties.ComputerSystemsAndControl);

            Console.WriteLine( firstStudent.Equals(secondStudent) );
        }
    }
}
