using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenditureManagement.Models
{
    public class ExpensesModels
    {
        public List<Expenses> Expensess { get; set; }
        public Expenses Expenses { get; set; }
        public List<ExpensesType> ExpensesTypes { get; set; }
        public List<TransactionType> TransactionTypes { get; set; }

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

    public class BackgroundColor
    {
        public static string[] label
        {
            get
            {
                return new string[] {
                    "rgb(128, 0, 0)",
                    "rgb(255, 160, 122)",
                    "rgb(60, 20, 60)",
                    "rgb(17, 122, 101)",
                    "rgb(133, 193, 233)",
                    "rgb(133, 73, 233)",
                    "rgb(247, 220, 111)",
                    "rgb(195, 155, 211)",
                    "rgb(130, 224, 170)",
                    "rgb(187, 100, 128)",
                    "rgb(240, 93, 83)",
                    "rgb(250, 127, 5)",
                    "rgb(94, 184, 250)",
                    "rgb(249, 46, 238)",
                    "rgb(162, 213, 37)",
                    "rgb(50, 255, 122)",
                };
            }
        }
    }
}