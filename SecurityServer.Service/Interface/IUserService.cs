using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;

namespace SecurityServer.Service.Interface
{
    public interface IUserService
    {
        public bool CreateUser(UserEntity user);
        public UserDtoDown GetAuthUser(string mail, string password);
        public List<UserAppDtoDown> GetUsers();
    }
}
