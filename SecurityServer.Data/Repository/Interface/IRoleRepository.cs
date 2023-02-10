namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;

    public interface IRoleRepository : IBaseRepository<Role>
    {
        IEnumerable<Role> GetAll(int id);
        Role Get(int id);
        Role Post(Role application);
        void Delete(int id);
    }
}
