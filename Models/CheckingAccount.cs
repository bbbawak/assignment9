using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(string ownerName, double currentBalance, string monthOpened, double monthlyInterestRate)
            : base(ownerName, currentBalance, monthOpened, "checking", monthlyInterestRate)
        {
        }

        public override double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance < 1500.00)
            {
                return 25.00 + (CurrentBalance * 0.02);
            }
            return base.CalculateMinimumBalanceFee();
        }

        public override string ToString()
        {
            return $"Account Type: {Type}\n{base.ToString()}";
        }
    }
}

