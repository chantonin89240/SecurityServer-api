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

        List<ApplicationEntity> IApplicationService.GetApplications()
        {
            List<ApplicationEntity> ListApplications = this.unitOfWork.ApplicationRepository.GetAll().ToList();
            return ListApplications;
        }

        ApplicationEntity IApplicationService.CreateApplication(ApplicationEntity application)
        {
            this.unitOfWork.CreateTransaction();
            ApplicationEntity Application = this.unitOfWork.ApplicationRepository.Post(application);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            return Application;
        }


        bool IApplicationService.DeleteApplication(int id)
        {
            this.unitOfWork.CreateTransaction();
            this.unitOfWork.ApplicationRepository.Delete(id);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            var appOk = this.unitOfWork.ApplicationRepository.Get(id);
            if (appOk.Id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
