using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Service.Interface
{
    public interface IApplicationService
    {
        public List<ApplicationEntity> GetApplications();
        public ApplicationEntity CreateApplication(ApplicationEntity application);
    }
}
