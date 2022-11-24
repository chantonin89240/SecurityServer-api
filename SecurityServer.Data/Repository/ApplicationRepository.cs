using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServer.Data;
using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;

namespace SecurityServer.Data.Repository
{
    public class ApplicationRepository : BaseRepository<ApplicationEntity>, IApplicationRepository
    {
        private SecurityServerDbContext context;

        public ApplicationRepository(SecurityServerDbContext context) : base (context) 
        {
            this.context = context;
        }

        IEnumerable<ApplicationEntity> IApplicationRepository.Get()
        {
            List<ApplicationEntity> applications = this.context.Applications.ToList();
            return applications;
        }

        ApplicationEntity IApplicationRepository.Get(int id)
        {
            ApplicationEntity application = new ApplicationEntity();
            return application;
        }

        void IApplicationRepository.Post(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }

        void IApplicationRepository.Update(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }

        void IApplicationRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
