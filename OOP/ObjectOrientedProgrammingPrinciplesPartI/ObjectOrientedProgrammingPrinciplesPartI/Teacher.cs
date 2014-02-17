using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Teacher : Person
    {
        List<Discipline> disciplines;
        
        public Teacher(string name) : base(name)
        {
            disciplines = new List<Discipline>();
        }

        internal void AddDiscipline(Discipline disc)
        {
            this.disciplines.Add(disc);
        }
    }
}
