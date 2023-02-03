namespace SecurityServer.AzureFunction
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using SecurityServer.Entities;
    using SecurityServer.Service.Interface;
    using System.Collections.Generic;

    public class RoleFunction
    {
        private IRoleService roleService;

        public RoleFunction(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        // function get roles
        [FunctionName("GetRoles")]
        public IActionResult GetRoles(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "roles/{id}")] HttpRequest req, int id, ILogger log)
        {
            // appel du service get roles
            List<RoleEntity> roles = roleService.GetRoles(id);
            // retour du résultat
            return new OkObjectResult(roles);
        }
    }
}
