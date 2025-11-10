using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    /// <summary>
    /// Derived class for Money Market accounts
    /// </summary>
    public class MoneyMarketAccount : BankAccount
    {
        /// <summary>
        /// Constructor that calls the base class constructor
        /// </summary>
        public MoneyMarketAccount(string ownerName, double currentBalance, string monthOpened, double monthlyInterestRate)
            : base(ownerName, currentBalance, monthOpened, "money market", monthlyInterestRate)
        {
        }

        /// <summary>
        /// Full override: Money Market accounts have no fees if balance is above 5000
        /// If below 5000, fee is 4.5% of balance plus a percentage based on how far below threshold
        /// </summary>
        public override double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance >= 5000.00)
            {
                return 0.0;
            }
            else
            {
                double shortfall = 5000.00 - CurrentBalance;
                double shortfallPercentage = (shortfall / 5000.00) * 0.10; // Up to 10% additional fee
                return (CurrentBalance * 0.045) + (CurrentBalance * shortfallPercentage);
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

