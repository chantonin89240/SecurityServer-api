using Microsoft.EntityFrameworkCore;
using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;

namespace SecurityServer.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {

        public UserRepository(SecurityServerDbContext context) : base(context)
        public UserRepository(SecurityServerDbContext context) : base(context)
        {

        }
        public UserEntity Add(UserEntity entity)
        {

        }

        IEnumerable<UserEntity> IUserRepository.Get()
        public string Delete(int id)
        {
            return this.GetAll();
        }

        UserEntity IUserRepository.Get(int id)
        public IEnumerable<UserEntity> Get()
        {
            return this.Get(id);
        }

        UserEntity IUserRepository.Get(string password, string mail)
        public UserEntity Get(int id)
        {
            return this._dbSet.Find(password, mail);
        }

        bool IUserRepository.Get(UserEntity user)
        {
            if (this._dbSet.Find(user.Id) != null)
        public UserDtoDown Get(string email)
        {
            var user = _dbSet.FirstOrDefault(u => u.Email == email);

            UserDtoDown userdto = new UserDtoDown()
            {
                return true;
                Email = user.Email,
                Password = user.Password,
                Salt = user.Salt,
            };
            return userdto;
            }
            else
        public UserEntity Get(UserDtoDown user)
            {
                return false;
            throw new NotImplementedException();
            }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        UserEntity IUserRepository.Post(UserEntity user)
        public UserEntity Post(UserEntity user)
       {
            return this.Add(user); 
        }

        

        UserEntity IUserRepository.Update(UserEntity user)
        public UserEntity Update(UserEntity user)
        {
            throw new NotImplementedException();
        }

        string IUserRepository.Delete(int id)
        void IBaseRepository<UserEntity>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
