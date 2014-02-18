using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Discipline : Comment
    {
        private string name;
        private uint numberOfExercises;
        private uint numberOfLectures;

        public Discipline(string name, uint numberOfLectures, uint numberOfExercises)
        {
            this.name = name;
            this.numberOfExercises = numberOfExercises;
            this.numberOfLectures = numberOfLectures;
        }

        public override string ToString()
        {
            string classLevel = "++++";
            StringBuilder result = new StringBuilder();

            result.Append(classLevel);
           result.Append("Discipline : ");
            result.Append(this.name);
            result.Append(" : Lectures ");
            result.Append(this.numberOfLectures);
            result.Append(" : Exercises ");
            result.Append(this.numberOfExercises);
            result.Append("\n");
            result.Append(this.GetAllCommentsToString());
            result.Append("\n");
            return result.ToString();
        }


    }
}
