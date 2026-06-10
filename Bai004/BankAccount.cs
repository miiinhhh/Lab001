using System;

namespace Bai004
{
    class BankAccount
    {
        public int AccountNumber{ get; set; }
        public string? Holder{ get; set; }
        public double Balance{ get; set; }

        private List<Transaction> history = new List<Transaction>();

        // Nạp tiền vào tài khoản
        public void Deposit(double amount)
        {
            Balance += amount;
            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.Deposit,
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);
        }

        // Rút tiền từ tài khoản
         public void Withdraw(double amount)
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

        // Chuyển tiền giữa hai tài khoản
        public void Transfer(BankAccount targetAccount, double amount)
        {
            if (ValidateWithdraw(amount) == false)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            Balance -= amount;
            targetAccount.Balance += amount;

            Transaction transaction = new Transaction
            {
                transactionType = TransactionType.Transfer,
                amount = amount,
                date = DateTime.Now
            };
            history.Add(transaction);

            Transaction targetTransaction = new Transaction
            {
                transactionType = TransactionType.Transfer,
                amount = amount,
                date = DateTime.Now
            };
            targetAccount.history.Add(targetTransaction);
        }

        //hàm validate khi rút tiền
        public bool ValidateWithdraw(double amount)
        {
            return amount <= Balance;
        }
    }
}