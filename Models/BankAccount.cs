using System;

namespace COMP3300Assignment9BernardBawak.Models
{
    public class BankAccount
    {
        public string OwnerName { get; set; }
        public double CurrentBalance { get; set; }
        public string MonthOpened { get; set; }
        public string Type { get; set; }
        public double MonthlyInterestRate { get; set; }

        public BankAccount(string ownerName, double currentBalance, string monthOpened, string type, double monthlyInterestRate)
        {
            OwnerName = ownerName;
            CurrentBalance = currentBalance;
            MonthOpened = monthOpened;
            Type = type;
            MonthlyInterestRate = monthlyInterestRate;
        }

        public virtual double CalculateMinimumBalanceFee()
        {
            if (CurrentBalance < 1200.00)
            {
                return CurrentBalance * 0.073;
            }
            return 0.0;
        }

        public override string ToString()
        {
            return $"Name: {OwnerName}, Balance: {CurrentBalance}, Month Opened: {MonthOpened}, Monthly Interest Rate: {MonthlyInterestRate}";
        }
    }
}

