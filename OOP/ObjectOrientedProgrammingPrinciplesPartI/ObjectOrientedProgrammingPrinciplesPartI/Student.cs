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
     
    }
}
