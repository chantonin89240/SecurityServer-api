namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Context;
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        SecurityServerDbContext context;
        public ApplicationRepository(SecurityServerDbContext context) : base (context) 
        {
            this.context = context;
        }

        public IEnumerable<Application> Get()
        {
            return this.GetAll();
        }

        ApplicationDtoDown IApplicationRepository.Get(int id)
        {
            
            var application = this.Get(id);
            if (application == null) return null;
 
            var usersapp = context.ApplicationUserRole.Where(ua => ua.IdApplication == application.Id).Select(ua=> ua.IdUser).ToList();
            var users = context.User.Where(ua => usersapp.Contains(ua.Id)).Select(ua => new { ua.Id, ua.FirstName, ua.LastName, ua.Email }).ToList();

            ApplicationDtoDown applicationDtoDown = new ApplicationDtoDown
            {
                Id = id,
                Name = application.Name,
                Description = application.Description,
                Url = application.Url,
                ClientSecret = application.ClientSecret,
            };

            foreach (var user in users)
            {
                UserAppDtoDown userAppDto = new UserAppDtoDown
                {
                    Id = user.Id, 
                    Email = user.Email,
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                };

                applicationDtoDown.Users.Add(userAppDto);
            }
            return applicationDtoDown;
        }

        Application IApplicationRepository.Get(string clientSecret)
        {
            Application application = this._dbSet.FirstOrDefault(a => a.ClientSecret == clientSecret);
            return application;
        }

        Application IApplicationRepository.Post(Application application)
        {
           return this.Add(application);
        }

        Application IApplicationRepository.Update(Application application)
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
