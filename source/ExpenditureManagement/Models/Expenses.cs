using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    public class ExpensesType : TableEntity
    {
        public string ExpensesTypeName { get; set; }
    }

    public class TransactionType : TableEntity
    {
        public string TransactionTypeName { get; set; }
    }

    public class LoginCred: TableEntity
    {
        public string UserName { get; set;}
        public string Password { get; set;}
        public bool IsActive { get; set; }
    }
}