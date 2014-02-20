using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    class DepositAccount : Account, IWithdraw
    {


        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        public void WithdrawMoney(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException("Cant Withdraw negative or zere amount.");
            this.Balance -= amount;
        }

        public override decimal CalculateInterestAmountForMonths(decimal numberOfMonths)
        {
            if (this.Balance < 1000M) return 0;

            return base.CalculateInterestAmountForMonths(numberOfMonths);
        }
    }
}
