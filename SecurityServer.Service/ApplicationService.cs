namespace SecurityServer.Service
{
    using SecurityServer.Entities;
    using SecurityServer.Data;
    using SecurityServer.Service.Interface;
    using SecurityServer.Entities.DtoDown;

    public class ApplicationService : IApplicationService
    {
        #region Variables
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;
        private ISalt _salt;
        #endregion

        #region Initialisation
        public ApplicationService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt) 
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }
        #endregion

        #region GetApplications
        List<ApplicationEntity> IApplicationService.GetApplications()
        {
            List<ApplicationEntity> ListApplications = this.unitOfWork.ApplicationRepository.GetAll().ToList();
            return ListApplications;
        }
        #endregion

        #region GetApplication(int id)
        ApplicationDtoDown IApplicationService.GetApplication(int id)
        {
            ApplicationDtoDown application = this.unitOfWork.ApplicationRepository.Get(id);
            application.Roles = this.unitOfWork.RoleRepository.GetAll(application.Id).ToList();
            return application;
        }
        #endregion

        #region GetSecret(string clientSecret)
        ApplicationEntity IApplicationService.GetSecret(string clientSecret)
        {
            ApplicationEntity application = this.unitOfWork.ApplicationRepository.Get(clientSecret);
            return application;
        }
        #endregion

        #region CreateApplication(ApplicationEntity application)
        bool IApplicationService.CreateApplication(ApplicationEntity application)
        {
            this.unitOfWork.CreateTransaction();
            application.ClientSecret = _salt.SaltGenerator();
            this.unitOfWork.ApplicationRepository.Post(application);
            if (string.IsNullOrEmpty(application.Url) || string.IsNullOrEmpty(application.Name))
            {
                return false;
            }
            else
            {
                this.unitOfWork.Commit();
                this.unitOfWork.Save();
                return true;
            }
            
        }
        #endregion

        #region DeleteApplication(int id)
        bool IApplicationService.DeleteApplication(int id)
        {
            this.unitOfWork.CreateTransaction();
            this.unitOfWork.ApplicationRepository.Delete(id);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            ApplicationDtoDown appOk = this.unitOfWork.ApplicationRepository.Get(id);
            if (appOk == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region UpdateApplication(ApplicationEntity app)
        // service update application
        ApplicationEntity IApplicationService.UpdateApplication(ApplicationEntity app)
        {
            // création d'une transaction
            this.unitOfWork.CreateTransaction();
            // appel du repository update
            ApplicationEntity appUpdate = this.unitOfWork.ApplicationRepository.Update(app);
            // appel du commit et du save de la transaction
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            // renvoi de l'application update
            return appUpdate;
        }
        #endregion
    }
}
