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
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;

        public ApplicationService(IUnitOfWork<SecurityServerDbContext> unit) 
        {
            this.unitOfWork = unit;
        }

        public List<ApplicationEntity> GetApplications()
        {
            this.unitOfWork.CreateTransaction();
            List<ApplicationEntity> ListApplications = this.unitOfWork.ApplicationRepository.GetAll().ToList();
            return ListApplications;
        }

        public ApplicationEntity CreateApplication(ApplicationEntity application)
        {
            this.unitOfWork.CreateTransaction();
            ApplicationEntity Application = this.unitOfWork.ApplicationRepository.Post(application);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            return Application;
        }

    }
}
