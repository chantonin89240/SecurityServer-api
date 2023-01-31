namespace SecurityServer.AzureFunction
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Newtonsoft.Json;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;
    using SecurityServer.Service;
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
            UserDtoDown userAuth = _userService.GetAuthUser(user.Email, user.Password);
            // récupération de l'url du client grâce au clientSecret
            var redirecteUri = _applicationService.GetSecret(user.ClientSecret);

            // vérification du user 
            if (userAuth != null)
            {
                // génération du code grant
                string codeGrant = _authenticationService.CodeGrant(userAuth, user.ClientSecret);
                // ajout du code grant à l'url de redirection
                string url = redirecteUri.Url + "/&code=" + codeGrant; 
                // redirection avec l'url passer en paramètre
                return new RedirectResult(url);
            }
            else
            {
                // retourne une erreur dans les logins 
                return new BadRequestErrorMessageResult("Login or Password not correct");
            }               
            
        }

        // function de récupération du token
        [FunctionName("getToken")]
        public async Task<IActionResult> getToken(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "GetAcces")] HttpRequest req)
        {
            // récupération du code grant passer en paramètre 
            string codeGrant = req.Query["CodeGrant"];

            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            codeGrant = codeGrant ?? data?.codeGrant;

            // appel du service de génération de token
            var token = _authenticationService.GenerateJWT(codeGrant);

            // retour du token
            return new OkObjectResult(token);

        }

        [FunctionName(nameof(GetData))]
        public static async Task<IActionResult> GetData(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "data")] HttpRequest req)
        {
            // Check if we have authentication info.
            ValidateJWTService auth = new ValidateJWTService(req);
            if (!auth.IsValid)
            {
                return new UnauthorizedResult(); // No authentication info.
            }
            string postData = await req.ReadAsStringAsync();
            return new OkObjectResult($"{postData}");
        }
    }

    public class UserCredentials
    {
        public string User
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
    }
}
