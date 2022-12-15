using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;

namespace SecurityServer.Data.Repository
{
    public class ApplicationRepository : BaseRepository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationRepository(SecurityServerDbContext context) : base (context) 
        {

        }

        IEnumerable<ApplicationEntity> IApplicationRepository.Get()
        {
            return this.GetAll();
        }

        ApplicationEntity IApplicationRepository.Get(int id)
        {
            ApplicationEntity application = new ApplicationEntity();
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
