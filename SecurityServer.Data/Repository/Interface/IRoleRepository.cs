namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;

    public interface IRoleRepository : IBaseRepository<RoleEntity>
    {
        IEnumerable<RoleEntity> GetAll(int id);
        IEnumerable<RoleEntity> GetAll();
        RoleEntity Get(int id);
        void Post(ApplicationRoleEntity roleApp);
        void Delete(int id);
    }
}
