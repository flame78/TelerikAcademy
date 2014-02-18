
namespace ObjectOrientedProgrammingPrinciplesPartI
{
    using System;
    class Program
    {
        static void Main()
        {
            School schoolTk = new School("Телерик");
            Teacher teacherIP = new Teacher("Иван Попов");
            Teacher teacherRS = new Teacher("Росен Стоянов");
            Student studentGG = new Student("Георгри Гегов", 1);
            Student studentII = new Student("Иван Иванов", 2);

            studentGG.AddComment("Първия");
            Console.WriteLine(studentGG);

            Discipline cSharp1 = new Discipline("C#1", 8, 8);
            Discipline cSharp2 = new Discipline("C#2", 10, 10);
            Discipline oOP = new Discipline("OOP", 6, 6);

            oOP.AddComment("Harder");
            cSharp1.AddComment("Start");

            teacherIP.AddDiscipline(cSharp1);
            teacherIP.AddDiscipline(cSharp2);
            teacherIP.AddDiscipline(oOP);
            teacherIP.AddComment("First Comment");
            teacherIP.AddComment("Second Comment");
            Console.WriteLine(teacherIP);
            StudentsClass first = new StudentsClass("Online 2013/2014");
            first.AddTeacher(teacherIP);
            first.AddTeacher(teacherRS);
            first.AddStudent(studentGG);
            first.AddStudent(studentII);
            schoolTk.AddClass(first);

        }
    }
}
