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
        UserEntity Get(string password, string mail);
        bool Get(UserEntity user);
        UserEntity Post(UserEntity user);
        UserEntity Update(UserEntity user);
        string Delete(int id);

    }
}
