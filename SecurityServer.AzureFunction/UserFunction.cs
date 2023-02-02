namespace SecurityServer.AzureFunction
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Service;
    using SecurityServer.Service.Interface;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserFunction
    {
        private IUserService userService;
        private ISalt _isalt;

        public UserFunction(IUserService userService, ISalt salt)
        {
            this.userService = userService;
            this._isalt = salt;
        }

        // function de création d'un user
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
            var salt = _isalt.SaltGenerator();

            // génération d'un mot de passe aléatoire 
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            char[] mdp = Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray();

            input.Password = new string(mdp);

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

        // function get application
        [FunctionName("GetUser")]
        public IActionResult GetApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "user/{id}")] HttpRequest req, int id, ILogger log)
        {
            // appel du service get user
            UserDtoDown user = userService.GetUser(id);
            // retour du résultat
            return new OkObjectResult(user);
        }

        // function delete user
        [FunctionName("DeleteUser")]
        public async Task<IActionResult> DeleteUser(
          [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "user/{id}")] HttpRequest req,
          int id,
          ILogger log)
        {
            // appel du service delete user
            bool result = userService.DeleteUser(id);
            // retour du résultat
            return new OkObjectResult(result);
        }

        // function update user
        [FunctionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "user/update")] HttpRequest req,
            ILogger log)
        {
            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<UserEntity>(requestBody);

            // création d'un user Entity
            UserEntity user = new UserEntity() { Id = input.Id, FirstName = input.FirstName, LastName = input.LastName, Password = input.Password, Salt = input.Salt, IsAdmin = input.IsAdmin };

            // appel du service update application
            // UserEntity appUpdate = userService.UpdateUser(user);
            // retour du résultat
            return new OkObjectResult(user);
        }
    }

}
