using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Service.Interface;

namespace SecurityServer.AzureFunction
{
    public class UserFunction
    {
        private IUserService userService;
        private ISalt _isalt;

        public UserFunction(IUserService userService, ISalt salt)
        {
            this.userService = userService;
            this._isalt = salt;
        }

        [FunctionName("CreateUser")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "user/create")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<UserEntity>(requestBody);
            
            // génération d'un salt
            var salt = _isalt.saltGenerator();
            // salt du password
            var nicePassword = _isalt.HashPassword(input.Password, salt);

            // création de l'user entity
            var user = new UserEntity() {FirstName = input.FirstName, LastName = input.LastName, Email = input.Email, Password = nicePassword, Salt = salt, avatar = input.avatar };
            // appel du service de création du user 
            bool result = userService.CreateUser(user);

            return new OkObjectResult(result);
        }

        // function get users
        [FunctionName("GetUsers")]
        public IActionResult GetApplications(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users")] HttpRequest req, ILogger log)
        {
            // appel du service get users
            List<UserAppDtoDown> appli = userService.GetUsers();
            // retour du résultat
            return new OkObjectResult(appli);
        }
    }

}
