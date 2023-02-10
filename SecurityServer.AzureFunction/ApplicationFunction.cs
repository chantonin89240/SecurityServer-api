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
    using SecurityServer.Service.Interface;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ApplicationFunction
    {
        private IApplicationService applicationService;

        public ApplicationFunction(IApplicationService applicationService)
        { 
            this.applicationService = applicationService;
        }

        // function get applications
        [FunctionName("GetApplications")]
        public IActionResult GetApplications(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "applications")] HttpRequest req, ILogger log)
        {
            // appel du service get applications
            List<Application> appli = applicationService.GetApplications();
            // retour du résultat
            return new OkObjectResult(appli);
        }

        // function get application
        [FunctionName("GetApplication")]
        public IActionResult GetApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "application/{id}")] HttpRequest req, int id, ILogger log)
        {
            // appel du service get application
            ApplicationDtoDown appli = applicationService.GetApplication(id);
            // retour du résultat
            return new OkObjectResult(appli);
        }

        // function create application
        [FunctionName("CreateApplication")]
        public async Task<IActionResult> CreateApplication(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "application/create")] HttpRequest req,
           ILogger log)
        {
            // récupération du body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<Application>(requestBody);

            // création d'une application Entity
            var app = new Application() { Name = input.Name, Description = input.Description, Url = input.Url };

            // appel du service create application
            var verif = applicationService.CreateApplication(app);

            if (verif == false)
            {
                // retour un message d'erreur
                return new BadRequestErrorMessageResult("Création d'application impossible - informations manquantes");
            }
            else
            {
                // retour du résultat
                return new OkObjectResult(app);
            }

        }

        // function delete application
        [FunctionName("DeleteApplication")]
        public async Task<IActionResult> DeleteApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "application/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            // appel du service delete application
            bool result = applicationService.DeleteApplication(id);
            // retour du résultat
            if (result)
            {
                return new OkObjectResult("L'application a été supprimé !");
            }
            else
            {
                return new BadRequestErrorMessageResult("La suppression de l'application à échouer !"); ;
            }
            
        }

        // function update application
        [FunctionName("UpdateApplication")]
        public async Task<IActionResult> UpdateApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "application/update")] HttpRequest req,
            ILogger log)
        {
            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<Application>(requestBody);

            // création d'une application Entity
           // ApplicationEntity app = new ApplicationEntity() { Id = input.Id, Name = input.Name, Description = input.Description, Url = input.Url, Users = input.Users.ToList() };

            // appel du service update application
            //ApplicationEntity appUpdate = applicationService.UpdateApplication(app);
            // retour du résultat
            return new OkObjectResult(input);
        }
    }
}

