namespace SecurityServer.Service
{
    using SecurityServer.Data;
    using SecurityServer.Entities;
    using SecurityServer.Service.Interface;

    public class RoleService : IRoleService
    {
        #region Variables
        // initialisation de unit of work
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;
        #endregion

        #region Initialisation
        public RoleService(IUnitOfWork<SecurityServerDbContext> unit)
        {
            this.unitOfWork = unit;
        }
        #endregion

        public List<RoleEntity> GetRoles(int id)
        {
            List<RoleEntity> ListRoles = this.unitOfWork.RoleRepository.GetAll(id).ToList();
            return ListRoles;
        }

        public RoleEntity GetRole(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateRole(RoleEntity role)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRole(int id)
        {
            throw new NotImplementedException();
        }
    }
}
