using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using System.Net;

namespace SecurityServer.Service.Interface
{
    public interface IUserService
    {
        public bool CreateUser(UserEntity user);
        public bool GetUser(string mail, string password);
        public string GetCodeGrant();
        public CodeGrantEntity GetToken(string codeGrant);
    }
}
