namespace SecurityServer.AzureFunction
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using SecurityServer.Entities;
    using SecurityServer.Service.Interface;
    using System.Collections.Generic;
    using System.Web.Http;
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
    using SecurityServer.Entities.DtoUp;

    [Authorize]
    public class RoleFunction
    {
        private IRoleService roleService;

        public RoleFunction(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        // function get roles app
        [FunctionName("GetRolesApp")]
        public IActionResult GetRolesApp(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "rolesApp/{id}")] HttpRequest req, int id, ILogger log)
        {
            // appel du service get roles
            List<RoleEntity> roles = roleService.GetRolesApp(id);
            // retour du résultat
            return new OkObjectResult(roles);
        }

        // function get roles
        [FunctionName("GetRoles")]
        public IActionResult GetRoles(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "roles/")] HttpRequest req, ILogger log)
        {
            // appel du service get roles
            List<RoleEntity> roles = roleService.GetRoles();
            // retour du résultat
            return new OkObjectResult(roles);
        }

        // function delete roles
        [FunctionName("DeleteRole")]
        public IActionResult DeleteRole(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "role/{id}")] HttpRequest req, int id, ILogger log)
        {
            // appel du service get roles
            bool result = roleService.DeleteRole(id);
            // retour du résultat
            if (result)
            {
                return new OkObjectResult("Le role a été supprimé !");
            }
            else
            {
                return new BadRequestErrorMessageResult("La suppression du role à échouer !"); ;
            }
        }

        // function add roles
        [FunctionName("AddRole")]
        public async Task<IActionResult> AddRole(
             [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "role/add")] HttpRequest req, ILogger log)
        {
            // récupération du body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // deserialization du body 
            ApplicationRoleEntity input = JsonConvert.DeserializeObject<ApplicationRoleEntity>(requestBody);

            // appel du service add role
            bool result = roleService.AddRole(input);
            // retour du résultat
            if (result)
            {
                return new OkObjectResult("Le role a été ajouté !");
            }
            else
            {
                return new BadRequestErrorMessageResult("le role n'a pas été créer !"); ;
            }
        }
    }
}
