using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    public class MoneyMarketAccount : BankAccount
    {
        public MoneyMarketAccount(string ownerName, double currentBalance, string monthOpened, double monthlyInterestRate)
            : base(ownerName, currentBalance, monthOpened, "money market", monthlyInterestRate)
        {
        }

        public override double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance >= 5000.00)
            {
                return 0.0;
            }
            else
            {
                double shortfall = 5000.00 - CurrentBalance;
                double shortfallPercentage = (shortfall / 5000.00) * 0.10;
                return (CurrentBalance * 0.045) + (CurrentBalance * shortfallPercentage);
            }
        }

        public override string ToString()
        {
            return $"Account Type: {Type}\n{base.ToString()}";
        }
    }
}

