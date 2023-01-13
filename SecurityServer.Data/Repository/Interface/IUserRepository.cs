namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;

    public  interface IUserRepository : IBaseRepository<UserEntity>
    {
        IEnumerable<UserEntity> Get();
        UserEntity Get(int id);
        bool Get(UserEntity user);
        UserEntity Post(UserEntity user);
        UserEntity Update(UserEntity user);
        string Delete(int id);
        UserEntity Get(string email);


    }
}
