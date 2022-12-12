using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserEntity Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return this.GetAll();
        }

        public UserEntity GetById(int id)
        {
            return this.GetById(id);
        }

        public IEnumerable<UserEntity> GetUsers(int id)
        {
            return this.GetUsers(id);
        }

        public void Post(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserEntity userEntity)
        {
            throw new NotImplementedException();
        }

        UserEntity IBaseRepository<UserEntity>.Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
