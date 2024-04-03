using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenditureManagement
{
    public static class Extension
    {
        public static long TimeStamp(this DateTime DTobj)
        {
            try
            {
                return ((DTobj.Ticks - 621355968000000000) / 10000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

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