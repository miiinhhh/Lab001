using System;

namespace Bai004;
class Bank
{
    class SavingAccount: BankAccount
    {
        private List<Transaction> history = new List<Transaction>();

        public override void Withdraw(double amount)
        {
            if (ValidateWithdraw(amount) == false)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            Balance -= amount;
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.Withdraw,
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);
        }
    }
    class CheckingAccount: BankAccount
    {
        private List<Transaction> history = new List<Transaction>();

        public override void Withdraw(double amount)
        {
            if (ValidateWithdraw(amount) == false)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            Balance -= amount;
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.Withdraw,
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);
        }
    }
    class BusinessAccount: BankAccount
    {
        private List<Transaction> history = new List<Transaction>();

        public override void Withdraw(double amount)
        {
            if (ValidateWithdraw(amount) == false)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            Balance -= amount;
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.Withdraw,
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);
        }
    }
}
