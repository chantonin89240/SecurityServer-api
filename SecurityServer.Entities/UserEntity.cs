using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class UserEntity : IUserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string avatar { get; set; }
        public bool IsAdmin { get; set; }

        public List<ApplicationEntity> Applications {  get; set; }


        public UserEntity() { }

        public UserEntity(int idrole, string firstname, string lastname, string email, string password, string salt, string avatar, bool isAdmin)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
            this.avatar = avatar;
            this.IsAdmin = isAdmin;
            Applications = new List<ApplicationEntity>();
        }
    }
}
