using Microsoft.EntityFrameworkCore;
using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;

namespace SecurityServer.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {

        public UserRepository(SecurityServerDbContext context) : base(context)
        {

        }

        public IEnumerable<UserEntity> Get()
        {
            return this.GetAll();
        }

        UserEntity IUserRepository.Get(int id)
        {
            return this.Get(id);
        }

        bool IUserRepository.Get(UserEntity user)
        {
            if (this._dbSet.Find(user.Id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UserDtoDown Get(string email)
        {
            var user = _dbSet.FirstOrDefault(u => u.Email == email);

            UserDtoDown userdto = new UserDtoDown()
            {
                id = user.Id,
                email = user.Email,
                password = user.Password,
                salt = user.Salt,
            };
            return userdto;
        }
        UserEntity IUserRepository.Update(UserEntity user)
        {
            throw new NotImplementedException();
        }
        string IUserRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        UserEntity IUserRepository.Post(UserEntity user)
        {
            return this.Add(user);
        }
    }
}
