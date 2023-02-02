namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public interface IUserService
    {
        public bool CreateUser(UserEntity user);
        public UserAuthDtoDown GetAuthUser(string mail, string password);
        public List<UserAppDtoDown> GetUsers();
        public bool DeleteUser(int id);
        public UserDtoDown GetUser(int id);
        public UserDtoDown UpdateUser(UserEntity user);
    }
}
