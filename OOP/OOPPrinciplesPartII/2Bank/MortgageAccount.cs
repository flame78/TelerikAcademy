using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }
        public override decimal CalculateInterestAmountForMonths(decimal numberOfMonths)
        {
            if (this.AccountCustomer is Individual)
                if (numberOfMonths > 6) return base.CalculateInterestAmountForMonths(numberOfMonths) - this.InterestRate * 6;
                else return 0;
            else if (this.AccountCustomer is Company)
                if (numberOfMonths > 12) return base.CalculateInterestAmountForMonths(numberOfMonths) - (this.InterestRate * 12) / 2;
                else return (this.InterestRate * numberOfMonths) / 2;


            throw new ArgumentNullException("Invalid Customer");
        }

    }
}
