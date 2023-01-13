namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;

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

        UserEntity IUserRepository.Get(string email)
        {
            var user = this._dbSet.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }
            else
            {
                UserEntity userdto = new UserEntity()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Salt = user.Salt,
                };
                return userdto;
            }
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
