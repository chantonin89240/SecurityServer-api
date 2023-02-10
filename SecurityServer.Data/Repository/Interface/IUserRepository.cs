namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public  interface IUserRepository : IBaseRepository<User>
    {
        IEnumerable<User> Get();
        UserDtoDown Get(int id);
        bool Get(User user);
        User Post(User user);
        UserDtoDown Update(User user);
        void Delete(int id);
        User Get(string email);
    }
}
