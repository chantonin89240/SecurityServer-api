namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoUp;

    public interface IRoleService
    {
        public List<RoleEntity> GetRolesApp(int id);
        public List<RoleEntity> GetRoles();
        public RoleEntity GetRole(int id);
        public bool AddRole(ApplicationRoleEntity role);
        public bool DeleteRole(int id);
    }
}
