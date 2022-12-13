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
        public UserEntity Add(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> Get()
        {
            throw new NotImplementedException();
        }

        public UserEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public UserDtoDown Get(string email)
        {
            var user = _dbSet.FirstOrDefault(u => u.Email == email);

            UserDtoDown userdto = new UserDtoDown()
            {
                Email = user.Email,
                Password = user.Password,
                Salt = user.Salt,
            };
            return userdto;
        }
        public UserEntity Get(UserDtoDown user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity Post(UserEntity user)
        {
            throw new NotImplementedException();
        }

        

        public UserEntity Update(UserEntity user)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<UserEntity>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
