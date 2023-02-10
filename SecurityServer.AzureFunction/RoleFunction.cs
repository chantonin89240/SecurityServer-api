namespace SecurityServer.AzureFunction
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Extensions.Logging;
    using Nest;
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
            List<Role> roles = roleService.GetRoles(id);
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
        //[FunctionName("AddRole")]
        //public IActionResult AddRole(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "role/add")] HttpRequest req, ILogger log)
        //{
        //    //// récupération du body
        //    //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    //// deserialization du body 
        //    //var input = JsonConvert.DeserializeObject<ApplicationEntity>(requestBody);

        //    //// création d'un 
        //    //// appel du service get roles
        //    //bool result = roleService.DeleteRole(id);
        //    //// retour du résultat
        //    //if (result)
        //    //{
        //    //    return new OkObjectResult("Le role a été supprimé !");
        //    //}
        //    //else
        //    //{
        //    //    return new BadRequestErrorMessageResult("La suppression du role à échouer !"); ;
        //    //}
        //}
    }
}
