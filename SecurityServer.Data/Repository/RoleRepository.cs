namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;

    public class RoleRepository : BaseRepository<RoleEntity>, IRoleRepository
    {
        SecurityServerDbContext context;

        public RoleRepository(SecurityServerDbContext context) : base(context)
        {
            this.context = context;
        }

        IEnumerable<RoleEntity> IRoleRepository.GetAll(int id)
        {
            List<RoleEntity> listRoles = context.Role.Join(context.ApplicationRole.Where(r => r.IdApplication == id), ro => ro.Id, us => us.IdRole, (Role, ApplicationRole) => Role).ToList();
            return listRoles;
        }

        RoleEntity IRoleRepository.Get(int id)
        {
            return this.Get(id);
        }

        RoleEntity IRoleRepository.Post(RoleEntity application)
        {
            throw new NotImplementedException();
        }

        void IRoleRepository.Delete(int id)
        {
            this.Delete(id);
        }

    }
}