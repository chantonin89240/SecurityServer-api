using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.DtoDown
{
    public class UserDtoDown
    {
        public int id;
        public string email;
        public string password;
        public string salt;
        public string token;
        public bool isAdmin;
    }
}
