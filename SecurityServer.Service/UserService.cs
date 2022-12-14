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

        private ISalt _salt;
        public UserService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt)
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }

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
         UserDtoDown IUserService.GetUser(string password, string email)
        {
            var userDto = this.unitOfWork.UserRepository.Get(email);

            if (userDto == null)
            {
                return null;
            }
            else
            {
                UserDtoDown userDtoDown = new UserDtoDown()
                {
                    id = userDto.id,
                    password = userDto.password,
                    email = userDto.email,
                    salt = userDto.salt
                };
                var truc = _salt.HashPassword(password, userDtoDown.salt);
                if (userDtoDown.password == _salt.HashPassword(password, userDtoDown.salt))
                {
                    return userDtoDown;
                }
                else
                {
                    return null;
                }
            }
           
        }
    }
}