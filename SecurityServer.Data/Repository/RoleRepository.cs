namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Context;
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;
    using static System.Net.Mime.MediaTypeNames;

    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository

    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        SecurityServerDbContext context;

        public RoleRepository(SecurityServerDbContext context) : base(context)
        {
            this.context = context;
        }

        IEnumerable<Role> IRoleRepository.GetAll(int id)
        {
            List<Role> listRoles = context.Role.Where(r => r.Applications.Any(a=>a.Id == id)).ToList();
            return listRoles;
        }


        IEnumerable<Role> IRoleRepository.GetAll()
        {
            List<Role> listRoles = this.GetAll().ToList();
            return listRoles;
        }

        Role IRoleRepository.Get(int id)
        {
            return this.Get(id);
        }

        Role IRoleRepository.Post(Role application)
        {
            this.context.ApplicationRole.Add(roleApp);
        }

        void IRoleRepository.Delete(int id)
        {
            this.Delete(id);
        }

    }
}