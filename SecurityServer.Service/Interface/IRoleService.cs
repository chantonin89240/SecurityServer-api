namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;

    public interface IRoleService
    {
        public List<Role> GetRoles(int id);
        public Role GetRole(int id);
        public bool CreateRole(Role role);
        public bool DeleteRole(int id);
    }
}
