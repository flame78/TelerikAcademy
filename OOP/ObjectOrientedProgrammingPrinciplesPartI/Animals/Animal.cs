using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    abstract class Animal : ISound
    {
        private string name;
        private byte age;
        private bool sexIsMale;

        public Animal(string name, byte age, bool sexIsMale)
        {
            this.name = name;
            this.age = age;
            this.sexIsMale = sexIsMale;
        }

        public byte Age { get { return this.age; } }
        public abstract void Sound();

        public override string ToString()
        {
            return this.GetType().Name+" "+this.name+" "+this.age+" "+(this.sexIsMale?"Male ":"Female ");
        }
        
    }
}
