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

namespace SecurityServer.AzureFunction
{
    public class ApplicationFunction
    {
        private IApplicationService applicationService;

        public ApplicationFunction(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [FunctionName("GetApplications")]
        public async Task<IActionResult> GetApplications(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetApplications")] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<ApplicationEntity> appli = applicationService.GetApplications();

            return new OkObjectResult(appli);
        }

        [FunctionName("CreateApplication")]
        public async Task<IActionResult> CreateApplication(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "CreateApplication")] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);
            var app = new ApplicationEntity() { Name = input.Name, Description = input.Description, Url = input.Url, ClientSecret = input.ClientSecret };
            applicationService.CreateApplication(app);
            return new OkObjectResult(app);
        }

        // function delete application
        [FunctionName("DeleteApplication")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteApplication")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // récupération du body 
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);

            // appel du service delete d'application
            bool result = applicationService.DeleteApplication(input.Id);

            return new OkObjectResult(result);
        }
    }
}
