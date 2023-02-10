﻿using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServer.Entities.DtoUp;

namespace SecurityServer.Data.Repository.Interface
{
    public interface IApplicationUserRoleRepository : IBaseRepository<ApplicationUserRoleEntity>
    {
        IEnumerable<ApplicationUserRoleEntity> GetUser(int idApp);
        UserAppUpdateDtoUp Get(int idApp, int idUser);
        void Post(ApplicationUserRoleEntity userRole);
        void DeleteApp(int idApp);
        void DeleteUser(int idApp, int idUser);
    }
}
