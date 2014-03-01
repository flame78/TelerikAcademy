using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Person
{
    class Person
    {
        private string name;
        private byte? age;

        public Person(string name, byte? age=null)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            var result = new StringBuilder(this.GetType().Name);
            result.AppendLine(" : "+this.name);
            if (this.age == null) result.AppendLine("Age is not specified");
            else result.AppendLine("Age : " + this.age);

            return result.ToString();
        }
    }
}
