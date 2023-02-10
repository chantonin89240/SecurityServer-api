using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoUp;
using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository
{
    public class ApplicationUserRoleRepository : BaseRepository<ApplicationUserRoleEntity>, IApplicationUserRoleRepository
    {

        SecurityServerDbContext context;
        public ApplicationUserRoleRepository(SecurityServerDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<ApplicationUserRoleEntity> GetUser(int idApp)
        {
            return this.context.ApplicationUserRole.Where(app => app.IdApplication == idApp);
        }

        public UserAppUpdateDtoUp Get(int idApp, int idUser)
        {
            throw new NotImplementedException();
        }

        public void Post(ApplicationUserRoleEntity userRole)
        {
            this.Add(userRole);
        }

        public void DeleteApp(int idApp)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(ApplicationUserRoleEntity truc, int idApp, int idUser)
        {
            context.ApplicationUserRole.(a => a.IdApplication == idApp).Where(u => u.IdUser == idUser);
        }
    }
}
