using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SecurityServer.Data;
using SecurityServer.Service;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;
using SecurityServer.Service.Interface;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System.Net;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Web.Http;

namespace SecurityServer.AzureFunction
{
    public class UserAuthentificationFunction
    {
        private IUserService _userService;
        public UserAuthentificationFunction(IUserService userService)
        {
            this._userService = userService;
        }




        [FunctionName("UserAuthentificationFunction")]
        [OpenApiOperation("userAuth", "authentication")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody("application/json", typeof(UserDtoUp))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(UserDtoDown), Description = "The OK response")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth")] UserDtoUp user, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            // TODO: Perform custom authentication here; we're just using a simple hard coded check for this example
            UserDtoDown userDtoDown = _userService.GetUser(user.password, user.email);

            if (userDtoDown == null)
            {
               
                return await Task.FromResult(new BadRequestErrorMessageResult("Email or password incorrect")).ConfigureAwait(false); ;
            }
            else
            {
                GenerateJWTToken generateJWTToken = new();
                string token = generateJWTToken.IsusingJWT(userDtoDown);
                userDtoDown.token = token;
                var userbody = new
                {
                    userDtoDown.id,
                    userDtoDown.email,
                    userDtoDown.token,
                    userDtoDown.isAdmin
                };
                return await Task.FromResult(new OkObjectResult(userbody)).ConfigureAwait(false);
            }
                
            
            }



        [FunctionName(nameof(GetData))]
        public static async Task<IActionResult> GetData(
    [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "data")] HttpRequest req, ILogger log)
        {
            // Check if we have authentication info.
            ValidateJWTService auth = new ValidateJWTService(req);
            if (!auth.IsValid)
            {
                return new UnauthorizedResult(); // No authentication info.
            }
            string postData = await req.ReadAsStringAsync();
            return new OkObjectResult($"{postData}");
        }
    }

    public class UserCredentials
    {
        public string User
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
    }
}
