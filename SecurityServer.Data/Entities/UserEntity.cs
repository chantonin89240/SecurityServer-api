using SecurityServer.Data.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Entities
{
    public class UserEntity : IUserEntity
    {
        public int Id { get; set; }
        public int IdRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string avatar { get; set; }

        public UserEntity() { }

        public UserEntity(int id, int idrole, string firstname, string lastname, string email, string password, string avatar)
        {
            this.Id = id;   
            this.IdRole = idrole;
            this.FirstName = firstname; 
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.avatar = avatar;
        }



    }
}
