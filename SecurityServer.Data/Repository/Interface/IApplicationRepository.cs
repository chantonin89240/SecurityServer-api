using SecurityServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public interface IApplicationRepository
    {
        void addApplication(ApplicationEntity application);
        void deleteApplication(ApplicationEntity application);
        ApplicationEntity find(int id);
        List<ApplicationEntity> findAll();
        void Update(ApplicationEntity application);
    }
}
