using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank : Machine, ITank
    {
        private bool defenseMode;
        public bool DefenseMode
        {
            get { return defenseMode; }
        }

        public void ToggleDefenseMode()
        {
            this.defenseMode = !this.defenseMode;
            if (this.defenseMode)
            {

                this.AttackPoints -= 40;
                this.DefensePoints += 30;

            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;

            }
        }

        internal Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = 100;
            this.defenseMode = false;
            ToggleDefenseMode();

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(base.ToString());
            result.Append("\r\n *Defense: ");
            result.Append(this.defenseMode ? "ON" : "OFF");


            return result.ToString();
        }

        public override void Attack(string target)
        {
            Console.WriteLine("tankatt" + target);
        }
    }
}
