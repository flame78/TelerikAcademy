﻿using System;
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

       
    }
}
