﻿namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Context;
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        SecurityServerDbContext context;

        public UserRepository(SecurityServerDbContext context) : base(context)
        {
            this.context = context;
        }

        IEnumerable<User> IUserRepository.Get()
        {
            return this.GetAll();
        }

        UserDtoDown IUserRepository.Get(int id)
        {
            User user = this.Get(id);

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

        bool IUserRepository.Get(User user)
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

        User IUserRepository.Get(string email)
        {
            var user = this._dbSet.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return null;
            }
            else
            {
                User userdto = new User()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Password = user.Password,
                    Salt = user.Salt,
                };
                return userdto;
            }
        }
        UserDtoDown IUserRepository.Update(User user)
        {
            User oldUser = this.Get(user.Id);
            
            if(user.FirstName != oldUser.FirstName)
                oldUser.FirstName = user.FirstName;
            if (user.LastName != oldUser.LastName)
                oldUser.LastName = user.LastName; 
            if (user.Email != oldUser.Email)
                oldUser.Email = user.Email;
            if (user.Avatar != oldUser.Avatar)
                oldUser.Avatar = user.Avatar;

            User userUpdate = this.Update(oldUser);  
            
            UserDtoDown userAft = new UserDtoDown()
            {
                Id = userUpdate.Id,
                Email = userUpdate.Email,
                Firstname = userUpdate.FirstName, 
                Lastname = userUpdate.LastName,
                Avatar = userUpdate.Avatar,
                IsAdmin = userUpdate.IsAdmin,
            };

            return userAft;
        }
        void IUserRepository.Delete(int id)
        {
            this.Delete(id);
        }

        User IUserRepository.Post(User user)
        {
            return this.Add(user);
        }


    }
}
