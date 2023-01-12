using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;

namespace SecurityServer.Data.Repository
{
    public class ApplicationRepository : BaseRepository<ApplicationEntity>, IApplicationRepository
    {

        SecurityServerDbContext context;
        public ApplicationRepository(SecurityServerDbContext context) : base (context) 
        {
            this.context = context;
        }

        IEnumerable<ApplicationEntity> IApplicationRepository.Get()
        {
            return this.GetAll();
        }
        //public ApplicationEntity GetApplicationWithUsers(int applicationId)
        //{
        //    List<ApplicationEntity> applicationEntities;
        //    List<UserApplicationEntity> userApplicationEntities;
        //    List<UserEntity> userEntities;
        //    var application = applicationEntities.Where(a => a.Id == applicationId).FirstOrDefault();
        //    if (application == null)
        //    {
        //        return null;
        //    }

        //    var userApplication = userApplicationEntities.Where(ua => ua.IdApplication == applicationId);
        //    var users = userApplication.Join(userEntities, ua => ua.IdUser, u => u.Id, (ua, u) => u).ToList();

        //    application.Users = users;

        //    return application;
        //}

        ApplicationDtoDown IApplicationRepository.Get(int id)
        {
            
            var application = this.Get(id);
            if (application == null) return null;
 
            var usersapp = context.UserApplication.Where(ua => ua.IdApplication == application.Id).Select(ua=> ua.IdUser).ToList();
            application.Users = context.User.Where(ua => usersapp.Contains(ua.Id)).ToList();
            var users = context.User.Where(ua => usersapp.Contains(ua.Id)).Select(ua => new { ua.FirstName, ua.LastName, ua.Email }).ToList();
            ApplicationDtoDown applicationDtoDown = new ApplicationDtoDown
            {
                Name = application.Name,
                Description = application.Description,
                Url = application.Url,
                ClientSecret = application.ClientSecret,
            };

            foreach (var user in users)
            {
                UserAppDtoDown userAppDto = new UserAppDtoDown
                {
                    email = user.Email,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                };

                applicationDtoDown.Userdto.Add(userAppDto);
            }
            return applicationDtoDown;
        }

        ApplicationEntity IApplicationRepository.Get(string clientSecret)
        {
            ApplicationEntity application = this._dbSet.FirstOrDefault(a => a.ClientSecret == clientSecret);
            return application;
        }

        ApplicationEntity IApplicationRepository.Post(ApplicationEntity application)
        {
           return this.Add(application);
        }

        ApplicationEntity IApplicationRepository.Update(ApplicationEntity application)
        {
            var attach = this._dbSet.Attach(application);

            attach.Property(a => a.Url).IsModified = true;
            attach.Property(a => a.Description).IsModified = true;
            attach.Property(a => a.Name).IsModified = true;

            return application;
        }

        void IApplicationRepository.Delete(int id)
        {
            this.Delete(id);
        }
    }
}
