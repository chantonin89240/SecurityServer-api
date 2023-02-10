namespace SecurityServer.Service
{
    using SecurityServer.Data;
    using SecurityServer.Data.Context;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Service.Interface;

    public class UserService : IUserService
    {
        #region Variables
        // initialisation de unit of work
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;
        private ISalt _salt;
        #endregion

        #region Initialisation
        public UserService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt)
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }
        #endregion

        #region CreateUser(UserEntity user)
        bool IUserService.CreateUser(User user)
        {
            this.unitOfWork.CreateTransaction();
            User thisUser = this.unitOfWork.UserRepository.Post(user);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            var userOk = this.unitOfWork.UserRepository.Get(thisUser);
            if (userOk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region GetAuthUser(string email, string password)
        UserAuthDtoDown IUserService.GetAuthUser(string email, string password)
        {
            var userDto = this.unitOfWork.UserRepository.Get(email);

            bool verifPassword = _salt.VerifiedPassword(userDto.Password, userDto.Salt, password);

            // vérification du password
            if (verifPassword)
            {
                UserAuthDtoDown user = new UserAuthDtoDown()
                {
                    Id = userDto.Id,
                    Email = userDto.Email,
                    IsAdmin = userDto.IsAdmin
                };

                return user;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetUsers
        List<UserAppDtoDown> IUserService.GetUsers()
        {
            List<User> ListUsers = this.unitOfWork.UserRepository.GetAll().ToList();
            List<UserAppDtoDown> usersDto = new List<UserAppDtoDown>();

            foreach(User user in ListUsers)
            {
                UserAppDtoDown us = new UserAppDtoDown()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Firstname = user.FirstName,
                    Lastname = user.LastName,
                };
                usersDto.Add(us);
            }
            
            return usersDto;
        }
        #endregion

        #region DeleteUser
        bool IUserService.DeleteUser(int id)
        {
            this.unitOfWork.CreateTransaction();
            this.unitOfWork.UserRepository.Delete(id);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            UserDtoDown userOk = this.unitOfWork.UserRepository.Get(id);
            if (userOk == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region GetUser(int id)
        UserDtoDown IUserService.GetUser(int id)
        {
            UserDtoDown user = this.unitOfWork.UserRepository.Get(id);
            return user;
        }

        #endregion

        #region UpdateUser(UserEntity user)
        UserDtoDown IUserService.UpdateUser(User user)
        {
            // création d'une transaction
            this.unitOfWork.CreateTransaction();
            // appel du repository update
            UserDtoDown userUpdate = this.unitOfWork.UserRepository.Update(user);
            // appel du commit et du save de la transaction
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            // renvoi du user update
            return userUpdate;
        }
        #endregion

        #region GetMailNotUse(string mail)
        public bool GetMailNotUse(string email)
        {
            User userDto = this.unitOfWork.UserRepository.Get(email);

            if(userDto == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}