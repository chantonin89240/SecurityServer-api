using SecurityServer.Data;
using SecurityServer.Data.Repository;
using SecurityServer.Entities;
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

         bool IUserService.GetUser(string email, string password)
        {
            var userDto = this.unitOfWork.UserRepository.Get(email);
            bool userAuth = false;

            if (userDto == null)
            {
                userAuth = false;
                return userAuth;
            }
            else
            {
                userAuth = true;
                return userAuth;
            }
           
        }

        string IUserService.GetCodeGrant()
        {
            return "le code grant";
        }

        CodeGrantEntity IUserService.GetToken(string codeGrant)
        {
            var grant =  this.unitOfWork.CodeGrantRepository.Get(codeGrant);


            return null;
        }
    }
}