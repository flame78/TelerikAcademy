using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    abstract class Account
    {
        public Customer AccountCustomer { get; private set;  }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; protected set; }
        public Account(Customer customer, decimal balance, decimal interestRate)
        {
          
            this.AccountCustomer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException("Cant deposit negative or zere amount.");
            this.Balance += amount;
        }
        public virtual decimal CalculateInterestAmountForMonths(decimal numberOfMonths)
        {
            return numberOfMonths * this.InterestRate;
        }

        public override string ToString()
        {
            return this.AccountCustomer.GetType().Name
                + " : "
                + this.AccountCustomer.Name
                + "  Balance = "
                + this.Balance
                + "  Interest Rate =  "
                + this.InterestRate;
        }
    }
}
