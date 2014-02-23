using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    internal abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healtPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string name, double attackPoints, double defensePoints) 
        {
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.name = name;
            this.targets = new List<string>();
        }

        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set { this.pilot = value; }
        }

        public double HealthPoints
        {
            get { return this.healtPoints; }
            set { this.healtPoints = value; }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            set { this.defensePoints = value; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public abstract void Attack(string target);
      

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("- ");
            result.Append(this.name);
            result.Append("\n *Type: ");
            result.Append(this.GetType().Name);
            result.Append("\n *Health: ");
            result.Append(this.HealthPoints);
            result.Append("\n *Attack: ");
            result.Append(this.AttackPoints);
            result.Append("\n *Defense: ");
            result.Append(this.DefensePoints);
            result.Append("\n *Targets: ");
            if (this.targets.Count() == 0) result.Append("None");
            else
            {
                foreach (var target in this.targets)
                {
                    result.Append(target);
                    result.Append(", ");
                }
                result.Remove(result.Length - 2, 2);
            }
            

            return result.ToString();
        }

      
    }
}
