using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2Human
{
    public abstract class Human
    {
        private string firstName; 
        private string lastName;

        public Human(string firstName, string lastName)
        {
            // TODO: Complete member initialization
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public override string ToString()
        {
            return this.firstName + " " + this.lastName;
        }

        public string FirstName { get { return this.firstName; } }
        public string LastName { get { return this.lastName; } }
    }
}
