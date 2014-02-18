
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
//            Console.WriteLine(studentGG);

            Discipline disciplineCSharp1 = new Discipline("C#1", 8, 8);
            Discipline disciplineCSharp2 = new Discipline("C#2", 10, 10);
            Discipline disciplineOOP = new Discipline("OOP", 6, 6);

            disciplineOOP.AddComment("Harder");
            disciplineCSharp1.AddComment("Start");

            teacherIP.AddDiscipline(disciplineCSharp1);
            teacherIP.AddDiscipline(disciplineCSharp2);
            teacherRS.AddDiscipline(disciplineOOP);
            teacherIP.AddComment("First Comment");
            teacherIP.AddComment("Second Comment");
//            Console.WriteLine(teacherIP);
            
            StudentsClass firstClass = new StudentsClass("Online 2013/2014");
            firstClass.AddTeacher(teacherIP);
            firstClass.AddTeacher(teacherRS);
            firstClass.AddStudent(studentGG);
            firstClass.AddStudent(studentII);

//            Console.WriteLine(firstClass);


            schoolTk.AddClass(firstClass);
        
            Console.WriteLine(schoolTk);
        }
    }
}
