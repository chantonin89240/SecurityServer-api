namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public interface IUserService
    {
        public bool CreateUser(User user);
        public UserAuthDtoDown GetAuthUser(string email, string password);
        public List<UserAppDtoDown> GetUsers();
        public bool DeleteUser(int id);
        public UserDtoDown GetUser(int id);
        public UserDtoDown UpdateUser(User user);
        public bool GetMailNotUse(string email);
    }
}
