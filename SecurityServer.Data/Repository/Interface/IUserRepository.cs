using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
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
        bool Get(UserEntity user);
        UserEntity Post(UserEntity user);
        UserEntity Update(UserEntity user);
        string Delete(int id);
        UserDtoDown Get(string email);
        public UserEntity Get(UserDtoDown user);


    }
}
