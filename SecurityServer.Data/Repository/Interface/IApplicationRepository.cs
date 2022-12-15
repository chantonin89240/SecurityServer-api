﻿using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;
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
        ApplicationEntity Post(ApplicationEntity application);
        ApplicationEntity Update(ApplicationEntity application);
        void Delete(int id);
    }
}
