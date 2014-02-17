using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class People
    {
        private string name;

        public People(string name)
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
