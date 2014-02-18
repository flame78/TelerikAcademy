using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class School
    {
        List<StudentsClass> classes;
        private string name;

        public School(string name)
        {
            classes = new List<StudentsClass>();
            this.name = name;
        }

        internal void AddClass(StudentsClass studentClass)
        {
            this.classes.Add(studentClass);
        }

        public override string ToString()
        {
            string classLevel = "+";
            StringBuilder result = new StringBuilder();

            result.Append(classLevel);

            result.Append("School\n");

            result.Append(classLevel);
            result.Append(this.name);
            result.Append("\n");
            

            foreach (var item in this.classes)
            {
                result.Append(item);
            }
            
            result.Append("\n");

            return result.ToString();
        }
    }

}
