using System;

namespace Bai004
{
    class BankAccount
    {
        public int AccountNumber{ get; set; }
        public string? Holder{ get; set; }
        public double Balance{ get; set; }

        private List<Transaction> history = new List<Transaction>();
        public void Deposit(double amount)
        {
            Balance += amount;
            Transaction transaction = new Transaction
            {
                type = "Deposit",
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);
        }
         public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            Balance -= amount;
            Transaction transaction = new Transaction
            {
                type = "Withdraw",
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);
        }
        public void Transfer(BankAccount targetAccount, double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            Balance -= amount;
            targetAccount.Balance += amount;

            Transaction transaction = new Transaction
            {
                type = "Transfer Out",
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);

            Transaction targetTransaction = new Transaction
            {
                type = "Transfer In",
                amount = amount,
                date = DateTime.Now
            };
            targetAccount.history.Add(targetTransaction);
        }
    }
}