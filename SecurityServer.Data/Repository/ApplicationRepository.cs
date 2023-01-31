namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

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

        ApplicationDtoDown IApplicationRepository.Get(int id)
        {
            
            var application = this.Get(id);
            if (application == null) return null;
 
            var usersapp = context.UserApplication.Where(ua => ua.IdApplication == application.Id).Select(ua=> ua.IdUser).ToList();
            application.Users = context.User.Where(ua => usersapp.Contains(ua.Id)).ToList();
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
