namespace SecurityServer.Service
{
    using SecurityServer.Data;
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
        bool IUserService.CreateUser(UserEntity user)
        {
            this.unitOfWork.CreateTransaction();
            UserEntity thisUser = this.unitOfWork.UserRepository.Add(user);
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
        UserDtoDown IUserService.GetAuthUser(string email, string password)
        {
            var userDto = this.unitOfWork.UserRepository.Get(email);

            UserDtoDown user = new UserDtoDown()
            {
                Id = userDto.Id,
                Email = userDto.Email,
                IsAdmin = userDto.IsAdmin
            };

            return user;
        }
        #endregion

        #region GetUsers
        List<UserAppDtoDown> IUserService.GetUsers()
        {
            List<UserEntity> ListUsers = this.unitOfWork.UserRepository.GetAll().ToList();
            List<UserAppDtoDown> usersDto = new List<UserAppDtoDown>();

            foreach(UserEntity user in ListUsers)
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
    }
}