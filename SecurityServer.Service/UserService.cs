using SecurityServer.Data;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Service.Interface;

namespace SecurityServer.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;
        private ISalt _salt;
        public UserService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt)
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }
        public UserEntity CreateUser(UserEntity user)
        {
            throw new NotImplementedException();
        }

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