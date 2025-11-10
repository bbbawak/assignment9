using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    /// <summary>
    /// Base class for bank accounts
    /// </summary>
    public class BankAccount
    {
        public string OwnerName { get; set; }
        public double CurrentBalance { get; set; }
        public string MonthOpened { get; set; }
        public string Type { get; set; }
        public double MonthlyInterestRate { get; set; }

        /// <summary>
        /// Base constructor for BankAccount
        /// </summary>
        public BankAccount(string ownerName, double currentBalance, string monthOpened, string type, double monthlyInterestRate)
        {
            OwnerName = ownerName;
            CurrentBalance = currentBalance;
            MonthOpened = monthOpened;
            Type = type;
            MonthlyInterestRate = monthlyInterestRate;
        }

        /// <summary>
        /// Calculates the minimum balance fee if balance is below 1200.00
        /// Returns 7.3% of current total if below threshold
        /// </summary>
        public virtual double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance < 1200.00)
            {
                return CurrentBalance * 0.073;
            }
            return 0.0;
        }

        /// <summary>
        /// Returns a string representation of the bank account
        /// </summary>
        public override string ToString()
        {
            return $"Name: {OwnerName}, Balance: {CurrentBalance}, Month Opened: {MonthOpened}, Monthly Interest Rate: {MonthlyInterestRate}";
        }
    }
}

