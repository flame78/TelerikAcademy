using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2Human
{
    class Worker : Human
    {
        public decimal WeekSalary { get; internal set; }
        public uint WorkHoursPerDay { get; internal set; }

        public Worker(string firstName, string lastName, decimal weekSalary, uint workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * 5);
        }

        public override string ToString()
        {
              return base.ToString()+ " : MoneyPerHour = " + this.MoneyPerHour() ;
        }


    }
}
