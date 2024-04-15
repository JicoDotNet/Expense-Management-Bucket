using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;

namespace ExpenditureManagement.Models
{
    public class ExpensesType : IExpensesType
    {
        public string ExpensesTypeName { get; set; }
    }
}