using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public  interface IUserRepository : IBaseRepository<UserEntity>
    {
        IEnumerable<UserEntity> Get();
        UserEntity Get(int id);
        void Post(UserEntity userEntity);
        void Update(UserEntity userEntity);
        void Delete(int id);

    }
}
