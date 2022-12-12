using SecurityServer.Entities;
using SecurityServer.Service.Interface;

namespace SecurityServer.Service
{
    public class UserService : IUserService
    {
        public UserEntity CreateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetUser(string password, string mail)
        {
            throw new NotImplementedException();
        }
    }
}