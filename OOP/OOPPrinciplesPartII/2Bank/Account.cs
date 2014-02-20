using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    class Account
    {
        private Customer customer;
        private decimal balance;
        private decimal interestRate;

        //decimal Balance()
        //{ 
        //    get; { return this.balance; }
        //    set; { this.balance = value; }
        //}
        public void Deposit(decimal money)
        { 

        }
        public virtual decimal CalculateInterest(decimal numberOfMonths)
        {
            return numberOfMonths * this.interestRate;
        }
    }
}
