using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2Human
{
    class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.grade = grade;
        }

        public int Grade
        {
            get { return this.grade; }
        }

        public override string ToString()
        {
            return base.ToString()+" : Grade = "+this.grade;
        }

    }
}
