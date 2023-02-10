namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoUp;

    public interface IRoleService
    {
        public List<Role> GetRolesApp(int id);
        public List<Role> GetRoles();
        public Role GetRole(int id);
       // public bool AddRole(ApplicationRoleEntity role);
       // public List<Role> GetRoles(int id);
        //public Role GetRole(int id);
        public bool CreateRole(Role role);
        public bool DeleteRole(int id);
    }
}
