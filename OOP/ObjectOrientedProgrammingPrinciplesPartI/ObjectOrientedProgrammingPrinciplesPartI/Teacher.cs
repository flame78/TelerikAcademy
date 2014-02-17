using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Teacher : Person, IComment
    {
        
        public string Comment
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Discipline Discipline
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
