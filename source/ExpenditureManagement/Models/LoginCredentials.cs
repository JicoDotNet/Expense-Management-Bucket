using Microsoft.WindowsAzure.Storage.Table;

namespace ExpenditureManagement.Models
{
    public class LoginCredentials : TableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}