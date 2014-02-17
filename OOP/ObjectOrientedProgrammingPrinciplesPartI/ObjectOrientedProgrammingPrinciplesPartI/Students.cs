using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Student : People, IComment
    {
        private int classNumber;
        private string comment;
        public int ClassNumber
        {
            get
            {
                throw new System.NotImplementedException();
            }
            
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }
    }
}
