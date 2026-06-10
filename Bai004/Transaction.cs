using System;

namespace Bai004
{
    class Transaction
    {
        public TransactionType transactionType { get; set; }
        public AccountType accountType { get; set; }
        public double amount { get; set; }
        public DateTime date { get; set; }
    }
}