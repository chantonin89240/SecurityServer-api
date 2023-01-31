namespace SecurityServer.Service.Interface
{
    using Microsoft.AspNetCore.Http;
    using SecurityServer.Entities.DtoDown;

    public interface IAuthenticationService
    {
        public string GenerateJWT(string codeGrant);
        public string CodeGrant(UserAuthDtoDown user, string clientSecret);
    }
}
