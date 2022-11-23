using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServer.Data;
using SecurityServer.Entities;

namespace SecurityServer.Data.Repository
{
    public class ApplicationRepository
    {
        private SecurityServerDbContext context;

        public ApplicationRepository(SecurityServerDbContext context) 
        {
            this.context = context;
        }

        public IEnumerable<ApplicationEntity> GetApplications()
        {
            List<ApplicationEntity> applications = this.context.Applications.ToList();
            return applications;
        }
    }
}
