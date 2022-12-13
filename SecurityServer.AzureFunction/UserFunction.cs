using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityServer.Entities;
using System.Runtime.CompilerServices;
using SecurityServer.Service;
using SecurityServer.Service.Interface;

namespace SecurityServer.AzureFunction
{
    public class UserFunction
    {
        private IUserService userService;

        public UserFunction(IUserService userService)
        {
            this.userService = userService;
        }

        private ISalt _isalt;
        public UserFunction(ISalt isalt)
        {
            this._isalt = isalt;
        }
        [FunctionName("CreateUser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateUser")] HttpRequest req,
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
    }
}
