using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    /// <summary>
    /// Derived class for Checking accounts
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Constructor that calls the base class constructor
        /// </summary>
        public CheckingAccount(string ownerName, double currentBalance, string monthOpened, double monthlyInterestRate)
            : base(ownerName, currentBalance, monthOpened, "checking", monthlyInterestRate)
        {
        }

        /// <summary>
        /// Partial override: Checking accounts have a flat fee structure
        /// If balance is below 1500, applies a flat fee of $25 plus 2% of balance
        /// Otherwise, uses base calculation
        /// </summary>
        public override double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance < 1500.00)
            {
                return 25.00 + (CurrentBalance * 0.02);
            }
            return base.CalculateMinimumBalanceFee();
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

