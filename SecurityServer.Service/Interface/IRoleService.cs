namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;

    public interface IRoleService
    {
        public List<RoleEntity> GetRoles(int id);
        public RoleEntity GetRole(int id);
        public bool CreateRole(RoleEntity role);
        public bool DeleteRole(int id);
    }
}
