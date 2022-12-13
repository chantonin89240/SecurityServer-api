using SecurityServer.Entities;
using System.Net;

namespace SecurityServer.Service.Interface
{
    public interface IUserService
    {
        public bool CreateUser(UserEntity user);
        public bool GetUser(string password, string mail);
    }
}
