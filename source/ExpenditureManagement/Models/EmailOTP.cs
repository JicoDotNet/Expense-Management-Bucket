using Microsoft.WindowsAzure.Storage.Table;

namespace ExpenditureManagement.Models
{
    public class EmailOTP : TableEntity
    {
        public string UserEmail { get; set; }
        public int OTP { get; set; }
        public bool IsActive { get; set; }
    }
}