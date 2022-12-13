using SecurityServer.Entities;
using System.Net;

namespace SecurityServer.Service.Interface
{
    public interface IUserService
    {
        public bool GetUser(string password, string mail);
        public UserEntity CreateUser(UserEntity user);
    }
}
