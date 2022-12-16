namespace SecurityServer.Service
{
    using SecurityServer.Entities;
    using SecurityServer.Data;
    using SecurityServer.Service.Interface;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;

    public class ApplicationService : IApplicationService
    {
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;
        private ISalt _salt;

        public ApplicationService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt) 
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }

        List<ApplicationEntity> IApplicationService.GetApplications()
        {
            List<ApplicationEntity> ListApplications = this.unitOfWork.ApplicationRepository.GetAll().ToList();
            return ListApplications;
        }

        bool IApplicationService.CreateApplication(ApplicationEntity application)
        {
            this.unitOfWork.CreateTransaction();
            application.ClientSecret = _salt.saltGenerator();
            this.unitOfWork.ApplicationRepository.Post(application);
            if (application.Url.Trim() == "" || application.Name.Trim() =="")
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


        bool IApplicationService.DeleteApplication(int id)
        {
            this.unitOfWork.CreateTransaction();
            this.unitOfWork.ApplicationRepository.Delete(id);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            var appOk = this.unitOfWork.ApplicationRepository.Get(id);
            if (appOk.Id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

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
    }
}
