using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    abstract class Customer
    {
        public string Name { get; protected set; }

        public Customer(string name)
        {
            this.Name = name;
        }
    }
}
