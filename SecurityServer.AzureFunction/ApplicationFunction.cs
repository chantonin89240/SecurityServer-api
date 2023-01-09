namespace SecurityServer.AzureFunction
{
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
    using SecurityServer.Service.Interface;
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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "application/get")] HttpRequest req, ILogger log)
        {
            // appel du service get applications
            List<ApplicationEntity> appli = applicationService.GetApplications();
            // retour du résultat
            return new OkObjectResult(appli);
        }

        // function get application
        [FunctionName("GetApplication")]
        public IActionResult GetApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "application/get/{id}")] HttpRequest req, int id, ILogger log)
        {
            // appel du service get application
            ApplicationEntity appli = applicationService.GetApplication(id);
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
            var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);

            // création d'une application Entity
            var app = new ApplicationEntity() { Name = input.Name, Description = input.Description, Url = input.Url, ClientSecret = input.ClientSecret };

            // appel du service create application
            var verif = applicationService.CreateApplication(app);

            if (verif == false)
            {
                return new BadRequestErrorMessageResult("Création d'application impossible - informations manquantes");
                //return null;
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
            return new OkObjectResult(result);
        }

        // function update application
        [FunctionName("UpdateApplication")]
        public async Task<IActionResult> UpdateApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "application/update")] HttpRequest req,
            ILogger log)
        {
            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);

            // création d'une application Entity
            var app = new ApplicationEntity() { Id = input.Id, Name = input.Name, Description = input.Description, Url = input.Url };

            // appel du service update application
            ApplicationEntity appUpdate = applicationService.UpdateApplication(app);
            // retour du résultat
            return new OkObjectResult(appUpdate);
        }
    }
}

