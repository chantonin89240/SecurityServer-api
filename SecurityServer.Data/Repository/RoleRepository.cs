namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;
    using static System.Net.Mime.MediaTypeNames;

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

        IEnumerable<RoleEntity> IRoleRepository.GetAll()
        {
            List<RoleEntity> listRoles = this.GetAll().ToList();
            return listRoles;
        }

        RoleEntity IRoleRepository.Get(int id)
        {
            return this.Get(id);
        }

        void IRoleRepository.Post(ApplicationRoleEntity roleApp)
        {
            this.context.ApplicationRole.Add(roleApp);
        }

        void IRoleRepository.Delete(int id)
        {
            this.Delete(id);
        }

    }
}