namespace SecurityServer.AzureFunction
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Newtonsoft.Json;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;
    using SecurityServer.Service.Interface;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class UserAuthentificationFunction
    {
        private IUserService _userService;
        private IApplicationService _applicationService;
        private IAuthenticationService _authenticationService;

        public UserAuthentificationFunction(IUserService userService, IApplicationService applicationService, IAuthenticationService authService)
        {
            this._userService = userService;
            this._applicationService = applicationService;
            this._authenticationService = authService;
        }

        // function d'authentification du user
        [FunctionName("UserAuthentification")]
        public  async Task<IActionResult> Authentification(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth")] UserDtoUp user)
        {
            // authentification du user et retourne un dto
            UserAuthDtoDown userAuth = _userService.GetAuthUser(user.Email, user.Password);

            // v�rification du user 
            if (userAuth != null)
            {
                // g�n�ration du code grant
                string codeGrant = _authenticationService.CodeGrant(userAuth, user.ClientSecret);

                // r�cup�ration de l'url du client gr�ce au clientSecret
                var redirecteUri = _applicationService.GetSecret(user.ClientSecret);

                CodeGrantDtoDown urlDto = new CodeGrantDtoDown()
                {
                    UrlRedirect = redirecteUri.Url,
                    CodeGrant = codeGrant,

                };

                return new OkObjectResult(urlDto);
            }
            else
            {
                // retourne une erreur dans les logins 
                return new BadRequestErrorMessageResult("Login or Password not correct");
            }               
            
        }

        // function de r�cup�ration du token
        [FunctionName("GetToken")]
        public async Task<IActionResult> getToken(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "GetAccess")] HttpRequest req)
        {
            // r�cup�ration du code grant passer en param�tre 
            string codeGrant = req.Query["CodeGrant"];

            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            codeGrant = codeGrant ?? data?.codeGrant;

            // appel du service de g�n�ration de token
            var token = _authenticationService.GenerateJWT(codeGrant);

            // retour du token
            return new OkObjectResult(token);
        }
    }
}
