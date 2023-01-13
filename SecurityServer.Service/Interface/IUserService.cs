namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public interface IUserService
    {
        public bool CreateUser(UserEntity user);
        public UserDtoDown GetAuthUser(string mail, string password);
        public List<UserAppDtoDown> GetUsers();
    }
}
