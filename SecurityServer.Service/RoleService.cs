namespace SecurityServer.Service
{
    using SecurityServer.Data;
    using SecurityServer.Data.Context;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
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

        public List<Role> GetRoles(int id)
        {
           // List<Role> ListRoles = this.unitOfWork.RoleRepository.GetAll(id).ToList();
            return null;
        }

        public Role GetRole(int id)
        {
            throw new NotImplementedException();
        }

        public bool CreateRole(Role role)
        {
            throw new NotImplementedException();
        }

        #region DeleteRole(int id)
        public bool DeleteRole(int id)
        {
            this.unitOfWork.CreateTransaction();
            this.unitOfWork.RoleRepository.Delete(id);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();

            Role roleOk = this.unitOfWork.RoleRepository.Get(id);
            if (roleOk == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
