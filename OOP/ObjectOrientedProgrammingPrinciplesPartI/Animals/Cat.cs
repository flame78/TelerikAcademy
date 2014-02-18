﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class Cat : Animal
    {
        public Cat(string name, byte age, bool sexIsMale) 
            : base(name,age,sexIsMale) { }

        public override void Sound()
        {
            Console.WriteLine("Miau");
        }
    }
}
