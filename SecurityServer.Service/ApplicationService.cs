using Microsoft.EntityFrameworkCore.ChangeTracking;
using SecurityServer.Data;
using SecurityServer.Data.Entities;
using SecurityServer.Data.UnitOfWork.Interface;
using SecurityServer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Service
{
    public class ApplicationService : IApplicationService
    {
      private IApplicationUnitOfWork _applicationUnitOfWork;

        public ApplicationService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public  List<ApplicationEntity> GetAll()
        {
            List<ApplicationEntity> applications = _applicationUnitOfWork.ApplicationRepository.findAll();
            return applications;
        }
    }
}
