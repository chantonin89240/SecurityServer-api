using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.DtoDown
{
    public class UserDtoDown
    {
        public int id { get; set; }
        public string email { get; set; }
        public bool isAdmin { get; set; }
    }
}
