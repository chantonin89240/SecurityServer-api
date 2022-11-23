using SecurityServer.Data.Entities;
using SecurityServer.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.LocalRepository
{
    public class LocalApplicationRepository : IApplicationRepository
    {
        private SecurityServerDbContext _context;
        public LocalApplicationRepository(SecurityServerDbContext context)
        {
            _context = context;
        }

        public void addApplication(ApplicationEntity application)
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
            return _context.Applications.ToList();
        }

        public void Update(ApplicationEntity application)
        {
            throw new NotImplementedException();
        }
    }
}
