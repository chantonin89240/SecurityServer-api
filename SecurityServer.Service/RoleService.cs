namespace SecurityServer.Service
{
    using SecurityServer.AzureFunction;
    using SecurityServer.Data;
    using SecurityServer.Data.Context;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;
    using SecurityServer.Service.Interface;
    using static System.Net.Mime.MediaTypeNames;

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

        #region GetRolesApp(int id)
        public List<RoleEntity> GetRolesApp(int id)
        public List<Role> GetRoles(int id)
        {
           // List<Role> ListRoles = this.unitOfWork.RoleRepository.GetAll(id).ToList();
            return null;
        }
        #endregion

        #region GetRoles(int id)
        public List<RoleEntity> GetRoles()
        {
            List<RoleEntity> ListRoles = this.unitOfWork.RoleRepository.GetAll().ToList();
            return ListRoles;
        }
        #endregion

        #region GetRole(int id)
        public RoleEntity GetRole(int id)

        public Role GetRole(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CreateRole(ApplicationRoleEntity role)
        public bool AddRole(ApplicationRoleEntity role)
        {
            // création de la transaction
            this.unitOfWork.CreateTransaction();
            // ajout de l'applicationRole
            this.unitOfWork.RoleRepository.Post(role);

            try 
        public bool CreateRole(Role role)
            {
                this.unitOfWork.Commit();
                this.unitOfWork.Save();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        #endregion

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
