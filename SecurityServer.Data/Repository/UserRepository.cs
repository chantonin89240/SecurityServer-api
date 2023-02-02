namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {

        public UserRepository(SecurityServerDbContext context) : base(context)
        {

        }

        public IEnumerable<UserEntity> Get()
        {
            return this.GetAll();
        }

        UserDtoDown IUserRepository.Get(int id)
        {
            var user = this.Get(id);

            if (user == null) return null;

            UserDtoDown userDtoDown = new UserDtoDown
            {
                Id = id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Avatar = user.Avatar,
                IsAdmin = user.IsAdmin,
            };

            return userDtoDown;
            
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
        void IUserRepository.Delete(int id)
        {
            this.Delete(id);
        }

        UserEntity IUserRepository.Post(UserEntity user)
        {
            return this.Add(user);
        }


    }
}
