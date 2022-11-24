using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServer.Entities;
using SecurityServer.Data;
using SecurityServer.Entities.IEntities;
using SecurityServer.Service.Interface;

namespace SecurityServer.Service
{
    public class ApplicationService : IApplicationService
    {
        private UnitOfWork? unitOfWork;

        public ApplicationService(UnitOfWork unit) 
        {
            this.unitOfWork = unit;
        }

        public List<ApplicationEntity> GetApplications()
        {
            List<ApplicationEntity> ListApplications = this.unitOfWork.Application.Get().ToList();
            return ListApplications;
        }

    }
}
