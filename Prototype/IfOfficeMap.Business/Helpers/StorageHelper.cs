using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfOfficeMap.Business.Helpers
{
    public static class StorageHelper
    {
        public static string GetAccountName()
        {
            return ConfigurationManager.AppSettings["StorageAccountName"];
        }

        public static string GetAccountKey()
        {
            return ConfigurationManager.AppSettings["StorageAccountKey"];
        }
    }
}
