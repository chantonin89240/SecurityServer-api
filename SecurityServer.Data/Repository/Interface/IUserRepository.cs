namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public  interface IUserRepository : IBaseRepository<UserEntity>
    {
        IEnumerable<UserEntity> Get();
        UserDtoDown Get(int id);
        bool Get(UserEntity user);
        UserEntity Post(UserEntity user);
        UserDtoDown Update(UserEntity user);
        void Delete(int id);
        UserEntity Get(string email);
    }
}
