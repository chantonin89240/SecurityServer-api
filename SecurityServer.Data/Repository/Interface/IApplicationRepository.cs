using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public interface IApplicationRepository : IBaseRepository<ApplicationEntity>
    {
        IEnumerable<ApplicationEntity> Get();
        ApplicationEntity Get(int id);
        void Post(ApplicationEntity application);
        void Update(ApplicationEntity application);
        void Delete(int id);
    }
}
