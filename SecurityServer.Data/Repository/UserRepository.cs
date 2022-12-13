using Microsoft.EntityFrameworkCore;
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
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(SecurityServerDbContext context) : base(context)
        {

        }

        IEnumerable<UserEntity> IUserRepository.Get()
        {
            return this.GetAll();
        }

        UserEntity IUserRepository.Get(int id)
        {
            return this.Get(id);
        }

        UserEntity IUserRepository.Get(string password, string mail)
        {
            return this._dbSet.Find(password, mail);
        }

        UserEntity IUserRepository.Post(UserEntity user)
        {
            return this.Add(user); 
        }

        UserEntity IUserRepository.Update(UserEntity user)
        {
            throw new NotImplementedException();
        }

        string IUserRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
