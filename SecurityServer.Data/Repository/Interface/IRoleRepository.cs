namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;

    public interface IRoleRepository : IBaseRepository<RoleEntity>
    {
        IEnumerable<RoleEntity> GetAll(int id);
        RoleEntity Get(int id);
        RoleEntity Post(RoleEntity application);
        void Delete(int id);
    }
}
