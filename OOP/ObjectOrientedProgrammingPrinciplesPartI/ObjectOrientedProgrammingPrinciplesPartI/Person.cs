using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Person : Comment
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }
    
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override string ToString()
        {
            string classLevel = "++++";
            StringBuilder result = new StringBuilder();

            result.Append(classLevel);
            result.Append("Person Name : ");
            result.Append(this.name);
            result.Append( "\n\n");

            return result.ToString();

        }
    }
}
