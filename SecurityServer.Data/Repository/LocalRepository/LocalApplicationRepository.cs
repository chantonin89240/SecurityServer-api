using SecurityServer.Entities;
using SecurityServer.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;

namespace SecurityServer.Data.Repository.LocalRepository
{
    public class LocalApplicationRepository : IApplicationRepository
    {
        private SecurityServerDbContext _context;
        public LocalApplicationRepository(SecurityServerDbContext context)
        {
            _context = context;
        }

        public ApplicationEntity Add(ApplicationEntity entity)
        {
            throw new NotImplementedException();
        }

        public void addApplication(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void deleteApplication(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }

        public ApplicationEntity find(int id)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationEntity> findAll()
        {
            return _context.Application.ToList();
        }

        public IEnumerable<ApplicationEntity> Get()
        {
            throw new NotImplementedException();
        }

        public ApplicationEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public ApplicationEntity Get(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationEntity GetString(string email)
        {
            throw new NotImplementedException();
        }

        public void Post(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }

        public void Update(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }
        void IApplicationRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<ApplicationEntity>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        ApplicationEntity IApplicationRepository.Post(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }

        ApplicationEntity IBaseRepository<ApplicationEntity>.Update(ApplicationEntity entity)
        {
            throw new NotImplementedException();
        }

        ApplicationEntity IApplicationRepository.Update(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }
    }
}
