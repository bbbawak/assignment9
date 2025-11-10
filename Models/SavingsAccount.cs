using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string ownerName, double currentBalance, string monthOpened, double monthlyInterestRate)
            : base(ownerName, currentBalance, monthOpened, "savings", monthlyInterestRate)
        {
        }

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

        public override string ToString()
        {
            return $"Account Type: {Type}\n{base.ToString()}";
        }
    }
}

