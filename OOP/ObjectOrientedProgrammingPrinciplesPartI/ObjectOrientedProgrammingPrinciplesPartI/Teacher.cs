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

        internal void RemoveDiscipline(Discipline disc)
        {
            this.disciplines.Remove(disc);
        }

        internal Discipline[] GetAllDisciplines()
        {
            return this.disciplines.ToArray();
        }

        internal string GetAllDisciplinesToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in this.disciplines)
            {
                result.Append(item);
            }

            return result.ToString();
        }
        public override string ToString()
        {
            StringBuilder result=new StringBuilder("Teacher\n"); 
            result.Append(base.ToString());
           result.Append(this.GetAllCommentsToString());
           result.Append(this.GetAllDisciplinesToString());

            return result.ToString();
        }
       
    }
}
