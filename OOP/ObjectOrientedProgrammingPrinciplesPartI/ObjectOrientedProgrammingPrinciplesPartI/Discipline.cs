using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Discipline : IComment
    {
        private string comment;
        private string name;
        private uint numberOfExercises;
        private uint numberOfLectures;

        public Discipline(string name, uint numberOfLectures, uint numberOfExercises, string comment = "")
        {
            this.comment = comment;
            this.name = name;
            this.numberOfExercises = numberOfExercises;
            this.numberOfLectures = numberOfLectures;
        }

        public string Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
                    }

        public uint NumberOfLectures
        {
            get
            {
                throw new System.NotImplementedException();
            }
           
        }

        public uint NumberOfExercises
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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
