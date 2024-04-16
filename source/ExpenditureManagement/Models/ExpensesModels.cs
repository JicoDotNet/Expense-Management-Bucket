using System.Collections.Generic;

namespace ExpenditureManagement.Models
{
    public class ExpensesModels
    {
        public List<Expenses> Expensess { get; set; }
        public Expenses Expenses { get; set; }
        public ExpensesTypes ExpensesTypes { get; set; }
        public TransactionTypes TransactionTypes { get; set; }
        public List<int> Years { get; set; }

        public GraphModel GraphModel { get; set; }
    }

    public class GraphModel
    {
        public string[] labels { get; set; }
        public List<DataSet> datasets { get; set; }
    }

    public class DataSet
    {
        public string label { get; set; }
        public int[] data { get; set; }
        public int borderWidth { get; set; }
        public string[] backgroundColor { get; set; }
    }
}