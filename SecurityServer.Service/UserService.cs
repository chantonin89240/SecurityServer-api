using SecurityServer.Data;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Service.Interface;

namespace SecurityServer.Service
{
    public class UserService : IUserService
    {
        // initialisation de unit of work
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;

      

        // fonction création d'un user
        public bool CreateUser(UserEntity user)
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

        private ISalt _salt;
        public UserService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt)
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }
        public UserEntity CreateUser(UserEntity user)
            {
                return false;
            }
        }

        // fonction récupération d'un user pour l'authentification
        public UserEntity GetUser(string password, string mail)
        public bool GetUser(string password, string email)
        {
            var userDto = this.unitOfWork.UserRepository.Get(email);
            UserDtoDown userDtoDown = new UserDtoDown()
            {
                Password = userDto.Password,
                Email = userDto.Email,
                Salt = userDto.Salt
            };
            var truc = _salt.HashPassword(password, userDtoDown.Salt);
            if (userDtoDown.Password == _salt.HashPassword(password, userDtoDown.Salt))
            {
                return true;
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
    }
}