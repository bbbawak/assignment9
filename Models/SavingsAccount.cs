using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    /// <summary>
    /// Derived class for Savings accounts
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Constructor that calls the base class constructor
        /// </summary>
        public SavingsAccount(string ownerName, double currentBalance, string monthOpened, double monthlyInterestRate)
            : base(ownerName, currentBalance, monthOpened, "savings", monthlyInterestRate)
        {
        }

        /// <summary>
        /// Full override: Savings accounts have a tiered fee structure
        /// If balance is below 1000, fee is 5% of balance
        /// If balance is between 1000-2000, fee is 3% of balance
        /// Otherwise, uses base calculation
        /// </summary>
        public override double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance < 1000.00)
            {
                return CurrentBalance * 0.05;
            }
            else if (CurrentBalance < 2000.00)
            {
                return CurrentBalance * 0.03;
            }
            else
            {
                return base.CalculateMinimumBalanceFee();
            }
        }

        /// <summary>
        /// Partial override: Adds account type to the base ToString
        /// </summary>
        public override string ToString()
        {
            return $"Account Type: {Type}\n{base.ToString()}";
        }
    }
}

