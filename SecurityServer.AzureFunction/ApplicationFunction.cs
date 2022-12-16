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
using Microsoft.EntityFrameworkCore;
using SecurityServer.Service;
using SecurityServer.Entities;
using SecurityServer.Service.Interface;
using SecurityServer.Entities.DtoUp;
using SecurityServer.Entities.DtoDown;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Extensions;
using System.Net;
using System.Web.Http;

namespace SecurityServer.AzureFunction
{
    public class ApplicationFunction
    {
        private IApplicationService applicationService;

        public ApplicationFunction(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        // function get applications
        [FunctionName("GetApplications")]
        public async Task<IActionResult> GetApplications(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetApplications")] HttpRequest req, ILogger log)
        {
            List<ApplicationEntity> appli = applicationService.GetApplications();
            // retour du résultat
            return new OkObjectResult(appli);
        }

        // function create application
        [FunctionName("CreateApplication")]
        public async Task<IActionResult> CreateApplication(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateApplication")] HttpRequest req,
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

            if (verif == null)
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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteApplication")] HttpRequest req,
            ILogger log)
        {
            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);

            // appel du service delete application
            bool result = applicationService.DeleteApplication(input.Id);
            // retour du résultat
            return new OkObjectResult(result);
        }

        // function update application
        [FunctionName("UpdateApplication")]
        public async Task<IActionResult> UpdateApplication(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "UpdateApplication")] HttpRequest req,
            ILogger log)
        {
            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);

            // création d'une application Entity
            var app = new ApplicationEntity() { Id = input.Id, Name = input.Name, Description = input.Description, Url = input.Url };

            // appel du service update application
            ApplicationEntity appUpdate =  applicationService.UpdateApplication(app);
            // retour du résultat
            return new OkObjectResult(appUpdate);
        }
    }
}
