using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using System.Net;

namespace SecurityServer.Service.Interface
{
    public interface IUserService
    {
        public bool CreateUser(UserEntity user);
        public UserDtoDown GetUser(string password, string mail);
    }
}
