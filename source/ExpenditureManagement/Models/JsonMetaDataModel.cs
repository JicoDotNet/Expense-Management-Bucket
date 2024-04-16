using System.Collections.Generic;

namespace ExpenditureManagement.Models
{
    public class JsonMetaDataModel
    {
        public List<string> TransactionTypes { get; set; }
        public List<string> ExpensesTypes { get; set; }
        public string[] BackgroundColors { get; set; }

        public int? StartingYear { get; set; }
    }
}