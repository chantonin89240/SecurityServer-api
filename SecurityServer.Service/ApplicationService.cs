namespace SecurityServer.Service
{
    using SecurityServer.Entities;
    using SecurityServer.Data;
    using SecurityServer.Service.Interface;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;
    using SecurityServer.Service.Comparer;
    using SecurityServer.Data.Context;

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
        List<Application> IApplicationService.GetApplications()
        {
            List<Application> ListApplications = this.unitOfWork.ApplicationRepository.GetAll().ToList();
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
        Application IApplicationService.GetSecret(string clientSecret)
        {
            Application application = this.unitOfWork.ApplicationRepository.Get(clientSecret);
            return application;
        }
        #endregion

        #region CreateApplication(ApplicationEntity application)
        bool IApplicationService.CreateApplication(Application application)
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
        ApplicationEntity IApplicationService.UpdateApplication(ApplicationUpdateDtoUp app)
        Application IApplicationService.UpdateApplication(Application app)
        {
            // création d'une application Entity
            ApplicationEntity appUp = new ApplicationEntity() { Id = app.Id, Name = app.Name, Description = app.Description, Url = app.Url };
            // création de la liste des users avec les roles
            List<UserAppUpdateDtoUp> users = new List<UserAppUpdateDtoUp>(app.Users.ToList());
           
            // création d'une transaction
            this.unitOfWork.CreateTransaction();

            // update de l'application
            if (app != null)
            {
                // appel du repository update
                appUp = this.unitOfWork.ApplicationRepository.Update(appUp);
            }
            else
            {
                return appUp;
            }

            // récupération de la liste des users de l'application
            List<ApplicationUserRoleEntity> appUsers = this.unitOfWork.ApplicationUserRoleRepository.GetUser(appUp.Id).ToList();

            // update de la table ApplicationUserRole
            if (appUsers != null) 
            {
                // création d'une liste ApplicationUserRoleEntity avec la liste des nouvelle 
                List<ApplicationUserRoleEntity> newUsers = new List<ApplicationUserRoleEntity>();
                
                foreach (UserAppUpdateDtoUp user in users)
                {
                    ApplicationUserRoleEntity add = new ApplicationUserRoleEntity() { IdUser = user.IdUser };
                    newUsers.Add(add);
                }

                // comparaison des liste pour suppression
                List<ApplicationUserRoleEntity> listDelete = appUsers.Except(newUsers, new UserAppComparer()).ToList();

                // delete des users
                if (listDelete.Count() != 0)
                {
                    foreach (ApplicationUserRoleEntity userDelete in listDelete)
                    {
                        this.unitOfWork.ApplicationUserRoleRepository.DeleteUser(appUp.Id, userDelete.IdUser);
                    }
                }

                // comparaison des liste pour ajout
                List<ApplicationUserRoleEntity> listAdd = newUsers.Except(appUsers, new UserAppComparer()).ToList();
                
                // ajout des users 
                if (listAdd.Count() != 0)
                {
                    foreach (ApplicationUserRoleEntity userAdd in listAdd)
                    {
                        this.unitOfWork.ApplicationUserRoleRepository.Post(userAdd);
                    }
                }




            }
            else
            {
                // la liste est null donc on ajoute tous
                foreach(UserAppUpdateDtoUp us in users)
                {
                    ApplicationUserRoleEntity usApp = new ApplicationUserRoleEntity()
                    { 
                        IdApplication = appUp.Id,
                        IdUser = us.IdUser,
                        IdRole = us.IdRole,
                    };

                    this.unitOfWork.ApplicationUserRoleRepository.Post(usApp);
                }
            }
            Application appUpdate = this.unitOfWork.ApplicationRepository.Update(app);
           
            // appel du commit et du save de la transaction
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            // renvoi de l'application update
            return appUp;
        }
        #endregion
    }
}
