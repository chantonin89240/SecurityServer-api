using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.AzureFunction
{
    public static class Salt
    {
        public static string saltGenerator()
        {
            return "true";
        }

        public static string SaltPassword(string salt, string password)
        {
            string nicePassword;
            return "nicePassword";
        }

    }
}
