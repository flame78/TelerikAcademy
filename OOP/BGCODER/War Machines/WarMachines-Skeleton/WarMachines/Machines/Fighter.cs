using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter : Machine, IFighter
    {
        private bool stealthMode ;
        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode =!this.stealthMode;
        }

        internal Fighter(string name, double attackPoints, double defensePoints, bool stealthMode) : base(name,attackPoints,defensePoints)
        {
            this.HealthPoints = 200;
            this.stealthMode = stealthMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append("\r\n *Stealth: ");
            result.Append(this.stealthMode ? "ON" : "OFF");
            return result.ToString();
        }

        public override void Attack(string target)
        {
            Console.WriteLine("figatt"+target);
        }
    }
}
