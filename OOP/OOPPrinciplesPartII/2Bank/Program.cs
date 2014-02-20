//A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. Customers could be individuals or companies.
//	All accounts have customer, balance and interest rate (monthly based). Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
// All accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as follows: number_of_months * interest_rate.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new Account[6];
            accounts[0] = new DepositAccount(new Individual("Pesho"), 500, 10);
            accounts[1] = new DepositAccount(new Company("Pesh LTD"), 1000, 10);
            accounts[2] = new LoanAccount(new Individual("Ivan"), 500, 10);
            accounts[3] = new LoanAccount(new Company("Ivan LTD"), 500, 10);
            accounts[4] = new MortgageAccount(new Individual("Goro LTD"), 500, 10);
            accounts[5] = new MortgageAccount(new Company("Goro LTD"), 500, 10);

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine("Interest amount for First month = " + account.CalculateInterestAmountForMonths(1));
            }
            Console.WriteLine("\n----------------------------");
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine("Interest amount for 3 month = " + account.CalculateInterestAmountForMonths(3));
            }
            Console.WriteLine("\n----------------------------");
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine("Interest amount for 6 month = " + account.CalculateInterestAmountForMonths(6));
            }
            Console.WriteLine("\n----------------------------");
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine("Interest amount for 12 month = " + account.CalculateInterestAmountForMonths(12));
            }
            Console.WriteLine("\n----------------------------");
            foreach (var account in accounts)
            {
                Console.WriteLine(account);
                Console.WriteLine("Interest amount for 24 month = " + account.CalculateInterestAmountForMonths(24));
            }


            Console.WriteLine("\n----------------------------");
            var deposAcc = new DepositAccount(new Individual("Pesho"), 500, 10);
            Console.WriteLine(deposAcc);
            deposAcc.Deposit(1000);
            Console.WriteLine("deposit 1000");
            Console.WriteLine(deposAcc);
            deposAcc.WithdrawMoney(500);
            Console.WriteLine("Withdraw 500");
            Console.WriteLine(deposAcc);



        }
    }
}
