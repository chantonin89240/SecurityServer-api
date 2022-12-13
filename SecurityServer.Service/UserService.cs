using SecurityServer.Data;
using SecurityServer.Entities;
using SecurityServer.Service.Interface;

namespace SecurityServer.Service
{
    public class UserService : IUserService
    {
        // initialisation de unit of work
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;

        public UserService(IUnitOfWork<SecurityServerDbContext> unit)
        {
            this.unitOfWork = unit;
        }

        // fonction création d'un user
        public UserEntity CreateUser(UserEntity user)
        {
            this.unitOfWork.CreateTransaction();
            UserEntity thisUser = this.unitOfWork.UserRepository.Add(user);
            return thisUser;
        }

        // fonction récupération d'un user pour l'authentification
        public UserEntity GetUser(string password, string mail)
        {
            throw new NotImplementedException();
        }
    }
}