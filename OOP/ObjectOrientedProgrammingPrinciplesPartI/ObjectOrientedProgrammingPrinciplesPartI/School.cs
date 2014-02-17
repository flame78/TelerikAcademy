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
    }
}
