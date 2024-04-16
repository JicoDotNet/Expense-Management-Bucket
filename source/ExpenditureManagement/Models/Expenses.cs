using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace ExpenditureManagement.Models
{
    public class Expenses : TableEntity
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Details { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public string ExpensesType { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
    }
}