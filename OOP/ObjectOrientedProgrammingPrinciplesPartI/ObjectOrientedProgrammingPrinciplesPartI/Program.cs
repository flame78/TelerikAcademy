
namespace ObjectOrientedProgrammingPrinciplesPartI
{
    using System;
    class Program
    {
        static void Main()
        {
            School schoolTk = new School("Телерик");
            Teacher ip = new Teacher("Иван Попов");
            Teacher rs = new Teacher("Росен Стоянов");
            Student gg = new Student("Георгри Гегов", 1);
            Student ii = new Student("Иван Иванов", 2);

            Discipline cSharp1 = new Discipline("C#1", 8, 8);
            Discipline cSharp2 = new Discipline("C#2", 10, 10);
            ip.AddDiscipline(cSharp1);
            rs.AddDiscipline(cSharp2);
            StudentsClass first = new StudentsClass("Online 2013/2014");
            first.AddTeacher(ip);
            first.AddTeacher(rs);
            first.AddStudent(gg);
            first.AddStudent(ii);
            schoolTk.AddClass(first);

        }
    }
}
