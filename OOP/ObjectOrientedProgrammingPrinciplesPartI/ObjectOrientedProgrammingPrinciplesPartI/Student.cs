using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Student : Person
    {
        private uint classNumber;
 
        public Student(string name, uint classNumber) : base(name)
        {
            this.classNumber = classNumber;
        }
    
        public uint ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("Student\n");
            result.Append(base.ToString());
            result.Append("Unique class number : ");
            result.Append(this.classNumber);
            result.Append("\n");
            result.Append(this.GetAllCommentsToString());
            return result.ToString();
        }
     
    }
}
