using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Person : Comment
    {
        private string name;

        public Person(string name="Unknow")
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
    }
}
