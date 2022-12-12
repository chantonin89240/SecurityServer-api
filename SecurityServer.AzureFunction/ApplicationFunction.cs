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
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GetApplications")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<ApplicationEntity> appli = applicationService.GetApplications();

            return new OkObjectResult(appli);
        }

        [FunctionName("CreteApplications")]
        public async Task<IActionResult> CreateApplication(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "GetApplications")] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            List<ApplicationEntity> appli = applicationService.GetApplications();

            return new OkObjectResult(appli);
        }
    }
}
