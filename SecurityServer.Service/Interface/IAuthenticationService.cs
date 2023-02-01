namespace SecurityServer.Service.Interface
{
    using Azure.Core;
    using Microsoft.AspNetCore.Http;
    using SecurityServer.Entities.DtoDown;

    public interface IAuthenticationService
    {
        public AccessToken GenerateJWT(string codeGrant);
        public string CodeGrant(UserAuthDtoDown user, string clientSecret);
    }
}
