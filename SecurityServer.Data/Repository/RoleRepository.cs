namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Context;
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;

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

        Role IRoleRepository.Get(int id)
        {
            return this.Get(id);
        }

        Role IRoleRepository.Post(Role application)
        {
            throw new NotImplementedException();
        }

        void IRoleRepository.Delete(int id)
        {
            this.Delete(id);
        }

    }
}