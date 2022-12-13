using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Service.Interface
{
    public interface ISalt
    {
        public string saltGenerator();
        public string HashPassword(string password, string salt);
    }
}
