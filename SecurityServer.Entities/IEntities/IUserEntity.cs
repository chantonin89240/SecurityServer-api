using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Entities.IEntities
{
    public interface IUserEntity
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string avatar { get; set; }
    }
}
