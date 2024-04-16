using System;

namespace ExpenditureManagement.Logic
{
    public class GenericLogic
    {
        public static DateTime IstNow
        {
            get
            {
                return DateTime.UtcNow.AddMinutes(330);
            }
        }
    }
}