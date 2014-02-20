using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)  {}
        public override decimal CalculateInterestAmountForMonths(decimal numberOfMonths)
        {
            if (this.AccountCustomer is Individual)
                return base.CalculateInterestAmountForMonths(numberOfMonths) -
                this.InterestRate*3;
            else if (this.AccountCustomer is Company)
                return base.CalculateInterestAmountForMonths(numberOfMonths) - this.InterestRate * 2;
            throw new ArgumentNullException("Invalid Customer");
        }
    }
}
