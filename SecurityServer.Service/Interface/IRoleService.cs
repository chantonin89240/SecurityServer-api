namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoUp;

    public interface IRoleService
    {
        public List<Role> GetRolesApp(int id);
        public List<Role> GetRoles();
        public Role GetRole(int id);
        public bool AddRole(ApplicationRoleDtoUp role);
        //public bool CreateRole(Role role);
        public bool DeleteRole(int id);
    }
}
