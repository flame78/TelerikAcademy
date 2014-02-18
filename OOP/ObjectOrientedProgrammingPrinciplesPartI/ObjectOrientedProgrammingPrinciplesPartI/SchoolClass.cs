using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class StudentsClass : Comment
    {
        private string classIdentifier;
        private List<Student> students;
        private List<Teacher> teachers;


        public StudentsClass(string classIdentifier)
        {
            this.classIdentifier = classIdentifier;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
        }

        public void AddStudent(Student st)
        {
            this.students.Add(st);
        }

        public void RemoveStudent(Student st)
        {
            this.students.Remove(st);
        }

        public Student[] GetStudents()
        {
            return this.students.ToArray();
        }

        public void AddTeacher(Teacher tr)
        {
            this.teachers.Add(tr);
        }

        public void RemoveTeacher(Teacher tr)
        {
            this.teachers.Remove(tr);
        }

        public Teacher[] GetTeachers()
        {
            return this.teachers.ToArray();
        }

        public override string ToString()
        {
            string classLevel = "++";
            StringBuilder result = new StringBuilder();

            result.Append(classLevel);

            result.Append("Class\n");

            result.Append(classLevel);
            result.Append(this.classIdentifier);
            result.Append("\n");
            result.Append(this.GetAllCommentsToString());

            foreach (var item in this.teachers)
            {
                result.Append(item);
            }

            foreach (var item in this.students)
            {
                result.Append(item);
            }

            result.Append("\n");

            return result.ToString();
        }
        
    }
}
