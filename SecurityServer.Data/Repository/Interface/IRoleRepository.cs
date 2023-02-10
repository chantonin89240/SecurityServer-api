namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoUp;

    public interface IRoleRepository : IBaseRepository<Role>
    {
        IEnumerable<Role> GetAll();
        IEnumerable<Role> GetAll(int id);
        Role Get(int id);
        Role Post(ApplicationRoleDtoUp application);
        void Delete(int id);
    }
}
